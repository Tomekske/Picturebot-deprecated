using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturebotGUI.src.POCO
{
    /// <summary>
    /// POCO class to store dimensions of the cropping canvas
    /// </summary>
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Constructor method of the canvas POCO class
        /// </summary>
        /// <param name="width">Width of the canvas</param>
        /// <param name="height">Height of the canvas</param>
        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// OVerride method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Width: {Width}; Height: {Height}";
        }
    }
}
