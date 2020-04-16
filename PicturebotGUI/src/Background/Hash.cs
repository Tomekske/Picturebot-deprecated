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

        /// <summary>
        /// This backgroundWorker class will hash every RAW file within the base flow and store
        /// </summary>
        /// <param name="backgroundWorker">The associated backgroundWorker object</param>
        /// <param name="config">The configuration object</param>
        /// <param name="formLoading">The formLoading object</param>
        /// <param name="shootInfo">The shoot information</param>
        /// <param name="flow">The flow where the file is stored</param>
        public Hash(BackgroundWorker backgroundWorker, Config config, FormLoading formLoading, string shootInfo, string flow)
        {
            BackgroundWorker = backgroundWorker;
            Config = config;
            FormLoading = formLoading;
            _shootInfo = shootInfo;
            _flow = flow;
        }

        /// <summary>
        /// Hash the RAW file
        /// </summary>
        public override void Work()
        {
            Flow flow = new Flow(Config);
            flow.HashRename(_shootInfo, _flow);
        }
    }
}
