using Picturebot.src.POCO;
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
    public class Convert : BaseBackground
    {
        public Convert(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
        }

        public override void Work()
        {
            int index = 1;

            try
            {
                Directory.GetCurrentDirectory();

                string cwd = Directory.GetCurrentDirectory();
                int count = Directory.GetFiles(cwd, "*.*", SearchOption.TopDirectoryOnly).Length;

                string[] files = Directory.GetFiles(cwd);

                var sortedFiles = new DirectoryInfo(cwd).GetFiles().OrderBy(f => f.CreationTime).ToList();

                foreach (var file in sortedFiles)
                {
                    if (!BackgroundWorker.CancellationPending)
                    {
                        int procent = index++ * 100 / count;
                        BackgroundWorker.ReportProgress(procent, $"Converting: {index - 1}/{count}");

                        src.Command.Base.Convert(Config.Index, file.ToString(), 50);
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
