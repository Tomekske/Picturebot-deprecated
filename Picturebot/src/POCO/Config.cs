using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturebot.src.POCO
{
    /// <summary>
    /// POCO class for the picturebot configuration file
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Property contains the absolute path to the workspace
        /// </summary>
        public string Workspace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BaseFlow { get; set; }
        /// <summary>
        /// Property contains the user defined name for the base flow
        /// </summary>
        public string Backup { get; set; }
        /// <summary>
        /// Property contains the user defined name for the backup flow
        /// </summary>
        public string Selection { get; set; }
        /// <summary>
        /// Property contains the user defined name for the selection flow
        /// </summary>
        public string Edited { get; set; }
        /// <summary>
        /// Property contains the user defined name for the edited flow
        /// </summary>
        public string Preview { get; set; }
        /// <summary>
        /// Property contains the user defined name for the preview flow
        /// </summary>
        public string Editing { get; set; }
        /// <summary>
        /// Property contains the user defined name for the editing flow
        /// </summary>
        public string Instagram { get; set; }
        /// <summary>
        /// Property contains the user defined name for the instagram flow
        /// </summary>
        public List<string> Workflows { get; set; }
        /// <summary>
        /// Property contains an array of flows
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Override the ToString() method
        /// </summary>
        /// <returns>Stringified picture object</returns>
        public override string ToString()
        {
            return $"Workspace: {Workspace}\r\n" +
                   $"BaseFlow: {BaseFlow}\r\n" +
                   $"Backup: {Backup}\r\n" +
                   $"Selection: {Selection}\r\n" +
                   $"Edited: {Edited}\r\n" +
                   $"Preview: {Preview}\r\n" +
                   $"Edited: {Edited}\r\n" +
                   $"Editing: {Editing}\r\n" +
                   $"Instagram: {Instagram}\r\n" +
                   $"Workflows: {string.Join(", ", Workflows.ToArray())}" +
                   $"Index: {Index}";
        }
    }
}
