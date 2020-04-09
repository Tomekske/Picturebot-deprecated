using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturebotGUI.src.GUIThread
{
    /// <summary>
    /// Static class which implements methods to pass listBox data safely to an other thread
    /// </summary>
    public static class ThreadListBox
    {
        /// <summary>
        /// Append an item to the specified listBox which is thread safe
        /// </summary>
        /// <param name="listBox">The specified listBox</param>
        /// <param name="item">Text that needs to be appended</param>
        public static void AppendItem(ListBox listBox, string item)
        {
            if (listBox.InvokeRequired)
            {
                listBox.Invoke((MethodInvoker)delegate ()
                {
                    AppendItem(listBox, item);
                });
            }
            else
            {
                listBox.Items.Add(item);
            }
        }

        /// <summary>
        /// Clear the listBox
        /// </summary>
        /// <param name="listBox">The specified listBox</param>
        public static void Clear(ListBox listBox)
        {
            if (listBox.InvokeRequired)
            {
                listBox.Invoke((MethodInvoker)delegate ()
                {
                    Clear(listBox);
                });
            }
            else
            {
                listBox.Items.Clear();
            }
        }
    }
}
