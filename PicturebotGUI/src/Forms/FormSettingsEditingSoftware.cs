using Picturebot.src.Enums;
using Picturebot.src.POCO;
using PicturebotGUI.src.Logger;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormSettingsEditingSoftware : Form
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// Create a FormSettingsEditingSoftware
        /// This saves the editing software paths to a configuration file
        /// </summary>
        public FormSettingsEditingSoftware()
        {
            InitializeComponent();

            // Show the current settings
            if(Properties.Settings.Default.ToolEditing != string.Empty)
            {
                txtSoftwareEditing.Text = Properties.Settings.Default.ToolEditing;
            }

            if (Properties.Settings.Default.ToolProcessing != string.Empty)
            {
                txtSoftwarePostProcessing.Text = Properties.Settings.Default.ToolProcessing;
            }
        }

        #region Buttons
        /// <summary>
        // This saves the editing software paths to a configuration file
        /// </summary>
        private void pbSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ToolEditing = txtSoftwareEditing.Text.Trim();
            Properties.Settings.Default.ToolProcessing = txtSoftwarePostProcessing.Text.Trim();

            Properties.Settings.Default.Save();

            _log.Info($"Application config: successfully saved ToolEditing = {Properties.Settings.Default.ToolEditing}");
            _log.Info($"Application config: successfully saved ToolProcessing = {Properties.Settings.Default.ToolProcessing}");

            this.Close();
        }
        #endregion Buttons
    }
}
