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
        /// List of most common raw picture format files
        /// </summary>
        public static List<string> RAW { get { return new List<string>() { ".K25", ".CR", ".CR2", ".CR3", ".ARI", ".ARW", ".EIP", ".NRW", ".RWZ", ".RW2", ".NEF", ".RAF", ".RAW", ".DCR", ".DNG", ".SRF", ".3FR", ".MEF", ".FFF", ".MOS", ".MFW", ".CRW", ".BAY", ".ORF", ".SR2", ".SRW", ".J6I", ".RWL", ".CS1", ".KDC", ".X3F", ".ERF", ".MRW", ".IIQ", ".PEF", ".CXI" }; } }
        /// <summary>
        /// List of most common compressed picture formats
        /// </summary>
        public static List<string> Compressed { get { return new List<string>() { ".jpg", ".jpeg", ".png", ".gif", ".tif", ".tiff", ".bmp" }; } }
        /// <summary>
        /// Picture with a NEF extension
        /// </summary>
        public static string NEF { get { return ".NEF"; } }
        /// <summary>
        /// Picture with a JPG extension
        /// </summary>
        public static string JPG { get { return ".jpg"; } }
        /// <summary>
        /// An Affinity file extension 
        /// </summary>
        public static string AFPHOTO { get { return ".afphoto"; } }
    }
}
