using PicturebotGUI.src.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Command
{
    /// <summary>
    /// Static class which implements commands to interact system calls within the GUI application
    /// </summary>
    static public class GUI
    {
        /// <summary>
        /// Static method to open the windows system explorer
        /// </summary>
        /// <param name="path">Path to the image</param>
        public static void Explorer(string path)
        {
            Shell.Execute(External.Explorer, path);
        }

        /// <summary>
        /// Static method to open a RAW image with editing software
        /// </summary>
        /// <param name="path">Path to the image</param>
        public static void EditingSoftware(string path)
        {
            Shell.Execute(External.Affinity, $"\"{path}\"");
        }

        /// <summary>
        /// Static method to open a specified URL in the user's default browser
        /// </summary>
        /// <param name="url"></param>
        public static void OpenWebsite(string url)
        {
            Process.Start(url);
        }

        /// <summary>
        /// Convert a RAW image to an JPG output
        /// </summary>
        /// <param name="source">Path to the picture that will get converted</param>
        /// <param name="output">Picture output path</param>
        public static void Convert(string source, string output)
        {
            // magick convert "<path>" -quality <quality>% -verbose "<outputPath>"
            Shell.ExecuteNoThread(External.Magick, $"convert \"{source}\" -quality 50 -verbose \"{output}\"");
        }
    }
}
