namespace PicturebotGUI
{
    partial class FormRenameShoot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRenameShoot));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtShoot = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShootname = new System.Windows.Forms.TextBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.54902F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.45098F));
            this.tableLayoutPanel1.Controls.Add(this.dtShoot, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtShootname, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbSave, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.97802F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.17583F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.3956F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(276, 124);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtShoot
            // 
            this.dtShoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtShoot.CustomFormat = "dd-MM-yyyy";
            this.dtShoot.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtShoot.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShoot.Location = new System.Drawing.Point(65, 30);
            this.dtShoot.Name = "dtShoot";
            this.dtShoot.Size = new System.Drawing.Size(208, 25);
            this.dtShoot.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // txtShootname
            // 
            this.txtShootname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShootname.Location = new System.Drawing.Point(65, 3);
            this.txtShootname.Name = "txtShootname";
            this.txtShootname.Size = new System.Drawing.Size(208, 20);
            this.txtShootname.TabIndex = 2;
            // 
            // pbSave
            // 
            this.pbSave.BackgroundImage = global::PicturebotGUI.Properties.Resources.Save;
            this.pbSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbSave.Location = new System.Drawing.Point(204, 59);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(69, 62);
            this.pbSave.TabIndex = 6;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // FormRenameShoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 124);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(292, 163);
            this.MinimumSize = new System.Drawing.Size(292, 163);
            this.Name = "FormRenameShoot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rename shoot";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShootname;
        private System.Windows.Forms.DateTimePicker dtShoot;
        private System.Windows.Forms.PictureBox pbSave;
    }
}