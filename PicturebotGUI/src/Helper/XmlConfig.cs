using Picturebot.src.Logger;
using PicturebotGUI.src.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PicturebotGUI.src.Helper
{
    public static class XmlConfig
    {
        /// <summary>
        /// Update an attribute within the appender element
        /// </summary>
        /// <param name="appender">Search for the correct appender</param>
        /// <param name="debugLevel">Set the debug level</param>
        public static void UpdateAttributesXML(string appender, string debugLevel)
        {
            log4net.ILog log = LogHelper.GetLogger();

            string xml = "PicturebotGUI.exe.config";
            string xpath = $"configuration/log4net/appender[@name='{appender}']/threshold/@value";

            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xml);

                XmlNode node = xmlDoc.SelectSingleNode(xpath);
                // Update the debug level attribute within the configuration file
                node.InnerText = debugLevel;

                xmlDoc.Save(xml);
                log.Info("UpdateAttributesXML: successfully updated the attribute with the new debug level");

            }
            catch (Exception e)
            {
                log.Error("UpdateAttributesXML: failed to update the attribute with the new debug level", e);
                MessageBox.Show(e.Message);
            }
        }
    }
}
