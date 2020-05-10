using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picturebot.src.POCO
{
    /// <summary>
    /// POCO class for obtaining the dimensions of a picture
    /// </summary>
    public class Dimension
    {
        /// <summary>
        /// Property contains the width of the picture
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Property contains the height of the picture
        /// </summary>
        public int Height { get; set; }

        public Dimension(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Override the ToString() method
        /// </summary>
        /// <returns>Stringified picture object</returns>
        public override string ToString()
        {
            return $"Dimension (Width, Height): ({Width}, {Height})";
        }
    }
}
