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
using Config = PicturebotGUI.src.POCO.Config;

namespace PicturebotGUI
{
    public partial class FormShoot : Form
    {
        private class Drag
        {
            public string Source { get; set; }
            public string Destination { get; set; }

            public Drag(string source, string desitnation)
            {
                Source = source;
                Destination = desitnation;
            }
        }

        private List<Config> _config = new List<Config>();
        private Form1 mainForm = null;
        private Dictionary<string, Drag> dictFiles = new Dictionary<string, Drag>();
        private int _wsIndex = 0;

        public FormShoot(Form form)
        {
            mainForm = form as Form1;
            _config = mainForm.config;
            _wsIndex = mainForm.wsIndex;

            InitializeComponent();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string date = dtShoot.Text;
            string shootname = $"{name} {date}";

            src.Command.Shoot.NewShoot(_config[_wsIndex].Index, name, date);

            Directory.SetCurrentDirectory(_config[_wsIndex].Workspace);

            int count = 1;
            int lenght = lbRaw.Items.Count;

            foreach(string file in lbRaw.Items)
            {
                lblOutput.Text = $"{count}/{lenght}";
                File.Copy(dictFiles[file].Source, dictFiles[file].Destination);
                count++;
            }

            this.mainForm.UpdateShootListBox();

            Directory.SetCurrentDirectory(Path.Combine(_config[_wsIndex].Workspace, shootname, _config[_wsIndex].BaseFlow));

            if (!bgwRename.IsBusy)
            {
                bgwRename.RunWorkerAsync();
            }
        }

        private void lbRaw_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string name = txtName.Text;
            string date = dtShoot.Text;
            string shootname = $"{name} {date}";

            foreach (var file in files)
            {
                string destination = Path.Combine(_config[_wsIndex].Workspace, shootname, _config[_wsIndex].BaseFlow, Picture.FileName(file));
                dictFiles.Add(Picture.FileName(file), new Drag(file, destination));
                lbRaw.Items.Add(Picture.FileName(file));
            }
        }

        private void lbRaw_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void bgwBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = 1;

            try
            {
                Directory.GetCurrentDirectory();

                string cwd = Directory.GetCurrentDirectory();
                int count = Directory.GetFiles(cwd, "*.*", SearchOption.TopDirectoryOnly).Length;

                string[] files = Directory.GetFiles(cwd);

                foreach (var file in files)
                {
                    if (!bgwBackup.CancellationPending)
                    {
                        int procent = index++ * 100 / count;
                        bgwBackup.ReportProgress(procent, $"Backup: {index - 1}/{count}");

                        string f = $"{index - 1} {file}";

                        src.Command.Base.Backup(_config[_wsIndex].Index, file);
                    }
                }
            }

            catch (Exception)
            {
                bgwBackup.CancelAsync();
            }
        }

        private void bgwBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblOutput.Text = e.UserState.ToString();
        }

        private void bgwBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblOutput.Text = "Backup has been finished";

            if (!bgwConvert.IsBusy)
            {
                bgwConvert.RunWorkerAsync();
            }
        }

        private void bgwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = 1;

            try
            {
                Directory.GetCurrentDirectory();

                string cwd = Directory.GetCurrentDirectory();
                int count = Directory.GetFiles(cwd, "*.*", SearchOption.TopDirectoryOnly).Length;

                string[] files = Directory.GetFiles(cwd);

                var sortedFiles = new DirectoryInfo(cwd).GetFiles().OrderBy(f => f.CreationTime).ToList();


                foreach (var file in sortedFiles)
                {
                    if (!bgwConvert.CancellationPending)
                    {
                        int procent = index++ * 100 / count;
                        bgwConvert.ReportProgress(procent, $"Converting: {index - 1}/{count}");

                        src.Command.Base.Convert(_config[_wsIndex].Index, file.ToString(), 50);
                    }
                }
            }

            catch (Exception)
            {
                bgwConvert.CancelAsync();
            }
        }

        private void bgwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblOutput.Text = e.UserState.ToString();
        }

        private void bgwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblOutput.Text = "Conversion has been finished";
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lbRaw.Enabled = true;
        }

        private void bgwRename_DoWork(object sender, DoWorkEventArgs e)
        {
            src.Command.Base.Hash(_config[_wsIndex].Index);
        }

        private void bgwRename_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgwRename_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!bgwBackup.IsBusy)
            {
                bgwBackup.RunWorkerAsync();
            }
        }
    }
}
