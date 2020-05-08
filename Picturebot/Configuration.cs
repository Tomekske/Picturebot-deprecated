using Picturebot.src.POCO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Picturebot.Properties;
using System.IO;

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
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("config.json", json);
        }

        public static List<Config> Delete(List<Config> config, int index)
        {
            config.RemoveAt(index);
            return config;
        }
    }
}
