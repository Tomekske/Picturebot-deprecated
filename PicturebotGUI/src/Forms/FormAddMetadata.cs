using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormAddMetadata : Form
    {
        public string Description { get; set; }
        public FormAddMetadata()
        {
            InitializeComponent();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            Description = txtDescription.Text.Trim();

            this.Close();
        }
    }
}
