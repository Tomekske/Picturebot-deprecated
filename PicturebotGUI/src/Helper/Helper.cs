using Picturebot.src.POCO;
using PicturebotGUI.src.POCO;
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
    /// Static class which has helper methods
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Sort pictures in a directory by creation time
        /// </summary>
        /// <param name="path">Path to directory where the pictures are stored</param>
        /// <returns></returns>
        public static string[] SortPicturesByLastWriteTime(string path)
        {
            string[] files = Directory.GetFiles(path);

            DateTime[] creationTimes = new DateTime[files.Length];

            for (int i = 0; i < files.Length; i++)
                creationTimes[i] = new FileInfo(files[i]).LastWriteTime;

            return files;
        }
    }
}
