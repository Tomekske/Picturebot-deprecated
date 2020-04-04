using Picturebot.src.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturebot
{
    public class Flow
    {
        public Config Config { get; set; }

        public Flow(Config config)
        {
            Config = config;
        }

        /// <summary>
        /// Delete a picture within the flow
        /// </summary>
        /// <param name="path">Path to the picture</param>
        public void Remove(string path)
        {
            Guard.Filesystem.PathExist(path);
            File.Delete(path);
        }

        /// <summary>
        /// Rename a picture a picture to the correct format with the correct index based on the creation date of the picture
        /// D:\Pictures\Zakopane 05-02-2020\RAW\Test.NEF -> D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_<index>.NEF
        /// </summary>
        /// <param name="picture">Picture object which contains the picture's meta data</param>
        /// <returns>Returns the path to the new file with the new filename</returns>
        public string RenamePicture(Picture picture)
        {
            // Add padding to the index: Zakopane_05-02-2020_1 -> Zakopane_05-02-2020_00001
            string paddedIndex = picture.Index.ToString().PadLeft(5, '0');

            // Get th
            int splittedLength = picture.Name.Length;

            // Construct the new filename
            string newFilename = splittedLength > 2 ? $"{picture.Name.Replace(' ', '_')}_{picture.Date}_{paddedIndex}{picture.Extension}" : $"{picture.Name}_{picture.Date}_{paddedIndex}{picture.Extension}";

            return Path.Combine(picture.Workspace, picture.ShootInfo, picture.Flow, newFilename);
        }

        /// <summary>
        /// Rename a picture according to the shoot name, all pictures have an index and are sorted by creation date
        /// Example: shoot name: Test 10-03-2020, picture: Test_10-03-2020_<index>
        /// </summary>
        /// <param name="shoot">Name of the shoot that will be used to rename a picture</param>
        public void Rename(string shoot)
        {
            // Loop-over every flow configured in the configuration file
            foreach (var flow in Config.Workflows)
            {
                // Get the absolute path to the flow directory
                string path = Path.Combine(Config.Workspace, shoot, flow);

                // Get all pictures within the flow and sort them by last write time(last modification time)
                var pictures = Directory.GetFiles(path, "*").OrderByDescending(d => new FileInfo(d).LastWriteTime).ToArray();
                // Get the amount of pictures within the flow directory
                int amountOfPictures = pictures.Length;

                // Only rename every picture within a flow when the directory contains pictures and when the flow isn't the backup flow
                if ((flow != Config.Backup) && (amountOfPictures != 0))
                {
                    // Loop-over every picture within a flow directory
                    for (int i = 0; i < amountOfPictures; i++)
                    {
                        Picture p = new Picture(pictures[i], Config.Workspace, i + 1);

                        Guard.Filesystem.PathExist(p.Absolute);
                        // TODO: check whether old picture is within the workspace
                        // TODO: check whether new picture is within the workspace
                        File.Move(p.Absolute, RenamePicture(p));
                    }
                }
            }
        }
    }
}
