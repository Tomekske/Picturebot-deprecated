using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.POCO
{
    public class Metadata
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Shoot { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Constructor method of the canvas POCO class
        /// </summary>
        /// <param name="width">Width of the canvas</param>
        /// <param name="height">Height of the canvas</param>
        public Metadata(string path, string name, string shoot, string description)
        {

            Path = path;
            Name = name;
            Shoot = shoot;
            Description = description;
        }

        /// <summary>
        /// OVerride method
        /// </summary>
        /// <returns></returns> 
        public override string ToString()
        {
            return $"Path: {Path}\r\nName: {Name}\r\nDescription: {Description}\r\nShoot: {Shoot}\r\n";
        }
    }
}
