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

        private Config _config;
        private Form1 mainForm = null;
        private Dictionary<string, Drag> dictFiles = new Dictionary<string, Drag>();

        public FormShoot(Form form, Config config)
        {
            mainForm = form as Form1;
            _config = config;
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string date = dtShoot.Text;
            string shootname = $"{name} {date}";

            Shell.Execute("pb", $"shoot -n {name} {date}");

            Directory.SetCurrentDirectory(_config.Workspace);

            int count = 1;
            int lenght = lbRaw.Items.Count;

            foreach(string file in lbRaw.Items)
            {
                lblOutput.Text = $"{count}/{lenght}";
                File.Copy(dictFiles[file].Source, dictFiles[file].Destination);
                count++;
            }

            this.mainForm.UpdateShootListBox();

            Directory.SetCurrentDirectory(Path.Combine(_config.Workspace, shootname, _config.BaseFlow));

            if (!bgwBackup.IsBusy)
            {
                bgwBackup.RunWorkerAsync();
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
                string destination = Path.Combine(_config.Workspace, shootname, _config.BaseFlow, Picture.FileName(file));
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
                        //Renaming: {picture} -> {newName} [{counter + 1}/{len(pictures)}
                        int procent = index++ * 100 / count;
                        bgwBackup.ReportProgress(procent, $"Backup: {index - 1}/{count}");

                        string f = $"{index - 1} {file}";

                        Shell.Execute("pb", $"base -b {index - 1}\"{file}\"");
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

                        Shell.Execute("pb", $"base -c \"{file}\" 50");
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
    }
}
