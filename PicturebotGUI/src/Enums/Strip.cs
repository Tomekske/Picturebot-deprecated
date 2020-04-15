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
    public static class Strip
    {
        public static string Convert { get { return "Convert"; } }
        public static string Delete { get { return "Delete"; } }
        public static string RenameShoot { get { return "Rename shoot"; } }
        public static string RenameBaseflow { get { return "Rename baseflow"; } }
        public static string Metadata { get { return "Metadata"; } }
        public static string CopyDescription { get { return "Copy description"; } }
        public static string Explorer { get { return "Open shoot in explorer"; } }
        public static string AddSelection { get { return "Add to selection"; } }
        public static string Edit { get { return "Edit with"; } }
    }
}
