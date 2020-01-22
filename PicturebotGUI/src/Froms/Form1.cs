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
using PicturebotGUI.src.Helper;
using PicturebotGUI.src.POCO;
using PicturebotGUI.src.Enums;

namespace PicturebotGUI
{
    public partial class Form1 : Form
    {
        public List<Config> config = new List<Config>();
        public List<string> lstPreview = new List<string>();
        public List<string> lstSelection = new List<string>();
        public List<string> lstEdited = new List<string>();
        public List<string> lstInstagram = new List<string>();

        public int wsIndex = 0;

        public Form1()
        {
            InitializeComponent();
            ReadConfigFile();
            UpdateShootListBox();
            Directory.SetCurrentDirectory(config[wsIndex].Workspace);
        }

        private void ReadConfigFile()
        {
            string data = File.ReadAllText(src.Command.Config.ConfigLocation());

            config = JsonConvert.DeserializeObject<List<Config>>(data);

            foreach (var c in config)
            {
                comboWorkspace.Items.Add(c.Workspace);
            }

            comboWorkspace.SelectedIndex = 0;
            wsIndex = comboWorkspace.SelectedIndex;

            config[wsIndex].Index = wsIndex;
        }

        private void btnNewShoot_Click(object sender, EventArgs e)
        {
            FormShoot f = new FormShoot(this);
            f.Show();
        }

        public void UpdateBaseListBox()
        {
            if(lbShoot.Text != string.Empty)
            {
                string basePath = Flow.BaseDirectory(config[wsIndex], lbShoot.Text);

                Directory.SetCurrentDirectory(basePath);

                string editedPath = Flow.EditedDirectory(config[wsIndex], lbShoot.Text);
                string selectionPath = Flow.SelectionDirectory(config[wsIndex], lbShoot.Text);
                string previewPath = Flow.PreviewDirectory(config[wsIndex], lbShoot.Text);
                string instagramPath = Flow.InstagramDirectory(config[wsIndex], lbShoot.Text);

                ListBoxFiles(lbPreview, previewPath, lstPreview);
                ListBoxFiles(lbEdited, editedPath, lstEdited);
                ListBoxFiles(lbSelection, selectionPath, lstSelection);
                ListBoxFiles(lbInstagram, instagramPath, lstInstagram);

                string pathPreview = Flow.PreviewDirectory(config[wsIndex], lbShoot.Text);
                int fileCount = Directory.GetFiles(pathPreview, "*.*", SearchOption.AllDirectories).Length;

                if (fileCount == 0)
                {
                    btnConvert.Enabled = true;
                }
            }
        }

        private void ListBoxFiles(ListBox lb, string path, List<string> lst)
        {
            string[] files = Helper.SortPicturesByCreationTime(path);

            lst.Clear();

            lb.Items.Clear();

            foreach (var file in files)
            {
                lb.Items.Add(Picture.FileName(file));

                if (Picture.Extension(file) == Extension.NEF) lst.Add(Picture.Preview(config[wsIndex], file));
                else lst.Add(file);
            }
        }

        public void UpdateShootListBox()
        {
            lbShoot.Items.Clear();

            // Get a list of all subdirectories  
            var dirs = from dir in
                Directory.EnumerateDirectories(config[wsIndex].Workspace)
                       select dir;

            foreach (var dir in dirs)
            {
                lbShoot.Items.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DisableButtons();

            if (!bgwConvert.IsBusy)
            {
                bgwConvert.RunWorkerAsync();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DisableButtons();

            if (!bgwBackup.IsBusy)
            {
                bgwBackup.RunWorkerAsync();
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            DisableButtons();

            if (!bgwRename.IsBusy)
            {
                bgwRename.RunWorkerAsync();
            }
        }

        private void EnableButtons()
        {
            btnBackup.Enabled = true;
            btnRename.Enabled = true;
            btnConvert.Enabled = true;
        }

        private void DisableButtons()
        {
            btnBackup.Enabled = false;
            btnRename.Enabled = false;
            btnConvert.Enabled = false;
        }

        private void ResetProgressBar()
        {
            cpProcess.Visible = false;
            cpProcess.Value = 0;
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

                        src.Command.Base.Backup(config[wsIndex].Index, file);
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
            cpProcess.Visible = true;
            lblProcess.Text = e.UserState.ToString();
            cpProcess.Value = e.ProgressPercentage;
            cpProcess.Update();
        }

        private void bgwBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButtons();
            ResetProgressBar();
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

                        src.Command.Base.Convert(config[wsIndex].Index, file.ToString(), 50);
                    }
                }
            }

            catch (Exception ex)
            {
                bgwConvert.CancelAsync();
            //    Console.WriteLine(ex);
            }
        }

