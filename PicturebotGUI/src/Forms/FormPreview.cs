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
using PicturebotGUI.src.POCO;

namespace PicturebotGUI
{
    public partial class FormPreview : Form
    {
        private int _amountOfPictures = 0;
        private int _index = 0;

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

            _index = index;

            pbPicture.ImageLocation = listPictures[_index].Absolute;

            _listPictures = listPictures;
            _amountOfPictures = listPictures.Count;

            UpdateMetaData(listPictures[_index].Absolute);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPreview_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: _index -= 1; UpdatePicture(); break;
                case Keys.D: _index += 1; UpdatePicture(); break;
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
            string msg = $"{_index + 1}/{_amountOfPictures}";

            this.Text = pbPicture.ImageLocation;
            lblIndex.Text = msg;
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

            if(Guard.Filesystem.IsPath(_listPictures[_index].Absolute))
            {
                pbPicture.ImageLocation = _listPictures[_index].Absolute;
                _log.Info($"PictureBox pbPicture: displayed \"{_listPictures[_index].Absolute}\"");
            }
            else
            {
                _log.Error($"PictureBox pbPicture: unable to display \"{_listPictures[_index].Absolute}\"");
            }

            UpdateMetaData(_listPictures[_index].Absolute);
        }
    }
}
