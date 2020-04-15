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

        /// <summary>
        /// This backgroundWorker class will move the pictures to the backup flow
        /// </summary>
        /// <param name="backgroundWorker">The associated backgroundWorker object</param>
        /// <param name="config">The configuration object</param>
        /// <param name="formLoading">The formLoading object</param>
        /// <param name="dictMoveFiles">Dictionary containing a source and destination property</param>
        /// <param name="listpictures">List containing all the pictures within the base flow</param>
        public Move(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, Dictionary<string, Drag> dictMoveFiles, List<Picture> listpictures)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            _dictMoveFiles = dictMoveFiles;
            _listpictures = listpictures;
        }

        /// <summary>
        /// Move all the pictures wihtin the base flow to the backup directory
        /// </summary>
        public override void Work()
        {
            int index = 1;
            int lenght = _listpictures.Count;

            foreach (var picture in _listpictures)
            {
                string text = $"Moved files: {index}/{lenght}";
                int procent = index++ * 100 / lenght;
                BackgroundWorker.ReportProgress(procent, text);

                File.Copy(_dictMoveFiles[picture.Absolute].Source, _dictMoveFiles[picture.Absolute].Destination);
            }
        }
    }
}
