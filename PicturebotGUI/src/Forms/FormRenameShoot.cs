using Picturebot.src.Enums;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormRenameShoot : Form
    {
        /// <summary>
        /// Property contains the shootInfo name
        /// </summary>
        public string ShootName { get; set; }
        /// <summary>
        /// Property contains the shootInfo date
        /// </summary>
        public string ShootDate { get; set; }

        /// <summary>
        /// Create a formRenameShoot
        /// This class renames the shoot to a new name
        /// </summary>
        /// <param name="shootInfo">Old shoot information</param>
        public FormRenameShoot(string shootInfo)
        {
            InitializeComponent();

            string[] tokens = shootInfo.Split(' ');

            //Get the shootname <name 12-12-12>
            Regex regex = new Regex(Pattern.Name);

            // Step 2: call Match on Regex instance.
            Match match = regex.Match(shootInfo);

            txtShootname.Text = match.Value;
            DateTime parsedDate = DateTime.ParseExact(tokens[tokens.Length - 1], "dd-MM-yyyy", null);

            dtShoot.Text = parsedDate.ToString();
        }

        #region Buttons
        /// <summary>
        /// The filled in shoot name and date are set to their associated properties
        /// </summary>
        private void pbSave_Click(object sender, EventArgs e)
        {
            ShootName = txtShootname.Text.Trim();
            ShootDate = dtShoot.Text;

            this.Close();
        }
        #endregion Buttons
    }
}
