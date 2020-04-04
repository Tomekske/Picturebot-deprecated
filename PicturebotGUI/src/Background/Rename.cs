using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PicturebotGUI.src.POCO;
using PicturebotGUI.src.Helper;
using System.IO;
using Picturebot.src.POCO;

namespace PicturebotGUI.src.Background
{
    public class Rename : BaseBackground
    {
        public Rename(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading)
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

                src.Command.Base.Hash(Config.Index);

                /*string[] files = src.Helper.Helper.SortPicturesByCreationTime(cwd);

                foreach (var file in files)
                {
                    if (!BackgroundWorker.CancellationPending)
                    {
                        int procent = index++ * 100 / count;
                        BackgroundWorker.ReportProgress(procent, $"Renaming: {index - 1}/{count}");
                        src.Command.Base.Rename(Config.Index, index - 1, file.ToString());
                    }
                }*/

                index = 1;

                RenamePreview(cwd);
            }

            catch (Exception ex)
            {
                BackgroundWorker.CancelAsync();
            }
        }

        private void RenamePreview(string cwd)
        {
/*            string shoot = Shoot.ShootName(cwd);
            string pathPreview = Path.Combine(Config.Workspace, shoot, Config.Preview);

            Directory.SetCurrentDirectory(pathPreview);*/

/*            string[] files = src.Helper.Helper.SortPicturesByCreationTime(pathPreview);

            foreach (var file in files)
            {
                File.Delete(file);
            }*/
        }
    }
}
