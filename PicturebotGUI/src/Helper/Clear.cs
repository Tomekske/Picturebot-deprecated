using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.Helper
{
    /// <summary>
    /// Static class which implements methods to clear, update GUI objects
    /// </summary>
    public static class Clear
    {
        /// <summary>
        /// Get pictures from the work flow and add them to the associated listBox 
        /// </summary>
        /// <param name="config">Configuration object</param>
        /// <param name="listBox">ListBox object containing the pictures</param>
        /// <param name="pictureBox">PictureBox object displaying the selected picture</param>
        /// <param name="listPictures">List of pictures containing the picture meta data</param>
        /// <param name="shoot">The current shoot name</param>
        /// <param name="workflow">The work flow that is getting edited</param>
        public static void ClearAndUpdateFlow(Config config, ListBox listBox, PictureBox pictureBox, List<Picture> listPictures, string shoot, string workflow)
        {
            // Get the path to the work flow
            string path = Path.Combine(config.Workspace, shoot, workflow);
            Guard.Filesystem.PathExist(path);

            // Get all the files and store them in an array sorted by last write time
            string[] files = Helper.SortPicturesByLastWriteTime(path);

            // Clear associated listBox, listPicture and pictureBox
            listBox.Items.Clear();
            listPictures.Clear();
            pictureBox.Image = null;

            // Loop-over every picture within the picture array
            for (int i = 0; i < files.Length; i++)
            {
                Picture picture = new Picture(files[i], config.Workspace, i + 1);
                // Add only the picture name to the associated listBox
                listBox.Items.Add(picture.Filename);
                // Add the picture object to the associated picture list
                listPictures.Add(picture);
            }
        }
    }
}
