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

        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private string _version = "1.0.2";

        public FormMain()
        {
            InitializeComponent();
            ReadConfigFile();
            GetWorkspaceShoots();

            // Set the current version name within the main form
            this.Text += _version;
        }

        #region ListBox
        /// <summary>
        /// Retrieve all the shoots within the workspace and append them to the shoot listBox
        /// </summary>
        public void GetWorkspaceShoots()
        {
            ThreadListBox.Clear(lbShoot);

            // Get a list of all subdirectories  
            var dirs = from dir in
                Directory.EnumerateDirectories(Config[WsIndex].Workspace)
                       select dir;

            // Get the shoot names within the workspace directories and append them to the shoot listBox
            foreach (var dir in dirs)
            {
                ThreadListBox.AppendItem(lbShoot, dir.Substring(dir.LastIndexOf("\\") + 1));
                _log.Debug($"ListBox lbShoot: \"{dir.Substring(dir.LastIndexOf("\\") + 1)}\" appended");
            }

            // Display the amount of pictures within the shoot label
            ThreadLabel.SetText(lblShoots, $"Shoots ({dirs.Count()})");
        }

        #region LeftClick
        /// <summary>
        /// Click on a shoot within the workspace to list all the pictures within every flow
        /// </summary>
        private void lbShoot_Click(object sender, EventArgs e)
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
                string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Preview, $"{picture.Filename}{Extension.JPG}");

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
                int countFileSelectionFlow = Helper.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Selection)).Count();

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
                menu.Items.Add($"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Affinity)}");

                var menuItemLuminar = new ToolStripMenuItem(Strip.AddSelection);
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
                menu.Items.Add($"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Affinity)}");

                var menuItemLuminar = new ToolStripMenuItem(Strip.AddSelection);
                menuItemLuminar.ShortcutKeyDisplayString = "L";
                menu.Items.Add(menuItemLuminar);

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
                    src.Command.General.Program(External.Affinity, picture.Absolute);
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
            if (lbEdited.Text != string.Empty)
            {
                // Get the path to the affinity file within the editing flow
                string path = Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Editing, $"{lbEdited.Text}{Extension.AFPHOTO}");

                // Only open the affinity file when it's exists within the editing flow
                if (File.Exists(path))
                {
                    src.Command.General.Program(External.Affinity, path);
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
        /// Hotkeys for to control the shoot listbBox menu items
        /// </summary>
        private void lbShoot_KeyDown(object sender, KeyEventArgs e)
        {
            string path = Path.Combine(Config[WsIndex].Workspace, _shoot);

            if (e.KeyCode == Keys.O)
            {
                lbShoot.SelectedItem = _shoot;
                src.Command.General.Explorer(Config[WsIndex], _shoot);
                e.SuppressKeyPress = true;
            }

            else if (e.KeyCode == Keys.Delete)
            {
                src.Command.General.DeleteShoot(path, Sht);
            }

            else if (e.KeyCode == Keys.F2)
            {
                _shoot = src.Command.General.RenameShoot(Config[WsIndex], Sht, _shoot);

                GetWorkspaceShoots();
                lbShoot.SelectedItem = _shoot;
                ClearAndUpdateFlows(_shoot);
            }
        }

        /// <summary>
        /// Hotkeys for to control the preview listbBox menu items
        /// </summary>
        private void lbPreview_KeyDown(object sender, KeyEventArgs e)
        {
            Picture picture = new Picture(_listPreviewPictures[lbPreview.SelectedIndex].Absolute);

            if (e.KeyCode == Keys.Delete)
            {
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbPreview, Flw, Workflow.Baseflow, Extension.NEF, true);
            }

            else if (e.KeyCode == Keys.O)
            {
                e.SuppressKeyPress = true;
                src.Command.General.Explorer(Config[WsIndex], _shoot);
            }

            else if (e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                src.Command.General.Selection(Config[WsIndex], picture);
            }
        }

        /// <summary>
        /// Hotkeys for to control the selection listbBox menu items
        /// </summary>
        private void lbSelection_KeyDown(object sender, KeyEventArgs e)
        {
            Picture picture = new Picture(_listSelectionPictures[lbSelection.SelectedIndex].Absolute);

            if (e.KeyCode == Keys.Delete)
            {
                src.Command.General.DeletePicture(Config[WsIndex], picture, pbSelection, Flw, Extension.NEF);
            }

            else if (e.KeyCode == Keys.O)
            {
                src.Command.General.Explorer(Config[WsIndex], _shoot);
            }

            else if (e.KeyCode == Keys.L)
            {
                src.Command.General.Program(External.Luminar, picture.Absolute);
            }
        }

        /// <summary>
        /// Hotkeys for to control the edited listbBox menu items
        /// </summary>
        private void lbEdited_KeyDown(object sender, KeyEventArgs e)
        {
            Picture picture = new Picture(_listEditedPictures[lbEdited.SelectedIndex].Absolute);

            if (e.KeyCode == Keys.Delete)
            {
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbEdited, Flw, Workflow.Edited, Extension.JPG);
            }

            else if (e.KeyCode == Keys.O)
            {
                e.SuppressKeyPress = true;
                src.Command.General.Explorer(Config[WsIndex], _shoot);
            }

            else if (e.KeyCode == Keys.L)
            {
                e.SuppressKeyPress = true;
                src.Command.General.Program(External.Luminar, picture.Absolute);
            }
        }

        /// <summary>
        /// Hotkeys for to control the instagram listbBox menu items
        /// </summary>
        private void lbInstagram_KeyDown(object sender, KeyEventArgs e)
        {
            Picture picture = new Picture(_listInstagramPictures[lbInstagram.SelectedIndex].Absolute);

            if (e.KeyCode == Keys.Delete)
            {
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbInstagram, Flw, Workflow.Instagram, Extension.JPG);
            }

            else if (e.KeyCode == Keys.O)
            {
                e.SuppressKeyPress = true;
                src.Command.General.Explorer(Config[WsIndex], _shoot);
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
            Config = Picturebot.Configuration.Read();

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
            // The same index is assigned to the config object
            Config[WsIndex].Index = WsIndex;
        }
        #endregion ConfigFile

        #region ComboBox
        /// <summary>
        /// Select the active workspace
        /// </summary>
        private void comboWorkspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected index
            WsIndex = comboWorkspace.SelectedIndex;
            // Assign the selected to the Config object
            Config[WsIndex].Index = WsIndex;

            Sht = new Shoot(Config[WsIndex]);
            Flw = new Flow(Config[WsIndex]);

            // Setup a file system watcher
            FileSystemWatcher watcher = new FileSystemWatcher(Config[WsIndex].Workspace);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            // Create even handlers
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;

            GetWorkspaceShoots();
            ClearPictureBoxesAndListBoxesAndLabels();
        }
        #endregion ComboBox

        #region ToolStrip
        /// <summary>
        /// Open the current workspace in the window explorer
        /// </summary>
        private void openWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            src.Command.GUI.Explorer(Config[WsIndex].Workspace);
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
        /// Get pictures from the work flow and add them to the associated listBox and display the amount of pictures within the listBoxes
        /// </summary>
        public void ClearAndUpdateFlows(string path)
        {
            int counter = 0;

            // Get pictures from the work flow and add them to the associated listBox 
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbPreview, pbPreview, _listPreviewPictures, _shoot, Workflow.Preview);
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbSelection, pbSelection, _listSelectionPictures, _shoot, Workflow.Selection);
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbEdited, pbEdited, _listEditedPictures, _shoot, Workflow.Edited);
            Clear.ClearAndUpdateFlow(Config[WsIndex], lbInstagram, pbInstagram, _listInstagramPictures, _shoot, Workflow.Instagram);

            // Display the amount of pictures within the associated flow labels
            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Preview)).Length;
            ThreadLabel.SetText(lblPreview, $"{Config[WsIndex].Preview} ({counter})");

            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Selection)).Length;
            ThreadLabel.SetText(lblSelection, $"{Config[WsIndex].Selection} ({counter})");

            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Edited)).Length;
            ThreadLabel.SetText(lblEdited, $"{Config[WsIndex].Edited} ({counter})");

            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Instagram)).Length;
            ThreadLabel.SetText(lblInstagram, $"{Config[WsIndex].Instagram} ({counter})");

            _log.Info($"Cleared and updated flows: \"{path}\"");
        }

        public void ClearAndUpdateFlow(ListBox listBox, PictureBox pictureBox, Label label, List<Picture> list, string workflow, string title, string path)
        {
            int counter = 0;

            // Get pictures from the work flow and add them to the associated listBox 
            Clear.ClearAndUpdateFlow(Config[WsIndex], listBox, pictureBox, list, _shoot, workflow);

            // Display the amount of pictures within the associated flow labels
            counter = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, workflow)).Length;
            ThreadLabel.SetText(label, $"{title} ({counter})");

            _log.Info($"Cleared and updated flow: \"{path}\"");
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
                isShootDeleting = true;
                src.Command.General.DeleteShoot(path, Sht);
            }

            else if (e.ClickedItem.Text == Strip.RenameBaseflow)
            {
                flow.Rename(path, true, true);

                ClearAndUpdateFlow(lbPreview, pbPreview, lblPreview, _listPreviewPictures, Workflow.Preview, Config[WsIndex].Preview, path);
            }

            else if(e.ClickedItem.Text == Strip.RenameShoot)
            {
                _shoot = src.Command.General.RenameShoot(Config[WsIndex], Sht, _shoot);
                GetWorkspaceShoots();
                lbShoot.SelectedItem = _shoot;
                ClearAndUpdateFlows(_shoot);
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
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbPreview, Flw, Workflow.Baseflow, Extension.NEF, true);
            }

            else if (e.ClickedItem.Text == Strip.AddSelection)
            {
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
            string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Selection, $"{picture.Filename}.NEF");

            if (e.ClickedItem.Text == Strip.Delete)
            {
                src.Command.General.DeletePicture(Config[WsIndex], picture, pbSelection, Flw, Extension.NEF);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Affinity)}")
            {
                src.Command.General.Program(External.Affinity, path);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Luminar)}")
            {
                src.Command.General.Program(External.Luminar, path);
            }
        }

        /// <summary>
        /// Edited listBox's menu strip
        /// </summary>
        private void Menu_EditedItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;
            string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Edited, picture.FilenameExtension);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbEdited, Flw, Workflow.Edited, picture.Extension);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Luminar)}")
            {
                src.Command.General.Program(External.Luminar, path);
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Affinity)}")
            {
                string pathToAffinity = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Editing, $"{picture.Filename}{Extension.AFPHOTO}");

                if (File.Exists(pathToAffinity))
                {
                    src.Command.General.Program(External.Affinity, pathToAffinity);
                }

                else
                {
                    MessageBox.Show($"{lbEdited.Text} doesn't have a editing file.");
                }
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
                src.Command.General.DeletePictureNotification(Config[WsIndex], picture, pbInstagram, Flw, Workflow.Instagram, picture.Extension);
            }
        }
        #endregion MenuStrip

        #region Watcher
        /// <summary>
        /// Update the ListBoxe's when a file within the directory is renamed
        /// </summary>
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (!e.FullPath.Contains("jpg_exiftool_tmp") && !e.FullPath.Contains(Workflow.Baseflow) && !e.FullPath.Contains(Workflow.Backup) && !e.FullPath.Contains(Workflow.Preview) && e.FullPath == Path.Combine(Config[WsIndex].Workspace, _shoot) && !isFileSaving)
            {
                ClearAndUpdateFlows(e.FullPath);
            }
        }

        /// <summary>
        /// Update the ListBoxe's when a file within the directory is created
        /// </summary>
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Preview)))
            {
                ClearAndUpdateFlow(lbPreview, pbPreview, lblPreview,_listPreviewPictures, Workflow.Preview, Config[WsIndex].Preview, e.FullPath);
                isFileSaving = true;
            }

            else if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Selection)))
            {
                ClearAndUpdateFlow(lbSelection, pbSelection, lblSelection, _listSelectionPictures, Workflow.Selection, Config[WsIndex].Selection, e.FullPath);
                isFileSaving = true;
            }

            else if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Edited)))
            {
                ClearAndUpdateFlow(lbEdited, pbEdited, lblEdited, _listEditedPictures, Workflow.Edited, Config[WsIndex].Edited, e.FullPath);
                isFileSaving = true;
            }

            else if (!e.FullPath.Contains("jpg_exiftool_tmp") && e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Instagram)))
            {
                ClearAndUpdateFlow(lbInstagram, pbInstagram, lblInstagram, _listInstagramPictures, Workflow.Instagram, Config[WsIndex].Instagram, e.FullPath);
                isFileSaving = true;
            }

        }

        /// <summary>
        /// Update the ListBoxe's when a file within the directory is deleted
        /// </summary>
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string pathShoot = Path.Combine(Config[WsIndex].Workspace, _shoot);

            // Check whether the shoot directory is getting deleted
            if (isShootDeleting)
            {
                if (e.FullPath == pathShoot)
                {
                    GetWorkspaceShoots();
                    ClearPictureBoxesAndListBoxesAndLabels();
                    isShootDeleting = false;
                }
            }

            else
            {
                // Check whether a picture within the preview flow is deleted
                if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Preview)))
                {
                    ClearAndUpdateFlow(lbPreview, pbPreview, lblPreview, _listPreviewPictures, Workflow.Preview, Config[WsIndex].Preview, e.FullPath);
                }

                else if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Selection)))
                {
                    ClearAndUpdateFlow(lbSelection, pbSelection, lblSelection, _listSelectionPictures, Workflow.Selection, Config[WsIndex].Selection, e.FullPath);
                }

                else if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Edited)))
                {
                    ClearAndUpdateFlow(lbEdited, pbEdited, lblSelection, _listEditedPictures, Workflow.Edited, Config[WsIndex].Edited, e.FullPath);
                }

                else if (e.FullPath.Contains(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Instagram)))
                {
                    ClearAndUpdateFlow(lbInstagram, pbInstagram, lblInstagram, _listInstagramPictures, Workflow.Instagram, Config[WsIndex].Instagram, e.FullPath);
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
            FormShoot f = new FormShoot(this);
            f.Show();
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
                FormPreview f = new FormPreview(_listPreviewPictures, lbPreview.SelectedIndex);
                _log.Info($"PictureBox pbPreview: opened \"{pbPreview.ImageLocation}\"");

                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbPreview: unable to open \"{pbPreview.ImageLocation}\"", ex);
                MessageBox.Show(ex.Message);
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
                    string path = Path.Combine(Config[WsIndex].Workspace, _listSelectionPictures[i].ShootInfo, Workflow.Preview, $"{_listSelectionPictures[i].Filename}.jpg");
                    list.Add(new Picture(path));
                }

                FormPreview f = new FormPreview(list, lbSelection.SelectedIndex);
                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbSelection: unable to open \"{pbSelection.ImageLocation}\"", ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Open a slide show containing the pictures within the edited list
        /// </summary>
        private void pbEdited_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(_listEditedPictures, lbEdited.SelectedIndex);
                _log.Info($"PictureBox pbEdited: opened \"{pbEdited.ImageLocation}\"");

                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbEdited: unable to open \"{pbEdited.ImageLocation}\"", ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Open a slide show containing the pictures within the instagram list
        /// </summary>
        private void pbInstagram_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(_listInstagramPictures, lbInstagram.SelectedIndex);
                _log.Info($"PictureBox pbInstagram: opened \"{pbInstagram.ImageLocation}\"");

                f.Show();
            }
            catch (Exception ex)
            {
                _log.Error($"PictureBox pbInstagram: unable to open \"{pbInstagram.ImageLocation}\"", ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion PictureBoxes
    }
}
