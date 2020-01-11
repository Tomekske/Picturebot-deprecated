namespace PicturebotGUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenConfigFileTStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCurrentDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwBackup = new System.ComponentModel.BackgroundWorker();
            this.bgwRename = new System.ComponentModel.BackgroundWorker();
            this.bgwConvert = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cpProcess = new CircularProgressBar.CircularProgressBar();
            this.lblProcess = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbShoot = new System.Windows.Forms.ListBox();
            this.btnNewShoot = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPreview = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.pbSelection = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSelection = new System.Windows.Forms.ListBox();
            this.lbEdited = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.radioSingle = new System.Windows.Forms.RadioButton();
            this.radioCompare = new System.Windows.Forms.RadioButton();
            this.pbEdited = new System.Windows.Forms.PictureBox();
            this.bgwSelection = new System.ComponentModel.BackgroundWorker();
            this.bgwEdited = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.lbInstagram = new System.Windows.Forms.ListBox();
            this.pbInstagram = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelection)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdited)).BeginInit();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInstagram)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.VersionTSMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenConfigFileTStripMenuItem,
            this.openCurrentDirectoryToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // OpenConfigFileTStripMenuItem
            // 
            this.OpenConfigFileTStripMenuItem.Name = "OpenConfigFileTStripMenuItem";
            this.OpenConfigFileTStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.OpenConfigFileTStripMenuItem.Text = "Open config file";
            this.OpenConfigFileTStripMenuItem.Click += new System.EventHandler(this.OpenConfigFileTStripMenuItem_Click);
            // 
            // openCurrentDirectoryToolStripMenuItem
            // 
            this.openCurrentDirectoryToolStripMenuItem.Name = "openCurrentDirectoryToolStripMenuItem";
            this.openCurrentDirectoryToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.openCurrentDirectoryToolStripMenuItem.Text = "Open current directory";
            this.openCurrentDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openCurrentDirectoryToolStripMenuItem_Click);
            // 
            // VersionTSMenuItem
            // 
            this.VersionTSMenuItem.Name = "VersionTSMenuItem";
            this.VersionTSMenuItem.Size = new System.Drawing.Size(57, 20);
            this.VersionTSMenuItem.Text = "Version";
            this.VersionTSMenuItem.Click += new System.EventHandler(this.VersionTSMenuItem_Click);
            // 
            // bgwBackup
            // 
            this.bgwBackup.WorkerReportsProgress = true;
            this.bgwBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBackup_DoWork);
            this.bgwBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwBackup_ProgressChanged);
            this.bgwBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBackup_RunWorkerCompleted);
            // 
            // bgwRename
            // 
            this.bgwRename.WorkerReportsProgress = true;
            this.bgwRename.WorkerSupportsCancellation = true;
            this.bgwRename.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRename_DoWork);
            this.bgwRename.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwRename_ProgressChanged);
            this.bgwRename.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRename_RunWorkerCompleted);
            // 
            // bgwConvert
            // 
            this.bgwConvert.WorkerReportsProgress = true;
            this.bgwConvert.WorkerSupportsCancellation = true;
            this.bgwConvert.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwConvert_DoWork);
            this.bgwConvert.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwConvert_ProgressChanged);
            this.bgwConvert.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwConvert_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.33193F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.668067F));
            this.tableLayoutPanel1.Controls.Add(this.cpProcess, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProcess, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 546);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 48);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cpProcess
            // 
            this.cpProcess.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpProcess.AnimationSpeed = 500;
            this.cpProcess.BackColor = System.Drawing.Color.Transparent;
            this.cpProcess.Dock = System.Windows.Forms.DockStyle.Right;
            this.cpProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.cpProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cpProcess.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cpProcess.InnerMargin = 2;
            this.cpProcess.InnerWidth = -1;
            this.cpProcess.Location = new System.Drawing.Point(914, 3);
            this.cpProcess.MarqueeAnimationSpeed = 2000;
            this.cpProcess.Name = "cpProcess";
            this.cpProcess.OuterColor = System.Drawing.Color.Gray;
            this.cpProcess.OuterMargin = -15;
            this.cpProcess.OuterWidth = 8;
            this.cpProcess.ProgressColor = System.Drawing.Color.Navy;
            this.cpProcess.ProgressWidth = 8;
            this.cpProcess.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpProcess.Size = new System.Drawing.Size(35, 18);
            this.cpProcess.StartAngle = 270;
            this.cpProcess.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpProcess.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpProcess.SubscriptText = ".23";
            this.cpProcess.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cpProcess.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpProcess.SuperscriptText = "°C";
            this.cpProcess.TabIndex = 11;
            this.cpProcess.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cpProcess.Value = 68;
            this.cpProcess.Visible = false;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProcess.Location = new System.Drawing.Point(881, 24);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(0, 24);
            this.lblProcess.TabIndex = 12;
            this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.78481F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.21519F));
            this.tableLayoutPanel2.Controls.Add(this.pbPreview, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.34483F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.65517F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(364, 522);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(3, 318);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(167, 201);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 5;
            this.pbPreview.TabStop = false;
            this.pbPreview.Click += new System.EventHandler(this.pbPreview_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lbShoot, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnNewShoot, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.41558F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.58442F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(144, 308);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // lbShoot
            // 
            this.lbShoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShoot.FormattingEnabled = true;
            this.lbShoot.Location = new System.Drawing.Point(3, 3);
            this.lbShoot.Name = "lbShoot";
            this.lbShoot.Size = new System.Drawing.Size(138, 253);
            this.lbShoot.TabIndex = 3;
            this.lbShoot.SelectedIndexChanged += new System.EventHandler(this.lbShoot_SelectedIndexChanged);
            // 
            // btnNewShoot
            // 
            this.btnNewShoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewShoot.Location = new System.Drawing.Point(3, 262);
            this.btnNewShoot.Name = "btnNewShoot";
            this.btnNewShoot.Size = new System.Drawing.Size(138, 43);
            this.btnNewShoot.TabIndex = 4;
            this.btnNewShoot.Text = "Add Shoot";
            this.btnNewShoot.UseVisualStyleBackColor = true;
            this.btnNewShoot.Click += new System.EventHandler(this.btnNewShoot_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lbPreview, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(176, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.09091F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.90909F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(185, 309);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // lbPreview
            // 
            this.lbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPreview.FormattingEnabled = true;
            this.lbPreview.Location = new System.Drawing.Point(3, 3);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(179, 253);
            this.lbPreview.Sorted = true;
            this.lbPreview.TabIndex = 6;
            this.lbPreview.SelectedIndexChanged += new System.EventHandler(this.lbPreview_SelectedIndexChanged);
            this.lbPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPreview_KeyDown);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.18692F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.81308F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel5.Controls.Add(this.btnRename, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnBackup, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnConvert, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 262);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(179, 44);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // btnRename
            // 
            this.btnRename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRename.Location = new System.Drawing.Point(106, 3);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(70, 38);
            this.btnRename.TabIndex = 15;
            this.btnRename.Text = "Rename files";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackup.Location = new System.Drawing.Point(44, 3);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(56, 38);
            this.btnBackup.TabIndex = 14;
            this.btnBackup.Text = "Backup shoot";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(3, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(35, 38);
            this.btnConvert.TabIndex = 13;
            this.btnConvert.Text = "Convert shoot";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.87013F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.12987F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.lbSelection, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbEdited, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(364, 24);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(385, 522);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.pbSelection, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 264);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.74509F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.2549F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(185, 255);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // pbSelection
            // 
            this.pbSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSelection.Location = new System.Drawing.Point(3, 3);
            this.pbSelection.Name = "pbSelection";
            this.pbSelection.Size = new System.Drawing.Size(179, 205);
            this.pbSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelection.TabIndex = 0;
            this.pbSelection.TabStop = false;
            this.pbSelection.Click += new System.EventHandler(this.pbSelection_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 214);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(179, 38);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // lbSelection
            // 
            this.lbSelection.AllowDrop = true;
            this.lbSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelection.FormattingEnabled = true;
            this.lbSelection.Location = new System.Drawing.Point(3, 3);
            this.lbSelection.Name = "lbSelection";
            this.lbSelection.Size = new System.Drawing.Size(185, 255);
            this.lbSelection.Sorted = true;
            this.lbSelection.TabIndex = 1;
            this.lbSelection.SelectedIndexChanged += new System.EventHandler(this.lbSelection_SelectedIndexChanged);
            this.lbSelection.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbSelection_DragEnter);
            this.lbSelection.DragOver += new System.Windows.Forms.DragEventHandler(this.lbSelection_DragOver);
            this.lbSelection.DoubleClick += new System.EventHandler(this.lbSelection_DoubleClick);
            this.lbSelection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSelection_KeyDown);
            // 
            // lbEdited
            // 
            this.lbEdited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEdited.FormattingEnabled = true;
            this.lbEdited.Location = new System.Drawing.Point(194, 3);
            this.lbEdited.Name = "lbEdited";
            this.lbEdited.Size = new System.Drawing.Size(188, 255);
            this.lbEdited.Sorted = true;
            this.lbEdited.TabIndex = 2;
            this.lbEdited.SelectedIndexChanged += new System.EventHandler(this.lbEdited_SelectedIndexChanged);
            this.lbEdited.DoubleClick += new System.EventHandler(this.lbEdited_DoubleClick);
            this.lbEdited.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEdited_KeyDown);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.pbEdited, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(194, 264);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.74509F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.2549F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(188, 255);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.92754F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.07246F));
            this.tableLayoutPanel10.Controls.Add(this.radioSingle, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.radioCompare, 1, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 214);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(182, 38);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // radioSingle
            // 
            this.radioSingle.AutoSize = true;
            this.radioSingle.Checked = true;
            this.radioSingle.Location = new System.Drawing.Point(3, 15);
            this.radioSingle.Name = "radioSingle";
            this.radioSingle.Size = new System.Drawing.Size(54, 17);
            this.radioSingle.TabIndex = 1;
            this.radioSingle.TabStop = true;
            this.radioSingle.Text = "Single";
            this.radioSingle.UseVisualStyleBackColor = true;
            // 
            // radioCompare
            // 
            this.radioCompare.AutoSize = true;
            this.radioCompare.Location = new System.Drawing.Point(84, 15);
            this.radioCompare.Name = "radioCompare";
            this.radioCompare.Size = new System.Drawing.Size(67, 17);
            this.radioCompare.TabIndex = 0;
            this.radioCompare.TabStop = true;
            this.radioCompare.Text = "Compare";
            this.radioCompare.UseVisualStyleBackColor = true;
            // 
            // pbEdited
            // 
            this.pbEdited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEdited.Location = new System.Drawing.Point(3, 3);
            this.pbEdited.Name = "pbEdited";
            this.pbEdited.Size = new System.Drawing.Size(182, 205);
            this.pbEdited.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEdited.TabIndex = 1;
            this.pbEdited.TabStop = false;
            this.pbEdited.Click += new System.EventHandler(this.pbEdited_Click);
            // 
            // bgwSelection
            // 
            this.bgwSelection.WorkerReportsProgress = true;
            this.bgwSelection.WorkerSupportsCancellation = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.lbInstagram, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.pbInstagram, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(752, 24);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(200, 522);
            this.tableLayoutPanel11.TabIndex = 5;
            // 
            // lbInstagram
            // 
            this.lbInstagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInstagram.FormattingEnabled = true;
            this.lbInstagram.Location = new System.Drawing.Point(3, 3);
            this.lbInstagram.Name = "lbInstagram";
            this.lbInstagram.Size = new System.Drawing.Size(194, 255);
            this.lbInstagram.TabIndex = 0;
            this.lbInstagram.SelectedIndexChanged += new System.EventHandler(this.lbInstagram_SelectedIndexChanged);
            this.lbInstagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbInstagram_KeyDown);
            // 
            // pbInstagram
            // 
            this.pbInstagram.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbInstagram.Location = new System.Drawing.Point(3, 264);
            this.pbInstagram.Name = "pbInstagram";
            this.pbInstagram.Size = new System.Drawing.Size(194, 208);
            this.pbInstagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInstagram.TabIndex = 2;
            this.pbInstagram.TabStop = false;
            this.pbInstagram.Click += new System.EventHandler(this.pbInstagram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 594);
            this.Controls.Add(this.tableLayoutPanel11);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSelection)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdited)).EndInit();
            this.tableLayoutPanel11.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CircularProgressBar.CircularProgressBar cpProcess;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox lbShoot;
        private System.Windows.Forms.ListBox lbPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ListBox lbSelection;
        private System.Windows.Forms.ListBox lbEdited;
        private System.Windows.Forms.Button btnNewShoot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.RadioButton radioSingle;
        private System.Windows.Forms.RadioButton radioCompare;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.PictureBox pbSelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.PictureBox pbEdited;
        private System.ComponentModel.BackgroundWorker bgwSelection;
        private System.ComponentModel.BackgroundWorker bgwEdited;
        private System.Windows.Forms.ToolStripMenuItem openCurrentDirectoryToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.ListBox lbInstagram;
        private System.Windows.Forms.PictureBox pbInstagram;
    }
}

