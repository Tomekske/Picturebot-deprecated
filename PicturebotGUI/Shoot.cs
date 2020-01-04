using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI
{
    public static class Shoot
    {
        public static string Absolute(string file)
        {
            return Path.GetFullPath(file);
        }

        public static string ShootPath(Config config, string shoot)
        {
            return Path.Combine(config.Workspace, shoot);
        }

        public static string ShootName(Config config, string file)
        {
             return ShootPath(config, file).Split('\\')[2];
        }

        public static string ShootName(string file)
        {
            return Absolute(file).Split('\\')[2];
        }
    }
}
