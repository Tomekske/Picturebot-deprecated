using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicturebotGUI.src.POCO;

namespace PicturebotGUI
{
    static public class Flow
    {
        private static string Base(Config config, string item, string flow)
        {
            return Path.Combine(config.Workspace, Shoot.ShootName(config, item), flow);
        }
        public static string BaseDirectory(Config config, string item)
        {
            return Base(config, item, config.BaseFlow);
        }

        public static string BackupDirectory(Config config, string item)
        {
            return Base(config, item, config.Backup);
        }

        public static string EditedDirectory(Config config, string item)
        {
            return Base(config, item, config.Edited);
        }

        public static string SelectionDirectory(Config config, string item)
        {
            return Base(config, item, config.Selection);
        }

        public static string PreviewDirectory(Config config, string item)
        {
            return Base(config, item, config.Preview);
        }

        public static string EditingDirectory(Config config, string item)
        {
            return Base(config, item, config.Editing);
        }

        public static string InstagramDirectory(Config config, string item)
        {
            return Base(config, item, config.Instagram);
        }
    }
}
