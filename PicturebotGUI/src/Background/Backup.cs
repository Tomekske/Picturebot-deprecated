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
    public class Backup : BaseBackground
    {
        public Backup(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading)
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

                foreach (var file in files)
                {
                    if (!BackgroundWorker.CancellationPending)
                    {
                        int procent = index++ * 100 / count;
                        BackgroundWorker.ReportProgress(procent, $"Backup: {index - 1}/{count}");

                        string f = $"{index - 1} {file}";

                        src.Command.Base.Backup(Config.Index, file);
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
