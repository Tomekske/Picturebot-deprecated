using Picturebot.src.POCO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Picturebot.Properties;
using System.IO;
using Picturebot.src.Logger;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Picturebot
{
    /// <summary>
    /// Static class which implements methods to interact with the picture's bot configuration file
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Read the picturebot's configuration JSON file
        /// </summary>
        /// <returns>Config list</returns>
        public static List<Config> Read()
        {
            #if DEBUG
                // Convert byte array to a UTF8 string
                string utf = Encoding.UTF8.GetString(Resources.config);

                return JsonConvert.DeserializeObject<List<Config>>(utf);
            #else
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments),"Picturebot","config.json");

                if (Guard.Filesystem.IsPath(path))
                {
                    // Convert byte array to a UTF8 string
                    string json = File.ReadAllText(path);

                    return JsonConvert.DeserializeObject<List<Config>>(json);
                }

                return null;           
            #endif
        }

        /// <summary>
        /// Write the config objects to the associated JSON file
        /// </summary>
        /// <param name="config">The configuration list containing config objects</param>
        public static void Write(List<Config> config)
        {
            string pathMyDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Picturebot");
            string path = Path.Combine(pathMyDocuments, "config.json");
            
            if(!Guard.Filesystem.IsPath(pathMyDocuments))
            {
                Directory.CreateDirectory(pathMyDocuments);
            }

            log4net.ILog log = LogHelper.GetLogger();

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(path, json);

            log.Info("Write: Data to configuration file written");
        }
        
        /// <summary>
        /// Delete a workspace within the configuration file
        /// </summary>
        /// <param name="config">Configuration list</param>
        /// <param name="index">The index at which the workspace needs to get deleted</param>
        public static void Delete(List<Config> config, int index)
        {
            log4net.ILog log = LogHelper.GetLogger();

            if (index >= 0)
            {
                log.Info($"Delete: Deleted \"{config[index].Workspace}\" from config file");

                config.RemoveAt(index);

                // Delete the configuration file when there are no workspaces left
                if (config.Count == 0)
                {
                    File.Delete("config.json");
                }
                else
                {
                    Write(config);
                }
            }
        }

        /// <summary>
        /// Edit a workspace within the configuration file
        /// </summary>
        /// <param name="configCurrent">List of all workspace configurations</param>
        /// <param name="configUpdated">Updated workspace configuration data</param>
        /// <param name="shoots">List of all shoots within the workspace</param>
        /// <param name="index">Selected workspace index</param>      
        /// <param name="path">Path to the workspace</param>      
        public static bool Edit(List<Config> configCurrent, Config configUpdated, IEnumerable<string> shoots, int index, string path)
        {
            log4net.ILog log = LogHelper.GetLogger();

            bool isRoot = true;

            // Get the shoot names within the workspace directories and append them to the shoot listBox
            foreach (var shoot in shoots)
            {
                string pathToShoot = Path.Combine(path, shoot.Substring(shoot.LastIndexOf("\\") + 1));

                // Simultaneously zip current config and updated config objects  
                var zippedWorkflows = configCurrent[index].Workflows.Zip(configUpdated.Workflows, (c, u) => new { Current = c, Updated = u });

                foreach (var flow in zippedWorkflows)
                {
                    // Rename flows when current flow and updated flow aren't equal
                    if (flow.Updated != flow.Current)
                    {
                        string source = Path.Combine(pathToShoot, flow.Current);
                        string destination = Path.Combine(pathToShoot, flow.Updated);

                        if (Guard.Filesystem.IsPath(source))
                        {
                            Directory.Move(source, destination);
                            log.Info($"Workspace rename: Renamed flow \"{source}\" -> \"{destination}\"");
                        }

                        else
                        {
                            log.Error($"Workspace rename: flow \"{source}\" doesn't exists");
                        }
                    }
                }
            }

            // Rename the workspace when updated and current workspace aren't equal
            if (configUpdated.Workspace != configCurrent[index].Workspace)
            {
                string rootWorkspaceCurrent =  configCurrent[index].Workspace.Substring(0, configCurrent[index].Workspace.LastIndexOf('\\'));
                string rootWorkspaceUpdated = configUpdated.Workspace.Substring(0, configUpdated.Workspace.LastIndexOf('\\'));

                // Only rename a workspace when the root directories are equal
                if (rootWorkspaceUpdated == rootWorkspaceCurrent)
                {
                    if (Guard.Filesystem.IsPath(configCurrent[index].Workspace))
                    {
                        Directory.Move(configCurrent[index].Workspace, configUpdated.Workspace);
                        configUpdated.Workspace = configUpdated.Workspace;
                        log.Info($"Workspace rename: Renamed workspace \"{rootWorkspaceCurrent}\" -> \"{rootWorkspaceUpdated}\"");
                    }
                    else
                    {
                        configUpdated.Workspace = configCurrent[index].Workspace;
                        isRoot = false;
                        log.Error($"Workspace rename: flow \"{rootWorkspaceCurrent}\" doesn't exists");
                    }
                }
                else
                {
                    configUpdated.Workspace = configCurrent[index].Workspace;
                    isRoot = false;
                    MessageBox.Show("Workspace roots aren't equal");
                    log.Info($"Workspace rename: Workspace roots \"{rootWorkspaceCurrent}\" and \"{rootWorkspaceUpdated}\" aren't equal");
                }
            }

            configCurrent[index] = configUpdated;
            Write(configCurrent);

            return isRoot;
        }
    }
}
