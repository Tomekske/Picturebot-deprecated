using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Enums
{
    /// <summary>
    /// String enum with context menu strip operations
    /// </summary>
    public class Strip
    {
        public static string Convert { get { return "Convert"; } }
        public static string Delete { get { return "Delete"; } }
        public static string Rename { get { return "Rename"; } }
        public static string Metadata { get { return "Metadata"; } }
        public static string CopyDescription { get { return "Copy description"; } }
    }
}
