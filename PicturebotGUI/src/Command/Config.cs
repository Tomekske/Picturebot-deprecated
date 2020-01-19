using PicturebotGUI.src.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Command
{
    /// <summary>
    /// Static class which implements commands to interact with the picturebot configurations
    /// </summary>
    static public class Config
    {
        /// <summary>
        /// Static method to print the picturebot's configuration file location
        /// </summary>
        public static string ConfigLocation()
        {
            return Shell.ExectutePipeOuput(External.Picturebot, "config -l");
        }
    }
}
