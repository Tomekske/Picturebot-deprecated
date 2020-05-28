namespace PicturebotGUI.src.POCO
{
    /// <summary>
    /// POCO class to store the source and destination path of an image
    /// </summary>
    public class Drag
    {
        /// <summary>
        /// The source directory of the image
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// The source destination of the image
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Stores the source and destination path of an image
        /// </summary>
        /// <param name="source">The source directory of the image</param>
        /// <param name="desitnation">The destination of the image within the base flow</param>
        public Drag(string source, string desitnation)
        {
            Source = source;
            Destination = desitnation;
        }
    }
}
