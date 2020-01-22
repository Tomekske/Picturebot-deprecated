using PicturebotGUI.src.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Command
{
    /// <summary>
    /// Static class which implements commands to interact with the base flow
    /// </summary>
    static public class Base
    {
        /// <summary>
        /// Static method to backup a picture within the backup flow
        /// </summary>
        /// <param name="index">Workspace index</param>
        /// <param name="file">File which is copied to the backup flow</param>
        public static void Backup(int index, string file)
        {
            Shell.Execute(External.Picturebot, $"base -b {index} \"{file}\"");
        }

        /// <summary>
        /// Static method to rename a picture
        /// </summary>
        /// <param name="index">Workspace index</param>
        /// <param name="order">Order of the image</param>
        /// <param name="file">File which is copied to the backup flow</param>
        public static void Rename(int index, int order, string file)
        {
            Shell.Execute("pb", $"base -r {index} {order - 1} \"{file}\"");
        }

        /// <summary>
        /// Static method to convert a RAW image to a JPEG
        /// </summary>
        /// <param name="index">Workspace index</param>
        /// <param name="file">Image which is converted to a JPEG</param>
        /// <param name="quality">Quality of the converted image</param>
        public static void Convert(int index, string file, int quality)
        {
            Shell.Execute("pb", $"base -c {index} \"{file}\" {quality}");
        }
    }
}
