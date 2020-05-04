using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Picturebot;
using Picturebot.src.Logger;
using Picturebot.src.POCO;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.POCO;

namespace PicturebotGUI
{
    public partial class FormPreview : Form
    {
        private int _amountOfPictures = 0;
        private int _index = 0;
        private string _metadata = string.Empty;

        private List<Picture> _listPictures = new List<Picture>();

        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// Preview form constructor
        /// </summary>
        /// <param name="listPictures">Picture list containing all the pictures within a specified flow</param>
        /// <param name="index">Current selected index</param>
        public FormPreview(List<Picture> listPictures, int index)
        {
            InitializeComponent();
            pbPicture.Size = new Size(1920, 1080);

            _index = index;

            _listPictures = listPictures;
            _amountOfPictures = listPictures.Count;

            DeterminePictureBoxSizeMode();
            UpdateMetaData(listPictures[_index].Absolute);
            //1880, 1040
        }

        #region PictureBox
        #region Click
        /// <summary>
        /// Display the next picture
        /// </summary>
        private void pbNextPicture_Click(object sender, EventArgs e)
        {
            _index += 1;

            UpdatePicture();
        }

        /// <summary>
        /// Display the previous picture
        /// </summary>
        private void pbPreviousPicture_Click(object sender, EventArgs e)
        {
            _index -= 1;
            UpdatePicture();
        }
        #endregion Click
        #endregion PictureBox


        #region KeyDown
        /// <summary>
        /// Use keyboard key to display the next and the previous pictures
        /// </summary>
        private void FormPreview_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: _index -= 1; UpdatePicture(); break;
                case Keys.Left: _index -= 1; UpdatePicture(); break;
                case Keys.D: _index += 1; UpdatePicture(); break;
                case Keys.Right: _index += 1; UpdatePicture(); break;
                case Keys.Escape: this.Close(); break;
            }
        }
        #endregion KeyDown

        /// <summary>
        /// Update the meta-data in the form such as the label counter and the file name within the window title
        /// </summary>
        /// <param name="path"></param>
        private void UpdateMetaData(string path)
        {
            string counter = $"{_index + 1}/{_amountOfPictures}";

            this.Text = pbPicture.ImageLocation;
            _metadata = $"\"{pbPicture.ImageLocation}\" [{counter}]";
        }

        /// <summary>
        /// Creating a circular list to slide through the image within the list
        /// </summary>
        private void UpdatePicture()
        {
            if (_index > _amountOfPictures - 1)
            {
                _index = 0;
            }

            else if (_index < 0)
            {
                _index = _amountOfPictures - 1;
            }

            if (Guard.Filesystem.IsPath(_listPictures[_index].Absolute))
            {
                //pbPicture.ImageLocation = _listPictures[_index].Absolute;
                DeterminePictureBoxSizeMode();
                _log.Info($"PictureBox pbPicture: displayed \"{_listPictures[_index].Absolute}\"");
            }
            else
            {
                _log.Error($"PictureBox pbPicture: unable to display \"{_listPictures[_index].Absolute}\"");
            }

            UpdateMetaData(_listPictures[_index].Absolute);
        }

        /// <summary>
        /// 
        /// </summary>
        private void pbPicture_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Segoe UI", 10))
            {
                e.Graphics.DrawString(_metadata, myFont, Brushes.White, new Point(2, 2));
            }
        }

        /// <summary>
        /// Obtain the dimension of a picture
        /// </summary>
        /// <param name="picture">Picture dimension</param>
        /// <returns></returns>
        private Dimension GetDimension(Picture picture)
        {
            int width, height = 0;
            Dimension dimension;

            using (Bitmap imgage = new Bitmap(picture.Absolute))
            {
                width = imgage.Width;
                height = imgage.Height;
            }

            dimension = new Dimension(width, height);

            _log.Debug($"{dimension} - \"{picture.Absolute}\"");

            return dimension;
        }

        /// <summary>
        /// Determine the most pleasing pictureBox size mode
        /// </summary>
        private void DeterminePictureBoxSizeMode()
        {
            Dimension dimension = GetDimension(_listPictures[_index]);

            if ((dimension.Width > dimension.Height) && _listPictures[_index].Absolute.Contains(Workflow.Preview))
            {
                pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
            }

            pbPicture.LoadAsync(_listPictures[_index].Absolute);
        }
    }
}
