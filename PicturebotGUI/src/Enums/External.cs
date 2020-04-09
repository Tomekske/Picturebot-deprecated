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
        public static string Explorer { get { return "explorer"; } }
        public static string Affinity {  get { return @"C:\Program Files\Affinity\Affinity Photo\Photo.exe"; } }
        public static string Luminar { get { return @"C:\Program Files\Skylum\Luminar 4\Luminar 4.exe"; } }
        public static string Magick { get { return "magick"; } }
    }
}
