using Picturebot;
using Picturebot.src.Logger;
using Picturebot.src.POCO;
using Picturebot.src.Helper;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.Command
{
    /// <summary>
    /// Static class which implements methods to interact with GUI elements and shortcuts
    /// </summary>
    public static class General
    {
        /// <summary>
        /// Delete a shoot within the workspace
        /// </summary>
        /// <param name="path">The path to the shoot</param>
        /// <param name="shoot">The shoot object</param>
        public static void DeleteShoot(string path, Shoot shoot)
        {
            var result = MessageBox.Show($"Are you sure to delete \"{path}\" ?", "Confirm Deletion!!", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                shoot.Remove(path);
            }
        }

        /// <summary>
        /// Open the shoot directory in the explorer
        /// </summary>
        /// <param name="config">The config object</param>
        /// <param name="shootInfo">the shoot information</param>
        public static void Explorer(Config config, string shootInfo)
        {
            GUI.Explorer(Path.Combine(config.Workspace, shootInfo));
        }

        /// <summary>
        /// Delete a picture using the confirmation pop-up
        /// </summary>
        /// <param name="config">The config object</param>
        /// <param name="picture">The picture object</param>
        /// <param name="pictureBox">the associated pictureBox</param>
        /// <param name="flow">The flow object</param>
        /// <param name="currentFlow">Set the current flow</param>
        /// <param name="extension">The desired file extension</param>
        /// <param name="isPreview">Check whether a picture within the preview flow is deleted</param>
        public static void DeletePictureNotification(Config config, Picture picture,PictureBox pictureBox, Flow flow, string currentFlow, string extension, bool isPreview = false)
        {
            var result = MessageBox.Show($"Are you sure to delete \"{picture.Absolute}\" ?", "Confirm Deletion!!", MessageBoxButtons.YesNo);

            // Create the path to the base flow, because every preview picture comes with a raw format which needs to get deleted as well
            string pathToBaseFlow = Path.Combine(config.Workspace, picture.ShootInfo, currentFlow, $"{picture.Filename}{extension}");

            if (result == DialogResult.Yes)
            {
                // Delete the picture within the base flow and the preview flow
                flow.Remove(picture.Absolute);

                // When a file within the preview flow is deleted then the associated base flow picture must be deleted
                if(isPreview)
                {
                    flow.Remove(pathToBaseFlow);
                }

                GUIThread.ThreadPictureBox.Clear(pictureBox);
            }
        }

        /// <summary>
        /// Delete a picture without a using the confirmation pop-up
        /// </summary>
        /// <param name="config">The config object</param>
        /// <param name="picture">The picture object</param>
        /// <param name="pictureBox">the associated pictureBox</param>
        /// <param name="flow">The flow object</param>
        /// <param name="extension">The desired file extension</param>
        public static void DeletePicture(Config config, Picture picture, PictureBox pictureBox, Flow flow, string extension)
        {
            string path = Path.Combine(config.Workspace, picture.ShootInfo, config.Selection, $"{picture.Filename}{extension}");
            flow.Remove(path);
            GUIThread.ThreadPictureBox.Clear(pictureBox);
        }

        /// <summary>
        /// Copy a picture within the base flow to the selection flow
        /// </summary>
        /// <param name="config">The config object</param>
        /// <param name="picture">The picture object</param>
        public static void Selection(Config config, Picture picture)
        {
            log4net.ILog log = LogHelper.GetLogger();

            // Get the path to the base flow
            string pathToBaseFlow = Path.Combine(config.Workspace, picture.ShootInfo, config.Base, $"{picture.Filename}{Extension.NEF}");

            // Get the path to the selection flow
            string pathToSelectionFlow = Path.Combine(config.Workspace, picture.ShootInfo, config.Selection, $"{picture.Filename}{Extension.NEF}");

            // Copy the picture to the selection flow only when isn't listed yet in the selection flow
            if (!Guard.Filesystem.IsPath(pathToSelectionFlow))
            {
                try
                {
                    File.Copy(pathToBaseFlow, pathToSelectionFlow);
                    log.Info($"ListBox lbPreview: copied \"{pathToBaseFlow}\" to \"{pathToSelectionFlow}\"");
                }
                catch (DirectoryNotFoundException e)
                {
                    log.Error($"ListBox lbPreview: unable to copy \"{pathToBaseFlow}\" to \"{pathToSelectionFlow}\"", e);
                    MessageBox.Show(e.Message);
                }
                catch (FileNotFoundException e)
                {
                    log.Error($"ListBox lbPreview: Picture \"{pathToBaseFlow}\" or \"{pathToSelectionFlow}\" not found", e);
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                log.Info($"ListBox lbPreview: \"{Path.Combine(config.Workspace, picture.ShootInfo, config.Base)}\" already exists in \"{Path.Combine(config.Workspace, picture.ShootInfo, config.Selection)}\"");
            }
        }

        /// <summary>
        /// Open a picture in editing software
        /// </summary>
        /// <param name="program">The preferred editing software</param>
        /// <param name="path">Path to the picture</param>
        public static void Program(string program, string path)
        {
            Shell.Execute(program, $"\"{path}\"");
        }

        /// <summary>
        /// Rename a every file within every shoot recursively and rename the shoot name
        /// </summary>
        /// <param name="config">The config object</param>
        /// <param name="shoot">Shoot object</param>
        /// <param name="oldShootInfo">The old shoot information</param>
        /// <returns></returns>
        public static string RenameShoot(Config config, Shoot shoot, string oldShootInfo)
        {
            // Open the form rename shoot
            FormRenameShoot formRenameShoot = new FormRenameShoot(config, oldShootInfo);
            formRenameShoot.ShowDialog();

            string pathToSelection = Path.Combine(config.Workspace, oldShootInfo, config.Selection);
            int countFileSelectionFlow = Picturebot.src.Helper.Helper.GetFiles(pathToSelection).Count();

            // Rename every file recursively
            shoot.Rename(oldShootInfo, formRenameShoot.ShootName, formRenameShoot.ShootDate, false, countFileSelectionFlow);
            string newShootInfo = $"{formRenameShoot.ShootName} {formRenameShoot.ShootDate}";

            return newShootInfo;
        }

        /// <summary>
        /// Open the associated work flow when uploading a picture to the cloud
        /// </summary>
        /// <param name="config"></param>
        /// <param name="shootInfo">Shoot information name</param>
        /// <param name="picture">Selected picture name</param>
        /// <param name="flow">The associated work flow name</param>
        /// <param name="url">The URL to the associated album in the cloud</param>
        public static void Upload(Config config, string shootInfo, string picture, string flow, string url)
        {
            log4net.ILog log = LogHelper.GetLogger();

            string pathToFlow = Path.Combine(config.Workspace, shootInfo, flow);
            string path = Path.Combine(pathToFlow, $"{picture}{Extension.JPG}");

            if(Guard.Filesystem.IsPath(pathToFlow) && Guard.Filesystem.IsPath(path))
            {
                GUI.Explorer(pathToFlow);
                GUI.OpenWebsite(url);

                log.Info($"Upload: Opening flow \"{pathToFlow}\" succeeded");
                log.Info($"Upload: Opening website \"{url}\" succeeded");
            }
        }
    }
}
