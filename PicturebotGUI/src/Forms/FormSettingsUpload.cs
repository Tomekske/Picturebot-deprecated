using Picturebot.src.Enums;
using Picturebot.src.POCO;
using PicturebotGUI.src.Logger;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormSettingsUpload : Form
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// Create a FormSettingsUpload
        /// This saves the URLs to a configuration file
        /// </summary>
        public FormSettingsUpload()
        {
            InitializeComponent();

            // Show the current settings
            if(Properties.Settings.Default.UploadEdited != string.Empty)
            {
                txtFlowEdited.Text = Properties.Settings.Default.UploadEdited;
            }

            if (Properties.Settings.Default.UploadInstagram != string.Empty)
            {
                txtFlowInstagram.Text = Properties.Settings.Default.UploadInstagram;
            }
        }

        #region Buttons
        /// <summary>
        /// This saves the URLs to a configuration file
        /// </summary>
        private void pbSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UploadEdited = txtFlowEdited.Text.Trim();
            Properties.Settings.Default.UploadInstagram = txtFlowInstagram.Text.Trim();

            Properties.Settings.Default.Save();

            _log.Info($"Application config: successfully saved UploadEdit = {Properties.Settings.Default.UploadEdited}");
            _log.Info($"Application config: successfully saved UploadInstagram = {Properties.Settings.Default.UploadInstagram}");

            this.Close();
        }
        #endregion Buttons
    }
}
