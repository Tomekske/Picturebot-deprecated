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
        public Dictionary<string, Drag> DictFiles { get; set; }
        public ListBox _listBox { get; set; }
        public Move(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, Dictionary<string, Drag> dictFiles, ListBox listbox)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            DictFiles = dictFiles;
            _listBox = listbox;
        }

        public override void Work()
        {
            int index = 1;
            int lenght = _listBox.Items.Count;

            foreach (string file in _listBox.Items)
            {
                string text = $"Moved files: {index}/{lenght}";
                int procent = index++ * 100 / lenght;
                BackgroundWorker.ReportProgress(procent, text);
                File.Copy(DictFiles[file].Source, DictFiles[file].Destination);
            }
        }
    }
}
