using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturebot.src.POCO;
using PicturebotGUI.src.POCO;

namespace PicturebotGUI.src.Background
{
    public class Hash : BaseBackground
    {
        public Hash(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
        }

        public override void Work()
        {
            src.Command.Base.Hash(Config.Index);
        }
    }
}
