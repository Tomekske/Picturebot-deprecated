using Newtonsoft.Json;
using Picturebot.src.Enums;
using Picturebot.src.POCO;
using PicturebotGUI.src.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormWorkspace : Form
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        private bool _editing;

        /// <summary>
        /// Create a FormWorkspace
        /// This class creates a new workspace
        /// </summary>
        public FormWorkspace(bool editing)
        {
            InitializeComponent();

            _editing = editing;

            string title = _editing == true ? "Edit workspace" : "Add workspace";

            this.Text = title;

            // Set the workspace textBox to the value within the configuration file
            if (Properties.Settings.Default.RootDirectory != string.Empty)
            {
                txtWorkspace.Text = Properties.Settings.Default.RootDirectory;
            }
        }

        private Config GetConfigObject()
        {
            Config config = new Config();
            config.Workspace = txtWorkspace.Text.Trim();
            config.Backup = txtBackup.Text.Trim();
            config.Editing = txtEditing.Text.Trim();
            config.Base = txtBase.Text.Trim();
            config.Preview = txtPreview.Text.Trim();
            config.Selection = txtSelection.Text.Trim();
            config.Edited = txtEdited.Text.Trim();
            config.Instagram = txtInstagram.Text.Trim();

            config.Workflows = new List<string>(new string[] { config.Backup, config.Editing, config.Base, config.Preview, config.Selection, config.Edited, config.Instagram });

            return config;
        }

        #region Buttons
        /// <summary>
        /// The filled in shoot name and date are set to their associated properties
        /// </summary>
        private void pbSave_Click(object sender, EventArgs e)
        {
            bool isDuplicate = false;

            Config config = GetConfigObject();

            bool isEmpty = config.Workflows.Contains(string.Empty);

            // Check if a list is unique
            bool isUnique = config.Workflows.GroupBy(i => i).Count() == config.Workflows.Count;

            // Only append the Config object when all properties are unique
            if(isUnique && !isEmpty)
            {
                List<Config> workspaces = Picturebot.Configuration.Read();

                if (workspaces != null)
                {
                    foreach (var workspace in workspaces)
                    {
                        // Check if the new workspace is a duplicate
                        if (workspace.Workspace == config.Workspace)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }
                }

                // Make duplicates are not added to the configuration file
                if(!isDuplicate)
                {
                    if (workspaces != null)
                    {
                        workspaces.Add(config);
                        Picturebot.Configuration.Write(workspaces);

                        this.Close();
                    }

                    else
                    {
                        Picturebot.Configuration.Write(new List<Config>(new Config[] { config }));

                        this.Close();
                    }

                    // Create the specified directory when it doesn't exist yet
                    if(!Guard.Filesystem.IsPath(config.Workspace))
                    {
                        try
                        {
                            Directory.CreateDirectory(config.Workspace);
                            _log.Info($"FormWorkspace: Created directory \"{config.Workspace}\"");
                        }
                        catch (DirectoryNotFoundException ex)
                        {
                            _log.Error($"FormWorkspace: Unable to create directory \"{config.Workspace}\"", ex);
                        }

                        catch (IOException ex)
                        {
                            _log.Error($"FormWorkspace: Unable to create directory \"{config.Workspace}\"", ex);
                        }

                        catch (UnauthorizedAccessException ex)
                        {
                            _log.Error($"FormWorkspace: Unable to create directory \"{config.Workspace}\"", ex);
                        }

                        catch (ArgumentNullException ex)
                        {
                            _log.Error($"FormWorkspace: Unable to create directory \"{config.Workspace}\"", ex);
                        }
                    }

                    _log.Info($"FormWorkspace serialized: Added - {config.ToString().Replace("\r\n", string.Empty)}");
                }
                else
                {
                    MessageBox.Show($"Workspace: {config.Workspace} already exists!");
                    _log.Info($"FormWorkspace serialized: workspace already exists - {config.ToString().Replace("\r\n", string.Empty)}");
                }
            }
            else
            {
                _log.Info("FormWorkspace: workflows aren't unique or are empty");
                MessageBox.Show("Workflows aren't unique or are empty");
            }
        }
        #endregion Buttons

        /// <summary>
        /// Select the workspace using the folder broswer dialog
        /// </summary>
        private void pbBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();

            if (Properties.Settings.Default.RootDirectory != string.Empty)
            {
                browser.SelectedPath = Properties.Settings.Default.RootDirectory;
            }

            // Select the directory
            if (browser.ShowDialog() == DialogResult.OK)
            {
                txtWorkspace.Text = browser.SelectedPath;
                Properties.Settings.Default.RootDirectory = browser.SelectedPath;
                Console.WriteLine(browser.SelectedPath);
                Properties.Settings.Default.Save();
                _log.Info($"FormWorkspace: Selected the \"{browser.SelectedPath}\" directory");
            }
        }
    }
}
