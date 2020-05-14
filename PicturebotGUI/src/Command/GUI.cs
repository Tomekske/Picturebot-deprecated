using PicturebotGUI.src.Enums;
using PicturebotGUI.src.Logger;
using PicturebotGUI.src.Command;
using System.Diagnostics;
using System.Windows.Forms;

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
            log4net.ILog log = LogHelper.GetLogger();

            if (Guard.Filesystem.IsPath(path))
            {
                Shell.Execute(External.Explorer, path);
                log.Info($"{External.Explorer}: \"{path}\" opened");
            }

            else
            {
                log.Error($"{External.Explorer}: unable to open \"{path}\"");
            }
        }

        /// <summary>
        /// Static method to open a RAW image with editing software
        /// </summary>
        /// <param name="path">Path to the image</param>
        public static void EditingSoftware(string path)
        {
            log4net.ILog log = LogHelper.GetLogger();

            if (Guard.Filesystem.IsPath(path))
            {
                Shell.Execute(External.Affinity, $"\"{path}\"");
                log.Info($"{External.Affinity}: \"{path}\" opened");
            }
            else
            {
                log.Error($"{External.Affinity}: Unable to open the \"{path}\" file");
            }
        }

        /// <summary>
        /// Static method to open a specified URL in the user's default browser
        /// </summary>
        /// <param name="url">URL to the website</param>
        public static void OpenWebsite(string url)
        {
            log4net.ILog log = LogHelper.GetLogger();

            try
            {
                Process.Start(url);
            }
            catch (System.Exception e)
            {
                MessageBox.Show("URL to website does not exist");
                log.Error("URL to website does not exist", e);
            }
        }

        /// <summary>
        /// Static method to open a specified file in the user's default editor
        /// </summary>
        /// <param name="path">Path to the file</param>
        public static void OpenFile(string path)
        {
            Process.Start(path);
        }

        /// <summary>
        /// Convert a RAW image to an JPG output
        /// </summary>
        /// <param name="source">Path to the picture that will get converted</param>
        /// <param name="output">Picture output path</param>
        public static void Convert(string source, string output)
        {
            log4net.ILog log = LogHelper.GetLogger();

            // magick convert "<path>" -quality <quality>% -verbose "<outputPath>"
            string command = $"convert \"{source}\" -quality 50 -verbose \"{output}\"";

            if (Guard.Filesystem.IsPath(source))
            {
                Shell.ExecuteNoThread(External.Magick, command);
                log.Info($"{External.Magick}: \"{command}\"");
            }

            else
            {
                log.Error($"{External.Magick}: unable to convert \"{command}\"");
            }
        }
    }
}
