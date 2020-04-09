using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.GUIThread
{
    /// <summary>
    /// Static class which implements methods to pass label data safely to an other thread
    /// </summary>
    public static class ThreadPictureBox
    {
        /// <summary>
        /// Set an image on a specified pictureBox which is thread safe
        /// </summary>
        /// <param name="pictureBox">The specified pictureBox</param>
        /// <param name="path">The path to the image</param>
        public static void ImageLocation(PictureBox pictureBox, string path)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke((MethodInvoker)delegate ()
                {
                    ImageLocation(pictureBox, path);
                });
            }
            else
            {
                pictureBox.ImageLocation = path;
            }
        }

        /// <summary>
        /// Clear the listBox
        /// </summary>
        /// <param name="listBox">The specified listBox</param>
        public static void Clear(PictureBox pictureBox)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke((MethodInvoker)delegate ()
                {
                    Clear(pictureBox);
                });
            }
            else
            {
                pictureBox.Image = null;
            }
        }
    }
}
