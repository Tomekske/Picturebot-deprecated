﻿using Picturebot.src.Enums;
using Picturebot.src.POCO;
using PicturebotGUI.src.Logger;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormWorkspace : Form
    {
        private Config _config;
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// Create a formRenameShoot
        /// This class renames the shoot to a new name
        /// </summary>
        /// <param name="config">Config object</param>
        /// <param name="shootInfo">Old shoot information</param>
        public FormWorkspace()
        {
            InitializeComponent();

            //_config = config;

/*            string[] tokens = shootInfo.Split(' ');

            //Get the shootname <name 12-12-12>
            Regex regex = new Regex(Pattern.Name);

            // Step 2: call Match on Regex instance.
            Match match = regex.Match(shootInfo);

            txtWorkspace.Text = match.Value;
            DateTime parsedDate = DateTime.ParseExact(tokens[tokens.Length - 1], "dd-MM-yyyy", null);

            dtShoot.Text = parsedDate.ToString();*/
        }

        #region Buttons
        /// <summary>
        /// The filled in shoot name and date are set to their associated properties
        /// </summary>
        private void pbSave_Click(object sender, EventArgs e)
        {
/*            ShootName = txtWorkspace.Text.Trim();
            ShootDate = dtShoot.Text;

            string shootInfo = $"{ShootName} {ShootDate}";

            // Get the path to the shoot
            string pathToShoot = Path.Combine(_config.Workspace, shootInfo);

            // Close the current form only when the new shoot name doesn't exists
            if (!Guard.Filesystem.IsPath(pathToShoot))
            {
                this.Close();
            }
            else
            {
                _log.Info($"Shoot: already \"{pathToShoot}\" exists");
                MessageBox.Show($"Shoot: already \"{pathToShoot}\" exists");
            }
*/        }
        #endregion Buttons
    }
}
