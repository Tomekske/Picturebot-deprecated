using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicturebotGUI.src.Enums;

namespace PicturebotGUI.src.Command
{
    /// <summary>
    /// Static class which implements commands to interact with shoots
    /// </summary>
    static public class Shoot
    {
        /// <summary>
        /// Create a new shoot within a workspace
        /// </summary>
        /// <param name="index">Workspace index</param>
        /// <param name="name">Name of the shoot</param>
        /// <param name="date">Date of the shoot</param>
        public static void NewShoot(int index, string name, string date)
        {
            Shell.Execute(External.Picturebot, $"shoot -n {index} \"{name}\" {date}");
        }
    }
}
