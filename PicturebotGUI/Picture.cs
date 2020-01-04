using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PicturebotGUI
{
    public static class Picture
    {
        public static string Base(Config config, string file)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(file), config.BaseFlow, $"{FileNameWithoutExtension(file)}.NEF");
        }

        /// <summary>
        /// Convert path to a backup path
        /// </summary>
        /// <param name="config"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Backup(Config config, string file)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(file), config.Backup, $"{FileNameWithoutExtension(file)}.NEF");
        }

        /// <summary>
        /// Convert path to an edit path
        /// </summary>
        /// <param name="config"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Edited(Config config, string file)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(file), config.Edited, $"{FileNameWithoutExtension(file)}.jpg");
        }

        public static string Editing(Config config, string file)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(file), config.Editing, $"{FileNameWithoutExtension(file)}.afphoto");
        }

        public static string Selection(Config config, string file)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(file), config.Selection, $"{FileNameWithoutExtension(file)}.NEF");
        }

        public static string Preview(Config config, string file)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(file), config.Preview, $"{FileNameWithoutExtension(file)}.jpg");
        }

        public static string Instagram(Config config, string file)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(file), config.Instagram, $"{FileNameWithoutExtension(file)}.jpg");
        }

        public static string FileName(string file)
        {
            return Path.GetFileName(file);
        }

        public static string FileNameWithoutExtension(string file)
        {
            return Path.GetFileNameWithoutExtension(file);
        }

        public static string Extension(string file)
        {
            return Path.GetExtension(file);
        }

        public static string Index(string file)
        {
            try
            {
                Regex re = new Regex(@"[a-zA-z]+_\d+-\d+-\d+_(\d+).[a-zA-Z]+");
                string fileName = FileName(file);
                Match match = re.Match(fileName);

                return match.Groups[1].Value;
            }
            catch (Exception ee)
            {

                Console.WriteLine(ee.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Obtain full file path to a certain file
        /// </summary>
        /// <param name="file">Filename (file.extension)</param>
        /// <returns>Returns the full path of the file</returns>
        public static string FullPath(string file)
        {
            return Path.GetFullPath(file);
        }
    }
}
