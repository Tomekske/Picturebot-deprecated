namespace PicturebotGUI
{
    partial class FormShoot
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
            this.btnFinish = new System.Windows.Forms.Button();
            this.lbRaw = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.dtShoot = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bgwBackup = new System.ComponentModel.BackgroundWorker();
            this.bgwConvert = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(444, 285);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lbRaw
            // 
            this.lbRaw.AllowDrop = true;
            this.lbRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRaw.Enabled = false;
            this.lbRaw.FormattingEnabled = true;
            this.lbRaw.Location = new System.Drawing.Point(600, 3);
            this.lbRaw.Name = "lbRaw";
            this.lbRaw.Size = new System.Drawing.Size(191, 346);
            this.lbRaw.Sorted = true;
            this.lbRaw.TabIndex = 1;
            this.lbRaw.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbRaw_DragDrop);
            this.lbRaw.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbRaw_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOutput);
            this.groupBox1.Controls.Add(this.dtShoot);
            this.groupBox1.Controls.Add(this.btnFinish);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblOutput
            // 
            this.lblOutput.Location = new System.Drawing.Point(25, 263);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(341, 27);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "label1";
            // 
            // dtShoot
            // 
            this.dtShoot.CustomFormat = "dd-MM-yyyy";
            this.dtShoot.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShoot.Location = new System.Drawing.Point(61, 46);
            this.dtShoot.Name = "dtShoot";
            this.dtShoot.Size = new System.Drawing.Size(136, 20);
            this.dtShoot.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(25, 52);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.62963F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.37037F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.18892F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.81108F));
            this.tableLayoutPanel2.Controls.Add(this.lbRaw, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 352);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // bgwBackup
            // 
            this.bgwBackup.WorkerReportsProgress = true;
            this.bgwBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBackup_DoWork);
            this.bgwBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwBackup_ProgressChanged);
            this.bgwBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBackup_RunWorkerCompleted);
            // 
            // bgwConvert
            // 
            this.bgwConvert.WorkerReportsProgress = true;
            this.bgwConvert.WorkerSupportsCancellation = true;
            this.bgwConvert.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwConvert_DoWork);
            this.bgwConvert.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwConvert_ProgressChanged);
            this.bgwConvert.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwConvert_RunWorkerCompleted);
            // 
            // FormShoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormShoot";
            this.Text = "FormShoot";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.ListBox lbRaw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.DateTimePicker dtShoot;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.ComponentModel.BackgroundWorker bgwBackup;
        private System.ComponentModel.BackgroundWorker bgwConvert;
    }
}