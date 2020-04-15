using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.PicturebotGUI;
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
            Guard.Filesystem.PathExist(pathToBaseFlow);

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
            string path = Path.Combine(config.Workspace, picture.ShootInfo, Workflow.Selection, $"{picture.Filename}{extension}");
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
            // Get the path to the base flow
            string pathToBaseFlow = Path.Combine(config.Workspace, picture.ShootInfo, Workflow.Baseflow, $"{picture.Filename}{Extension.NEF}");
            Guard.Filesystem.PathExist(pathToBaseFlow);

            // Get the path to the selection flow
            string pathToSelectionFlow = Path.Combine(config.Workspace, picture.ShootInfo, Workflow.Selection, $"{picture.Filename}{Extension.NEF}");

            // Copy the picture to the selection flow only when isn't listed yet in the selection flow
            if (!Guard.Filesystem.IsPath(pathToSelectionFlow))
            {
                File.Copy(pathToBaseFlow, pathToSelectionFlow);
                Guard.Filesystem.PathExist(pathToSelectionFlow);
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
    }
}
