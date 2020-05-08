using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Background
{
    public class Backup : BaseBackground
    {
        private string _shootInfo = string.Empty;

        /// <summary>
        /// This backgroundWorker class will backup every file within the base flow
        /// </summary>
        /// <param name="backgroundWorker">The associated backgroundWorker object</param>
        /// <param name="config">The configuration object</param>
        /// <param name="formLoading">The formLoading object</param>
        /// <param name="shootInfo">The shoot information</param>
        public Backup(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, string shootInfo)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            _shootInfo = shootInfo;
        }

        /// <summary>
        /// Backup every picture within the base flow
        /// </summary>
        public override void Work()
        {
            int index = 1;

            try
            {
                // Get the path to the base flow directory
                string path = Path.Combine(Config.Workspace, _shootInfo, Config.Base);

                int count = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;

                // Order the files by last write time
                string[] files = Directory.GetFiles(path).OrderByDescending(d => new FileInfo(d).LastWriteTime).ToArray();

                // Loop-over ever picture in the files array
                foreach (var file in files)
                {
                    if (!BackgroundWorker.CancellationPending)
                    {
                        Picture picture = new Picture(file, Config.Workspace);

                        // Get the back up flow directory
                        string destination = Path.Combine(Config.Workspace, _shootInfo, Config.Backup, picture.FilenameExtension);

                        int procent = index++ * 100 / count;
                        BackgroundWorker.ReportProgress(procent, $"Backup: {index - 1}/{count}");

                        File.Copy(picture.Absolute, destination);
                    }
                }
            }

            catch (Exception)
            {
                BackgroundWorker.CancelAsync();
            }
        }
    }
}
