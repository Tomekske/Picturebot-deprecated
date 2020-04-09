using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picturebot;
using Picturebot.src.POCO;
using PicturebotGUI.src.Enums;
using PicturebotGUI.src.POCO;

namespace PicturebotGUI.src.Background
{
    public class Hash : BaseBackground
    {
        private string _shootInfo = string.Empty;
        private string _flow = string.Empty;

        public Hash(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, string shootInfo, string flow)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            _shootInfo = shootInfo;
            _flow = flow;
        }

        public override void Work()
        {
            Flow flow = new Flow(Config);
            flow.HashRename(_shootInfo, _flow);
        }
    }
}
