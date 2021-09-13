using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MARC;
using SwiftExcel;

namespace MARCmanager
{
    public partial class Form1 : Form
    {
        #region methods and stuff
        private FileMARC myMARC;
        private List<string> permanentLocations = new List<string>();
        private int marcRecordCount;
        private int max653;


        private void importMARCFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    string fromPath = openFileDialog.FileName;
                    myMARC = new FileMARC();
                    myMARC.ImportMARC(fromPath);
                    permanentLocations.Clear();
                    cbPlacements.Items.Clear();
                    cbPlacements.Enabled = false;
                    cbPlacements.Text = "";
                    chkUsePlacementDataFrom.Checked = false;
                    CheckMARCData();
                    UpdateListView("");
                    exportToXLSXFileToolStripMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Oops, there was an unexpected error!\nHere's the error message: {ex.Message}");
                }


            }
        }

        /// <summary>
        /// Checks the contents of the MARC data, presents a count of items, 
        /// and loads unique permanent placement values into the variable permanentLocations.
        /// </summary>
        private void CheckMARCData()
        {
            marcRecordCount = myMARC.Count;
            statusLabel.Text = $"Loaded {marcRecordCount} Records.";
            foreach (Record record in myMARC)
            {
                List<Field> locationFields = record.GetFields("952");
                if (locationFields != null && locationFields[0].IsDataField())
                {
                    foreach (DataField locationDataField in locationFields)
                    {
                        Subfield libraryData = locationDataField['a'];
                        if (!permanentLocations.Contains(libraryData.Data))
                        {
                            permanentLocations.Add(libraryData.Data);
                            Console.WriteLine(libraryData.Data);
                        }
                    }
                }
            }
            myMARC.Reset();

        }

        /// <summary>
        /// Loads the data from permanentLocations into the comboBox.
        /// </summary>
        private void ReloadPlacement()
        {
            cbPlacements.Items.Clear();
            foreach (var loc in permanentLocations)
            {
                cbPlacements.Items.Add(loc);
            }
            cbPlacements.Enabled = true;
        }

        /// <summary>
        /// Resets the ListView to the default layout.
        /// </summary>
        /// <param name="showPlacement"></param>
        private void InitListView(bool showPlacement = false)
        {
            listViewMain.Items.Clear();
            listViewMain.Columns.Clear();
            listViewMain.Columns.Add("author", "Author", 200);
            listViewMain.Columns.Add("title", "Title", 200);
            listViewMain.Columns.Add("type", "Type", 150);
            if (showPlacement)
            {
                listViewMain.Columns.Add("placement", "Placement", 150);
            }
            listViewMain.Columns.Add("col653", "MARC 653", 180);
            listViewMain.Columns.Add("col655", "MARC 655", 180);
        }

        private void UpdateListView(string placementDataFilter)
        {

            InitListView(placementDataFilter == "" ? false : true);
            foreach (Record record in myMARC)
            {
                Field authorField = record["100"];
                Field titleField = record["245"];
                Field typeField = record["942"];
                List<Field> locationFields = record.GetFields("952");
                List<Field> marc653Fields = record.GetFields("653");
                List<Field> marc655Fields = record.GetFields("655");

                string Author;
                string CoAuthors = "";
                string Title;
                string Type;
                string Placement;

                #region authorfield
                if (authorField == null)
                {
                    Author = "";
                }
                else
                {
                    if (authorField.IsDataField())
                    {
                        DataField authorDataField = (DataField)authorField;
                        Subfield authorName = authorDataField['a'];
                        Author = authorName.Data;
                    }
                    else
                    {
                        Author = "";
                    }
                }
                #endregion

                #region titleField
                Title = "";
                if (titleField == null)
                {
                    Title = "";
                }
                else
                {
                    if (titleField.IsDataField())
                    {
                        DataField titleDataField = (DataField)titleField;
                        Subfield titleA = titleDataField['a'];
                        Subfield titleB = titleDataField['b'];
                        Subfield coAuthorsField = titleDataField['c'];

                        if (titleA != null)
                        {
                            Title += titleA.Data;
                            if (Title.EndsWith("/"))
                            {
                                Title = Title.Substring(0, Title.Length - 1);
                            }
                        }
                        if (titleB != null)
                        {
                            Title = Title.TrimEnd();
                            Title += " ";
                            Title += titleB.Data;
                            if (Title.EndsWith("/"))
                            {
                                Title = Title.Substring(0, Title.Length - 1);
                            }
                        }
                        if (coAuthorsField != null)
                        {
                            CoAuthors = coAuthorsField.Data;
                        }
                    }
                    else
                    {
                        Title = "";
                    }
                }
                if (Title.EndsWith("."))
                {
                    Title = Title.Substring(0, Title.Length - 1);
                }
                #endregion

                #region typeField
                Type = "";
                if (typeField != null)
                {
                    if (typeField.IsDataField())
                    {
                        DataField typeDataField = (DataField)typeField;
                        Subfield typeData = typeDataField['c'];
                        if (typeData != null)
                        {
                            Type = typeData.Data;
                        }

                    }
                    else
                    {
                        Type = "";
                    }
                }
                #endregion

                #region locationField
                Placement = "";
                if (locationFields != null)
                {
                    if (locationFields[0].IsDataField())
                    {
                        if (placementDataFilter != null && placementDataFilter != "")
                        {
                            if (Placement == "")
                            {
                                foreach (DataField locationDataField in locationFields)
                                {
                                    Subfield libraryData = locationDataField['a'];
                                    Subfield placementData = locationDataField['c'];
                                    if (libraryData.Data == placementDataFilter)
                                    {
                                        if (placementData != null)
                                        {
                                            Placement = placementData.Data == null ? "" : placementData.Data;
                                        }
                                        else
                                        {
                                            Placement = "";
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Placement = "";
                    }
                }
                #endregion




                #region fix_author_field


                if (Author.EndsWith(","))
                {
                    Author = Author.Substring(0, Author.Length - 1);
                }
                #endregion
                ListViewItem lvi = new ListViewItem(Author);
                lvi.SubItems.Add(Title);
                lvi.SubItems.Add(Type);
                if (!string.IsNullOrEmpty(placementDataFilter))
                {
                    lvi.SubItems.Add(Placement);
                }


                #region marc653Field
                string marc653 = string.Empty;
                //Placement = "";
                int subjectCounter = 0;
                if (marc653Fields.Count > 0)
                {
                    if (marc653Fields[0].IsDataField())
                    {
                        foreach (DataField field in marc653Fields)
                        {
                            if(subjectCounter<num653.Value)
                            {
                                Subfield sub653a = field['a'];

                                if (sub653a != null && sub653a.Data != null)
                                {
                                    marc653 += $"{sub653a.Data}, ";
                                    subjectCounter++;
                                }
                            }
                            else
                            {
                                continue;
                            }
                            
                        }
                    }
                }

                if (marc653.EndsWith(", "))
                {
                    marc653 = marc653.Substring(0, marc653.Length - 2);
                }
                lvi.SubItems.Add(marc653);

                #endregion

                #region marc655Field
                string marc655 = string.Empty;
                //Placement = "";
                if (marc655Fields.Count > 0)
                {
                    if (marc655Fields[0].IsDataField())
                    {
                        foreach (DataField field in marc655Fields)
                        {
                            Subfield sub655a = field['a'];

                            if (sub655a != null && sub655a.Data != null)
                            {
                                marc655 += $"{sub655a.Data}, ";
                            }
                        }
                    }
                }

                if (marc655.EndsWith(", "))
                {
                    marc655 = marc655.Substring(0, marc655.Length - 2);
                }
                lvi.SubItems.Add(marc655);

                #endregion


                listViewMain.Items.Add(lvi);
            }
            myMARC.Reset();
            if (!string.IsNullOrEmpty(placementDataFilter))
            {
                statusLabel.Text = $"Fetched placement data for all items located in {placementDataFilter} (if they have a placement there...)";
            }
        }


        /// <summary>
        /// Presents a Save Dialog, and exports the data to an xlsx-file at the selected path.
        /// </summary>
        private void exportFile()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;
                WriteExcel(savePath);
                statusLabel.Text = $"Exported {marcRecordCount} Records to {savePath}";
            }
        }

        private void WriteExcel(string savePath)
        {
            using (var ew = new ExcelWriter(savePath))
            {
                int columnCounter = 1;
                int xlRow = 1;
                foreach (ColumnHeader col in listViewMain.Columns)
                {
                    ew.Write(col.Text, columnCounter, xlRow);
                    columnCounter++;
                }

                xlRow++;

                foreach (ListViewItem item in listViewMain.Items)
                {
                    columnCounter = 0;
                    //ew.Write(item.Text, columnCounter, xlRow);
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    {
                        columnCounter++;
                        ew.Write(subitem.Text, columnCounter, xlRow);
                    }
                    xlRow++;
                }
            }
        }

        #endregion

        #region formstuff
        public Form1()
        {
            InitializeComponent();
        }


        private void chkUsePlacementDataFrom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsePlacementDataFrom.Checked)
            {
                ReloadPlacement();
            }
            else
            {
                cbPlacements.Enabled = false;
            }


        }


        private void cbPlacements_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlacement = cbPlacements.SelectedItem.ToString();
            UpdateListView(selectedPlacement);
        }



        private void exportToXLSXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void num653_ValueChanged(object sender, EventArgs e)
        {
            max653 = (int)num653.Value;
            if(myMARC!=null)
            {
                if (cbPlacements.SelectedIndex == -1 && myMARC != null)
                {
                    UpdateListView("");
                }
                else
                {
                    string selectedPlacement = cbPlacements.SelectedItem.ToString();
                    UpdateListView(selectedPlacement);
                }
            }
            else
            {
                // nothing to do.
            }
        }
    }
}
