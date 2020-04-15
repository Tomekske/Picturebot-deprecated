using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Enums
{
    /// <summary>
    /// String enum with common used external programs
    /// </summary>
    public static class External
    {
        /// <summary>
        /// The explorer command line program
        /// </summary>
        public static string Explorer { get { return "explorer"; } }
        /// <summary>
        /// Path to the affinity program
        /// </summary>
        public static string Affinity {  get { return @"C:\Program Files\Affinity\Affinity Photo\Photo.exe"; } }
        /// <summary>
        /// Path to the Luminar 4 program
        /// </summary>
        public static string Luminar { get { return @"C:\Program Files\Skylum\Luminar 4\Luminar 4.exe"; } }
        /// <summary>
        /// The imageMagick command line program
        /// </summary>
        public static string Magick { get { return "magick"; } }
    }
}