        private void bgwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            cpProcess.Visible = true;
            lblProcess.Text = e.UserState.ToString();
            cpProcess.Value = e.ProgressPercentage;
        }

        private void bgwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateBaseListBox();
            EnableButtons();
            ResetProgressBar();
            btnConvert.Enabled = false;
        }

        private void bgwRename_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = 1;

            try
            {
                Directory.GetCurrentDirectory();

                string cwd = Directory.GetCurrentDirectory();
                int count = Directory.GetFiles(cwd, "*.*", SearchOption.TopDirectoryOnly).Length;

                string[] files = Helper.SortPicturesByCreationTime(cwd);

                foreach (var file in files)
                {
                    if (!bgwRename.CancellationPending)
                    {
                        int procent = index++ * 100 / count;
                        bgwRename.ReportProgress(procent, $"Renaming: {index - 1}/{count}");

                        src.Command.Base.Rename(config[wsIndex].Index, index, file.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                bgwRename.CancelAsync();
            //    Console.WriteLine(ex);
            }
        }

        private void bgwRename_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            cpProcess.Visible = true;
            lblProcess.Text = e.UserState.ToString();
            cpProcess.Value = e.ProgressPercentage;
        }

        private void bgwRename_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateBaseListBox();
            EnableButtons();
            ResetProgressBar();
            Update();
        }

        private void lbShoot_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBaseListBox();
        }

        private void lbPreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPreview.Text != string.Empty)
            {
                string PreviewPathSelectedFile = Picture.Preview(config[wsIndex], lbPreview.Text);

                string x = Picture.Extension(PreviewPathSelectedFile);

                if (File.Exists(PreviewPathSelectedFile))
                {
                    pbPreview.ImageLocation = PreviewPathSelectedFile;
                }

                else
                {
                //    Console.WriteLine("ooooops");
                }
            }
        }

        /// <summary>
        /// Maximize the preview image
        /// </summary>
        private void pbPreview_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(config[wsIndex], pbPreview.ImageLocation, lstPreview);
                f.Show();
            }
            catch (Exception ee)
            {
            //    Console.WriteLine(ee);
            }
        }

        private void lbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSelection.Text != string.Empty)
            {
                if (radioSingle.Checked == true)
                {
                    pbSelection.ImageLocation = Picture.Preview(config[wsIndex], lbSelection.Text);
                }

                else
                {
                    string selectionPathSelectedFile = Picture.Preview(config[wsIndex], lbSelection.Text);
                    string EditedSelectedFile = Picture.Edited(config[wsIndex], lbSelection.Text);

                    if (File.Exists(selectionPathSelectedFile))
                    {
                        pbSelection.ImageLocation = selectionPathSelectedFile;
                        pbEdited.ImageLocation = EditedSelectedFile;
                    }

                    else
                    {
                        //Console.WriteLine("ooooops");
                    }
                }
            }
        }

        private void lbEdited_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdited.Text != string.Empty)
            {
                if (radioSingle.Checked == true)
                {
                    string PreviewPathSelectedFile = Picture.Edited(config[wsIndex], lbEdited.Text);

                    if (File.Exists(PreviewPathSelectedFile))
                    {
                        pbEdited.ImageLocation = PreviewPathSelectedFile;
                    }

                    else
                    {
                     //   Console.WriteLine("ooooops");
                    }
                }
                else
                {
                    string selectionPathSelectedFile = Picture.Preview(config[wsIndex], lbEdited.Text);
                    string EditedSelectedFile = Picture.Edited(config[wsIndex], lbEdited.Text);

                    if (File.Exists(selectionPathSelectedFile) && File.Exists(EditedSelectedFile))
                    {
                        pbSelection.Visible = false;
                        pbEdited.Visible = false;

                        pbSelection.ImageLocation = selectionPathSelectedFile;
                        pbEdited.ImageLocation = EditedSelectedFile;

                        pbSelection.Visible = true;
                        pbEdited.Visible = true;
                    }

                    else
                    {
                     //   Console.WriteLine("ooooops");
                    }
                }
            }
        }

        /// <summary>
        /// Maximize the preview image
        /// </summary>
        private void pbSelection_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(config[wsIndex], pbSelection.ImageLocation, lstSelection);
                f.Show();
            }

            catch (Exception ee)
            {
             //   Console.WriteLine(ee);
            }
        }

        /// <summary>
        /// Maximize the preview image
        /// </summary>
        private void pbEdited_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(config[wsIndex], pbEdited.ImageLocation, lstEdited);
                f.Show();
            }

            catch(Exception ee)
            {
             //   Console.WriteLine(ee);
            }
        }

        private void openCurrentDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string shoot = Shoot.ShootName(config[wsIndex], Directory.GetCurrentDirectory());
                string workspace = config[wsIndex].Workspace;

                src.Command.GUI.Explorer(Path.Combine(workspace, shoot));
            }
            catch (Exception)
            {
                MessageBox.Show("There is no selected shoot");
            }
        }

        private void lbSelection_DoubleClick(object sender, EventArgs e)
        {
            if (lbSelection.Text != string.Empty)
            {
                string selectionPathSelectedFile = Picture.Base(config[wsIndex], lbSelection.Text);

                src.Command.GUI.EditingSoftware(selectionPathSelectedFile);
            }
        }

        private void lbEdited_DoubleClick(object sender, EventArgs e)
        {
            if (lbEdited.Text != string.Empty)
            {
                string selectionPathSelectedFile = Picture.Editing(config[wsIndex], lbEdited.Text);

                if (File.Exists(selectionPathSelectedFile))
                {
                    src.Command.GUI.EditingSoftware(selectionPathSelectedFile);
                }

                else
                {
                    MessageBox.Show($"{lbEdited.Text} has not been edited yet.");
                }
            }
        }

        private void VersionTSMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(src.Command.Config.ScriptVersion());
        }

        private void OpenConfigFileTStripMenuItem_Click(object sender, EventArgs e)
        {
            src.Command.Config.OpenConfigFile();
        }

        private void lbSelection_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
                lbSelection.Items.Add(e.Data.GetData(DataFormats.Text));
            }
        }

        private void lbSelection_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        /// <summary>
        /// Maximize the preview image
        /// </summary>
        private void pbInstagram_Click(object sender, EventArgs e)
        {
            try
            {
                FormPreview f = new FormPreview(config[wsIndex], pbInstagram.ImageLocation, lstInstagram);
                f.Show();
            }

            catch(Exception ee)
            {
             //   Console.WriteLine(ee);
            }
        }

        private void lbInstagram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbInstagram.Text != string.Empty)
            {
                string instagramPathSelectedFile = Picture.Instagram(config[wsIndex], lbInstagram.Text);

                if (File.Exists(instagramPathSelectedFile))
                {
                    pbInstagram.ImageLocation = instagramPathSelectedFile;
                }

                else
                {
                  //  Console.WriteLine("ooooops");
                }
            }
        }

        private void lbEdited_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                string selectionPathSelectedFile = Picture.Editing(config[wsIndex], lbEdited.Text);

                if (File.Exists(selectionPathSelectedFile))
                {
                    // Temporary
                    string prog = @"C:\Program Files\Adobe Lightroom Classic CC\Lightroom.exe";
                    Shell.Execute(prog, string.Empty);
                }

                else
                {
                    MessageBox.Show($"{lbEdited.Text} has not been edited yet.");
                }
            }

            // Open the edited flow in explorer and open the google photo's website
            else if (e.KeyCode == Keys.U)
            {
                try
                {
                    string shoot = Shoot.ShootName(config[wsIndex], Directory.GetCurrentDirectory());
                    string workspace = config[wsIndex].Edited;

                    src.Command.GUI.Explorer(Path.Combine(config[wsIndex].Workspace, shoot, workspace));
                }
                catch (Exception)
                {
                    MessageBox.Show("There is no selected shoot");
                }

                src.Command.GUI.OpenWebsite("https://photos.google.com/albums?hl=nl");
            }

            else if (e.KeyCode == Keys.T)
            {
                FormCrop f = new FormCrop(this, config[wsIndex], Picture.Edited(config[wsIndex], lbEdited.Text));
                f.Show();
            }

            else if (e.KeyCode == Keys.Delete)
            {
                string editedPath = Picture.Edited(config[wsIndex], lbEdited.Text);

                Helper.DeletePicture(this, editedPath, true);
            }
        }

        private void lbPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                string previewPathSelectedFile = Picture.Base(config[wsIndex], lbPreview.Text);
                string selectionPathSelectedFile = Picture.Selection(config[wsIndex], lbPreview.Text);

                lbSelection.Items.Add(Picture.FileName(selectionPathSelectedFile));

                File.Copy(previewPathSelectedFile, selectionPathSelectedFile);
            }

            else if (e.KeyCode == Keys.Delete)
            {
                string previewPath = Picture.Preview(config[wsIndex], lbPreview.Text);
                string basePath = Picture.Base(config[wsIndex], lbPreview.Text);

                Helper.DeletePicture(this, basePath, true);
                Helper.DeletePicture(this, previewPath);
            }
        }

        private void lbInstagram_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.U)
            {
                try
                {
                    string shoot = Shoot.ShootName(config[wsIndex], Directory.GetCurrentDirectory());
                    string workspace = config[wsIndex].Instagram;

                    src.Command.GUI.Explorer(Path.Combine(config[wsIndex].Workspace, shoot, workspace));
                }
                catch (Exception)
                {
                    MessageBox.Show("There is no selected shoot");
                }

                src.Command.GUI.OpenWebsite("https://photos.google.com/albums?hl=nl");
            }

            else if(e.KeyCode == Keys.Delete)
            {
                string instagramPath = Picture.Instagram(config[wsIndex], lbInstagram.Text);
                Helper.DeletePicture(this, instagramPath);
            }
        }

        private void lbSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                string selectionPath = Picture.Selection(config[wsIndex], lbSelection.Text);

                Helper.DeletePicture(this, selectionPath);
            }
        }

        private void comboWorkspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            wsIndex = comboWorkspace.SelectedIndex;
            config[wsIndex].Index = wsIndex;
            UpdateShootListBox();
        }
    }
}
