using Picturebot.src.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturebot
{
    public class Workspace
    {
        public List<Config> Config { get; set; }

        /// <summary>
        /// Workspace constructor
        /// The workspace class handles everything related to the workspace directory
        /// </summary>
        public Workspace(List<Config> config)
        {
            Config = config;
        }

        /// <summary>
        /// Add a new workspace
        /// </summary>
        /// <param name="name">Name of the new workspace</param>
        public void Add(string name)
        {
            // TODO
        }

        /// <summary>
        /// Remove an existing workspace
        /// </summary>
        /// <param name="name">Name of an existing workspace that will get deleted</param>
        public void Remove(string name)
        {
            // TODO
        }
    }
}
