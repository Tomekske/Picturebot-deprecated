namespace PicturebotGUI
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenConfigFileTStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwBackup = new System.ComponentModel.BackgroundWorker();
            this.bgwRename = new System.ComponentModel.BackgroundWorker();
            this.bgwConvert = new System.ComponentModel.BackgroundWorker();
            this.lbShoot = new System.Windows.Forms.ListBox();
            this.comboWorkspace = new System.Windows.Forms.ComboBox();
            this.bgwSelection = new System.ComponentModel.BackgroundWorker();
            this.bgwEdited = new System.ComponentModel.BackgroundWorker();
            this.bgwMassRename = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutWorkspace = new System.Windows.Forms.TableLayoutPanel();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbSelection = new System.Windows.Forms.ListBox();
            this.tableLayoutShoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelShoots = new System.Windows.Forms.Panel();
            this.panelLabelShoots = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbAddShoot = new System.Windows.Forms.PictureBox();
            this.panelEdited = new System.Windows.Forms.Panel();
            this.lbEdited = new System.Windows.Forms.ListBox();
            this.panelLabelEdited = new System.Windows.Forms.Panel();
            this.lblEdited = new System.Windows.Forms.Label();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.lbPreview = new System.Windows.Forms.ListBox();
            this.panelLabelPreview = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.panelInstagram = new System.Windows.Forms.Panel();
            this.lbInstagram = new System.Windows.Forms.ListBox();
            this.panelLabelInstagram = new System.Windows.Forms.Panel();
            this.lblInstagram = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbSelection = new System.Windows.Forms.PictureBox();
            this.pbEdited = new System.Windows.Forms.PictureBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSelection = new System.Windows.Forms.Label();
            this.pbInstagram = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutWorkspace.SuspendLayout();
            this.panelConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutShoot.SuspendLayout();
            this.panelShoots.SuspendLayout();
            this.panelLabelShoots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddShoot)).BeginInit();
            this.panelEdited.SuspendLayout();
            this.panelLabelEdited.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelLabelPreview.SuspendLayout();
            this.panelInstagram.SuspendLayout();
            this.panelLabelInstagram.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdited)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.panelSelection.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstagram)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.VersionTSMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1098, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenConfigFileTStripMenuItem,
            this.openWorkspaceToolStripMenuItem,
            this.addWorkspaceToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // OpenConfigFileTStripMenuItem
            // 
            this.OpenConfigFileTStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.OpenConfigFileTStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.OpenConfigFileTStripMenuItem.Name = "OpenConfigFileTStripMenuItem";
            this.OpenConfigFileTStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenConfigFileTStripMenuItem.Text = "Open config file";
            this.OpenConfigFileTStripMenuItem.Click += new System.EventHandler(this.OpenConfigFileTStripMenuItem_Click);
            // 
            // openWorkspaceToolStripMenuItem
            // 
            this.openWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.openWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openWorkspaceToolStripMenuItem.Name = "openWorkspaceToolStripMenuItem";
            this.openWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openWorkspaceToolStripMenuItem.Text = "Open workspace";
            this.openWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.openWorkspaceToolStripMenuItem_Click);
            // 
            // addWorkspaceToolStripMenuItem
            // 
            this.addWorkspaceToolStripMenuItem.Name = "addWorkspaceToolStripMenuItem";
            this.addWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addWorkspaceToolStripMenuItem.Text = "Add workspace";
            // 
            // VersionTSMenuItem
            // 
            this.VersionTSMenuItem.ForeColor = System.Drawing.Color.White;
            this.VersionTSMenuItem.Name = "VersionTSMenuItem";
            this.VersionTSMenuItem.Size = new System.Drawing.Size(57, 21);
            this.VersionTSMenuItem.Text = "Version";
            // 
            // bgwBackup
            // 
            this.bgwBackup.WorkerReportsProgress = true;
            // 
            // bgwRename
            // 
            this.bgwRename.WorkerReportsProgress = true;
            this.bgwRename.WorkerSupportsCancellation = true;
            // 
            // bgwConvert
            // 
            this.bgwConvert.WorkerReportsProgress = true;
            this.bgwConvert.WorkerSupportsCancellation = true;
            // 
            // lbShoot
            // 
            this.lbShoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lbShoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbShoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShoot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShoot.ForeColor = System.Drawing.Color.White;
            this.lbShoot.FormattingEnabled = true;
            this.lbShoot.ItemHeight = 17;
            this.lbShoot.Location = new System.Drawing.Point(0, 40);
            this.lbShoot.Name = "lbShoot";
            this.lbShoot.Size = new System.Drawing.Size(194, 416);
            this.lbShoot.TabIndex = 3;
            this.lbShoot.Click += new System.EventHandler(this.lbShoot_Click);
            this.lbShoot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbShoot_MouseDown);
            // 
            // comboWorkspace
            // 
            this.comboWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.comboWorkspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboWorkspace.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboWorkspace.ForeColor = System.Drawing.Color.White;
            this.comboWorkspace.FormattingEnabled = true;
            this.comboWorkspace.Location = new System.Drawing.Point(438, 18);
            this.comboWorkspace.Name = "comboWorkspace";
            this.comboWorkspace.Size = new System.Drawing.Size(267, 25);
            this.comboWorkspace.TabIndex = 8;
            this.comboWorkspace.SelectedIndexChanged += new System.EventHandler(this.comboWorkspace_SelectedIndexChanged);
            // 
            // bgwSelection
            // 
            this.bgwSelection.WorkerReportsProgress = true;
            this.bgwSelection.WorkerSupportsCancellation = true;
            // 
            // tableLayoutWorkspace
            // 
            this.tableLayoutWorkspace.ColumnCount = 1;
            this.tableLayoutWorkspace.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutWorkspace.Controls.Add(this.panelConfig, 0, 0);
            this.tableLayoutWorkspace.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutWorkspace.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutWorkspace.Name = "tableLayoutWorkspace";
            this.tableLayoutWorkspace.RowCount = 1;
            this.tableLayoutWorkspace.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutWorkspace.Size = new System.Drawing.Size(1098, 60);
            this.tableLayoutWorkspace.TabIndex = 6;
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.pictureBox1);
            this.panelConfig.Controls.Add(this.comboWorkspace);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfig.Location = new System.Drawing.Point(3, 3);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(1092, 54);
            this.panelConfig.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PicturebotGUI.Properties.Resources.Gear;
            this.pictureBox1.Location = new System.Drawing.Point(711, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lbSelection
            // 
            this.lbSelection.AllowDrop = true;
            this.lbSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lbSelection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbSelection.ForeColor = System.Drawing.Color.White;
            this.lbSelection.FormattingEnabled = true;
            this.lbSelection.ItemHeight = 17;
            this.lbSelection.Location = new System.Drawing.Point(0, 40);
            this.lbSelection.Name = "lbSelection";
            this.lbSelection.Size = new System.Drawing.Size(218, 208);
            this.lbSelection.Sorted = true;
            this.lbSelection.TabIndex = 1;
            this.lbSelection.SelectedIndexChanged += new System.EventHandler(this.lbSelection_SelectedIndexChanged);
            this.lbSelection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbSelection_MouseDown);
            // 
            // tableLayoutShoot
            // 
            this.tableLayoutShoot.ColumnCount = 1;
            this.tableLayoutShoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutShoot.Controls.Add(this.panelShoots, 0, 0);
            this.tableLayoutShoot.Controls.Add(this.pbAddShoot, 0, 1);
            this.tableLayoutShoot.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutShoot.Location = new System.Drawing.Point(0, 85);
            this.tableLayoutShoot.Name = "tableLayoutShoot";
            this.tableLayoutShoot.RowCount = 3;
            this.tableLayoutShoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.4F));
            this.tableLayoutShoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.6F));
            this.tableLayoutShoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutShoot.Size = new System.Drawing.Size(200, 509);
            this.tableLayoutShoot.TabIndex = 7;
            // 
            // panelShoots
            // 
            this.panelShoots.Controls.Add(this.lbShoot);
            this.panelShoots.Controls.Add(this.panelLabelShoots);
            this.panelShoots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShoots.Location = new System.Drawing.Point(3, 3);
            this.panelShoots.Name = "panelShoots";
            this.panelShoots.Size = new System.Drawing.Size(194, 456);
            this.panelShoots.TabIndex = 5;
            // 
            // panelLabelShoots
            // 
            this.panelLabelShoots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelShoots.Controls.Add(this.label1);
            this.panelLabelShoots.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelShoots.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLabelShoots.Location = new System.Drawing.Point(0, 0);
            this.panelLabelShoots.Name = "panelLabelShoots";
            this.panelLabelShoots.Size = new System.Drawing.Size(194, 40);
            this.panelLabelShoots.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 21F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shoots";
            // 
            // pbAddShoot
            // 
            this.pbAddShoot.BackgroundImage = global::PicturebotGUI.Properties.Resources.Shoot;
            this.pbAddShoot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbAddShoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAddShoot.Location = new System.Drawing.Point(3, 465);
            this.pbAddShoot.Name = "pbAddShoot";
            this.pbAddShoot.Size = new System.Drawing.Size(194, 32);
            this.pbAddShoot.TabIndex = 6;
            this.pbAddShoot.TabStop = false;
            this.pbAddShoot.Click += new System.EventHandler(this.pbAddShoot_Click);
            // 
            // panelEdited
            // 
            this.panelEdited.Controls.Add(this.lbEdited);
            this.panelEdited.Controls.Add(this.panelLabelEdited);
            this.panelEdited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdited.Location = new System.Drawing.Point(451, 3);
            this.panelEdited.Name = "panelEdited";
            this.panelEdited.Size = new System.Drawing.Size(218, 248);
            this.panelEdited.TabIndex = 9;
            // 
            // lbEdited
            // 
            this.lbEdited.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lbEdited.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbEdited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEdited.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbEdited.ForeColor = System.Drawing.Color.White;
            this.lbEdited.FormattingEnabled = true;
            this.lbEdited.ItemHeight = 17;
            this.lbEdited.Location = new System.Drawing.Point(0, 40);
            this.lbEdited.Name = "lbEdited";
            this.lbEdited.Size = new System.Drawing.Size(218, 208);
            this.lbEdited.Sorted = true;
            this.lbEdited.TabIndex = 2;
            this.lbEdited.SelectedIndexChanged += new System.EventHandler(this.lbEdited_SelectedIndexChanged);
            this.lbEdited.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbEdited_MouseDown);
            // 
            // panelLabelEdited
            // 
            this.panelLabelEdited.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelEdited.Controls.Add(this.lblEdited);
            this.panelLabelEdited.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelEdited.Location = new System.Drawing.Point(0, 0);
            this.panelLabelEdited.Name = "panelLabelEdited";
            this.panelLabelEdited.Size = new System.Drawing.Size(218, 40);
            this.panelLabelEdited.TabIndex = 0;
            // 
            // lblEdited
            // 
            this.lblEdited.AutoSize = true;
            this.lblEdited.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEdited.Font = new System.Drawing.Font("Tahoma", 21F);
            this.lblEdited.ForeColor = System.Drawing.Color.White;
            this.lblEdited.Location = new System.Drawing.Point(0, 0);
            this.lblEdited.Name = "lblEdited";
            this.lblEdited.Size = new System.Drawing.Size(91, 34);
            this.lblEdited.TabIndex = 0;
            this.lblEdited.Text = "Edited";
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.lbPreview);
            this.panelPreview.Controls.Add(this.panelLabelPreview);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreview.Location = new System.Drawing.Point(3, 3);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(218, 248);
            this.panelPreview.TabIndex = 0;
            // 
            // lbPreview
            // 
            this.lbPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lbPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPreview.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbPreview.ForeColor = System.Drawing.Color.White;
            this.lbPreview.FormattingEnabled = true;
            this.lbPreview.ItemHeight = 17;
            this.lbPreview.Location = new System.Drawing.Point(0, 40);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(218, 208);
            this.lbPreview.Sorted = true;
            this.lbPreview.TabIndex = 6;
            this.lbPreview.SelectedIndexChanged += new System.EventHandler(this.lbPreview_SelectedIndexChanged);
            this.lbPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPreview_MouseDown);
            // 
            // panelLabelPreview
            // 
            this.panelLabelPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelPreview.Controls.Add(this.lblPreview);
            this.panelLabelPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelPreview.Location = new System.Drawing.Point(0, 0);
            this.panelLabelPreview.Name = "panelLabelPreview";
            this.panelLabelPreview.Size = new System.Drawing.Size(218, 40);
            this.panelLabelPreview.TabIndex = 0;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPreview.Font = new System.Drawing.Font("Tahoma", 21F);
            this.lblPreview.ForeColor = System.Drawing.Color.White;
            this.lblPreview.Location = new System.Drawing.Point(0, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(111, 34);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Preview";
            // 
            // panelInstagram
            // 
            this.panelInstagram.Controls.Add(this.lbInstagram);
            this.panelInstagram.Controls.Add(this.panelLabelInstagram);
            this.panelInstagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInstagram.Location = new System.Drawing.Point(675, 3);
            this.panelInstagram.Name = "panelInstagram";
            this.panelInstagram.Size = new System.Drawing.Size(220, 248);
            this.panelInstagram.TabIndex = 8;
            // 
            // lbInstagram
            // 
            this.lbInstagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lbInstagram.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbInstagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInstagram.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbInstagram.ForeColor = System.Drawing.Color.White;
            this.lbInstagram.FormattingEnabled = true;
            this.lbInstagram.ItemHeight = 17;
            this.lbInstagram.Location = new System.Drawing.Point(0, 40);
            this.lbInstagram.Name = "lbInstagram";
            this.lbInstagram.Size = new System.Drawing.Size(220, 208);
            this.lbInstagram.TabIndex = 0;
            this.lbInstagram.SelectedIndexChanged += new System.EventHandler(this.lbInstagram_SelectedIndexChanged);
            this.lbInstagram.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbInstagram_MouseDown);
            // 
            // panelLabelInstagram
            // 
            this.panelLabelInstagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelInstagram.Controls.Add(this.lblInstagram);
            this.panelLabelInstagram.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelInstagram.Location = new System.Drawing.Point(0, 0);
            this.panelLabelInstagram.Name = "panelLabelInstagram";
            this.panelLabelInstagram.Size = new System.Drawing.Size(220, 40);
            this.panelLabelInstagram.TabIndex = 0;
            // 
            // lblInstagram
            // 
            this.lblInstagram.AutoSize = true;
            this.lblInstagram.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInstagram.Font = new System.Drawing.Font("Tahoma", 21F);
            this.lblInstagram.ForeColor = System.Drawing.Color.White;
            this.lblInstagram.Location = new System.Drawing.Point(0, 0);
            this.lblInstagram.Name = "lblInstagram";
            this.lblInstagram.Size = new System.Drawing.Size(142, 34);
            this.lblInstagram.TabIndex = 0;
            this.lblInstagram.Text = "Instagram";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pbSelection, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbEdited, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbPreview, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelInstagram, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelPreview, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEdited, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSelection, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbInstagram, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(200, 85);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(898, 509);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // pbSelection
            // 
            this.pbSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbSelection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSelection.BackgroundImage")));
            this.pbSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSelection.Location = new System.Drawing.Point(227, 257);
            this.pbSelection.Name = "pbSelection";
            this.pbSelection.Size = new System.Drawing.Size(218, 249);
            this.pbSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelection.TabIndex = 0;
            this.pbSelection.TabStop = false;
            // 
            // pbEdited
            // 
            this.pbEdited.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbEdited.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbEdited.BackgroundImage")));
            this.pbEdited.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbEdited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEdited.Location = new System.Drawing.Point(451, 257);
            this.pbEdited.Name = "pbEdited";
            this.pbEdited.Size = new System.Drawing.Size(218, 249);
            this.pbEdited.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEdited.TabIndex = 1;
            this.pbEdited.TabStop = false;
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbPreview.BackgroundImage = global::PicturebotGUI.Properties.Resources.LogoImage;
            this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(3, 257);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(218, 249);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 5;
            this.pbPreview.TabStop = false;
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.lbSelection);
            this.panelSelection.Controls.Add(this.panel1);
            this.panelSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelection.Location = new System.Drawing.Point(227, 3);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(218, 248);
            this.panelSelection.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.lblSelection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 40);
            this.panel1.TabIndex = 1;
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSelection.Font = new System.Drawing.Font("Tahoma", 21F);
            this.lblSelection.ForeColor = System.Drawing.Color.White;
            this.lblSelection.Location = new System.Drawing.Point(0, 0);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(126, 34);
            this.lblSelection.TabIndex = 0;
            this.lblSelection.Text = "Selection";
            // 
            // pbInstagram
            // 
            this.pbInstagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbInstagram.BackgroundImage = global::PicturebotGUI.Properties.Resources.LogoImage;
            this.pbInstagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbInstagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbInstagram.Location = new System.Drawing.Point(675, 257);
            this.pbInstagram.Name = "pbInstagram";
            this.pbInstagram.Size = new System.Drawing.Size(220, 249);
            this.pbInstagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInstagram.TabIndex = 11;
            this.pbInstagram.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1098, 594);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutShoot);
            this.Controls.Add(this.tableLayoutWorkspace);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picturebot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutWorkspace.ResumeLayout(false);
            this.panelConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutShoot.ResumeLayout(false);
            this.panelShoots.ResumeLayout(false);
            this.panelLabelShoots.ResumeLayout(false);
            this.panelLabelShoots.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddShoot)).EndInit();
            this.panelEdited.ResumeLayout(false);
            this.panelLabelEdited.ResumeLayout(false);
            this.panelLabelEdited.PerformLayout();
            this.panelPreview.ResumeLayout(false);
            this.panelLabelPreview.ResumeLayout(false);
            this.panelLabelPreview.PerformLayout();
            this.panelInstagram.ResumeLayout(false);
            this.panelLabelInstagram.ResumeLayout(false);
            this.panelLabelInstagram.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdited)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.panelSelection.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstagram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenConfigFileTStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VersionTSMenuItem;
        private System.ComponentModel.BackgroundWorker bgwBackup;
        private System.ComponentModel.BackgroundWorker bgwRename;
        private System.ComponentModel.BackgroundWorker bgwConvert;
        private System.Windows.Forms.ListBox lbShoot;
        private System.ComponentModel.BackgroundWorker bgwSelection;
        private System.ComponentModel.BackgroundWorker bgwEdited;
        private System.Windows.Forms.ToolStripMenuItem openWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboWorkspace;
        private System.ComponentModel.BackgroundWorker bgwMassRename;
        private System.Windows.Forms.TableLayoutPanel tableLayoutWorkspace;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutShoot;
        private System.Windows.Forms.Panel panelLabelShoots;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelShoots;
        private System.Windows.Forms.ListBox lbSelection;
        private System.Windows.Forms.Panel panelEdited;
        private System.Windows.Forms.ListBox lbEdited;
        private System.Windows.Forms.Panel panelLabelEdited;
        private System.Windows.Forms.Label lblEdited;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.ListBox lbPreview;
        private System.Windows.Forms.Panel panelLabelPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Panel panelInstagram;
        private System.Windows.Forms.ListBox lbInstagram;
        private System.Windows.Forms.Panel panelLabelInstagram;
        private System.Windows.Forms.Label lblInstagram;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.PictureBox pbEdited;
        private System.Windows.Forms.PictureBox pbSelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbAddShoot;
        private System.Windows.Forms.ToolStripMenuItem addWorkspaceToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbInstagram;
    }
}

