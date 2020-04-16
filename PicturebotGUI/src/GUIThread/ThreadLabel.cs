using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.GUIThread
{
    /// <summary>
    /// Static class which implements methods to pass label data safely to an other thread
    /// </summary>
    public static class ThreadLabel
    {
        /// <summary>
        /// Set a text on a specified label which is thread safe
        /// </summary>
        /// <param name="label">The specified label</param>
        /// <param name="text">Text that needs to be set</param>
        public static void SetText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate()
                {
                    SetText(label, text);
                });
            }
            else
            {
                label.Text = text;
            }
        }
    }
}
