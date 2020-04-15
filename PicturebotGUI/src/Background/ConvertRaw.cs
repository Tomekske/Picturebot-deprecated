using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Command;
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
    public class ConvertRaw : BaseBackground
    {
        private string _shootInfo = string.Empty;

        /// <summary>
        /// This backgroundWorker class will convert every RAW file within the base flow and store is a JPG in the preview flow
        /// </summary>
        /// <param name="backgroundWorker">The associated backgroundWorker object</param>
        /// <param name="config">The configuration object</param>
        /// <param name="formLoading">The formLoading object</param>
        /// <param name="shootInfo">The shoot information</param>
        public ConvertRaw(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, string shootInfo)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            _shootInfo = shootInfo;
        }

        /// <summary>
        /// Convert every RAW file within the base flow and store is a JPG in the preview flow
        /// </summary>
        public override void Work()
        {
            int index = 1;

            try
            {
                // Get the path to the base flow
                string path = Path.Combine(Config.Workspace, _shootInfo, Workflow.Baseflow);
                Guard.Filesystem.PathExist(path);

                int count = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;

                // Order the files by last write time
                string[] files = Directory.GetFiles(path).OrderByDescending(d => new FileInfo(d).LastWriteTime).Reverse().ToArray();

                // Order the files by last write time
                foreach (var file in files)
                {
                    if (!BackgroundWorker.CancellationPending)
                    {
                        Picture picture = new Picture(file, Config.Workspace, index - 1);

                        int procent = index++ * 100 / count;
                        BackgroundWorker.ReportProgress(procent, $"Converting: {index - 1}/{count}");

                        // Get the path to the preview flow
                        string destination = Path.Combine(Config.Workspace, _shootInfo, Workflow.Preview, $"{picture.Filename}.jpg");
                        // Convert the picture
                        GUI.Convert(picture.Absolute, destination);
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
