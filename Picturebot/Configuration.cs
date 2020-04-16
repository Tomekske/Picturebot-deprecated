using Picturebot.src.POCO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Picturebot.Properties;

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
    }
}
