using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.POCO
{
    public class Drag
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public Drag(string source, string desitnation)
        {
            Source = source;
            Destination = desitnation;
        }
    }
}
