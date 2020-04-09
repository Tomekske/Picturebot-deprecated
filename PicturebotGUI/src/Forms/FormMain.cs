using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Helper;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.GUIThread;
using Picturebot.Properties;

namespace PicturebotGUI
{
    public partial class FormMain : Form
    {
        public List<Config> Config { get; set; }
        public int WsIndex { get; set; }

        public Workspace Ws { get; set; }
        public Shoot Sht { get; set; }
        public Flow Flw { get; set; }

        private List<Picture> _listPreviewPictures = new List<Picture>();
        private List<Picture> _listSelectionPictures = new List<Picture>();
        private List<Picture> _listEditedPictures = new List<Picture>();
        private List<Picture> _listInstagramPictures = new List<Picture>();

        private string _shoot = string.Empty;

        private bool isFileSaving = false;

        public FormMain()
        {
            InitializeComponent();
            ReadConfigFile();
            GetWorkspaceShoots();

            Ws = new Workspace(Config);
            Sht = new Shoot(Config[WsIndex]);
            Flw = new Flow(Config[WsIndex]);

            // Setup a file system watcher
            FileSystemWatcher watcher = new FileSystemWatcher(Config[WsIndex].Workspace);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Created += Watcher_Created;
            //watcher.Renamed += Watcher_Renamed;
        }

        #region ListBox
        /// <summary>
        /// Retrieve all the shoots within the workspace and append them to the shoot listBox
        /// </summary>
        public void GetWorkspaceShoots()
        {
            lbShoot.Items.Clear();

            // Get a list of all subdirectories  
            var dirs = from dir in
                Directory.EnumerateDirectories(Config[WsIndex].Workspace)
                       select dir;

            // Get the shoot names within the workspace directories and append them to the shoot listBox
            foreach (var dir in dirs)
            {
                lbShoot.Items.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
            }
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
                ClearAndUpdateFlow();
                isFileSaving = false;
            }
        }

