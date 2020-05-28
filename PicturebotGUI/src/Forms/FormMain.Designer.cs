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
            this.openWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigFileTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reorderWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lbSelection = new System.Windows.Forms.ListBox();
            this.tableLayoutShoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelShoots = new System.Windows.Forms.Panel();
            this.panelLabelShoots = new System.Windows.Forms.Panel();
            this.lblShoots = new System.Windows.Forms.Label();
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
            this.defaultFileTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutWorkspace.SuspendLayout();
            this.panelConfig.SuspendLayout();
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
            this.workspaceToolStripMenuItem,
            this.VersionTSMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1456, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWorkspaceToolStripMenuItem,
            this.openLogFileToolStripMenuItem,
            this.openConfigFileTSMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
            this.fileToolStripMenuItem.Text = "Files";
            // 
            // openWorkspaceToolStripMenuItem
            // 
            this.openWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.openWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openWorkspaceToolStripMenuItem.Name = "openWorkspaceToolStripMenuItem";
            this.openWorkspaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.openWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.openWorkspaceToolStripMenuItem.Text = "Open workspace";
            this.openWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.openWorkspaceToolStripMenuItem_Click);
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.openLogFileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.openLogFileToolStripMenuItem.Text = "Open log file";
            this.openLogFileToolStripMenuItem.Click += new System.EventHandler(this.openLogFileToolStripMenuItem_Click);
            // 
            // openConfigFileTSMenuItem
            // 
            this.openConfigFileTSMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.openConfigFileTSMenuItem.ForeColor = System.Drawing.Color.White;
            this.openConfigFileTSMenuItem.Name = "openConfigFileTSMenuItem";
            this.openConfigFileTSMenuItem.Size = new System.Drawing.Size(223, 22);
            this.openConfigFileTSMenuItem.Text = "Open config file ";
            this.openConfigFileTSMenuItem.Click += new System.EventHandler(this.openConfigFileToolStripMenuItem_Click);
            // 
            // workspaceToolStripMenuItem
            // 
            this.workspaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWorkspaceToolStripMenuItem,
            this.editWorkspaceToolStripMenuItem,
            this.reorderWorkspaceToolStripMenuItem,
            this.deleteWorkspaceToolStripMenuItem});
            this.workspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.workspaceToolStripMenuItem.Name = "workspaceToolStripMenuItem";
            this.workspaceToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.workspaceToolStripMenuItem.Text = "Workspace";
            // 
            // addWorkspaceToolStripMenuItem
            // 
            this.addWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.addWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addWorkspaceToolStripMenuItem.Name = "addWorkspaceToolStripMenuItem";
            this.addWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.addWorkspaceToolStripMenuItem.Text = "Add workspace";
            this.addWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.addWorkspaceToolStripMenuItem_Click);
            // 
            // editWorkspaceToolStripMenuItem
            // 
            this.editWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.editWorkspaceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.editWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editWorkspaceToolStripMenuItem.Name = "editWorkspaceToolStripMenuItem";
            this.editWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.editWorkspaceToolStripMenuItem.Text = "Edit workspace";
            this.editWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.editWorkspaceToolStripMenuItem_Click);
            // 
            // reorderWorkspaceToolStripMenuItem
            // 
            this.reorderWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.reorderWorkspaceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.reorderWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reorderWorkspaceToolStripMenuItem.Name = "reorderWorkspaceToolStripMenuItem";
            this.reorderWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.reorderWorkspaceToolStripMenuItem.Text = "Reorder workspace";
            this.reorderWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.reorderWorkspaceToolStripMenuItem_Click);
            // 
            // deleteWorkspaceToolStripMenuItem
            // 
            this.deleteWorkspaceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.deleteWorkspaceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.deleteWorkspaceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteWorkspaceToolStripMenuItem.Name = "deleteWorkspaceToolStripMenuItem";
            this.deleteWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.deleteWorkspaceToolStripMenuItem.Text = "Delete workspace";
            this.deleteWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.deleteWorkspaceToolStripMenuItem_Click);
            // 
            // VersionTSMenuItem
            // 
            this.VersionTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadSettingsToolStripMenuItem,
            this.loggingToolStripMenuItem,
            this.loggingConsoleToolStripMenuItem,
            this.defaultFileTypeToolStripMenuItem});
            this.VersionTSMenuItem.ForeColor = System.Drawing.Color.White;
            this.VersionTSMenuItem.Name = "VersionTSMenuItem";
            this.VersionTSMenuItem.Size = new System.Drawing.Size(61, 21);
            this.VersionTSMenuItem.Text = "Settings";
            // 
            // uploadSettingsToolStripMenuItem
            // 
            this.uploadSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.uploadSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.uploadSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.uploadSettingsToolStripMenuItem.Name = "uploadSettingsToolStripMenuItem";
            this.uploadSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uploadSettingsToolStripMenuItem.Text = "Upload settings";
            this.uploadSettingsToolStripMenuItem.Click += new System.EventHandler(this.uploadSettingsToolStripMenuItem_Click);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.loggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.errorToolStripMenuItem});
            this.loggingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.loggingToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loggingToolStripMenuItem.Text = "Logging level";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.errorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.errorToolStripMenuItem.Text = "Error";
            this.errorToolStripMenuItem.Click += new System.EventHandler(this.errorToolStripMenuItem_Click);
            // 
            // loggingConsoleToolStripMenuItem
            // 
            this.loggingConsoleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.loggingConsoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugConsoleToolStripMenuItem,
            this.errorConsoleToolStripMenuItem});
            this.loggingConsoleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.loggingConsoleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.loggingConsoleToolStripMenuItem.Name = "loggingConsoleToolStripMenuItem";
            this.loggingConsoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loggingConsoleToolStripMenuItem.Text = "Logging console";
            // 
            // debugConsoleToolStripMenuItem
            // 
            this.debugConsoleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.debugConsoleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.debugConsoleToolStripMenuItem.Name = "debugConsoleToolStripMenuItem";
            this.debugConsoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.debugConsoleToolStripMenuItem.Text = "Debug";
            this.debugConsoleToolStripMenuItem.Click += new System.EventHandler(this.debugConsoleToolStripMenuItem_Click);
            // 
            // errorConsoleToolStripMenuItem
            // 
            this.errorConsoleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.errorConsoleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.errorConsoleToolStripMenuItem.Name = "errorConsoleToolStripMenuItem";
            this.errorConsoleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.errorConsoleToolStripMenuItem.Text = "Error";
            this.errorConsoleToolStripMenuItem.Click += new System.EventHandler(this.errorConsoleToolStripMenuItem_Click);
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
            this.lbShoot.Size = new System.Drawing.Size(236, 612);
            this.lbShoot.TabIndex = 3;
            this.lbShoot.SelectedIndexChanged += new System.EventHandler(this.lbShoot_SelectedIndexChanged);
            this.lbShoot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbShoot_KeyDown);
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
            this.comboWorkspace.Location = new System.Drawing.Point(545, 18);
            this.comboWorkspace.Name = "comboWorkspace";
            this.comboWorkspace.Size = new System.Drawing.Size(297, 25);
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
            this.tableLayoutWorkspace.Size = new System.Drawing.Size(1456, 60);
            this.tableLayoutWorkspace.TabIndex = 6;
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.comboWorkspace);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfig.Location = new System.Drawing.Point(3, 3);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(1450, 54);
            this.panelConfig.TabIndex = 0;
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
            this.lbSelection.Size = new System.Drawing.Size(297, 314);
            this.lbSelection.Sorted = true;
            this.lbSelection.TabIndex = 1;
            this.lbSelection.SelectedIndexChanged += new System.EventHandler(this.lbSelection_SelectedIndexChanged);
            this.lbSelection.DoubleClick += new System.EventHandler(this.lbSelection_DoubleClick);
            this.lbSelection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSelection_KeyDown);
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
            this.tableLayoutShoot.Size = new System.Drawing.Size(242, 721);
            this.tableLayoutShoot.TabIndex = 7;
            // 
            // panelShoots
            // 
            this.panelShoots.Controls.Add(this.lbShoot);
            this.panelShoots.Controls.Add(this.panelLabelShoots);
            this.panelShoots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShoots.Location = new System.Drawing.Point(3, 3);
            this.panelShoots.Name = "panelShoots";
            this.panelShoots.Size = new System.Drawing.Size(236, 652);
            this.panelShoots.TabIndex = 5;
            // 
            // panelLabelShoots
            // 
            this.panelLabelShoots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelShoots.Controls.Add(this.lblShoots);
            this.panelLabelShoots.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelShoots.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelLabelShoots.Location = new System.Drawing.Point(0, 0);
            this.panelLabelShoots.Name = "panelLabelShoots";
            this.panelLabelShoots.Size = new System.Drawing.Size(236, 40);
            this.panelLabelShoots.TabIndex = 4;
            // 
            // lblShoots
            // 
            this.lblShoots.AutoSize = true;
            this.lblShoots.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShoots.Font = new System.Drawing.Font("Tahoma", 21F);
            this.lblShoots.ForeColor = System.Drawing.Color.White;
            this.lblShoots.Location = new System.Drawing.Point(0, 0);
            this.lblShoots.Name = "lblShoots";
            this.lblShoots.Size = new System.Drawing.Size(99, 34);
            this.lblShoots.TabIndex = 0;
            this.lblShoots.Text = "Shoots";
            // 
            // pbAddShoot
            // 
            this.pbAddShoot.BackgroundImage = global::PicturebotGUI.Properties.Resources.Shoot;
            this.pbAddShoot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbAddShoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAddShoot.Location = new System.Drawing.Point(3, 661);
            this.pbAddShoot.Name = "pbAddShoot";
            this.pbAddShoot.Size = new System.Drawing.Size(236, 48);
            this.pbAddShoot.TabIndex = 6;
            this.pbAddShoot.TabStop = false;
            this.pbAddShoot.Click += new System.EventHandler(this.pbAddShoot_Click);
            // 
            // panelEdited
            // 
            this.panelEdited.Controls.Add(this.lbEdited);
            this.panelEdited.Controls.Add(this.panelLabelEdited);
            this.panelEdited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdited.Location = new System.Drawing.Point(609, 3);
            this.panelEdited.Name = "panelEdited";
            this.panelEdited.Size = new System.Drawing.Size(297, 354);
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
            this.lbEdited.Size = new System.Drawing.Size(297, 314);
            this.lbEdited.Sorted = true;
            this.lbEdited.TabIndex = 2;
            this.lbEdited.SelectedIndexChanged += new System.EventHandler(this.lbEdited_SelectedIndexChanged);
            this.lbEdited.DoubleClick += new System.EventHandler(this.lbEdited_DoubleClick);
            this.lbEdited.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEdited_KeyDown);
            this.lbEdited.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbEdited_MouseDown);
            // 
            // panelLabelEdited
            // 
            this.panelLabelEdited.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelEdited.Controls.Add(this.lblEdited);
            this.panelLabelEdited.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelEdited.Location = new System.Drawing.Point(0, 0);
            this.panelLabelEdited.Name = "panelLabelEdited";
            this.panelLabelEdited.Size = new System.Drawing.Size(297, 40);
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
            this.lblEdited.Size = new System.Drawing.Size(0, 34);
            this.lblEdited.TabIndex = 0;
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.lbPreview);
            this.panelPreview.Controls.Add(this.panelLabelPreview);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreview.Location = new System.Drawing.Point(3, 3);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(297, 354);
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
            this.lbPreview.Size = new System.Drawing.Size(297, 314);
            this.lbPreview.Sorted = true;
            this.lbPreview.TabIndex = 6;
            this.lbPreview.SelectedIndexChanged += new System.EventHandler(this.lbPreview_SelectedIndexChanged);
            this.lbPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPreview_KeyDown);
            this.lbPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbPreview_MouseDown);
            // 
            // panelLabelPreview
            // 
            this.panelLabelPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelPreview.Controls.Add(this.lblPreview);
            this.panelLabelPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelPreview.Location = new System.Drawing.Point(0, 0);
            this.panelLabelPreview.Name = "panelLabelPreview";
            this.panelLabelPreview.Size = new System.Drawing.Size(297, 40);
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
            this.lblPreview.Size = new System.Drawing.Size(0, 34);
            this.lblPreview.TabIndex = 0;
            // 
            // panelInstagram
            // 
            this.panelInstagram.Controls.Add(this.lbInstagram);
            this.panelInstagram.Controls.Add(this.panelLabelInstagram);
            this.panelInstagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInstagram.Location = new System.Drawing.Point(912, 3);
            this.panelInstagram.Name = "panelInstagram";
            this.panelInstagram.Size = new System.Drawing.Size(299, 354);
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
            this.lbInstagram.Size = new System.Drawing.Size(299, 314);
            this.lbInstagram.TabIndex = 0;
            this.lbInstagram.SelectedIndexChanged += new System.EventHandler(this.lbInstagram_SelectedIndexChanged);
            this.lbInstagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbInstagram_KeyDown);
            this.lbInstagram.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbInstagram_MouseDown);
            // 
            // panelLabelInstagram
            // 
            this.panelLabelInstagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panelLabelInstagram.Controls.Add(this.lblInstagram);
            this.panelLabelInstagram.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabelInstagram.Location = new System.Drawing.Point(0, 0);
            this.panelLabelInstagram.Name = "panelLabelInstagram";
            this.panelLabelInstagram.Size = new System.Drawing.Size(299, 40);
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
            this.lblInstagram.Size = new System.Drawing.Size(0, 34);
            this.lblInstagram.TabIndex = 0;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(242, 85);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1214, 721);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // pbSelection
            // 
            this.pbSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbSelection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSelection.BackgroundImage")));
            this.pbSelection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSelection.Location = new System.Drawing.Point(306, 363);
            this.pbSelection.Name = "pbSelection";
            this.pbSelection.Size = new System.Drawing.Size(297, 355);
            this.pbSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelection.TabIndex = 0;
            this.pbSelection.TabStop = false;
            this.pbSelection.Click += new System.EventHandler(this.pbSelection_Click);
            // 
            // pbEdited
            // 
            this.pbEdited.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbEdited.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbEdited.BackgroundImage")));
            this.pbEdited.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbEdited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEdited.Location = new System.Drawing.Point(609, 363);
            this.pbEdited.Name = "pbEdited";
            this.pbEdited.Size = new System.Drawing.Size(297, 355);
            this.pbEdited.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEdited.TabIndex = 1;
            this.pbEdited.TabStop = false;
            this.pbEdited.Click += new System.EventHandler(this.pbEdited_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbPreview.BackgroundImage = global::PicturebotGUI.Properties.Resources.LogoImage;
            this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(3, 363);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(297, 355);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 5;
            this.pbPreview.TabStop = false;
            this.pbPreview.Click += new System.EventHandler(this.pbPreview_Click);
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.lbSelection);
            this.panelSelection.Controls.Add(this.panel1);
            this.panelSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelection.Location = new System.Drawing.Point(306, 3);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(297, 354);
            this.panelSelection.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.lblSelection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 40);
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
            this.lblSelection.Size = new System.Drawing.Size(0, 34);
            this.lblSelection.TabIndex = 0;
            // 
            // pbInstagram
            // 
            this.pbInstagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.pbInstagram.BackgroundImage = global::PicturebotGUI.Properties.Resources.LogoImage;
            this.pbInstagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbInstagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbInstagram.Location = new System.Drawing.Point(912, 363);
            this.pbInstagram.Name = "pbInstagram";
            this.pbInstagram.Size = new System.Drawing.Size(299, 355);
            this.pbInstagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInstagram.TabIndex = 11;
            this.pbInstagram.TabStop = false;
            this.pbInstagram.Click += new System.EventHandler(this.pbInstagram_Click);
            // 
            // defaultFileTypeToolStripMenuItem
            // 
            this.defaultFileTypeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.defaultFileTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawToolStripMenuItem,
            this.compressedToolStripMenuItem});
            this.defaultFileTypeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.defaultFileTypeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.defaultFileTypeToolStripMenuItem.Name = "defaultFileTypeToolStripMenuItem";
            this.defaultFileTypeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defaultFileTypeToolStripMenuItem.Text = "Default file type";
            // 
            // rawToolStripMenuItem
            // 
            this.rawToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rawToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rawToolStripMenuItem.Name = "rawToolStripMenuItem";
            this.rawToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rawToolStripMenuItem.Text = "RAW ";
            this.rawToolStripMenuItem.Click += new System.EventHandler(this.rawToolStripMenuItem_Click);
            // 
            // compressedToolStripMenuItem
            // 
            this.compressedToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.compressedToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.compressedToolStripMenuItem.Name = "compressedToolStripMenuItem";
            this.compressedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.compressedToolStripMenuItem.Text = "Compressed";
            this.compressedToolStripMenuItem.Click += new System.EventHandler(this.compressedToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1456, 806);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutShoot);
            this.Controls.Add(this.tableLayoutWorkspace);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1472, 845);
            this.MinimumSize = new System.Drawing.Size(1472, 845);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picturebot ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutWorkspace.ResumeLayout(false);
            this.panelConfig.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblShoots;
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
        private System.Windows.Forms.PictureBox pbAddShoot;
        private System.Windows.Forms.PictureBox pbInstagram;
        private System.Windows.Forms.ToolStripMenuItem openLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggingConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigFileTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reorderWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultFileTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressedToolStripMenuItem;
    }
}

