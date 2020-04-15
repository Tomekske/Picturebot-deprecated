using Guard;
using Picturebot.src.Logger;
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
        private Config _config { get; set; }
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// Shoot constructor
        /// The workspace class handles everything related to the shoot operations
        /// </summary>
        public Shoot(Config config)
        {
            _config = config;
        }

        /// <summary>
        /// Add a new shoot within the workspace directory
        /// Example: "<location> <dd-MM-YYYY>" -> "London 20-02-2020"
        /// </summary>
        /// <param name="name">shoot name</param>
        public void Add(string name)
        {
            string shootRoot = Path.Combine(_config.Workspace, name);

            // Create a new shoot when it doesn't exists yet
            if (!Guard.Filesystem.IsPath(shootRoot))
            {
                try
                {
                    // Create a new shoot
                    Directory.CreateDirectory(shootRoot);

                    _log.Info($"Shoot: created \"{shootRoot}\" shoot");

                    // Create all the flows within the shoot
                    InitialiseShoot(shootRoot);
                }
                catch (DirectoryNotFoundException e)
                {
                    _log.Info($"Shoot: unable to create a new shoot \"{shootRoot}\"", e);
                }
            }
        }

        /// <summary>
        /// Remove a specified shoot within the workspace directory
        /// </summary>
        /// <param name="path">Path the shoot</param>
        public void Remove(string path)
        {
            if(Guard.Filesystem.IsPath(path))
            {
                Directory.Delete(path, true);

                _log.Info($"Shoot: deleted \"{path}\"");
            }

            else
            {
                _log.Info($"Shoot: unable to delete \"{path}\"");
            }
        }

        /// <summary>
        /// Rename a shoot name and recursively rename all pictures within every flow accordingly to the new shoot name
        /// </summary>
        /// <param name="name">New shoot name</param>
        public void Rename(string oldShootInfo, string shootName, string shootDate)
        {
            string newShoot = $"{shootName} {shootDate}";
            Flow flow = new Flow(_config);

            flow.Rename(oldShootInfo, false, newShoot);

            string source = Path.Combine(_config.Workspace, oldShootInfo);
            string destination = Path.Combine(_config.Workspace, newShoot);

            try
            {
                Directory.Move(source, destination); 
                _log.Info($"InitialiseShoot: moved \"{source}\" to \"{destination}\"");

            }
            catch (DirectoryNotFoundException e)
            {
                _log.Error($"InitialiseShoot: unable to move \"{source}\" to \"{destination}\"", e);
            }
        }

        /// <summary>
        /// Create all flows configured in the configuration file
        /// </summary>
        /// <param name="root">Root directory of the newly created shoot</param>
        private void InitialiseShoot(string root)
        {
            // Loop-over every flow defined in the workspace array object within the config file
            foreach (var flow in _config.Workflows)
            {
                // Create an absolute root path to the flow that is about to get created within the shoot
                string flowRoot = Path.Combine(root, flow);

                try
                {
                    Directory.CreateDirectory(flowRoot);
                    _log.Info($"Shoot: created \"{flowRoot}\" flow");
                }
                catch (DirectoryNotFoundException e)
                {
                    _log.Error($"Shoot: unable to \"{flowRoot}\" flow", e);

                }
            }
        }
    }
}
