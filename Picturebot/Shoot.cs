using Guard;
using Picturebot.src.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturebot
{
    public class Shoot
    {
        public Config Config { get; set; }

        /// <summary>
        /// Shoot constructor
        /// The workspace class handles everything related to the shoot operations
        /// </summary>
        public Shoot(Config config)
        {
            Config = config;
        }

        /// <summary>
        /// Add a new shoot within the workspace directory
        /// Example: "<location> <dd-MM-YYYY>" -> "London 20-02-2020"
        /// </summary>
        /// <param name="name">shoot name</param>
        public void Add(string name)
        {
            string shootRoot = Path.Combine(Config.Workspace, name);

            if (!Guard.Filesystem.IsPath(shootRoot))
            {
                // Create a new shoot
                Directory.CreateDirectory(shootRoot);

                //Check whether is successfully created
                Guard.Filesystem.PathExist(shootRoot);

                // Create all the flows within the shoot
                InitialiseShoot(shootRoot);
            }
        }

        /// <summary>
        /// Remove a specified shoot within the workspace directory
        /// </summary>
        /// <param name="path">Path the the shoot</param>
        public void Remove(string path)
        {
            Guard.Filesystem.PathExist(path);
            Directory.Delete(path, true);
        }

        /// <summary>
        /// Rename a shoot name and recursively rename all pictures within every flow accordingly to the new shoot name
        /// </summary>
        /// <param name="name">New shoot name</param>
        public void Rename(string path)
        {
            List<Picture> pictureList = new List<Picture>();

             
            // TODO
            // Rename Pictures in flows
            // Rename Shoot name
        }

        /// <summary>
        /// Create all flows configured in the configuration file
        /// </summary>
        /// <param name="root">Root directory of the newly created shoot</param>
        private void InitialiseShoot(string root)
        {
            // Loop-over every flow defined in the workspace array object within the config file
            foreach (var flow in Config.Workflows)
            {
                // Create an absolute root path to the flow that is about to get created within the shoot
                string flowRoot = Path.Combine(root, flow);
                Directory.CreateDirectory(flowRoot);
            }
        }
    }
}
