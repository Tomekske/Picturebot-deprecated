using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturebot.src.Enums
{
    /// <summary>
    /// String enum with regex patterns
    /// </summary>
    public static class Pattern
    {
        /// <summary>
        /// Obtain shoot information from a path: D:\Pictures\London 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF -> London 05-02-2020
        /// </summary>
        public static string Shoot { get { return @"(\w+( +\w+)*\s+\d+-\d+-\d+)"; } }

        /// <summary>
        /// Obtain the date when the shoot was taken from the shoot information: London 05-02-2020 -> 05-02-2020
        /// </summary>
        public static string Date { get { return @"\d+-\d+-\d+"; } }

        /// <summary>
        /// Obtain the shoot name from the shoot information: London 05-02-2020 -> London
        /// </summary>
        public static string Name {  get { return @"(\w+( +\w+)*\s)"; } }
    }
}
