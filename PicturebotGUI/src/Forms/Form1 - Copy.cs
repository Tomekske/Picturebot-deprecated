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
using PicturebotGUI.src.Background;
using Convert = PicturebotGUI.src.Background.Convert;
using Newtonsoft.Json.Linq;
using PicturebotGUI.src.Database;
using Picturebot;
using Picturebot.src.POCO;

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
        private FormLoading _formLoading = new FormLoading();
        private Rename _bgwRename;
        private Convert _bgwConvert;
        private MassRename _bgwMassRename;
        private string _shoot = string.Empty;
        private string dllPath = Directory.GetCurrentDirectory();

        public Workspace Ws { get; set; }

        public Picturebot.Shoot shoot { get; set; }
        public Form1()
        {
            InitializeComponent();
            ReadConfigFile();
            UpdateShootListBox();
            Directory.SetCurrentDirectory(config[wsIndex].Workspace);
            Ws = new Workspace(config);
            shoot = new Picturebot.Shoot(config[wsIndex]);
        }  

        #region ListBoxes
        #region Click
        private void lbShoot_SelectedIndexChanged(object sender, EventArgs e)
        {
            _shoot = lbShoot.Text;
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

        private void lbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSelection.Text != string.Empty)
            {
                pbSelection.ImageLocation = Picture.Preview(config[wsIndex], lbSelection.Text);
            }
        }

        private void lbEdited_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdited.Text != string.Empty)
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
                Directory.SetCurrentDirectory(Path.Combine(config[wsIndex].Workspace, _shoot, config[wsIndex].BaseFlow));
                string PreviewPathSelectedFile = Picture.Edited(config[wsIndex], lbEdited.Text);

                if (File.Exists(PreviewPathSelectedFile))
                {
                    pbEdited.ImageLocation = PreviewPathSelectedFile;
                }
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
        #endregion Click

        #region DubbelClick
        private void lbSelection_DoubleClick(object sender, EventArgs e)
        {
            if (lbSelection.Text != string.Empty)
            {
                int selected = lbSelection.SelectedIndex;
                string selectionPathSelectedFile = Picture.Base(config[wsIndex], lbSelection.Text);

                src.Command.GUI.EditingSoftware(selectionPathSelectedFile);

                UpdateBaseListBox();

                lbSelection.SelectedIndex = selected;

            }
        }

        private void lbEdited_DoubleClick(object sender, EventArgs e)
        {
            if (lbEdited.Text != string.Empty)
            {
                int selected = lbEdited.SelectedIndex;
                string selectionPathSelectedFile = Picture.Editing(config[wsIndex], lbEdited.Text);

                if (File.Exists(selectionPathSelectedFile))
                {
                    src.Command.GUI.EditingSoftware(selectionPathSelectedFile);

                    UpdateBaseListBox();

                    lbEdited.SelectedIndex = selected;
                }

                else
                {
                    MessageBox.Show($"{lbEdited.Text} has not been edited yet.");
                }
            }
        }

        #endregion DubbelClick

        #region Keys
        private void lbPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                try
                {
                    string previewPathSelectedFile = Picture.Base(config[wsIndex], lbPreview.Text);
                    string selectionPathSelectedFile = Picture.Selection(config[wsIndex], lbPreview.Text);

                    lbSelection.Items.Add(Picture.FileName(selectionPathSelectedFile));

                    File.Copy(previewPathSelectedFile, selectionPathSelectedFile);
                }

                catch (Exception ee)
                {
                    Console.WriteLine("Selection already exists");
                }
            }

            else if (e.KeyCode == Keys.Delete)
            {
                string previewPath = Picture.Preview(config[wsIndex], lbPreview.Text);
                string basePath = Picture.Base(config[wsIndex], lbPreview.Text);

                int item = lbPreview.SelectedIndex;

                Console.WriteLine(item);
                Helper.DeletePictureBasePreview(this, config[wsIndex], basePath, true);

                lbPreview.SelectedIndex = item;
            }
        }

        private void lbInstagram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U)
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

            else if (e.KeyCode == Keys.Delete)
            {
                string instagramPath = Picture.Instagram(config[wsIndex], lbInstagram.Text);
                Helper.DeletePicture(this, instagramPath);
            }
        }

        private void lbSelection_KeyDown(object sender, KeyEventArgs e)
        {
            int item = lbSelection.SelectedIndex;


            if (e.KeyCode == Keys.Delete)
            {
                int count = lbSelection.Items.Count;

                if (count != 0)
                {
                    string selectionPath = Picture.Selection(config[wsIndex], lbSelection.Text);

                    Helper.DeletePicture(this, selectionPath);

                    if (item == count - 1)
                    {
                        lbSelection.SelectedIndex = item - 1;
                    }

                    else
                    {
                        lbSelection.SelectedIndex = item;
                    }
                }
            }

            else if (e.KeyCode == Keys.L)
            {
                string selectionPathSelectedFile = Picture.Base(config[wsIndex], lbSelection.Text);

                if (File.Exists(selectionPathSelectedFile))
                {
                    Shell.Execute(External.Luminar, $"\"{selectionPathSelectedFile}\"");

                    UpdateBaseListBox();
                    lbSelection.SelectedIndex = item;
                }

                else
                {
                    MessageBox.Show($"{lbEdited.Text} has not been edited yet.");
                }
            }
        }

        private void lbEdited_KeyDown(object sender, KeyEventArgs e)
        {
            int selected = lbEdited.SelectedIndex;

            if (e.KeyCode == Keys.C)
            {

                string selectionPathSelectedFile = Picture.Editing(config[wsIndex], lbEdited.Text);

                if (File.Exists(selectionPathSelectedFile))
                {
                    // Temporary
                    string prog = @"C:\Program Files\Adobe Lightroom Classic CC\Lightroom.exe";
                    Shell.Execute(prog, string.Empty);

                    UpdateBaseListBox();

                    lbEdited.SelectedIndex = selected;
                }

                else
                {
                    MessageBox.Show($"{lbEdited.Text} has not been edited yet.");
                }
            }

            else if (e.KeyCode == Keys.L)
            {
                string selectionPathSelectedFile = Picture.Edited(config[wsIndex], lbEdited.Text);

                if (File.Exists(selectionPathSelectedFile))
                {
                    Shell.Execute(External.Luminar, $"\"{selectionPathSelectedFile}\"");
                    UpdateBaseListBox();

                    lbEdited.SelectedIndex = selected;
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

            else if (e.Control && e.KeyCode == Keys.D)
            {
                string filename = lbEdited.SelectedItem.ToString();

                Metadata m;
                string pathToFile = Path.Combine(config[wsIndex].Workspace, _shoot, config[wsIndex].Edited, filename);
                Directory.SetCurrentDirectory(dllPath);

                m = SqliteDataAccess.LoadMetadata(pathToFile);
                Console.WriteLine(m.Description);
                Clipboard.SetText(m.Description);
            }
        }

        #endregion Keys

        #region MenuStrip
        #region RightClick
        private void lbShoot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add(Strip.Convert);
                menu.Items.Add(Strip.Rename);
                menu.Items.Add(Strip.Delete);

                menu.Show(lbShoot, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }

        private void lbEdited_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menuEdited = new ContextMenuStrip();
                menuEdited.Items.Add(Strip.Metadata);
                menuEdited.Items.Add(Strip.CopyDescription);

                menuEdited.Show(lbEdited, new Point(e.X, e.Y));
                menuEdited.ItemClicked += MenuEdited_ItemClicked;
            }
        }
        #endregion RightClick

        #region Events
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Console.WriteLine(e.ClickedItem);
            string shootName = lbShoot.SelectedItem.ToString();
            string shootPath = Shoot.ShootPath(config[wsIndex], shootName);

            Directory.SetCurrentDirectory(config[wsIndex].Workspace);

            if (e.ClickedItem.Text == Strip.Delete)
            {
                var result = MessageBox.Show($"Are you sure to delete \"{shootPath}\" ?", "Confirm Delete!!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    shoot.Remove(shootPath);
                    UpdateShootListBox();
                    // Refresh flow listboxes
                    ClearListBoxes();
                }
            }

            else if (e.ClickedItem.Text == Strip.Rename)
            {
                Picturebot.Flow flow = new Picturebot.Flow(config[wsIndex]);
                flow.Rename(_shoot);
                UpdateBaseListBox();
                UpdateShootListBox();
                /*                FormRenameShoot formRenameshoot = new FormRenameShoot(_shoot);

                                formRenameshoot.ShowDialog();


                                string newShoot = $"{formRenameshoot.ShootName} {formRenameshoot.ShootDate}";

                                var flows = config[wsIndex].Workflow;

                                string newName = newShoot.Replace(" ", "_");

                                string test = shootName.Replace(" ", "_");

                                Console.WriteLine($"HIER: {newName}");

                                foreach (var flow in flows)
                                {
                                    string pathToFlow = Path.Combine(config[wsIndex].Workspace, shootName, flow);
                                    //Console.WriteLine(pathToFlow);

                                    if (Directory.Exists(pathToFlow) && flow != config[wsIndex].Backup)
                                    {
                                        int count = Directory.GetFiles(pathToFlow).Length;

                                        if (count != 0)
                                        {
                                            var files = Directory.GetFiles(pathToFlow);

                                            foreach (var file in files)
                                            {

                                                string filename = Path.GetFileName(file);
                                                string[] tokens = filename.Split('_');

                                                string order = tokens[tokens.Length - 1];

                                                string full = Path.Combine(config[wsIndex].Workspace, shootName, flow, $"{newName}_{order}");

                                                File.Move(file, full);
                                            }
                                        }
                                    }
                                }

                                Console.WriteLine($"{Path.Combine(config[wsIndex].Workspace, _shoot)} -> {Path.Combine(config[wsIndex].Workspace, newShoot)}");
                                UpdateBaseListBox();
                                UpdateShootListBox();
                                Directory.SetCurrentDirectory(config[wsIndex].Workspace);
                                Directory.Move(Path.Combine(Path.Combine(config[wsIndex].Workspace, _shoot)), Path.Combine(config[wsIndex].Workspace, newShoot));
                                UpdateShootListBox();
                */
            }

            else if (e.ClickedItem.Text == Strip.Convert)
            {
                _formLoading.Show();

                _bgwMassRename.Start();
            }
        }

        private void MenuEdited_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string filename = lbEdited.SelectedItem.ToString();
            string pathToFile = Path.Combine(config[wsIndex].Workspace, _shoot, config[wsIndex].Edited, filename);
            string shoot = _shoot;
            Directory.SetCurrentDirectory(dllPath);

            if (e.ClickedItem.Text == Strip.Metadata)
            {
                FormAddMetadata formAddMetadata = new FormAddMetadata();

                formAddMetadata.ShowDialog();
                Metadata meta = new Metadata(pathToFile, filename, shoot, formAddMetadata.Description);

                SqliteDataAccess.SaveMetadata(meta);

                UpdateShootListBox();
            }

            else if (e.ClickedItem.Text == Strip.CopyDescription)
            {
                Metadata m;
                pathToFile = Path.Combine(config[wsIndex].Workspace, _shoot, config[wsIndex].Edited, filename);
                Directory.SetCurrentDirectory(dllPath);

                m = SqliteDataAccess.LoadMetadata(pathToFile);
                Console.WriteLine(m.Description);
                Clipboard.SetText(m.Description);

                Directory.SetCurrentDirectory(config[wsIndex].Workspace);

            }
        }

        #endregion Evens

        #endregion MenuStrip
        #endregion ListBoxes

        #region BackgroundWorker
        #region MassRename
        private void bgwMassRename_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = Path.Combine(config[wsIndex].Workspace, _shoot, config[wsIndex].BaseFlow);
            Console.WriteLine($"{path} 1111");

            if (Directory.Exists(path))
            {
                Console.WriteLine("ERIN11111");
                Directory.SetCurrentDirectory(path);
            }
            _bgwMassRename.Work();
        }

        private void bgwMassRename_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwMassRename.Progress("Working");
        }

        private void bgwMassRename_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_formLoading.Close();
            //UpdateBaseListBox();

            _bgwConvert.Start();
        }
        #endregion MassRename

        #region Rename
        private void bgwRename_DoWork(object sender, DoWorkEventArgs e)
        {

            _bgwRename.Work();
        }

        private void bgwRename_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwRename.Progress(e.UserState.ToString());
        }

        private void bgwRename_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateBaseListBox();
            Update();

            _bgwConvert.Start();
        }

        #endregion Rename

        #region Convert
        private void bgwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            //UpdateBaseListBox();
            string path = Path.Combine(config[wsIndex].Workspace, _shoot, config[wsIndex].BaseFlow);

            if (Directory.Exists(path))
            {
                Console.WriteLine("ERIN");
                Directory.SetCurrentDirectory(path);
            }
            _bgwConvert.Work();
        }

        private void bgwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _bgwConvert.Progress(e.UserState.ToString());
        }

        private void bgwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateBaseListBox();
            _formLoading.Close();
        }
        #endregion Convert
        #endregion BackgroundWorker

        #region PictureBox
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

            catch (Exception ee)
            {
                //   Console.WriteLine(ee);
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

            catch (Exception ee)
            {
                //   Console.WriteLine(ee);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Open config file");
        }
        private void pbAddShoot_Click(object sender, EventArgs e)
        {
            FormShoot f = new FormShoot(this);
            f.Show();
        }

        #endregion PictureBox

        #region Menu
        private void OpenConfigFileTStripMenuItem_Click(object sender, EventArgs e)
        {
            src.Command.Configg.OpenConfigFile();
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

        private void VersionTSMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(src.Command.Configg.ScriptVersion());
        }
        #endregion Menu

        #region ComboBox
        private void comboWorkspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            wsIndex = comboWorkspace.SelectedIndex;
            config[wsIndex].Index = wsIndex;

            _bgwRename = new Rename(bgwRename, config[wsIndex], _formLoading);
            _bgwConvert = new Convert(bgwConvert, config[wsIndex], _formLoading);
            _bgwMassRename = new MassRename(bgwMassRename, config[wsIndex], _formLoading);

            UpdateShootListBox();
            // Refresh flow listboxes
            ClearListBoxes();

            ClearPictureBoxes();
        }
        #endregion ComboBox

        private void ReadConfigFile()
        {
            config = Picturebot.Configuration.Read();

            foreach (var c in config)
            {
                comboWorkspace.Items.Add(c.Workspace);
            }

            comboWorkspace.SelectedIndex = 0;
            wsIndex = comboWorkspace.SelectedIndex;

            config[wsIndex].Index = wsIndex;
        }

        public void UpdateBaseListBox()
        {
            if(lbShoot.Text != string.Empty)
            {
                ClearPictureBoxes();
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

        private void addWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("hier");

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine(fbd.SelectedPath);
                Ws.Add(fbd.SelectedPath);
            }
        }

        private void ClearListBoxes()
        {
            lbEdited.Items.Clear();
            lbInstagram.Items.Clear();
            lbPreview.Items.Clear();
            lbSelection.Items.Clear();
        }

        private void ClearPictureBoxes()
        {
            pbPreview.Image = null;
            pbSelection.Image = null;
            pbEdited.Image = null;
            pbInstagram.Image = null;
        }
    }   
}
