using Picturebot;
using Picturebot.src.POCO;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Picturebot.src.Helper;
using PicturebotGUI.src.GUIThread;
using PicturebotGUI.src.Enums;

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

            // Clear associated listBox, listPicture and pictureBox
            listPictures.Clear();
            ThreadListBox.Clear(listBox);
            ThreadPictureBox.Clear(pictureBox);

            string[] files = { };

            // Only sort the pictures within the preview workflow
            if (workflow == Workflow.Edited || workflow == Workflow.Instagram || workflow == Workflow.Selection)
            {
                // Get all the files and store them in an array sorted by last write time
                files = Picturebot.src.Helper.Helper.GetFiles(path);
            }
            else
            {
                files = Picturebot.src.Helper.Helper.GetFilesOrderByDescendingLastWriteTime(path);
            }

            // Loop-over every picture within the picture array
            for (int i = 0; i < files.Length; i++)
            {
                Picture picture = new Picture(files[i], config.Workspace, i + 1);
                // Add only the picture name to the associated listBox
                //listBox.Items.Add(picture.Filename);
                ThreadListBox.AppendItem(listBox, picture.Filename);
                // Add the picture object to the associated picture list
                listPictures.Add(picture);
            }
        }
    }
}
