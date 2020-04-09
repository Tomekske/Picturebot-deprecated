using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.Background
{
    public class Move : BaseBackground
    {
        public Dictionary<string, Drag> _dictMoveFiles { get; set; }
        private List<Picture> _listpictures = new List<Picture>();
        public Move(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, Dictionary<string, Drag> dictMoveFiles, List<Picture> listpictures)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            _dictMoveFiles = dictMoveFiles;
            _listpictures = listpictures;
        }

        public override void Work()
        {
            int index = 1;
            int lenght = _listpictures.Count;

            foreach (var picture in _listpictures)
            {
                string text = $"Moved files: {index}/{lenght}";
                int procent = index++ * 100 / lenght;
                BackgroundWorker.ReportProgress(procent, text);
                Console.WriteLine($"SRC: {_dictMoveFiles[picture.Absolute].Source}");
                Console.WriteLine($"DST: {_dictMoveFiles[picture.Absolute].Destination}");

                File.Copy(_dictMoveFiles[picture.Absolute].Source, _dictMoveFiles[picture.Absolute].Destination);
            }
        }
    }
}
