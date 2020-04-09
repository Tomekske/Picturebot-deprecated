using Picturebot.src.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Picturebot.Properties;
using System.IO;
using System.Reflection;

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
            // Convert byte array to a UTF8 string
            string utf = Encoding.UTF8.GetString(Resources.config);
            
            return JsonConvert.DeserializeObject<List<Config>>(utf);
        }

        /// <summary>
        /// Public method to obtain the config resource string
        /// </summary>
        /// <returns>Config resource string</returns>
        public static string GetConfigResource()
        {
            var x = Resources.config;
            return string.Empty;
            //return Encoding.UTF8.GetString(Resources.config);
        }
    }
}