        /// <summary>
        /// Get pictures from the work flow and add them to the associated listBox and display the amount of pictures within the listBoxes
        /// </summary>
        public void ClearAndUpdateFlow()
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
                }

                else
                {
                    Console.WriteLine("File to picture doesn't exist");
                    //log file
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
                string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Preview, $"{picture.Filename}.jpg");

                // Check whether the path to the picture exists
                if (Guard.Filesystem.IsPath(path))
                {
                    // Display the picture in the pictureBox
                    pbSelection.ImageLocation = path;
                }

                else
                {
                    Console.WriteLine("File to picture doesn't exist");
                    //log file
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
                }

                else
                {
                    Console.WriteLine("File to picture doesn't exist");
                    //log file
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
                }

                else
                {
                    Console.WriteLine("File to picture doesn't exist");
                    //log file
                }
            }
        }
        #endregion LeftClick

        #region RightClick
        #region ShootListBox
        /// <summary>
        /// Right click on the shoot listBox
        /// </summary>
        private void lbShoot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbShoot.Text != string.Empty)
            {
                int countFileSelectionFlow = Directory.GetFiles(Path.Combine(Config[WsIndex].Workspace, _shoot, Workflow.Selection), "*").Count();
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add(Strip.Explorer);

                // A shoot can only be renamed when the selection folder contains files
                if(countFileSelectionFlow == 0)
                {
                    menu.Items.Add(Strip.Convert);
                    menu.Items.Add(Strip.RenameBaseflow);
                }
                else
                {
                    menu.Items.Add(Strip.RenameShoot);
                }

                menu.Items.Add(Strip.Delete);
                menu.Tag = lbShoot.SelectedItem.ToString();

                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbShoot, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_ShootItemRightClicked;
            }
        }
        #endregion ShootListBox

        #region PreviewListBox
        /// <summary>
        /// Right click on the preview listBox
        /// </summary>
        private void lbPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbPreview.Text != string.Empty)
            {
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add(Strip.AddSelection);
                menu.Items.Add(Strip.Delete);

                menu.Tag = _listPreviewPictures[lbPreview.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbPreview, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_PreviewItemRightClicked;
            }
        }

        #endregion PreviewListBox

        #region SelectionListBox
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
                menu.Items.Add($"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Luminar)}");
                menu.Items.Add(Strip.Delete);

                menu.Tag = _listSelectionPictures[lbSelection.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbSelection, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_SelectionItemRightClicked;
            }
        }

        #endregion SelectionListBox

        #region EditedListBox
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
                menu.Items.Add($"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Luminar)}");
                menu.Items.Add(Strip.Delete);

                menu.Tag = _listEditedPictures[lbEdited.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbEdited, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_EditedItemRightClicked;
            }
        }
        #endregion EditedListBox

        #region InstagramListBox
        /// <summary>
        /// Right click on the Instagram listBox
        /// </summary>
        private void lbInstagram_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbInstagram.Text != string.Empty)
            {
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add(Strip.Delete);

                menu.Tag = _listInstagramPictures[lbInstagram.SelectedIndex];
                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbInstagram, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_InstagramItemRightClicked;
            }
        }

        #endregion InstagramListBox
        #endregion RightClick
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

            //Loop over every workspace within the configuration file
            foreach (var c in Config)
            {
                // Append every workspace to the combobox, this way the user can switch between workspaces
                comboWorkspace.Items.Add(c.Workspace);
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
            pbPreview.Image = null;
            pbSelection.Image = null;
            pbEdited.Image = null;
            pbInstagram.Image = null;

            // Set listBox to the default settings
            lbEdited.Items.Clear();
            lbInstagram.Items.Clear();
            lbPreview.Items.Clear();
            lbSelection.Items.Clear();

            // Set labels to the default settings
            lblPreview.Text = Config[WsIndex].Preview;
            lblSelection.Text = Config[WsIndex].Selection;
            lblEdited.Text = Config[WsIndex].Edited;
            lblInstagram.Text = Config[WsIndex].Instagram;
        }
        #endregion ClearPictureBoxes

        #endregion PictureBoxes

        #region MenuStrip
        #region ShootListBox
        /// <summary>
        /// Shoot listBox's menu strip
        /// </summary>
        private void Menu_ShootItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            string shoot = (sender as ContextMenuStrip).Tag.ToString();

            string path = Path.Combine(Config[WsIndex].Workspace, shoot);
            //Guard.Filesystem.PathExist(path);

            Flow flow = new Flow(Config[WsIndex]);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                var result = MessageBox.Show($"Are you sure to delete \"{path}\" ?", "Confirm Deletion!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Sht.Remove(path);
                    GetWorkspaceShoots();
                    ClearPictureBoxesAndListBoxesAndLabels();
                }
            }

            else if (e.ClickedItem.Text == Strip.RenameBaseflow)
            {
                flow.Rename(path, true);

                ClearAndUpdateFlow();
            }

            else if(e.ClickedItem.Text == Strip.RenameShoot)
            {
                FormRenameShoot formRenameShoot = new FormRenameShoot(_shoot);
                formRenameShoot.ShowDialog();
                Sht.Rename(_shoot, formRenameShoot.ShootName, formRenameShoot.ShootDate);
                _shoot = $"{formRenameShoot.ShootName} {formRenameShoot.ShootDate}";
                ClearAndUpdateFlow();
                GetWorkspaceShoots();
            }

            else if (e.ClickedItem.Text == Strip.Convert)
            {
                // TODO
            }

            else if (e.ClickedItem.Text == Strip.Explorer)
            {
                src.Command.GUI.Explorer(Path.Combine(Config[WsIndex].Workspace, _shoot));
            }
        }
        #endregion ShootListBox

        #region PreviewListBox
        /// <summary>
        /// Preview listBox's menu strip
        /// </summary>
        private void Menu_PreviewItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;

            Guard.Filesystem.PathExist(picture.Absolute);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                var result = MessageBox.Show($"Are you sure to delete \"{picture.Absolute}\" ?", "Confirm Deletion!!", MessageBoxButtons.YesNo);

                // Create the path to the base flow, because every preview picture comes with a raw format which needs to get deleted as well
                string pathToBaseFlow = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Baseflow, $"{picture.Filename}{Extension.NEF}");
                Guard.Filesystem.PathExist(pathToBaseFlow);

                if (result == DialogResult.Yes)
                {
                    // Delete the picture within the base flow and the preview flow
                    Flw.Remove(picture.Absolute);
                    Flw.Remove(pathToBaseFlow);

                    // Update the preview listBox
                    ClearAndUpdateFlow();
                    // Set the preview pictureBox to it's default value
                    pbPreview.Image = null;
                }
            }

            else if (e.ClickedItem.Text == Strip.AddSelection)
            {
                // Get
                string pathToSelection = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Baseflow, $"{picture.Filename}{Extension.NEF}");
                Guard.Filesystem.PathExist(pathToSelection);

                string pathToSelectionFlow = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Selection, $"{picture.Filename}{Extension.NEF}");

                // Copy the picture to the selection flow only when isn't listed yet in the selection flow
                if (!Guard.Filesystem.IsPath(pathToSelectionFlow))
                {
                    File.Copy(pathToSelection, pathToSelectionFlow);
                    Guard.Filesystem.PathExist(pathToSelectionFlow);

                    // Updated selection listBox
                    //ClearAndUpdateFlow();
                }
            }
        }

        #endregion PreviewListBox

        #region SelectionListBox
        /// <summary>
        /// Selection listBox's menu strip
        /// </summary>
        private void Menu_SelectionItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;
            string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Selection, $"{picture.Filename}.NEF");

            Guard.Filesystem.PathExist(path);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                Flw.Remove(path);

                // Update the preview listBox
                ClearAndUpdateFlow();
                // Set the preview pictureBox to it's default value
                pbPreview.Image = null;
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Affinity)}")
            {
                Shell.Execute(External.Affinity, $"\"{path}\"");
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Luminar)}")
            {
                Shell.Execute(External.Luminar, $"\"{path}\"");
            }
        }
        #endregion SelectionListBox 

        #region EditedListBox
        /// <summary>
        /// Edited listBox's menu strip
        /// </summary>
        private void Menu_EditedItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;
            string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Edited, picture.FilenameExtension);

            Guard.Filesystem.PathExist(path);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                var result = MessageBox.Show($"Are you sure to delete \"{path}\" ?", "Confirm Deletion!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Flw.Remove(path);

                    // Update the preview listBox
                    ClearAndUpdateFlow();
                }
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Luminar)}")
            {
                Shell.Execute(External.Luminar, $"\"{path}\"");
            }

            else if (e.ClickedItem.Text == $"{Strip.Edit} {Path.GetFileNameWithoutExtension(External.Affinity)}")
            {
                string pathToAffinity = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Editing, $"{picture.Filename}.afphoto");

                // If there is an Affinity file, open the file. Else open the picture within the edited flow
                if (Guard.Filesystem.IsPath(pathToAffinity))
                {
                    Shell.Execute(External.Affinity, $"\"{pathToAffinity}\"");
                }
                else
                {
                    Shell.Execute(External.Affinity, $"\"{path}\"");
                }
            }
        }
        #endregion EditedListBox

        #region InstagramListBox
        /// <summary>
        /// Instagram listBox's menu strip
        /// </summary>
        private void Menu_InstagramItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Get the passed data from the context strip menu 
            Picture picture = (Picture)(sender as ContextMenuStrip).Tag;
            string path = Path.Combine(Config[WsIndex].Workspace, picture.ShootInfo, Workflow.Instagram, picture.FilenameExtension);

            Guard.Filesystem.PathExist(path);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                var result = MessageBox.Show($"Are you sure to delete \"{path}\" ?", "Confirm Deletion!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Flw.Remove(path);

                    // Update the preview listBox
                    ClearAndUpdateFlow();
                }
            }
        }
        #endregion InstagramListBox
        #endregion MenuStrip

        #region Watcher
        /// <summary>
        /// Update the ListBoxe's when a file within the directory is renamed
        /// </summary>
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (!e.FullPath.Contains("jpg_exiftool_tmp") && !e.FullPath.Contains(Workflow.Baseflow) && !e.FullPath.Contains(Workflow.Backup) && !e.FullPath.Contains(Workflow.Preview) && e.FullPath == Path.Combine(Config[WsIndex].Workspace, _shoot) && !isFileSaving)
            {
                ClearAndUpdateFlow();
            }
        }

        /// <summary>
        /// Update the ListBoxe's when a file within the directory is created
        /// </summary>
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if(!e.FullPath.Contains("jpg_exiftool_tmp") && !e.FullPath.Contains(Workflow.Baseflow) && !e.FullPath.Contains(Workflow.Backup) && !e.FullPath.Contains(Workflow.Preview) && !Directory.Exists(e.FullPath))
            {
                ClearAndUpdateFlow();
                isFileSaving = true;
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

        private void OpenConfigFileTStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Configuration.GetConfigResource());
        }
    }
}
