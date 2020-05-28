using ImageProcessor;
using Picturebot.src.Enums;
using Picturebot.src.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Picturebot
{
    public class Picture
    {
        /// <summary>
        /// Get the extension name from a file path
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Get shoot information from a file path
        /// </summary>
        public string ShootInfo { get; set; }
        /// <summary>
        /// Get the date when the shoot was taken from a file path
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Get the shoot name from a file path
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get the absolute file path
        /// </summary>
        public string Absolute { get; set; }
        /// <summary>
        /// Get the relative file path
        /// </summary>
        public string Relative { get; set; }
        /// <summary>
        /// Get the flow name from a file path
        /// </summary>
        public string Flow { get; set; }
        /// <summary>
        /// Get the workspace name from a file path
        /// </summary>
        public string Workspace { get; set; }
        /// <summary>
        /// Get the index of the picture within a list
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Get the file name without extension
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// Get the file name with extension
        /// </summary>
        public string FilenameExtension { get; set; }
        public DateTime ModificationDate { get; set; }

        /// <summary>
        /// Picture constructor
        /// Picture class gets all the necessary meta-data from a single picture 
        /// </summary>
        /// <param name="path">The absolute path to the picture</param>
        /// <param name="workspace">The workspace name where the picture is located</param>
        /// <param name="index">The file index of the picture</param>
        public Picture(string path, string workspace, int index)
        {
            Index = index;
            Extension = GetExtension(path);
            ShootInfo = GetShootInformation(path);
            Date = GetShootDate(path);
            Name = GetShootName(path);
            Absolute = path;
            Flow = GetFlow(path);
            Relative = GetRelative(path);
            Workspace = workspace;
            Filename = GetFilename(path);
            FilenameExtension = $"{GetFilename(path)}{Extension}";
            ModificationDate = GetModificationDate(path);
        }

        /// <summary>
        /// Picture constructor
        /// Picture class gets all the necessary meta-data from a single picture 
        /// </summary>
        /// <param name="path">The absolute path to the picture</param>
        /// <param name="workspace">The workspace name where the picture is located</param>
        public Picture(string path, string workspace)
        {
            Index = 0;
            Extension = GetExtension(path);
            ShootInfo = GetShootInformation(path);
            Date = GetShootDate(path);
            Name = GetShootName(path);
            Absolute = path;
            Flow = GetFlow(path);
            Relative = GetRelative(path);
            Workspace = workspace;
            Filename = GetFilename(path);
            FilenameExtension = $"{GetFilename(path)}{Extension}";
            ModificationDate = GetModificationDate(path);
        }

        /// <summary>
        /// Picture constructor
        /// Picture class gets all the necessary meta-data from a single picture 
        /// </summary>
        /// <param name="path">The absolute path to the picture</param>
        public Picture(string path)
        {
            Index = 0;
            Extension = GetExtension(path);
            ShootInfo = GetShootInformation(path);
            Date = GetShootDate(path);
            Name = GetShootName(path);
            Absolute = path;
            Flow = GetFlow(path);
            Relative = GetRelative(path);
            Workspace = string.Empty;
            Filename = GetFilename(path);
            FilenameExtension = $"{GetFilename(path)}{Extension}";
            ModificationDate = GetModificationDate(path);
        }

        /// <summary>
        /// Get the extension from a file or file path 
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>The file extension</returns>
        private string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }

        /// <summary>
        /// Get shoot information from a file path
        /// Example: "D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF" -> "Zakopane 05-02-2020"
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>The shoot name on success</returns>
        private string GetShootInformation(string path)
        {
            Regex regex = new Regex(Pattern.Shoot);
            Match match = regex.Match(path);

            return match.Success ? match.Value : string.Empty;
        }

        /// <summary>
        /// Get the date from within the shoot name
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>The date of the shoot on success</returns>
        private string GetShootDate(string path)
        {
            // First regex obtains the shoot name 
            Regex regexShoot = new Regex(Pattern.Shoot);
            Match matchShoot = regexShoot.Match(path);

            string shoot = matchShoot.Success ? matchShoot.Value : string.Empty;

            // Second regex obtains the date within the shoot name
            Regex regexDate = new Regex(Pattern.Date);
            Match matchDate = regexDate.Match(shoot);

            return matchDate.Success ? matchDate.Value : string.Empty;
        }

        /// <summary>
        /// Get the shoot name
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>The name of the shoot on success</returns>
        private string GetShootName(string path)
        {
            // First regex obtains the shoot name 
            Regex regexShoot = new Regex(Pattern.Shoot);
            Match matchShoot = regexShoot.Match(path);

            string shoot = matchShoot.Success ? matchShoot.Value : string.Empty;

            // Second regex obtains the date within the shoot name
            Regex regexDate = new Regex(Pattern.Name);
            Match matchDate = regexDate.Match(shoot);

            return matchDate.Success ? matchDate.Value.Trim() : string.Empty;
        }

        /// <summary>
        /// Get the flow name of a file path
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>The flow name on success</returns>
        private string GetFlow(string path)
        {
            string[] tokens = path.Split('\\');
            int length = tokens.Length;

            return length >= 2 ? tokens[tokens.Length - 2] : string.Empty;
        }

        /// <summary>
        /// Get the relative file path
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>The the relative file path on success</returns>
        private string GetRelative(string path)
        {
            string[] tokens = path.Split('\\');
            int length = tokens.Length;

            return length >= 4 ? Path.Combine(tokens[length - 4], tokens[length - 3], tokens[length - 2], tokens[length - 1]) : string.Empty;
        }

        /// <summary>
        /// Get the filename from a file path
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>The filename</returns>
        private string GetFilename(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        /// <summary>
        /// Get the modification date of a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The last modification time of the specified file</returns>
        private DateTime GetModificationDate(string path)
        {
            return File.GetLastWriteTime(path);
        }

        /// <summary>
        /// Override the ToString() method
        /// </summary>
        public override string ToString()
        {
            return $"Index: {Index}\r\n" +
                    $"Workspace: {Workspace}\r\n" +
                    $"Flow: {Flow}\r\n" +
                    $"ShootInfo: {ShootInfo}\r\n" +
                    $"Filename: {Filename}\r\n" +
                    $"FilenameExtension: {FilenameExtension}\r\n" +
                    $"Date: {Date}\r\n" +
                    $"Name: {Name}\r\n" +
                    $"Extension: {Extension}\r\n" +
                    $"Modification Date: {ModificationDate.Date}\r\n" +
                    $"Absolute: {Absolute}\r\n" +
                    $"Relative: {Relative}\r\n";
        }
    }
}
