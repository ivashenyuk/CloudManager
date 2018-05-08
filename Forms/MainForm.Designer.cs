namespace Graduation_Work
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mPanel = new MetroFramework.Controls.MetroPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.rdoTile = new MetroFramework.Controls.MetroRadioButton();
            this.rdoList = new MetroFramework.Controls.MetroRadioButton();
            this.rdoDetails = new MetroFramework.Controls.MetroRadioButton();
            this.rdoSmall = new MetroFramework.Controls.MetroRadioButton();
            this.rdoLarge = new MetroFramework.Controls.MetroRadioButton();
            this.listView = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastChange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатиФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завантажитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileWindow = new System.Windows.Forms.OpenFileDialog();
            this.saveFileWindow = new System.Windows.Forms.SaveFileDialog();
            this.створитиПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mPanel
            // 
            this.mPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPanel.Controls.Add(this.splitContainer1);
            this.mPanel.HorizontalScrollbarBarColor = true;
            this.mPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanel.HorizontalScrollbarSize = 10;
            this.mPanel.Location = new System.Drawing.Point(10, 87);
            this.mPanel.Name = "mPanel";
            this.mPanel.Size = new System.Drawing.Size(1163, 678);
            this.mPanel.TabIndex = 0;
            this.mPanel.VerticalScrollbarBarColor = true;
            this.mPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mPanel.VerticalScrollbarSize = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rdoTile);
            this.splitContainer1.Panel2.Controls.Add(this.rdoList);
            this.splitContainer1.Panel2.Controls.Add(this.rdoDetails);
            this.splitContainer1.Panel2.Controls.Add(this.rdoSmall);
            this.splitContainer1.Panel2.Controls.Add(this.rdoLarge);
            this.splitContainer1.Panel2.Controls.Add(this.listView);
            this.splitContainer1.Size = new System.Drawing.Size(1163, 678);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(215, 678);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // rdoTile
            // 
            this.rdoTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoTile.AutoSize = true;
            this.rdoTile.Location = new System.Drawing.Point(298, 647);
            this.rdoTile.Name = "rdoTile";
            this.rdoTile.Size = new System.Drawing.Size(42, 15);
            this.rdoTile.TabIndex = 1;
            this.rdoTile.Text = "Tile";
            this.rdoTile.UseSelectable = true;
            this.rdoTile.CheckedChanged += new System.EventHandler(this.rdoTile_CheckedChanged);
            // 
            // rdoList
            // 
            this.rdoList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoList.AutoSize = true;
            this.rdoList.Location = new System.Drawing.Point(251, 647);
            this.rdoList.Name = "rdoList";
            this.rdoList.Size = new System.Drawing.Size(41, 15);
            this.rdoList.TabIndex = 1;
            this.rdoList.Text = "List";
            this.rdoList.UseSelectable = true;
            this.rdoList.CheckedChanged += new System.EventHandler(this.rdoList_CheckedChanged);
            // 
            // rdoDetails
            // 
            this.rdoDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoDetails.AutoSize = true;
            this.rdoDetails.Checked = true;
            this.rdoDetails.Location = new System.Drawing.Point(187, 647);
            this.rdoDetails.Name = "rdoDetails";
            this.rdoDetails.Size = new System.Drawing.Size(58, 15);
            this.rdoDetails.TabIndex = 1;
            this.rdoDetails.TabStop = true;
            this.rdoDetails.Text = "Details";
            this.rdoDetails.UseSelectable = true;
            this.rdoDetails.CheckedChanged += new System.EventHandler(this.rdoDetails_CheckedChanged);
            // 
            // rdoSmall
            // 
            this.rdoSmall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoSmall.AutoSize = true;
            this.rdoSmall.Location = new System.Drawing.Point(103, 647);
            this.rdoSmall.Name = "rdoSmall";
            this.rdoSmall.Size = new System.Drawing.Size(78, 15);
            this.rdoSmall.TabIndex = 1;
            this.rdoSmall.Text = "Small Icon";
            this.rdoSmall.UseSelectable = true;
            this.rdoSmall.CheckedChanged += new System.EventHandler(this.rdoSmall_CheckedChanged);
            // 
            // rdoLarge
            // 
            this.rdoLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoLarge.AutoSize = true;
            this.rdoLarge.Location = new System.Drawing.Point(19, 647);
            this.rdoLarge.Name = "rdoLarge";
            this.rdoLarge.Size = new System.Drawing.Size(78, 15);
            this.rdoLarge.TabIndex = 1;
            this.rdoLarge.Text = "Large Icon";
            this.rdoLarge.UseSelectable = true;
            this.rdoLarge.CheckedChanged += new System.EventHandler(this.rdoLarge_CheckedChanged);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colLastChange,
            this.colType,
            this.colSize});
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(2, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(942, 631);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 300;
            // 
            // colLastChange
            // 
            this.colLastChange.Text = "Last Date Change";
            this.colLastChange.Width = 150;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 100;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 150;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "defaultImgFile.png");
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(10, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1163, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem1
            // 
            this.файлToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатиФайлToolStripMenuItem,
            this.завантажитиToolStripMenuItem,
            this.створитиПапкуToolStripMenuItem});
            this.файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            this.файлToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem1.Text = "Файл";
            // 
            // скачатиФайлToolStripMenuItem
            // 
            this.скачатиФайлToolStripMenuItem.Name = "скачатиФайлToolStripMenuItem";
            this.скачатиФайлToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.скачатиФайлToolStripMenuItem.Text = "Скачати";
            this.скачатиФайлToolStripMenuItem.Click += new System.EventHandler(this.скачатиФайлToolStripMenuItem_Click);
            // 
            // завантажитиToolStripMenuItem
            // 
            this.завантажитиToolStripMenuItem.Name = "завантажитиToolStripMenuItem";
            this.завантажитиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.завантажитиToolStripMenuItem.Text = "Завантажити";
            this.завантажитиToolStripMenuItem.Click += new System.EventHandler(this.завантажитиToolStripMenuItem_Click);
            // 
            // openFileWindow
            // 
            this.openFileWindow.CheckFileExists = false;
            this.openFileWindow.CheckPathExists = false;
            this.openFileWindow.Multiselect = true;
            this.openFileWindow.RestoreDirectory = true;
            // 
            // створитиПапкуToolStripMenuItem
            // 
            this.створитиПапкуToolStripMenuItem.Name = "створитиПапкуToolStripMenuItem";
            this.створитиПапкуToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.створитиПапкуToolStripMenuItem.Text = "Створити папку";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 788);
            this.Controls.Add(this.mPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 20, 20);
            this.Text = "Ваш менеджер файлів в Хмарі";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colLastChange;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem1;
        private MetroFramework.Controls.MetroRadioButton rdoTile;
        private MetroFramework.Controls.MetroRadioButton rdoList;
        private MetroFramework.Controls.MetroRadioButton rdoDetails;
        private MetroFramework.Controls.MetroRadioButton rdoSmall;
        private MetroFramework.Controls.MetroRadioButton rdoLarge;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem скачатиФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завантажитиToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileWindow;
        private System.Windows.Forms.SaveFileDialog saveFileWindow;
        private System.Windows.Forms.ToolStripMenuItem створитиПапкуToolStripMenuItem;
    }
}

