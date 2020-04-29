using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Enums
{
    /// <summary>
    /// String enum with appender names used for logging
    /// </summary>
    public static class Appender
    {
        /// <summary>
        /// Property to obtain the console appender value
        /// </summary>
        public static string Console { get { return "ConsoleAppender"; } }
        /// <summary>
        /// Property to obtain the file appender value
        /// </summary>
        public static string File { get { return "FileAppender"; } }
    }
}
