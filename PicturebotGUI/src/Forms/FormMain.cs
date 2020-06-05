using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Helper;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.GUIThread;
using System.Diagnostics;
using PicturebotGUI.src.Logger;
using Picturebot.src.Helper;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace PicturebotGUI
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Property to access the config object from within every form class
        /// </summary>
        public List<Config> Config { get; set; }
        /// <summary>
        /// Property to access the workspace index from within every form class
        /// </summary>
        public int WsIndex { get; set; }
        /// <summary>
        /// Property to access the Shoot object from within every form class
        /// </summary>
        public Shoot Sht { get; set; }
        /// <summary>
        /// Property to access the flow object from within every form class
        /// </summary>
        public Flow Flw { get; set; }

        private List<Picture> _listPreviewPictures = new List<Picture>();
        private List<Picture> _listSelectionPictures = new List<Picture>();
        private List<Picture> _listEditedPictures = new List<Picture>();
        private List<Picture> _listInstagramPictures = new List<Picture>();

        private string _shoot = string.Empty;

        private bool isFileSaving = false;
        private bool isShootDeleting = false;

        private bool isWatcherCreated = false;
        private bool isWatcherDeleted = false;

        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        public FormMain()
        {
            // Hack to make sure the appearance of the date picker won't change
            Application.EnableVisualStyles();

            InitializeComponent();
            ReadConfigFile();
            GetWorkspaceShoots();

            // Set the current version name within the main form
            this.Text += Properties.Settings.Default.Version;

            // Set the menustrip checks depending on the value within the config file
            if (Properties.Settings.Default.LoggingLevelFileAppender == LoggingLevel.Debug)
            {
                debugToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"debugToolStripMenuItem\"");
            }
            else if (Properties.Settings.Default.LoggingLevelFileAppender == LoggingLevel.Error)
            {
                errorToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"errorToolStripMenuItem\"");
            }

            if(Properties.Settings.Default.DefaultUploadType == FileType.RAW)
            {
                rawToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"rawToolStripMenuItem\"");
            }

            else if (Properties.Settings.Default.DefaultUploadType == FileType.Compressed)
            {
                compressedToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"compressedToolStripMenuItem\"");
            }

            #if DEBUG
                if (Properties.Settings.Default.LoggingLevelConsoleAppender == LoggingLevel.Debug)
                {
                    debugConsoleToolStripMenuItem.Checked = true;
                    _log.Debug("Toolstrip menu: Checked item \"debugToolStripMenuItem\"");
                }
                else if (Properties.Settings.Default.LoggingLevelConsoleAppender == LoggingLevel.Error)
                {
                    errorConsoleToolStripMenuItem.Checked = true;
                    _log.Debug("Toolstrip menu: Checked item \"errorToolStripMenuItem\"");
                }
            #else
            openConfigFileTSMenuItem.Visible = false;
                loggingConsoleToolStripMenuItem.Visible = false;
            #endif
        }

        #region ListBox
        /// <summary>
        /// Retrieve all the shoots within the workspace and append them to the shoot listBox
        /// </summary>
        public void GetWorkspaceShoots()
        {
            if (Config != null)
            {
                ThreadListBox.Clear(lbShoot);
                comboWorkspace.Enabled = true;

                // Get a list of all subdirectories  
                var dirs = Directory.EnumerateDirectories(Config[WsIndex].Workspace);

                // Get the shoot names within the workspace directories and append them to the shoot listBox
                foreach (var dir in dirs)
                {
                    ThreadListBox.AppendItem(lbShoot, dir.Substring(dir.LastIndexOf("\\") + 1));
                    _log.Debug($"ListBox lbShoot: \"{dir.Substring(dir.LastIndexOf("\\") + 1)}\" appended");
                }

                // Display the amount of pictures within the shoot label
                ThreadLabel.SetText(lblShoots, $"Shoots ({dirs.Count()})");
            }

            else
            {
                comboWorkspace.Enabled = false;
            }
        }

        #region LeftClick
        /// <summary>
        /// Click on a shoot within the workspace to list all the pictures within every flow
        /// </summary>
        private void lbShoot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbShoot.Text != string.Empty)
            {
                _shoot = lbShoot.SelectedItem.ToString();
                ClearAndUpdateFlows(_shoot);
                isFileSaving = false;
            }
        }

        /// <summary>
        /// Displays the picture in the pictureBox when clicking on the picture within the preview listBox
        /// </summary>
        private void lbPreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPreview.Text != string.Empty)
            {
                // Get the absolute path to the picture
                string path = _listPreviewPictures[lbPreview.SelectedIndex].Absolute;

                // Check whether the path to the picture exists
                if (Guard.Filesystem.IsPath(path))
                {
                    // Display the picture in the pictureBox
                    pbPreview.ImageLocation = path;

                    _log.Info($"PictureBox pbPreview: \"{path}\" displayed");
                }

                else
                {
                    _log.Error($"PictureBox pbPreview: unable to display \"{path}\"");
                    MessageBox.Show($"PictureBox pbPreview: unable to display \"{path}\"");
                }
            }
        }

        /// <summary>
        /// Displays the picture in the pictureBox when clicking on the picture within the selection listBox
        /// </summary>
        private void lbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSelection.Text != string.Empty)
            {
                // Get the absolute path to the picture
                Picture picture = _listSelectionPictures[lbSelection.SelectedIndex];
                string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Config[WsIndex].Preview, $"{picture.Filename}{Extension.JPG}");

                // Check whether the path to the picture exists
                if (Guard.Filesystem.IsPath(path))
                {
                    // Display the picture in the pictureBox
                    pbSelection.ImageLocation = path;

                    _log.Info($"PictureBox pbSelection: \"{path}\" displayed");
                }

                else
                {
                    _log.Error($"PictureBox pbSelection: unable to display \"{path}\"");
                    MessageBox.Show($"PictureBox pbSelection: unable to display \"{path}\"");
                }
            }
        }

        /// <summary>
        /// Displays the picture in the pictureBox when clicking on the picture within the edited listBox
        /// </summary>
        private void lbEdited_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdited.Text != string.Empty)
            {
                // Get the absolute path to the picture
                string path = _listEditedPictures[lbEdited.SelectedIndex].Absolute;

                // Check whether the path to the picture exists
                if (Guard.Filesystem.IsPath(path))
                {
                    // Display the picture in the pictureBox
                    pbEdited.ImageLocation = path;
                    
                    _log.Info($"PictureBox pbEdited: \"{path}\" displayed");
                }

                else
                {
                    _log.Error($"PictureBox pbEdited: unable to display \"{path}\"");
                    MessageBox.Show($"PictureBox pbEdited: unable to display \"{path}\"");
                }
            }
        }

        /// <summary>
        /// Displays the picture in the pictureBox when clicking on the picture within the instagram listBox
        /// </summary>
        private void lbInstagram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbInstagram.Text != string.Empty)
            {
                string path = _listInstagramPictures[lbInstagram.SelectedIndex].Absolute;

                // Check whether the path to the picture exists
                if (Guard.Filesystem.IsPath(path))
                {
                    // Display the picture in the pictureBox
                    pbInstagram.ImageLocation = path;

                    _log.Info($"PictureBox pbInstagram: \"{path}\" displayed");
                }

                else
                {
                    _log.Error($"PictureBox pbInstagram: unable to display \"{path}\"");
                    MessageBox.Show($"PictureBox pbInstagram: unable to display \"{path}\"");
                }
            }
        }
        #endregion LeftClick

        #region RightClick
        /// <summary>
        /// Right click on the shoot listBox
        /// </summary>
        private void lbShoot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbShoot.Text != string.Empty)
            {
                int countFileSelectionFlow = Helper.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Selection)).Count();

                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();

                var menuExplorer = new ToolStripMenuItem(Strip.Explorer);
                menuExplorer.ShortcutKeyDisplayString = "O";
                menu.Items.Add(menuExplorer);

                // A shoot can only be renamed when the selection folder contains files
                if (countFileSelectionFlow == 0)
                {
                    menu.Items.Add(Strip.RenameBaseflow);
                }

                var menuRenameShoot = new ToolStripMenuItem(Strip.RenameShoot);
                menuRenameShoot.ShortcutKeys = Keys.F2;
                menu.Items.Add(menuRenameShoot);

                var menuItemDelete = new ToolStripMenuItem(Strip.Delete);
                menuItemDelete.ShortcutKeyDisplayString = "Del";
                menu.Items.Add(menuItemDelete);

                menu.Tag = lbShoot.SelectedItem.ToString();

                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbShoot, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_ShootItemRightClicked;
            }
        }

        /// <summary>
        /// Right click on the preview listBox
        /// </summary>
        private void lbPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbPreview.Text != string.Empty)
            {
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();

                var menuItemSelection = new ToolStripMenuItem(Strip.AddSelection);
                menuItemSelection.ShortcutKeyDisplayString = "S";
                menu.Items.Add(menuItemSelection);

                var menuItemDelete = new ToolStripMenuItem(Strip.Delete);
                menuItemDelete.ShortcutKeyDisplayString = "Del";
                menu.Items.Add(menuItemDelete);

                menu.Tag = _listPreviewPictures[lbPreview.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbPreview, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_PreviewItemRightClicked;
            }
        }

        /// <summary>
        /// Right click on the selection listBox
        /// </summary>
        private void lbSelection_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbSelection.Text != string.Empty)
            {
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add($"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolEditing)}");

                var menuItemLuminar = new ToolStripMenuItem($"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolProcessing)}");
                menuItemLuminar.ShortcutKeyDisplayString = "L";
                menu.Items.Add(menuItemLuminar);

                var menuItemDelete = new ToolStripMenuItem(Strip.Delete);
                menuItemDelete.ShortcutKeyDisplayString = "Del";
                menu.Items.Add(menuItemDelete);

                menu.Tag = _listSelectionPictures[lbSelection.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbSelection, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_SelectionItemRightClicked;
            }
        }

        /// <summary>
        /// Right click on the edited listBox
        /// </summary>
        private void lbEdited_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbEdited.Text != string.Empty)
            {
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add($"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolEditing)}");

                var menuItemLuminar = new ToolStripMenuItem($"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolProcessing)}");
                menuItemLuminar.ShortcutKeyDisplayString = "L";
                menu.Items.Add(menuItemLuminar);

                var menuItemUpload = new ToolStripMenuItem(Strip.Upload);
                menuItemUpload.ShortcutKeyDisplayString = "U";
                menu.Items.Add(menuItemUpload);

                var menuItemDelete = new ToolStripMenuItem(Strip.Delete);
                menuItemDelete.ShortcutKeyDisplayString = "Del";
                menu.Items.Add(menuItemDelete);

                menu.Tag = _listEditedPictures[lbEdited.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbEdited, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_EditedItemRightClicked;
            }
        }

        /// <summary>
        /// Right click on the Instagram listBox
        /// </summary>
        private void lbInstagram_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbInstagram.Text != string.Empty)
            {
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();

                var menuItemUpload = new ToolStripMenuItem(Strip.Upload);
                menuItemUpload.ShortcutKeyDisplayString = "U";
                menu.Items.Add(menuItemUpload);

                var menuItemDelete = new ToolStripMenuItem(Strip.Delete);
                menuItemDelete.ShortcutKeyDisplayString = "Del";
                menu.Items.Add(menuItemDelete);

                menu.Tag = _listInstagramPictures[lbInstagram.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbInstagram, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_InstagramItemRightClicked;
            }
        }
        #endregion RightClick

        #region DoubleClick
        /// <summary>
        /// Double click to edit a RAW picture
        /// </summary>
        private void lbSelection_DoubleClick(object sender, EventArgs e)
        {
            if(lbSelection.Text != string.Empty)
            {
                Picture picture = new Picture(_listSelectionPictures[lbSelection.SelectedIndex].Absolute);

                if(Guard.Filesystem.IsPath(picture.Absolute))
                {
                    src.Command.General.Program(Properties.Settings.Default.ToolEditing, picture.Absolute);
                }

                else
                {
                    _log.Error($"ListBox _lstSelection: unable to open \"{picture.Absolute}\" file");
                    MessageBox.Show($"ListBox _lstSelection: unable to open \"{picture.Absolute}\" file");
                }
            }
        }

        /// <summary>
        /// Double click to edit an edited picture
        /// </summary>
        private void lbEdited_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture(_listEditedPictures[lbEdited.SelectedIndex].Absolute);

            if (lbEdited.Text != string.Empty)
            {
                // Get the path to the affinity file within the editing flow
                string path = Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Editing); //, $"{lbEdited.Text}{Extension.AFPHOTO}");

                // Obtain just the RAW picture within the base flow
                string selectedRawPicture = new Picture(Directory.GetFiles(path, $"{picture.Filename}.*")[0]).Absolute;

                // Only open the affinity file when it's exists within the editing flow
                if (File.Exists(selectedRawPicture))
                {
                    isWatcherCreated = true;
                    src.Command.General.Program(Properties.Settings.Default.ToolEditing, selectedRawPicture);
                }

                else
                {
                    _log.Info($"{lbEdited.Text} doesn't have a editing file");
                    MessageBox.Show($"{lbEdited.Text} doesn't have a editing file");
                }
            }
        }
        #endregion DoubleClick

        #region KeyEnter
        /// <summary>
        /// Hotkeys to control the shoot listbBox menu items
        /// </summary>
        private void lbShoot_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string path = Path.Combine(Config[WsIndex].Workspace, _shoot);

                // Make sure it's not possible to perform keyboard actions when the listBox is empty
                if (lbShoot.Items.Count != 0)
                {
                    if (e.KeyCode == Keys.O)
                    {
                        lbShoot.SelectedItem = _shoot;
                        src.Command.General.Explorer(Config[WsIndex], _shoot);
                        e.SuppressKeyPress = true;
                    }

                    else if (e.KeyCode == Keys.Delete)
                    {
                        isWatcherDeleted = true;
                        isShootDeleting = true;
                        src.Command.General.DeleteShoot(path, Sht);
                    }

                    else if (e.KeyCode == Keys.F2)
                    {
                        _shoot = src.Command.General.RenameShoot(Config[WsIndex], Sht, _shoot);

                        // Only refresh the workspace when a shoot was renamed
                        if (_shoot != string.Empty)
                        {
                            GetWorkspaceShoots();
                            lbShoot.SelectedItem = _shoot;
                            ClearAndUpdateFlows(_shoot);
                        }
                    }
                }
            }

            catch (NullReferenceException ex)
            {
                _log.Info("Unable to browse through shoots, because there are no workspaces added to the project", ex);
            }

            catch  (ArgumentOutOfRangeException ex)
            {
                _log.Info("Unable to browse through shoots, because there are no workspaces added to the project", ex);
            }
        }

        /// <summary>
        /// Hotkeys to control the preview listbBox menu items
        /// </summary>
        private void lbPreview_KeyDown(object sender, KeyEventArgs e)
        {
            // Make sure it's not possible to perform keyboard actions when the listBox is empty
            if (lbPreview.Items.Count != 0)
            {
                Picture picture = new Picture(_listPreviewPictures[lbPreview.SelectedIndex].Absolute);

                if (e.KeyCode == Keys.Delete)
                {
                    isWatcherDeleted = true;
                    src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbPreview, Flw, Config[WsIndex].Base, true);
                }

                else if (e.KeyCode == Keys.O)
                {
                    e.SuppressKeyPress = true;
                    src.Command.General.Explorer(Config[WsIndex], _shoot);
                }

                else if (e.KeyCode == Keys.S)
                {
                    e.SuppressKeyPress = true;
                    isWatcherCreated = true;
                    src.Command.General.Selection(Config[WsIndex], picture);
                }

                else if(e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        FormPreview f = new FormPreview(Config[WsIndex], _listPreviewPictures, lbPreview.SelectedIndex);
                        _log.Info($"PictureBox pbPreview: opened \"{pbPreview.ImageLocation}\"");

                        f.Show();
                    }
                    catch (Exception ex)
                    {
                        _log.Error($"PictureBox pbPreview: unable to open \"{pbPreview.ImageLocation}\"", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Hotkeys to control the selection listbBox menu items
        /// </summary>
        private void lbSelection_KeyDown(object sender, KeyEventArgs e)
        {
            // Make sure it's not possible to perform keyboard actions when the listBox is empty
            if (lbSelection.Items.Count != 0)
            {
                Picture picture = new Picture(_listSelectionPictures[lbSelection.SelectedIndex].Absolute);

                if (e.KeyCode == Keys.Delete)
                {
                    isWatcherDeleted = true;
                    src.Command.General.DeletePicture(picture, pbSelection, Flw);
                }

                else if (e.KeyCode == Keys.O)
                {
                    src.Command.General.Explorer(Config[WsIndex], _shoot);
                }

                else if (e.KeyCode == Keys.L)
                {
                    isWatcherCreated = true;
                    src.Command.General.Program(Properties.Settings.Default.ToolProcessing, picture.Absolute);
                }

                else if(e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        // Create a temporary list where the path is converted to a preview flow because the pictures within a selection flow contain a RAW file format
                        List<Picture> list = new List<Picture>();

                        for (int i = 0; i < _listSelectionPictures.Count; i++)
                        {
                            string path = Path.Combine(Config[WsIndex].Workspace, _listSelectionPictures[i].ShootInfo, Config[WsIndex].Preview, $"{_listSelectionPictures[i].Filename}.jpg");
                            list.Add(new Picture(path));
                        }

                        FormPreview f = new FormPreview(Config[WsIndex], list, lbSelection.SelectedIndex);
                        f.Show();
                    }
                    catch (Exception ex)
                    {
                        _log.Error($"PictureBox pbSelection: unable to open \"{pbSelection.ImageLocation}\"", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Hotkeys to control the edited listbBox menu items
        /// </summary>
        private void lbEdited_KeyDown(object sender, KeyEventArgs e)
        {
            // Make sure it's not possible to perform keyboard actions when the listBox is empty
            if (lbEdited.Items.Count != 0)
            {
                Picture picture = new Picture(_listEditedPictures[lbEdited.SelectedIndex].Absolute);

                if (e.KeyCode == Keys.Delete)
                {
                    isWatcherDeleted = true;
                    src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbEdited, Flw, Config[WsIndex].Edited, false, true);
                }

                else if (e.KeyCode == Keys.O)
                {
                    e.SuppressKeyPress = true;
                    src.Command.General.Explorer(Config[WsIndex], _shoot);
                }

                else if (e.KeyCode == Keys.L)
                {
                    e.SuppressKeyPress = true;
                    isWatcherCreated = true;
                    src.Command.General.Program(Properties.Settings.Default.ToolProcessing, picture.Absolute);
                }

                else if (e.KeyCode == Keys.U)
                {
                    src.Command.General.Upload(Config[WsIndex], _shoot, lbEdited.Text, Config[WsIndex].Edited, Properties.Settings.Default.UploadEdited);
                }

                else if(e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        FormPreview f = new FormPreview(Config[WsIndex], _listEditedPictures, lbEdited.SelectedIndex);
                        _log.Info($"PictureBox pbEdited: opened \"{pbEdited.ImageLocation}\"");

                        f.Show();
                    }
                    catch (Exception ex)
                    {
                        _log.Error($"PictureBox pbEdited: unable to open \"{pbEdited.ImageLocation}\"", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Hotkeys to control the instagram listbBox menu items
        /// </summary>
        private void lbInstagram_KeyDown(object sender, KeyEventArgs e)
        {
            // Make sure it's not possible to perform keyboard actions when the listBox is empty
            if (lbInstagram.Items.Count != 0)
            {
                Picture picture = new Picture(_listInstagramPictures[lbInstagram.SelectedIndex].Absolute);

                if (e.KeyCode == Keys.Delete)
                {
                    isWatcherDeleted = true;
                    //src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbInstagram, Flw, Config[WsIndex].Instagram, Extension.JPG);
                    src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbInstagram, Flw, Config[WsIndex].Instagram);
                }

                else if (e.KeyCode == Keys.O)
                {
                    e.SuppressKeyPress = true;
                    src.Command.General.Explorer(Config[WsIndex], _shoot);
                }

                else if (e.KeyCode == Keys.U)
                {
                    src.Command.General.Upload(Config[WsIndex], _shoot, lbInstagram.Text, Config[WsIndex].Instagram, Properties.Settings.Default.UploadInstagram);
                }

                else if(e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        FormPreview f = new FormPreview(Config[WsIndex], _listInstagramPictures, lbInstagram.SelectedIndex);
                        _log.Info($"PictureBox pbInstagram: opened \"{pbInstagram.ImageLocation}\"");

                        f.Show();
                    }
                    catch (Exception ex)
                    {
                        _log.Error($"PictureBox pbInstagram: unable to open \"{pbInstagram.ImageLocation}\"", ex);
                    }
                }
            }
        }
        #endregion KeyEnter
        #endregion ListBox

        #region ConfigFile
        /// <summary>
        /// Load the data from the configuration file within the config object
        /// And set the comboBox's value to the first workspace within the configuration file
        /// </summary>
        private void ReadConfigFile()
        {
            Config = new List<Config>();

            // Read the configuration file
            Config = Configuration.Read();

            if (Config != null)
            {
                _log.Info("Config file: successfully populated the config object");

                //Loop over every workspace within the configuration file
                foreach (var c in Config)
                {
                    // Append every workspace to the combobox, this way the user can switch between workspaces
                    comboWorkspace.Items.Add(c.Workspace);
                    _log.Info($"ComboBox comboWorkspace: \"{c.Workspace}\" added");
                }

                // The default workspace is always the zero-th index
                comboWorkspace.SelectedIndex = 0;
                // The workspace index is determined by the default value of the selected index of the combobox(index=0)
                WsIndex = comboWorkspace.SelectedIndex;
            }
        }
        #endregion ConfigFile

        #region ComboBox
        /// <summary>
        /// Select the active workspace
        /// </summary>
        private void comboWorkspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Config != null)
            {
                // Get the selected index
                WsIndex = comboWorkspace.SelectedIndex;

                Sht = new Shoot(Config[WsIndex]);
                Flw = new Flow(Config[WsIndex]);

                if(Guard.Filesystem.IsPath(Config[WsIndex].Workspace))
                {
                    // Setup a file system watcher
                    FileSystemWatcher watcher = new FileSystemWatcher(Config[WsIndex].Workspace);
                    watcher.EnableRaisingEvents = true;
                    watcher.IncludeSubdirectories = true;

                    // Create even handlers
                    watcher.Created += Watcher_Created;
                    watcher.Deleted += Watcher_Deleted;

                    GetWorkspaceShoots();
                    ClearPictureBoxesAndListBoxesAndLabels();

                    _log.Info($"Workspace: {Config[WsIndex].Workspace} has successfully loaded shoots");
                }

                else
                {
                    ThreadListBox.Clear(lbShoot);
                    ClearPictureBoxesAndListBoxesAndLabels();

                    MessageBox.Show($"Workspace: {Config[WsIndex].Workspace} does not exists - unable to load shoots");
                    _log.Info($"Workspace: {Config[WsIndex].Workspace} does not exists - unable to load shoots");
                }
            }
        }
        #endregion ComboBox

        #region ToolStrip
        /// <summary>
        /// Open the current workspace in the window explorer
        /// </summary>
        private void openWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                src.Command.GUI.Explorer(Config[WsIndex].Workspace);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Unable to open workspace explorer because there are no workspaces added to the project");
                _log.Info("Unable to open workspace explorer because there are no workspaces added to the project", ex);
            }
        }

        /// <summary>
        /// Open the log file
        /// </summary>
        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the relative path to the log file
            string relativePath = "logger.log";

            if (Guard.Filesystem.IsPath(relativePath))
            {
                // Get the absolute path to the logging file
                string absolutePath = Path.GetFullPath(relativePath);

                if (Guard.Filesystem.IsPath(relativePath))
                {
                    Process.Start(absolutePath);
                    _log.Info($"Log file: \"{absolutePath}\" found");
                }
                else
                {
                    _log.Error($"Log file: \"{absolutePath}\" absolute path not found");
                    MessageBox.Show($"Log file: \"{absolutePath}\" absolute path not found");
                }
            }

            else
            {
                _log.Error($"Log file: \"{relativePath}\" relative path not found");
                MessageBox.Show($"Log file: \"{relativePath}\" relative path not found");
            }
        }

        /// <summary>
        /// Configure the upload settings to the cloud
        /// </summary>
        private void uploadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettingsUpload form = new FormSettingsUpload();
            form.ShowDialog();
        }

        /// <summary>
        /// Delete a workspace within the configuration file
        /// </summary>
         private void deleteWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
         {
            // Only delete a workspace when a configuration file exists
            if (Config != null)
            {
                var result = MessageBox.Show($"Are you sure to delete the \"{Config[WsIndex].Workspace}\" workspace ?", "Confirm Deletion!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Configuration.Delete(Config, WsIndex);
                    
                    // When there are no workspaces left after deleting a workspace form the configuration file then restore the default values
                    if (Config.Count == 0)
                    {
                        comboWorkspace.Items.Clear();
                        comboWorkspace.ResetText();
                        comboWorkspace.Enabled = false;
                        lbShoot.Items.Clear();
                        ClearPictureBoxesAndListBoxesAndLabelsEverything();
                    }
                    else
                    {
                        comboWorkspace.Items.Clear();
                        ReadConfigFile();

                        GetWorkspaceShoots();
                    }
                }
            }

            else
            {
                MessageBox.Show("There is no workspace to delete");
                _log.Info("Workspace: There is no workspace to delete");
            }
        }

        /// <summary>
        /// Edit a workspace within the configuration file
        /// </summary>
        private void editWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Config != null)
            {
                FormWorkspace form = new FormWorkspace(true, WsIndex);
                form.ShowDialog();

                comboWorkspace.Items.Clear();
                ReadConfigFile();
                GetWorkspaceShoots();
            }

            else
            {
                MessageBox.Show("There is no workspace to edit");
                _log.Info("Workspace: There is no workspace to edit");
            }
        }
        #endregion ToolStrip

        #region PictureBoxes
        #region ClearPictureBoxes
        /// <summary>
        /// Clear all the picturesBoxes and display the background image
        /// Clear all listBoxes and labels as well
        /// </summary>
        private void ClearPictureBoxesAndListBoxesAndLabels()
        {
            // Set pictureBox to the default settings
            ThreadPictureBox.Clear(pbPreview);
            ThreadPictureBox.Clear(pbSelection);
            ThreadPictureBox.Clear(pbEdited);
            ThreadPictureBox.Clear(pbInstagram);

            // Set listBox to the default settings
            ThreadListBox.Clear(lbPreview);
            ThreadListBox.Clear(lbSelection);
            ThreadListBox.Clear(lbEdited);
            ThreadListBox.Clear(lbInstagram);

            // Set labels to the default settings
            ThreadLabel.SetText(lblPreview, Config[WsIndex].Preview);
            ThreadLabel.SetText(lblSelection, Config[WsIndex].Selection);
            ThreadLabel.SetText(lblEdited, Config[WsIndex].Edited);
            ThreadLabel.SetText(lblInstagram, Config[WsIndex].Instagram);
        }

        /// <summary>
        /// Restore the default values for the 
        /// </summary>
        private void ClearPictureBoxesAndListBoxesAndLabelsEverything()
        {
            // Set pictureBox to the default settings
            ThreadPictureBox.Clear(pbPreview);
            ThreadPictureBox.Clear(pbSelection);
            ThreadPictureBox.Clear(pbEdited);
            ThreadPictureBox.Clear(pbInstagram);

            // Set listBox to the default settings
            ThreadListBox.Clear(lbShoot);
            ThreadListBox.Clear(lbPreview);
            ThreadListBox.Clear(lbSelection);
            ThreadListBox.Clear(lbEdited);
            ThreadListBox.Clear(lbInstagram);

            // Set labels to their default settings
            ThreadLabel.SetText(lblShoots, "Shoots");
            ThreadLabel.SetText(lblPreview, string.Empty);
            ThreadLabel.SetText(lblSelection, string.Empty);
            ThreadLabel.SetText(lblEdited, string.Empty);
            ThreadLabel.SetText(lblInstagram, string.Empty);
        }

        /// <summary>
        /// Get pictures from the work flow and add them to the associated listBox and display the amount of pictures within the listBoxes
        /// </summary>
        public void ClearAndUpdateFlows(string path)
        {
            int counter = 0;

            // Get pictures from the work flow and add them to the associated listBox 
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbPreview, pbPreview, _listPreviewPictures, _shoot, Config[WsIndex].Preview);
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbSelection, pbSelection, _listSelectionPictures, _shoot, Config[WsIndex].Selection);
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbEdited, pbEdited, _listEditedPictures, _shoot, Config[WsIndex].Edited);
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbInstagram, pbInstagram, _listInstagramPictures, _shoot, Config[WsIndex].Instagram);

            // Display the amount of pictures within the associated flow labels
            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Preview)).Length;
            ThreadLabel.SetText(lblPreview, $"{Config[WsIndex].Preview} ({counter})");

            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Selection)).Length;
            ThreadLabel.SetText(lblSelection, $"{Config[WsIndex].Selection} ({counter})");

            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Edited)).Length;
            ThreadLabel.SetText(lblEdited, $"{Config[WsIndex].Edited} ({counter})");

            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Instagram)).Length;
            ThreadLabel.SetText(lblInstagram, $"{Config[WsIndex].Instagram} ({counter})");

            _log.Info($"Cleared and updated flows: \"{path}\"");
        }

        /// <summary>
        /// Update the associated work flow
        /// </summary>
        /// <param name="listBox">The associated listBox</param>
        /// <param name="pictureBox">The associated pictureBox</param>
        /// <param name="label">The associated label</param>
        /// <param name="list">The associated list containing the pictures</param>
        /// <param name="workflow">The associated listBox</param>
        /// <param name="title">The associated flow name of the label</param>
        /// <param name="path">The flow that has been updated</param>
        public void ClearAndUpdateFlow(ListBox listBox, PictureBox pictureBox, Label label, List<Picture> list, string workflow, string title, string path)
        {
            int counter = 0;

            // Get pictures from the work flow and add them to the associated listBox 
            Clear.ClearAndUpdateFlow(Config[WsIndex], listBox, pictureBox, list, _shoot, workflow);

            // Display the amount of pictures within the associated flow labels
            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, workflow)).Length;
            ThreadLabel.SetText(label, $"{title} ({counter})");

            _log.Info($"Cleared and updated flow: \"{workflow}\" - \"{path}\"");
        }
        #endregion ClearPictureBoxes
        #endregion PictureBoxes

        #region MenuStrip
        /// <summary>
        /// Shoot listBox's menu strip
        /// </summary>
        private void Menu_ShootItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            string shoot = (sender as ContextMenuStrip).Tag.ToString();

            string path = Path.Combine(Config[WsIndex].Workspace, shoot);

            Flow flow = new Flow(Config[WsIndex]);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                isWatcherDeleted = true;
                isShootDeleting = true;
                src.Command.General.DeleteShoot(path, Sht);
            }

            else if (e.ClickedItem.Text == Strip.RenameBaseflow)
            {
                flow.Rename(path, true, true);

                ClearAndUpdateFlow(lbPreview, pbPreview, lblPreview, _listPreviewPictures, Config[WsIndex].Preview, Config[WsIndex].Preview, path);
            }

            else if(e.ClickedItem.Text == Strip.RenameShoot)
            {
                _shoot = src.Command.General.RenameShoot(Config[WsIndex], Sht, _shoot);

                // Only refresh the workspace when a shoot was renamed
                if (_shoot != string.Empty)
                {
                    GetWorkspaceShoots();
                    lbShoot.SelectedItem = _shoot;
                    ClearAndUpdateFlows(_shoot);
                }
            }

            else if (e.ClickedItem.Text == Strip.Explorer)
            {
                src.Command.General.Explorer(Config[WsIndex], _shoot);
            }
        }

        /// <summary>
        /// Preview listBox's menu strip
        /// </summary>
        private void Menu_PreviewItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;

            if (e.ClickedItem.Text == Strip.Delete)
            {
                isWatcherDeleted = true;
                isShootDeleting = false;
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbPreview, Flw, Config[WsIndex].Base, true);
            }

            else if (e.ClickedItem.Text == Strip.AddSelection)
            {
                isWatcherCreated = true;
                src.Command.General.Selection(Config[WsIndex], picture);
            }
        }

        /// <summary>
        /// Selection listBox's menu strip
        /// </summary>
        private void Menu_SelectionItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;

            if (e.ClickedItem.Text == Strip.Delete)
            {
                isWatcherDeleted = true;
                isShootDeleting = false;
                src.Command.General.DeletePicture(picture, pbSelection, Flw);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolEditing)}")
            {
                src.Command.General.Program(Properties.Settings.Default.ToolEditing, picture.Absolute);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolProcessing)}")
            {
                isWatcherCreated = true;
                src.Command.General.Program(Properties.Settings.Default.ToolProcessing, picture.Absolute);
            }
        }

        /// <summary>
        /// Edited listBox's menu strip
        /// </summary>
        private void Menu_EditedItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;

            if (e.ClickedItem.Text == Strip.Delete)
            {
                isWatcherDeleted = true;
                isShootDeleting = false;
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbEdited, Flw, Config[WsIndex].Edited, false, true);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolProcessing)}")
            {
                isWatcherCreated = true;
                src.Command.General.Program(Properties.Settings.Default.ToolProcessing, picture.Absolute);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(Properties.Settings.Default.ToolEditing)}")
            {
                string pathToAffinity = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Config[WsIndex].Editing, $"{picture.Filename}{Extension.AFPHOTO}");

                if (File.Exists(pathToAffinity))
                {
                    src.Command.General.Program(Properties.Settings.Default.ToolEditing, pathToAffinity);
                }

                else
                {
                    MessageBox.Show($"{lbEdited.Text} doesn't have a editing file.");
                }
            }

            else if(e.ClickedItem.Text == Strip.Upload)
            {
                src.Command.General.Upload(Config[WsIndex], _shoot, lbEdited.Text, Config[WsIndex].Edited, Properties.Settings.Default.UploadEdited);
            }
        }

        /// <summary>
        /// Instagram listBox's menu strip
        /// </summary>
        private void Menu_InstagramItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;

            if (e.ClickedItem.Text == Strip.Delete)
            {
                isWatcherDeleted = true;
                isShootDeleting = false;
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbInstagram, Flw, Config[WsIndex].Instagram);
            }

            else if (e.ClickedItem.Text == Strip.Upload)
            {
                src.Command.General.Upload(Config[WsIndex], _shoot, lbInstagram.Text, Config[WsIndex].Instagram, Properties.Settings.Default.UploadInstagram);
            }
        }

        /// <summary>
        /// Select the debug logging level of the file appender
        /// </summary>
        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorToolStripMenuItem.Checked = false;

            if(!debugToolStripMenuItem.Checked)
            {
                debugToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"debugToolStripMenuItem\"");
                Properties.Settings.Default.LoggingLevelFileAppender = LoggingLevel.Debug;
                _log.Info("Toolstrip menu: Saved \"debugToolStripMenuItem\" in config file");
                Properties.Settings.Default.Save();
                XmlConfig.UpdateAttributesXML(Appender.File, LoggingLevel.Debug);
            }
        }

        /// <summary>
        /// Select the error logging level of the file appender
        /// </summary>
        private void errorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debugToolStripMenuItem.Checked = false;

            if (!errorToolStripMenuItem.Checked)
            {
                errorToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"errorToolStripMenuItem\"");
                Properties.Settings.Default.LoggingLevelFileAppender = LoggingLevel.Error;
                _log.Info("Toolstrip menu: Saved \"errorToolStripMenuItem\" in config file");
                Properties.Settings.Default.Save();
                XmlConfig.UpdateAttributesXML(Appender.File, LoggingLevel.Error);
            }
        }

        /// <summary>
        /// Select the debug logging level of the console appender
        /// </summary>
        private void debugConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorConsoleToolStripMenuItem.Checked = false;

            if (!debugConsoleToolStripMenuItem.Checked)
            {
                debugConsoleToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"debugConsoleToolStripMenuItem\"");
                Properties.Settings.Default.LoggingLevelConsoleAppender = LoggingLevel.Debug;
                _log.Info("Toolstrip menu: Saved \"debugConsoleToolStripMenuItem\" in config file");
                Properties.Settings.Default.Save();
                XmlConfig.UpdateAttributesXML(Appender.Console, LoggingLevel.Debug);
            }
        }

        /// <summary>
        /// Select the error logging level of the console appender
        /// </summary>
        private void errorConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debugConsoleToolStripMenuItem.Checked = false;

            if (!errorConsoleToolStripMenuItem.Checked)
            {
                errorConsoleToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"errorConsoleToolStripMenuItem\"");
                Properties.Settings.Default.LoggingLevelConsoleAppender = LoggingLevel.Error;
                _log.Info("Toolstrip menu: Saved \"errorConsoleToolStripMenuItem\" in config file");
                Properties.Settings.Default.Save();
                XmlConfig.UpdateAttributesXML(Appender.Console, LoggingLevel.Error);
            }
        }

        /// <summary>
        /// Add a new workspace to the configuration file
        /// </summary>
        private void addWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWorkspace form = new FormWorkspace(false, WsIndex);
            form.ShowDialog();
            comboWorkspace.Items.Clear();
            ReadConfigFile();
            GetWorkspaceShoots();
        }

        /// <summary>
        /// Open the configuration file within the default editor
        /// </summary>
        private void openConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "config.json";

            if(Guard.Filesystem.IsPath(path))
            {
                src.Command.GUI.OpenFile(path);
            }
            else
            {
                MessageBox.Show($"\"{path}\" does not exist");
            }
        }

        /// <summary>
        /// Reorder the workspace order
        /// </summary>
        private void reorderWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Only reorder files when there is at least one workspace within the configuration file
            if(comboWorkspace.Items.Count != 0)
            {
                FormReorderWorkspace form = new FormReorderWorkspace(Config);
                form.ShowDialog();

                comboWorkspace.Items.Clear();
                ReadConfigFile();
                GetWorkspaceShoots();
            }

            else
            {
                MessageBox.Show("There are no shoots to reorder, add a new shoot");
                _log.Info("There are no shoots to reorder, add a new shoot");
            }
        }
        
        /// <summary>
        /// Select the RAW upload file type as the default setting
        /// </summary>
        private void rawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compressedToolStripMenuItem.Checked = false;

            if (!rawToolStripMenuItem.Checked)
            {
                rawToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"rawToolStripMenuItem\"");
                Properties.Settings.Default.DefaultUploadType = FileType.RAW;
                _log.Info("Toolstrip menu: Saved \"rawToolStripMenuItem\" in config file");
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Select the compressed upload file type as the default setting
        /// </summary>
        private void compressedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rawToolStripMenuItem.Checked = false;

            if (!compressedToolStripMenuItem.Checked)
            {
                compressedToolStripMenuItem.Checked = true;
                _log.Debug("Toolstrip menu: Checked item \"compressedToolStripMenuItem\"");
                Properties.Settings.Default.DefaultUploadType = FileType.Compressed;
                _log.Info("Toolstrip menu: Saved \"compressedToolStripMenuItem\" in config file");
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Open the configuration file within the default editor
        /// </summary>
        private void edtingToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettingsEditingSoftware form = new FormSettingsEditingSoftware();
            form.Show();
        }
        #endregion MenuStrip

        #region Watcher
        /// <summary>
        /// Update the ListBoxe's when a file within the directory is renamed
        /// </summary>
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            _log.Debug($"Watcher renamed: \"{e.FullPath}\"");

            if (!e.FullPath.Contains("jpg_exiftool_tmp") && !e.FullPath.Contains(Config[WsIndex].Base) && !e.FullPath.Contains(Config[WsIndex].Backup) && !e.FullPath.Contains(Config[WsIndex].Preview) && e.FullPath == Path.Combine(Config[WsIndex].Workspace, _shoot) && !isFileSaving)
            {
                ClearAndUpdateFlows(e.FullPath);
            }
        }

        /// <summary>
        /// Update the ListBoxe's when a file within the directory is created
        /// </summary>
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            _log.Debug($"Watcher Created: \"{e.FullPath}\"");

            if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Preview)) && isWatcherCreated)
            {
                ClearAndUpdateFlow(lbPreview, pbPreview, lblPreview, _listPreviewPictures, Config[WsIndex].Preview, Config[WsIndex].Preview, e.FullPath);
                isFileSaving = true;
                isWatcherCreated = false;
            }

            else if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Selection)) && isWatcherCreated)
            {
                ClearAndUpdateFlow(lbSelection, pbSelection, lblSelection, _listSelectionPictures, Config[WsIndex].Selection, Config[WsIndex].Selection, e.FullPath);
                isFileSaving = true;
                isWatcherCreated = false;
            }

            else if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Edited)))
            {
                ClearAndUpdateFlow(lbEdited, pbEdited, lblEdited, _listEditedPictures, Config[WsIndex].Edited, Config[WsIndex].Edited, e.FullPath);
            }

            else if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Instagram)) && isWatcherCreated)
            {
                ClearAndUpdateFlow(lbInstagram, pbInstagram, lblInstagram, _listInstagramPictures, Config[WsIndex].Instagram, Config[WsIndex].Instagram, e.FullPath);
                isFileSaving = true;
                isWatcherCreated = false;
            }
        }

        /// <summary>
        /// Update the ListBoxe's when a file within the directory is deleted
        /// </summary>
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (isWatcherDeleted)
            {
                // Check whether the shoot directory is getting deleted
                if (isShootDeleting)
                {
                    string pathShoot = Path.Combine(Config[WsIndex].Workspace, _shoot);
                    
                    _log.Debug($"Watcher deleted shoot: \"{e.FullPath}\"");

                    if (e.FullPath == pathShoot)
                    {
                        int indexBefore = ThreadListBox.SelectedIndex(lbShoot);

                        GetWorkspaceShoots();
                        ClearPictureBoxesAndListBoxesAndLabels();
                        int countItems = lbShoot.Items.Count;
                        ThreadListBox.SetSelectedIndex(lbShoot, Methods.CalcListBoxIndex(indexBefore, countItems));

                        isShootDeleting = false;
                        isWatcherDeleted = false;
                    }
                }

                else
                {
                    _log.Debug($"Watcher deleted flow: \"{e.FullPath}\"");

                    // Check whether a picture within the preview flow is deleted
                    if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Preview)))
                    {
                        int indexBefore = ThreadListBox.SelectedIndex(lbPreview);
                        ClearAndUpdateFlow(lbPreview, pbPreview, lblPreview, _listPreviewPictures, Config[WsIndex].Preview, Config[WsIndex].Preview, e.FullPath);
                        int countItems = lbPreview.Items.Count;
                        ThreadListBox.SetSelectedIndex(lbPreview, Methods.CalcListBoxIndex(indexBefore, countItems));
                    }

                    else if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Selection)))
                    {
                        int indexBefore = ThreadListBox.SelectedIndex(lbSelection);
                        ClearAndUpdateFlow(lbSelection, pbSelection, lblSelection, _listSelectionPictures, Config[WsIndex].Selection, Config[WsIndex].Selection, e.FullPath);
                        int countItems = lbSelection.Items.Count;

                        ThreadListBox.SetSelectedIndex(lbSelection, Methods.CalcListBoxIndex(indexBefore, countItems));
                    }

                    else if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Edited)))
                    {
                        int indexBefore = ThreadListBox.SelectedIndex(lbEdited);
                        ClearAndUpdateFlow(lbEdited, pbEdited, lblEdited, _listEditedPictures, Config[WsIndex].Edited, Config[WsIndex].Edited, e.FullPath);
                        int countItems = lbEdited.Items.Count;

                        ThreadListBox.SetSelectedIndex(lbEdited, Methods.CalcListBoxIndex(indexBefore, countItems));
                    }

                    else if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Config[WsIndex].Instagram)))
                    {
                        int indexBefore = ThreadListBox.SelectedIndex(lbInstagram);
                        ClearAndUpdateFlow(lbInstagram, pbInstagram, lblInstagram, _listInstagramPictures, Config[WsIndex].Instagram, Config[WsIndex].Instagram, e.FullPath);
                        int countItems = lbInstagram.Items.Count;

                        ThreadListBox.SetSelectedIndex(lbInstagram, Methods.CalcListBoxIndex(indexBefore, countItems));
                    }

                    isWatcherDeleted = false;
                }
            }
        }
        #endregion Watcher

        #region Buttons
        /// <summary>
        /// Add a new shoot button
        /// </summary>
        private void pbAddShoot_Click(object sender, EventArgs e)
        {
            if(comboWorkspace.Items.Count != 0)
            {
                FormShoot f = new FormShoot(this);
                f.Show();
            }

            else
            {
                _log.Info("FormShoot: unable to open formShoot");
            }
        }
        #endregion Buttons

        #region PictureBoxes
        /// <summary>
        /// Open a slide show containing the pictures within the preview list
        /// </summary>
        private void pbPreview_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(Config[WsIndex], _listPreviewPictures, lbPreview.SelectedIndex);
                _log.Info($"PictureBox pbPreview: opened \"{pbPreview.ImageLocation}\"");

                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbPreview: unable to open \"{pbPreview.ImageLocation}\"", ex);
            }
        }

        /// <summary>
        /// Open a slide show containing the pictures within the selection list
        /// </summary>
        private void pbSelection_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a temporary list where the path is converted to a preview flow because the pictures within a selection flow contain a RAW file format
                List<Picture> list = new List<Picture>();

                for (int i = 0; i < _listSelectionPictures.Count; i++)
                {
                    string path = Path.Combine(Config[WsIndex].Workspace, _listSelectionPictures[i].ShootInfo, Config[WsIndex].Preview, $"{_listSelectionPictures[i].Filename}.jpg");
                    list.Add(new Picture(path));
                }

                FormPreview f = new FormPreview(Config[WsIndex], list, lbSelection.SelectedIndex);
                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbSelection: unable to open \"{pbSelection.ImageLocation}\"", ex);
            }
        }

        /// <summary>
        /// Open a slide show containing the pictures within the edited list
        /// </summary>
        private void pbEdited_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(Config[WsIndex], _listEditedPictures, lbEdited.SelectedIndex);
                _log.Info($"PictureBox pbEdited: opened \"{pbEdited.ImageLocation}\"");

                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbEdited: unable to open \"{pbEdited.ImageLocation}\"", ex);
            }
        }

        /// <summary>
        /// Open a slide show containing the pictures within the instagram list
        /// </summary>
        private void pbInstagram_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(Config[WsIndex], _listInstagramPictures, lbInstagram.SelectedIndex);
                _log.Info($"PictureBox pbInstagram: opened \"{pbInstagram.ImageLocation}\"");

                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbInstagram: unable to open \"{pbInstagram.ImageLocation}\"", ex);
            }
        }
        #endregion PictureBoxes
    }
}
