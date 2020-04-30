using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Enums
{
    /// <summary>
    /// String enum with common picture extensions
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Picture with a NEF extension
        /// </summary>
        public static string NEF { get { return ".NEF"; } }
        /// <summary>
        /// Picture with a JPG extension
        /// </summary>
        public static string JPG { get { return ".jpg"; } }
        /// <summary>
        /// Picture with a JPEG extension
        /// </summary>
        public static string JPEG { get { return ".jpeg"; } }
        /// <summary>
        /// Picture with a PNG extension
        /// </summary>
        public static string PNG { get { return ".png"; } }
        /// <summary>
        /// An Affinity file extension 
        /// </summary>
        public static string AFPHOTO { get { return ".afphoto"; } }
    }
}
