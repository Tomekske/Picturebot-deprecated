using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Enums
{
    /// <summary>
    /// String enum with workflow values
    /// </summary>
    public static class Workflow
    {
        /// <summary>
        /// Contains the base flow value: RAW
        /// </summary>
        public static string Baseflow { get { return "RAW"; } }
        /// <summary>
        /// Contains the preview flow value: Preview
        /// </summary>
        public static string Preview { get { return "Preview"; } }
        /// <summary>
        /// Contains the backup flow value: Backup
        /// </summary>
        public static string Backup { get { return "Backup"; } }
        /// <summary>
        /// Contains the selection flow value: Selection
        /// </summary>
        public static string Selection { get { return "Selection"; } }
        /// <summary>
        /// Contains the edited flow value: Edited
        /// </summary>
        public static string Edited { get { return "Edited"; } }
        /// <summary>
        /// Contains the editing flow value: Affinity
        /// </summary>
        public static string Editing { get { return "Affinity"; } }
        /// <summary>
        /// Contains the instagram flow value: Instagram
        /// </summary>
        public static string Instagram { get { return "Instagram"; } }
    }
}
