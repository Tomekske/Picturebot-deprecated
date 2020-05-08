namespace PicturebotGUI
{
    partial class FormReorderWorkspace
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.lbWorkspaces = new PicturebotGUI.ListBoxReorder();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbWorkspaces, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbSave, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 456F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbSave
            // 
            this.pbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSave.BackgroundImage = global::PicturebotGUI.Properties.Resources.Save;
            this.pbSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbSave.Location = new System.Drawing.Point(166, 459);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(95, 48);
            this.pbSave.TabIndex = 2;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // lbWorkspaces
            // 
            this.lbWorkspaces.AllowDrop = true;
            this.lbWorkspaces.AllowItemDrag = true;
            this.lbWorkspaces.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
            this.lbWorkspaces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbWorkspaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWorkspaces.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbWorkspaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbWorkspaces.ForeColor = System.Drawing.Color.White;
            this.lbWorkspaces.FormattingEnabled = true;
            this.lbWorkspaces.ItemHeight = 16;
            this.lbWorkspaces.Location = new System.Drawing.Point(3, 3);
            this.lbWorkspaces.Name = "lbWorkspaces";
            this.lbWorkspaces.Size = new System.Drawing.Size(258, 450);
            this.lbWorkspaces.TabIndex = 5;
            this.lbWorkspaces.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbWorkspaces_DrawItem);
            // 
            // FormReorderWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(264, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormReorderWorkspace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormReorderWorkspace";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ListBoxReorder lbWorkspaces;
        private System.Windows.Forms.PictureBox pbSave;
    }
}