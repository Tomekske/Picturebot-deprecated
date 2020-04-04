using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Enums
{
    public static class Workflow
    {
        public static string Baseflow { get { return "RAW"; } }
        public static string Preview { get { return "Preview"; } }
        public static string Backup { get { return "Backup"; } }
        public static string Selection { get { return "Selection"; } }
        public static string Edited { get { return "Edited"; } }
        public static string Editing { get { return "Affinity"; } }
        public static string Instagram { get { return "Instagram"; } }
    }
}
