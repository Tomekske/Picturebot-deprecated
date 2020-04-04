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
    public class MassRename : BaseBackground
    {
        public MassRename(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
        }

        public override void Work()
        {
/*            string cwd = Directory.GetCurrentDirectory();
            string shoot = Shoot.ShootName(cwd);
            string pathPreview = Path.Combine(Config.Workspace, shoot, Config.BaseFlow);

            // Console.WriteLine(pathPreview);

            Directory.SetCurrentDirectory(pathPreview);
            src.Command.Base.MassRename(Config.Index);

            pathPreview = Path.Combine(Config.Workspace, shoot, Config.Preview);
            string[] files = Directory.GetFiles(pathPreview);

            foreach (var file in files)
            {
                File.Delete(file);
            }*/


            //RenamePreview();
        }

        private void RenamePreview(string[] files)
        {


        }
    }
}
