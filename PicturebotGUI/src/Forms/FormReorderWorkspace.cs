using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormReorderWorkspace : Form
    {
        private List<Config> _configList;
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// This class lets the user reorder the workspaces order within the configuration file
        /// </summary>
        /// <param name="configList">The current workspaces order within the configuration file</param>
        public FormReorderWorkspace(List<Config> configList)
        {
            InitializeComponent();
            _configList = configList;

            AppendToListBox();
        }

        /// <summary>
        /// Append all the workspaces within the listBox
        /// </summary>
        private void AppendToListBox()
        {
            foreach (var config in _configList)
            {
                lbWorkspaces.Items.Add(config.Workspace);
                _log.Debug($"FormReorderWorkspace: \"{config.Workspace}\" added to listBox");
            }
        }

        /// <summary>
        /// Save the reordered workspaces to the configuration file
        /// </summary>
        private void pbSave_Click(object sender, EventArgs e)
        {
            List<Config> _orderedConfigList = new List<Config>();

            // Map all the current current workspace meta-data and append it to a new ordered configuration list
            foreach (var workspace in lbWorkspaces.Items)
            {
                _orderedConfigList.Add(_configList.First(x => x.Workspace == workspace));
                _log.Debug($"FormReorderWorkspace: added \"{workspace}\" to _orderedConfigList");
            }

            Configuration.Write(_orderedConfigList);

            this.Close();
        }

        /// <summary>
        /// Change the background of the first element within the listBox to indicate the default workspace 
        /// </summary>
        private void lbWorkspaces_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                switch (e.Index)
                {
                    case 0: e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 153, 204)), e.Bounds); break;
                    default: e.DrawBackground(); break;
                }

                using (Brush textBrush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(lbWorkspaces.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Location);
                }
            }
        }
    }
}
