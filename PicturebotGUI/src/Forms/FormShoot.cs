using Picturebot;
using Picturebot.src.Logger;
using Picturebot.src.POCO;
using PicturebotGUI.src.Background;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.GUIThread;
using PicturebotGUI.src.Helper;
using PicturebotGUI.src.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PicturebotGUI
{
    public partial class FormShoot : Form
    {
        private FormMain _formMain = null;
        private FormLoading _formLoading = new FormLoading();

        private Config _config;

        private Hash _bgwHash;
        private ConvertRaw _bgwConvert;
        private Backup _bgwBackup;
        private Move _bgwMove;

        private string _shootInfo = string.Empty;
        private List<Picture> _listPictures = new List<Picture>();
        private Dictionary<string, Drag> _dictMoveFiles = new Dictionary<string, Drag>();
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        public FormShoot(Form form)
        {
            // Create a formMain object
            _formMain = form as FormMain;

            InitializeComponent();

            // Initialize config object
            _config = _formMain.Config[_formMain.WsIndex];

            _log.Info("FormShoot: opened formShoot");

            if(Properties.Settings.Default.DefaultUploadType == FileType.RAW)
            {
                radioRAW.Checked = true;
            }

            else if (Properties.Settings.Default.DefaultUploadType == FileType.Compressed)
            {
                radioCompressed.Checked = true;
            }
        }

        #region Backgroundworker
        #region Move
        /// <summary>
        /// Move the pictures to the baseFlow directory
        /// </summary>
        private void bgwMove_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwMove.Work();
        }

        /// <summary>
        /// Display progression status of the move operation
        /// </summary>
        private void bgwMove_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwMove.Progress(e.UserState.ToString());
        }

        /// <summary>
        /// When all files are moved start the hashing procedure
        /// </summary>
        private void bgwMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string path = Path.Combine(_config.Workspace, _shootInfo, _config.Base);

            _bgwMove.Finished("Hashing files!");

            if (Directory.Exists(path))
            {
                _bgwHash.Start();
            }
        }
        #endregion Move

        #region Backup
        /// <summary>
        /// Move the pictures to the backup flow
        /// </summary>
        private void bgwBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwBackup.Work();
        }

        /// <summary>
        /// Display progression status of the backup operation
        /// </summary>
        private void bgwBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwBackup.Progress(e.UserState.ToString());
        }

        /// <summary>
        /// When all files are hashed start the conversion procedure
        /// </summary>
        private void bgwBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (radioRAW.Checked)
            {
                _bgwConvert.Start();
            }
            else
            {
                _bgwMove.MoveFiles(_shootInfo);
                _formMain.GetWorkspaceShoots();

                // Close the loading form
                _formLoading.Close();
                // Close the current form
                this.Close();
            }
        }
        #endregion Backup

        #region Hash
        /// <summary>
        /// Hash the pictures within the base flow
        /// </summary>
        private void bgwHash_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwHash.Work();
        }

        /// <summary>
        /// Display progression status of the hash operation
        /// </summary>
        private void bgwHash_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        /// <summary>
        /// When all files are hashed start the backup procedure
        /// </summary>
        private void bgwHash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bgwBackup.Start();
        }
        #endregion Hash

        #region Convert
        /// <summary>
        /// Convert RAW pictures within the base flow to a JPG format
        /// </summary>
        private void bgwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwConvert.Work();
        }

        /// <summary>
        /// Display progression status of the convert operation
        /// </summary>
        private void bgwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (radioRAW.Checked)
            {
                _bgwConvert.Progress(e.UserState.ToString());
            }
        }

        /// <summary>
        /// When all files are converted start the conversion procedure close the form
        /// </summary>
        private void bgwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (radioRAW.Checked)
            {
                _formMain.GetWorkspaceShoots();

                // Close the loading form
                _formLoading.Close();
                // Close the current form
                this.Close();
            }
        }

        #endregion Convert
        #endregion Backgroundworker

        #region TextBox
        /// <summary>
        /// Enable the raw listBox when text is entered
        /// </summary>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lbRaw.Enabled = true;
        }
        #endregion TextBox

        #region Buttons
        #region LeftClick
        /// <summary>
        /// Add pictures to the newly created shoot
        /// </summary>
        private void pbSaveShoot_Click(object sender, EventArgs e)
        {
            bool isEmpty = txtName.Text.Trim() == string.Empty ? true : false;

            // Only add the shoot when there are items within the listBox and when the shoot has a name
            if (!isEmpty && lbRaw.Items.Count != 0)
            {
                // Format shoot information
                _shootInfo = $"{txtName.Text.Trim()} {dtShoot.Text}";

                string pathToShoot = Path.Combine(_config.Workspace, _shootInfo);

                // Start the processing chain only when the new shoot name doesn't exists
                if (!Guard.Filesystem.IsPath(pathToShoot))
                {                   
                    if (radioRAW.Checked)
                    {
                        bool isExtension = _listPictures.All(o => Extension.RAW.Any(w => w.ToLower() == o.Extension.ToLower()));

                        // Only initialize the background worker chain when all pictures within the listBox are a RAW file format
                        if (isExtension)
                        {
                            InitialiseBackgroundWorkerChain();
                        }

                        else
                        {
                            MessageBox.Show("One or more files are not a RAW format");
                            _log.Info("One or more files are not a RAW format");
                        }
                    }

                    else if (radioCompressed.Checked)
                    {
                        bool isExtension = _listPictures.All(o => Extension.Compressed.Any(w => w.ToLower() == o.Extension.ToLower()));

                        // Only initialize the background worker chain when all pictures within the listBox are a compressed file format
                        if (isExtension)
                        {
                            InitialiseBackgroundWorkerChain();
                        }

                        else
                        {
                            MessageBox.Show("One or more files are not a compressed format");
                            _log.Info("One or more files are not a compressed format");
                        }
                    }
                }

                else
                {
                    _log.Info($"Shoot: already \"{pathToShoot}\" exists");
                    MessageBox.Show($"Shoot: already \"{pathToShoot}\" exists");
                }
            }

            else
            {
                MessageBox.Show("Make sure to enter a shoot name and that at least one picture is dragged within the listBox");
                _log.Info("Make sure to enter a shoot name and that at least one picture is dragged within the listBox");
            }
        }
        #endregion LeftClick

        #region RightClick
        /// <summary>
        /// Show the menu strip when right clicking on an item within the listBox
        /// </summary>
        private void lbRaw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbRaw.Text != string.Empty)
            {
                // Add menu items to the context menu strip
                ContextMenuStrip menu = new ContextMenuStrip();

                var menuItemDelete = new ToolStripMenuItem(Strip.Delete);
                menuItemDelete.ShortcutKeyDisplayString = "Del";
                menu.Items.Add(menuItemDelete);

                menu.Tag = lbRaw.SelectedItem;

                // The context menu is shown on the current coordinates of the mouse 
                menu.Show(lbRaw, new Point(e.X, e.Y));
                // Create an event handler
                menu.ItemClicked += Menu_AddPicturesItemRightClicked;
            }
        }
        #endregion RightClick
        #endregion Buttons  

        #region ListBoxs
        #region DragAndDrop
        /// <summary>
        /// Prepare the data when files are dropped within the listBox
        /// </summary>
        private void lbRaw_DragDrop(object sender, DragEventArgs e)
        {
            // Get all the dragged files
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Array.Sort(files);

            // Loop over the dragged pictures
            foreach (var file in files)
            {
                Picture picture = new Picture(file, _config.Workspace);

                // Append picture to the listBox
                lbRaw.Items.Add(picture.FilenameExtension);

                // Append picture to the picture list
                _listPictures.Add(picture);
            }

            src.GUIThread.ThreadLabel.SetText(lblAddPictures, $"RAW pictures ({lbRaw.Items.Count})");
        }

        /// <summary>
        /// Establish the drop effects when the files are entering the listBox
        /// </summary>
        private void lbRaw_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }
        #endregion DragAndDrop

        #endregion ListBox

        #region KeyDown
        /// <summary>
        /// Use shortcuts to execute something
        /// </summary>
        private void lbRaw_KeyDown(object sender, KeyEventArgs e)
        {
            int index = lbRaw.SelectedIndex;

            // Make sure it's not possible to perform keyboard actions when the listBox is empty
            if (lbRaw.Items.Count != 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int indexBefore = lbRaw.SelectedIndex;

                    lbRaw.Items.RemoveAt(index);
                    _listPictures.RemoveAt(index);

                    int countItems = lbRaw.Items.Count;

                    ThreadLabel.SetText(lblAddPictures, $"RAW pictures ({lbRaw.Items.Count})");
                    lbRaw.SelectedIndex = Methods.CalcListBoxIndex(indexBefore, countItems);
                }
            }
        }
        #endregion KeyDown

        /// <summary>
        /// Delete menu event 
        /// </summary>
        private void Menu_AddPicturesItemRightClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = lbRaw.SelectedIndex;
            int indexBefore = lbRaw.SelectedIndex;

            lbRaw.Items.RemoveAt(index);
            _listPictures.RemoveAt(index);

            int countItems = lbRaw.Items.Count;

            ThreadLabel.SetText(lblAddPictures, $"RAW pictures ({lbRaw.Items.Count})");
            lbRaw.SelectedIndex = Methods.CalcListBoxIndex(indexBefore, countItems);
        }

        /// <summary>
        /// Initialize the background worker chains
        /// </summary>
        private void InitialiseBackgroundWorkerChain()
        {
            Shoot shoot = new Shoot(_config);
            // Create the new shoot within the workspace
            shoot.Add(_shootInfo);

            // Loop-over every picture within the _listPictures list
            foreach (var raw in _listPictures)
            {
                string source = raw.Absolute;
                string destination = Path.Combine(_config.Workspace, _shootInfo, _config.Base, raw.FilenameExtension);

                _dictMoveFiles.Add(raw.Absolute, new Drag(source, destination));
            }

            // Initialize background workers
            _bgwMove = new Move(bgwMove, _config, _formLoading, _dictMoveFiles, _listPictures);
            _bgwHash = new Hash(bgwHash, _config, _formLoading, _shootInfo, _config.Base);
            _bgwBackup = new Backup(bgwBackup, _config, _formLoading, _shootInfo);
            _bgwConvert = new ConvertRaw(bgwConvert, _config, _formLoading, _shootInfo);

            // Open the loading form
            _formLoading.Show();
            // Start the moving procedure
            _bgwMove.Start();
        }
    }
}
