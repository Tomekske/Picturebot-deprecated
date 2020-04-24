using Picturebot;
using Picturebot.src.Logger;
using Picturebot.src.POCO;
using PicturebotGUI.src.Background;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

        public object GUiThread { get; private set; }

        public FormShoot(Form form)
        {
            // Create a formMain object
            _formMain = form as FormMain;
              
            InitializeComponent();

            // Initialize config object
            _config = _formMain.Config[_formMain.WsIndex];
        }

        #region BackgroundWorker
        #region Start
        #region MoveFiles
        /// <summary>
        /// Move the pictures to the baseFlow directory
        /// </summary>
        private void bgwMove_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwMove.Work();
        }
        #endregion MoveFiles

        #region HashFiles
        /// <summary>
        /// Hash the pictures within the base flow
        /// </summary>
        private void bgwHash_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwHash.Work();
        }
        #endregion HashFiles

        #region BackupFiles
        /// <summary>
        /// Move the pictures to the backup flow
        /// </summary>
        private void bgwBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwBackup.Work();
        }
        #endregion BackupFiles

        #region ConvertFiles
        /// <summary>
        /// Convert RAW pictures within the base flow to a JPG format
        /// </summary>
        private void bgwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwConvert.Work();
        }
        #endregion ConvertFiles
        #endregion Start

        #region Progress
        #region MoveFiles
        /// <summary>
        /// Display progression status of the move operation
        /// </summary>
        private void bgwMove_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwMove.Progress(e.UserState.ToString());
        }
        #endregion MoveFiles

        #region HashFiles
        /// <summary>
        /// Display progression status of the hash operation
        /// </summary>
        private void bgwHash_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        #endregion HashFiles

        #region BackupFiles
        /// <summary>
        /// Display progression status of the backup operation
        /// </summary>
        private void bgwBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwBackup.Progress(e.UserState.ToString());
        }
        #endregion BackupFiles

        #region ConvertFiles
        /// <summary>
        /// Display progression status of the convert operation
        /// </summary>
        private void bgwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwConvert.Progress(e.UserState.ToString());
        }
        #endregion ConvertFiles
        #endregion Progress

        #region Completed
        #region MoveFiles
        /// <summary>
        /// When all files are moved start the hashing procedure
        /// </summary>
        private void bgwMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             string path = Path.Combine(_config.Workspace, _shootInfo, _config.BaseFlow);

            _bgwMove.Finished("Hashing files!");

            if (Directory.Exists(path))
            {
               _bgwHash.Start();
            }
        }
        #endregion MoveFiles

        #region HashFiles
        /// <summary>
        /// When all files are hashed start the backup procedure
        /// </summary>
        private void bgwHash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bgwBackup.Start();
        }
        #endregion HashFiles

        #region BackupFiles
        /// <summary>
        /// When all files are hashed start the conversion procedure
        /// </summary>
        private void bgwBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bgwConvert.Start();
        }
        #endregion BackupFiles

        #region ConvertFiles
        /// <summary>
        /// When all files are converted start the conversion procedure close the form
        /// </summary>
        private void bgwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _formMain.GetWorkspaceShoots();
            
            // Close the loading form
            _formLoading.Close();
            // Close the current form
            this.Close();
        }
        #endregion ConvertFiles

        #endregion Completed
        #endregion BackgroundWorker

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
        /// <summary>
        /// Add pictures to the newly created shoot
        /// </summary>
        private void pbSaveShoot_Click(object sender, EventArgs e)
        {
            // Make sure pictures are moved to the listBox
            if(lbRaw.Items.Count == 0)
            {
                MessageBox.Show($"Make sure the shoot information is filled in and at least one picture is dragged into the listBox");
            }

            else
            {
                _shootInfo = $"{txtName.Text.Trim()} {dtShoot.Text}";
                Shoot shoot = new Shoot(_config);

                if(shoot.Add(_shootInfo))
                {
                    _bgwMove = new Move(bgwMove, _config, _formLoading, _dictMoveFiles, _listPictures);
                    _bgwHash = new Hash(bgwHash, _config, _formLoading, _shootInfo, Workflow.Baseflow);
                    _bgwBackup = new Backup(bgwBackup, _config, _formLoading, _shootInfo);
                    _bgwConvert = new ConvertRaw(bgwConvert, _config, _formLoading, _shootInfo);

                    // Open the loading form
                    _formLoading.Show();
                    // Start the moving procedure
                    _bgwMove.Start();
                }
            }
        }
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

            // Format shoot information
            _shootInfo = $"{txtName.Text.Trim()} {dtShoot.Text}";
            int index = 0;

            string pathToShoot = Path.Combine(_config.Workspace, _shootInfo);

            // Start the processing chain only when the new shoot name doesn't exists
            if (!Guard.Filesystem.IsPath(pathToShoot))
            {
                // Loop over the dragged pictures
                foreach (var file in files)
                {
                    // Get the destination path where the pictures are going to be moved to
                    string destination = Path.Combine(pathToShoot, _config.BaseFlow, Path.GetFileName(file));

                    // Picture object containing all the necessary meta-data 
                    Picture picture = new Picture(destination, _config.Workspace, index);

                    _dictMoveFiles.Add(picture.Absolute, new Drag(file, destination));
                    // Append picture to the listBox
                    lbRaw.Items.Add(picture.FilenameExtension);

                    // Append picture to the picture list
                    _listPictures.Add(picture);
                    index++;
                }
            }
            else
            {
                _log.Info($"Shoot: already \"{pathToShoot}\" exists");
                MessageBox.Show($"Shoot: already \"{pathToShoot}\" exists");   
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
    }
}
