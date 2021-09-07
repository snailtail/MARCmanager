
namespace MARCmanager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMARCFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToXLSXFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkUsePlacementDataFrom = new System.Windows.Forms.CheckBox();
            this.cbPlacements = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewMain = new System.Windows.Forms.ListView();
            this.columnAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPlacement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.column653 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column655 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "MARC Files|*.iso2709|All files|*.*";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xlsx";
            this.saveFileDialog.Filter = "Excel Files|*.xlsx|All files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1214, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMARCFileToolStripMenuItem,
            this.exportToXLSXFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importMARCFileToolStripMenuItem
            // 
            this.importMARCFileToolStripMenuItem.Name = "importMARCFileToolStripMenuItem";
            this.importMARCFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.importMARCFileToolStripMenuItem.Text = "Import MARC file...";
            this.importMARCFileToolStripMenuItem.ToolTipText = "Click to import a MARC File";
            this.importMARCFileToolStripMenuItem.Click += new System.EventHandler(this.importMARCFileToolStripMenuItem_Click);
            // 
            // exportToXLSXFileToolStripMenuItem
            // 
            this.exportToXLSXFileToolStripMenuItem.Enabled = false;
            this.exportToXLSXFileToolStripMenuItem.Name = "exportToXLSXFileToolStripMenuItem";
            this.exportToXLSXFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exportToXLSXFileToolStripMenuItem.Text = "Export to XLSX file...";
            this.exportToXLSXFileToolStripMenuItem.ToolTipText = "Click to export the list to an Excel file.";
            this.exportToXLSXFileToolStripMenuItem.Click += new System.EventHandler(this.exportToXLSXFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Exits the application";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chkUsePlacementDataFrom
            // 
            this.chkUsePlacementDataFrom.AutoSize = true;
            this.chkUsePlacementDataFrom.Location = new System.Drawing.Point(12, 23);
            this.chkUsePlacementDataFrom.Name = "chkUsePlacementDataFrom";
            this.chkUsePlacementDataFrom.Size = new System.Drawing.Size(148, 17);
            this.chkUsePlacementDataFrom.TabIndex = 5;
            this.chkUsePlacementDataFrom.Text = "Use Placement data from:";
            this.chkUsePlacementDataFrom.UseVisualStyleBackColor = true;
            this.chkUsePlacementDataFrom.CheckedChanged += new System.EventHandler(this.chkUsePlacementDataFrom_CheckedChanged);
            // 
            // cbPlacements
            // 
            this.cbPlacements.Enabled = false;
            this.cbPlacements.FormattingEnabled = true;
            this.cbPlacements.Location = new System.Drawing.Point(166, 21);
            this.cbPlacements.Name = "cbPlacements";
            this.cbPlacements.Size = new System.Drawing.Size(185, 21);
            this.cbPlacements.TabIndex = 6;
            this.cbPlacements.SelectedIndexChanged += new System.EventHandler(this.cbPlacements_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 743);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(1214, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // listViewMain
            // 
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAuthor,
            this.columnTitle,
            this.columnType,
            this.columnPlacement,
            this.column653,
            this.column655});
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(0, 3);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(1214, 689);
            this.listViewMain.TabIndex = 2;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            // 
            // columnAuthor
            // 
            this.columnAuthor.Text = "Author";
            this.columnAuthor.Width = 200;
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Title";
            this.columnTitle.Width = 200;
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            this.columnType.Width = 150;
            // 
            // columnPlacement
            // 
            this.columnPlacement.Text = "Placement";
            this.columnPlacement.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listViewMain);
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1223, 692);
            this.panel1.TabIndex = 8;
            // 
            // column653
            // 
            this.column653.Text = "MARC 653";
            this.column653.Width = 180;
            // 
            // column655
            // 
            this.column655.Text = "MARC 655";
            this.column655.Width = 180;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 765);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.cbPlacements);
            this.Controls.Add(this.chkUsePlacementDataFrom);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MARCmanager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMARCFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToXLSXFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkUsePlacementDataFrom;
        private System.Windows.Forms.ComboBox cbPlacements;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.ColumnHeader columnAuthor;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnPlacement;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader column653;
        private System.Windows.Forms.ColumnHeader column655;
    }
}

