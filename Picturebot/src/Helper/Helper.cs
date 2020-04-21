using Picturebot.src.Logger;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Picturebot.src.Helper
{
    /// <summary>
    /// Static class which has helper methods
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Sort pictures in a directory by last write time
        /// </summary>
        /// <param name="path">Path to directory where the pictures are stored</param>
        /// <returns></returns>
        public static string[] GetFilesOrderByDescendingLastWriteTime(string path)
        {
            string[] pictures = { };

            log4net.ILog log = LogHelper.GetLogger();

            try
            {
                pictures = Directory.GetFiles(path, "*").OrderByDescending(d => new FileInfo(d).LastWriteTime).Reverse().ToArray();

                log.Info($"Helper GetFilesOrderByDescending: Successfully fetched files from \"{path}\"");
                return pictures;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error($"Helper GetFilesOrderByDescending: unable to fetch files from \"{path}\"", e);
                MessageBox.Show(e.Message);
            }

            return pictures;
        }

        /// <summary>
        /// Get all the files without sorting them
        /// </summary>
        /// <param name="path">Path to directory where the pictures are stored</param>
        /// <returns></returns>
        public static string[] GetFiles(string path)
        {
            string[] pictures = { };

            log4net.ILog log = LogHelper.GetLogger();

            try
            {
                pictures = Directory.GetFiles(path, "*");

                log.Info($"Helper GetFilesOrderByDescending: Successfully fetched files from \"{path}\"");
                return pictures;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error($"Helper GetFilesOrderByDescending: unable to fetch files from \"{path}\"", e);
                MessageBox.Show(e.Message);
            }

            return pictures;
        }
    }
}
