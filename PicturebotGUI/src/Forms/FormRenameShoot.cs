using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PicturebotGUI.src.POCO;
using System.Text.RegularExpressions;

namespace PicturebotGUI
{ 
    public partial class FormRenameShoot : Form
    {
        public string ShootName { get; set; }
        public string ShootDate { get; set; }
        public FormRenameShoot(string shoot)
        {
            InitializeComponent();
            string[] tokens = shoot.Split(' ');

            //Get the shootname <name 12-12-12>
            Regex regex = new Regex(@"(\w+( +\w+)*\s+)");

            // Step 2: call Match on Regex instance.
            Match match = regex.Match(shoot);

            txtShootname.Text = match.Value;
            DateTime parsedDate = DateTime.ParseExact(tokens[tokens.Length - 1], "dd-MM-yyyy", null);

            dtShoot.Text = parsedDate.ToString();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            ShootName = txtShootname.Text.Trim();
            ShootDate = dtShoot.Text;

            this.Close();
        }
    }
}
