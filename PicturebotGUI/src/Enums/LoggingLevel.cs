using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Enums
{
    /// <summary>
    /// String enum with debug logging levels
    /// </summary>
    public static class LoggingLevel
    {
        /// <summary>
        /// Debug logging level
        /// </summary>
        public static string Debug { get { return "DEBUG"; } }
        /// <summary>
        /// Error logging level
        /// </summary>
        public static string Error { get { return "ERROR"; } }
    }
}
