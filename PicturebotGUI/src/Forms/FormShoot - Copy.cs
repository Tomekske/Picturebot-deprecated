using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PicturebotGUI.src.POCO;
using PicturebotGUI.src.Command;
using PicturebotGUI.src.Background;
using Picturebot;
using Picturebot.src.POCO;
using Convert = PicturebotGUI.src.Background.Convert;
using PicturebotGUI.src.Helper;

namespace PicturebotGUI
{
    public partial class FormShoot : Form
    {
        private FormLoading _formLoading = new FormLoading();
        private List<Config> _config = new List<Config>();
        private Form1 mainForm = null;
        private Dictionary<string, Drag> dictFiles = new Dictionary<string, Drag>();
        private int _wsIndex = 0;
        private string _shootname;

        private Hash _bgwHash;
        private Convert _bgwConvert;
        private Backup _bgwBackup;
        private Move _bgwMove;

        public FormShoot(Form form)
        {
            mainForm = form as Form1;
          
            InitializeComponent();

            _bgwMove = new Move(bgwMove, _config[_wsIndex], _formLoading, dictFiles, lbRaw);
            _bgwHash = new Hash(bgwHash, _config[_wsIndex], _formLoading);
            _bgwBackup = new Backup(bgwBackup, _config[_wsIndex], _formLoading);
            _bgwConvert = new Convert(bgwConvert, _config[_wsIndex], _formLoading);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string date = dtShoot.Text;
            _shootname = $"{name} {date}";

            src.Command.Shoot.NewShoot(_config[_wsIndex].Index, name, date);

            Directory.SetCurrentDirectory(_config[_wsIndex].Workspace);

            _formLoading.Show();


            _bgwMove.Start();
        }

        private void lbRaw_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string name = txtName.Text;
            string date = dtShoot.Text;
            string shootname = $"{name} {date}";

            foreach (var file in files)
            {
                //string destination = Path.Combine(_config[_wsIndex].Workspace, shootname, _config[_wsIndex].BaseFlow, Picture.FileName(file));
                //dictFiles.Add(Picture.FileName(file), new Drag(file, destination));
                //lbRaw.Items.Add(Picture.FileName(file));
            }
        }

        private void lbRaw_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        //===============================================================================================================
        private void bgwMove_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwMove.Work();
        }

        private void bgwMove_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwMove.Progress(e.UserState.ToString());
        }

        private void bgwMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.mainForm.UpdateShootListBox();
            string currentDir = Path.Combine(_config[_wsIndex].Workspace, _shootname, _config[_wsIndex].BaseFlow);
            Directory.SetCurrentDirectory(currentDir);

            _bgwMove.Finished("Hashing files!");

            if (Directory.Exists(currentDir))
            {
                _bgwHash.Start();
            }

        }

        //=========================================================================================================================

        private void bgwHash_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwHash.Work();
        }

        private void bgwHash_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void bgwHash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bgwHash.Finished("Finished hashing!");
            _bgwBackup.Start();
        }

        //=========================================================================================================================

        private void bgwBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwBackup.Work();
        }

        private void bgwBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwBackup.Progress(e.UserState.ToString());
        }

        private void bgwBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bgwBackup.Finished("BACKUP RDY");
            _bgwConvert.Start();
        }

        //=========================================================================================================================

        private void bgwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            _bgwConvert.Work();   
        }

        private void bgwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwConvert.Progress(e.UserState.ToString());
        }

        private void bgwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _bgwConvert.Finished("Finished conversion");
            _formLoading.Close();
            this.Close();
        }

        //=========================================================================================================================


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lbRaw.Enabled = true;
        }

        private void pbSaveShoot_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string date = dtShoot.Text;

            _shootname = $"{name} {date}";
            Picturebot.Shoot sht = new Picturebot.Shoot(_config[_wsIndex]);
            sht.Add(_shootname);

            _formLoading.Show();
            _bgwMove.Start();
        }

        private void FormShoot_Load(object sender, EventArgs e)
        {

        }
    }
}
