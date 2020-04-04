using Picturebot.src.POCO;
using PicturebotGUI.src.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.Background
{
    public abstract class BaseBackground
    {
        public BackgroundWorker BackgroundWorker { get; set; }
        public Config Config { get; set; }
        public FormLoading FormLoading { get; set; }

        public void Start()
        {
            if (!BackgroundWorker.IsBusy)
            {
                BackgroundWorker.RunWorkerAsync();
            }
        }

        public void Progress(string text)
        {
            FormLoading.SetLabelStatus(text);
        }

        public void Finished(string text)
        {
            FormLoading.SetLabelStatus(text);
        }

        public abstract void Work();
    }
}
