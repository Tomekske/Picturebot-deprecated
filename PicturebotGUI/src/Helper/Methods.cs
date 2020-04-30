using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.Helper
{
    public static class Methods
    {
        /// <summary>
        /// Calculate the selected position within the listBox
        /// </summary>
        /// <param name="indexBefore">The selected index before a deletion is performed</param>
        /// <param name="countAfter">Count the amount of files after a deletion is performed</param>
        /// <returns>The calculated index</returns>
        public static int CalcListBoxIndex(int indexBefore, int countAfter)
        {
            int index = 0;

            // The last picture within the listBox is deleted
            if ((indexBefore == countAfter) && (countAfter != 0))
                index = indexBefore - 1;
            else if ((indexBefore < countAfter) && (countAfter != 0))
                index = indexBefore;
            else
                index = -1;

            return index;
        }
    }
}
