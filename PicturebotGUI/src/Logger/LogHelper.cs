using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace PicturebotGUI.src.Logger
{
    public static class LogHelper
    {
        /// <summary>
        /// Helper to obtain the filename where the logger was called from
        /// </summary>
        /// <param name="filename">Path tho the filename</param>
        /// <returns>Full path to the file where the logger was called from</returns>
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
