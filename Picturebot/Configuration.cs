using Picturebot.src.POCO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Picturebot.Properties;
using System.IO;
using Picturebot.src.Logger;

namespace Picturebot
{
    /// <summary>
    /// Static class which implements methods to interact with the picture's bot configuration file
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Read the picturebot's configuration JSON file
        /// </summary>
        /// <returns>Config list</returns>
        public static List<Config> Read()
        {
            #if DEBUG
                // Convert byte array to a UTF8 string
                string utf = Encoding.UTF8.GetString(Resources.config);

                return JsonConvert.DeserializeObject<List<Config>>(utf);
            #else
                if (Guard.Filesystem.IsPath("config.json"))
                {
                    // Convert byte array to a UTF8 string
                    string json = File.ReadAllText("config.json");

                    return JsonConvert.DeserializeObject<List<Config>>(json);
                }

                return null;           
            #endif
        }

        /// <summary>
        /// Write the config objects to the associated JSON file
        /// </summary>
        /// <param name="config">The configuration list containing config objects</param>
        public static void Write(List<Config> config)
        {
            log4net.ILog log = LogHelper.GetLogger();

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("config.json", json);

            log.Info("Write: Data to configuration file written");
        }
        
        /// <summary>
        /// Delete a workspace within the configuration file
        /// </summary>
        /// <param name="config">Configuration list</param>
        /// <param name="index">The index at which the workspace needs to get deleted</param>
        public static void Delete(List<Config> config, int index)
        {
            log4net.ILog log = LogHelper.GetLogger();

            if (index >= 0)
            {
                log.Info($"Delete: Deleted \"{config[index].Workspace}\" from config file");

                config.RemoveAt(index);

                // Delete the configuration file when there are no workspaces left
                if (config.Count == 0)
                {
                    File.Delete("config.json");
                }
                else
                {
                    Write(config);
                }
            }
        }

        public static void Edit(List<Config> config, Config oldConfig, int index)
        {
            List<Config> c = Read();

            if(config[index].Workspace != oldConfig.Workspace)
            {
                // Workspace naam veranderen
            }

            if(c[index].Base != oldConfig.Base)
            {
                string pathSource = Path.Combine(oldConfig.Workspace, oldConfig.Base);
                string pathDestination = Path.Combine(oldConfig.Workspace, c[index].Base);

                System.Console.WriteLine($"SRC: {pathSource}");
                System.Console.WriteLine($"DST: {pathDestination}");
            }

            //Write(c);
        }
    }
}
