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
        /// Static method returns the picturebot's configuration file location
        /// </summary>
        /// <returns>Returns the picturebot's configuration file location</returns>
        public static string ConfigLocation()
        {
            return Shell.ExectutePipeOuput(External.Picturebot, "config -l");
        }

        /// <summary>
        /// Static method to open the configuration file
        /// </summary>
        public static void OpenConfigFile()
        {
            Shell.Execute("pb", "config -s");
        }

        /// <summary>
        /// Static method which returns the picturebot's script version
        /// </summary>
        /// <returns>Returns the picturebot's script version</returns>
        public static string ScriptVersion()
        {
            return Shell.ExectutePipeOuput("pb", "config -v");
        }
    }
}
