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
        public string Workspace { get; set; }
        public string BaseFlow { get; set; }
        public string Backup { get; set; }
        public string Selection { get; set; }
        public string Edited { get; set; }
        public string Preview { get; set; }
        public string Editing { get; set; }
        public string Instagram { get; set; }
        public List<string> Workflows { get; set; }
        public int Index { get; set; }

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
                   $"Hobbies: {string.Join(", ", Workflows.ToArray())}" +
                   $"Index: {Index}";
        }
    }
}
