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
        public ConvertRaw(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, string shootInfo)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            _shootInfo = shootInfo;
        }

        public override void Work()
        {
            int index = 1;

            try
            {
                /*                # magick convert "<path>" -quality <quality>% -verbose "<outputPath>"
                                command = f"magick convert \"{path}\" -quality {quality}% -verbose \"{output}\""*/

               string path = Path.Combine(Config.Workspace, _shootInfo, Workflow.Baseflow);
                Guard.Filesystem.PathExist(path);


                int count = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length;

                string[] files = Directory.GetFiles(path).OrderByDescending(d => new FileInfo(d).LastWriteTime).Reverse().ToArray();

                foreach (var file in files)
                {
                    if (!BackgroundWorker.CancellationPending)
                    {
                        int procent = index++ * 100 / count;
                        BackgroundWorker.ReportProgress(procent, $"Converting: {index - 1}/{count}");
                        Picture picture = new Picture(file, Config.Workspace, index - 1);
                        string dst = Path.Combine(Config.Workspace, _shootInfo, Workflow.Preview, $"{picture.Filename}.jpg");

                        Console.WriteLine(picture.Absolute);
                        Console.WriteLine(dst);
                        GUI.Convert(picture.Absolute, dst);
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
