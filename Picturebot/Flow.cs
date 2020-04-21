using Picturebot.src.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Picturebot.src.Logger;
using Picturebot.src.Helper;
using System.Windows.Forms;

namespace Picturebot
{
    public class Flow
    {
        private Config _config { get; set; }

        private static readonly log4net.ILog _log = LogHelper.GetLogger();


        /// <summary>
        /// The Flow constructor
        /// Allows to perform operations on pictures within the flow such as: creation, deleting, renaming and hashing
        /// </summary>
        /// <param name="config">Config object</param>
        public Flow(Config config)
        {
            _config = config;
        }

        /// <summary>
        /// Delete a picture within the flow
        /// </summary>
        /// <param name="path">Path to the picture</param>
        public void Remove(string path)
        {
            if(Guard.Filesystem.IsPath(path))
            {
                File.Delete(path);
                _log.Info($"Flow: deleted \"{path}\"");
            }
            else 
            {
                _log.Error($"Flow: couldn't delete \"{path}\"");
                MessageBox.Show($"Flow: couldn't delete \"{path}\"");
            }
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
            
            // Path to the new file name
            return Path.Combine(picture.Workspace, picture.ShootInfo, picture.Flow, newFilename);
        }

        /// <summary>
        /// Rename a picture according to the shoot name, all pictures have an index and are sorted by creation date
        /// Example: shoot name: Test 10-03-2020, picture: Test_10-03-2020_<index>
        /// </summary>
        /// <param name="shootInfo">Name of the shoot that will be used to rename a picture</param>
        /// <param name="isBaseflow">Check if flow is the baseFlow directory</param>
        /// <param name="isHash">Check if pictures need to be hashed</param>
        /// <param name="newShootInfo">The new shootInfo that will be used to rename a picture</param>
        public void Rename(string shootInfo, bool isBaseflow, bool isHash, string newShootInfo = "")
        {
            // Loop-over every flow configured in the configuration file
            foreach (var flow in _config.Workflows)
            {
                // Get the absolute path to the flow directory
                string path = Path.Combine(_config.Workspace, shootInfo, flow);

                // Get all pictures within the flow and sort them by last write time(last modification time)
                var pictures = Helper.GetFilesOrderByDescendingLastWriteTime(path);
                // Get the amount of pictures within the flow directory
                int amountOfPictures = pictures.Length;

                // Check if files need to be hashed before renaming
                if (isHash)
                {
                    HashRename(shootInfo, flow);
                    pictures = Helper.GetFilesOrderByDescendingLastWriteTime(path);
                }

                //  Only rename the files within the baseFlow
                if (isBaseflow)
                {
                    // Only rename every picture within a flow when the directory contains pictures and when the flow isn't the backup flow
                    if ((flow != _config.Backup) && ((flow == _config.BaseFlow) || (flow == _config.Preview)) && (amountOfPictures != 0))
                    {
                        // Loop-over every picture within a flow directory
                        for (int i = 0; i < amountOfPictures; i++)
                        {
                            Picture p = new Picture(pictures[i], _config.Workspace, i + 1);

                            try
                            {
                                File.Move(p.Absolute, RenamePicture(p));
                                _log.Info($"Flow: renamed \"{p.Absolute}\" into \"{RenamePicture(p)}\"");
                            }
                            catch (IOException e)
                            {
                                _log.Error($"Flow: unable to rename \"{p.Absolute}\" into \"{RenamePicture(p)}\"", e);
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }

                else
                {
                    string newName = newShootInfo.Replace(" ", "_");
                    string pathToFlow = Path.Combine(_config.Workspace, shootInfo, flow);

                    if (Directory.Exists(pathToFlow) && (flow != _config.Backup) && (amountOfPictures != 0))
                    {
                        var files = Directory.GetFiles(pathToFlow);

                        foreach (var file in files)
                        {
                            string filename = Path.GetFileName(file);
                            string[] tokens = filename.Split('_');
                            string order = tokens[tokens.Length - 1];

                            string full = Path.Combine(_config.Workspace, shootInfo, flow, $"{newName}_{order}");

                            try
                            {
                                File.Move(file, full);
                                _log.Info($"Flow: renamed \"{file}\" into \"{full}\"");
                            }
                            catch (IOException e)
                            {
                                _log.Error($"Flow: unable to rename \"{file}\" into \"{full}\"", e);
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Rename a whole flow according to their hash value in order to make sure that there won't be any conflicting file names
        /// </summary>
        /// <param name="shootInfo">Shoot information</param>
        /// <param name="flow">The flow name where the files need to be hashed</param>
        public void HashRename(string shootInfo, string flow)
        {
            string path = Path.Combine(_config.Workspace, shootInfo, flow);

            var pictures = Helper.GetFilesOrderByDescendingLastWriteTime(path);
            // Get the amount of pictures within the flow directory
            int amountOfPictures = pictures.Length;

            for(int i = 0; i < amountOfPictures; i++)
            {
                Picture picture = new Picture(pictures[i], _config.Workspace, i + 1);
                string dest = Path.Combine(_config.Workspace, shootInfo, flow, HashRenamePicture(picture));

                try
                {
                    File.Move(picture.Absolute, dest);
                    _log.Info($"Flow: renamed \"{picture.Absolute}\" into \"{dest}\"");
                }
                catch (IOException e)
                {
                    _log.Error($"Flow: unable to rename \"{picture.Absolute}\" into \"{dest}\"");
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// Rename a file according to it's hash value in order to make sure that there won't be any conflicting file names
        /// </summary>
        /// <param name="picture">Picture object containing all the meta-data</param>
        /// <returns></returns>
        public string HashRenamePicture(Picture picture)
        {
            string hash = string.Empty;

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, picture.Absolute);
            }

            // Formatting the new filename for the picture
            string name = $"pb_{picture.Index.ToString().PadLeft(5, '0')}_{hash.Substring(0, 10)}{picture.Extension}";
            
            return Path.Combine(picture.Workspace, picture.ShootInfo, picture.Flow, name);
        }

        /// <summary>
        /// Create a hashed string
        /// </summary>
        /// <param name="md5Hash">The MD5 hash</param>
        /// <param name="input">The input string which is going to get compute</param>
        /// <returns>Hashed string</returns>
        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes and create a string
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
