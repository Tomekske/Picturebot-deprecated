using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.POCO
{
    public class Metadata
    {
        /// <summary>
        /// Full path name of an image
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Name of the image
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ShootInfo of the image
        /// </summary>
        public string Shoot { get; set; }
        /// <summary>
        /// Description of the image
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This class contains the meta-data of an image which is getting stored within a database
        /// </summary>
        /// <param name="path">Full path name of an image</param>
        /// <param name="name">Name of the image</param>
        /// <param name="shoot">ShootInfo of the image</param>
        /// <param name="description">Description of the image</param>
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
