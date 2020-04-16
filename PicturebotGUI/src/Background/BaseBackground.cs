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
        /// <summary>
        /// BackgroundWorker object
        /// </summary>
        public BackgroundWorker BackgroundWorker { get; set; }
        /// <summary>
        /// Config object
        /// </summary>
        public Config Config { get; set; }
        /// <summary>
        /// FormLoading objerct
        /// </summary>
        public FormLoading FormLoading { get; set; }

        /// <summary>
        /// Start the backgroundWorker sequence
        /// </summary>
        public void Start()
        {
            if (!BackgroundWorker.IsBusy)
            {
                BackgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Set the progress status in the associated label
        /// </summary>
        /// <param name="text"></param>
        public void Progress(string text)
        {
            FormLoading.SetLabelStatus(text);
        }

        /// <summary>
        /// Set the finish status in the associated label
        /// </summary>
        /// <param name="text"></param>
        public void Finished(string text)
        {
            FormLoading.SetLabelStatus(text);
        }

        /// <summary>
        /// Implement a different ways of the work method
        /// </summary>
        public abstract void Work();
    }
}
