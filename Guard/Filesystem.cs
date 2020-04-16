using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guard
{
    static public class Filesystem
    {
        /// <summary>
        /// Throws an exception when a file or a directory path doesn't exists
        /// </summary>
        /// <param name="path">Path to the file or directory</param>
        public static void PathExist(string path)
        {
            if (File.Exists(path)) { }
            else if (Directory.Exists(path)) { }
            else
            {
                throw new FileNotFoundException($"Specified file or directory doesn't exists: {path}");
            }
        }

        /// <summary>
        /// Check whether a file or a directory path exists
        /// </summary>
        /// <param name="path">Path to the file or directory</param>
        /// <returns>Returns true if a file or directory exists or false when the file or directory doesn't exists</returns>
        public static bool IsPath(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else if (Directory.Exists(path))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check whether the current working directory is a nested directory within the baseflow directory
        /// </summary>
        /// <param name="path">Baseflow path of the shoot</param>
        /// <param name="cwd">Current working directory located within the base path</param>
        /// <param name="identical">Check whether current working directory and baseflow paths are identical</param>
        /// <returns>Returns true on success and false on failure</returns>
        public static bool IsPathCwd(string path, string cwd, bool identical = false)
        {
            if (identical)
            {
                return cwd == path ? true : false;
            }

            // Obtain the base directory from the baseflow directory
            string baseDirectory = new DirectoryInfo(path).Name;
            // Split the cwd file path into tokens 
            string[] tokenized = cwd.Split(Path.DirectorySeparatorChar);

            foreach (var token in tokenized)
            {
                // Returns true if the baseeDirectory equal one of the tokens in the cwd
                if (baseDirectory == token)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
