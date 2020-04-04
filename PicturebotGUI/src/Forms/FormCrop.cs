using ImageProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PicturebotGUI.src.POCO;
using Picturebot.src.POCO;

namespace PicturebotGUI
{
    public partial class FormCrop : Form
    {
        private Point _coordframe;
        private bool _toggle = false;

        private Bitmap _bitmap;
        private Bitmap _bmpCropped;

        private Canvas _canvas = new Canvas(250 ,250);
        private Config _config;
        private string _filepath;
        private Form1 _mainForm = null;
        private Pen _penCrop = new Pen(Color.Red, 1);

        /// <summary>
        /// Constructor of the FormCrop class
        /// </summary>
        /// <param name="form">Main form of the GUI application</param>
        /// <param name="config">Configuration object to access picture's bot configuration settings</param>
        /// <param name="filepath">File path to the picture which is getting cropped</param>
        public FormCrop(Form form, Config config, string filepath)
        {
            InitializeComponent();
            _mainForm = form as Form1;

            _config = config;
            _filepath = filepath;

            _bitmap = new Bitmap(_filepath);
            pbCrop.Image = (Image)_bitmap;

            _coordframe = new Point(0, 0);

            lbPictureBox.Text = $"{pbCrop.Width}x{pbCrop.Height}";
            lblPicture.Text = $"{_bitmap.Width}x{_bitmap.Height}";
        }

        /// <summary>
        /// Method to toggle the canvas frame
        /// </summary>
        private void pbCrop_MouseDown(object sender, MouseEventArgs e)
        {
            // Invert boolean
            _toggle = true ? _toggle = !_toggle : _toggle = !_toggle;
        }

        /// <summary>
        /// Draw a cropping canvas within the picturebox
        /// The selected area will be cropped
        /// </summary>
        /// <param name="canvas">Canvas dimensions</param>
        /// <param name="x">Canvas origin X-position</param>
        /// <param name="y">Canvas origin y-position</param>
        private void DrawCanvas(Canvas canvas, Point point)
        {
            // Refresh the picturebox every time the canvas is drawn
            pbCrop.Refresh();
            // Draw a the canvas as a rectangle 
            pbCrop.CreateGraphics().DrawRectangle(_penCrop, point.X, point.Y, canvas.Width, canvas.Height);
        }

        /// <summary>
        /// AABB collision algorithm
        /// </summary>
        /// <param name="canvas">Dimensions of the canvas frame</param>
        /// <returns>Returns true on collision</returns>
        private bool Collision(Canvas canvas)
        {
            // Top left corner
            if (_coordframe.X < 0 && _coordframe.Y < 0)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.X = 0;
                _coordframe.Y = 0;

                DrawCanvas(canvas, new Point(0, 0));

                return true;
            }

            // Top right corner
            if (_coordframe.X + canvas.Width > pbCrop.Width && _coordframe.Y < 0)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.X = pbCrop.Width - canvas.Width;
                _coordframe.Y = 0;

                DrawCanvas(canvas, new Point(pbCrop.Width - canvas.Width - 1, 0));

                return true;
            }

            // Bottom right corner
            if (_coordframe.X + canvas.Width > pbCrop.Width && _coordframe.Y + canvas.Height > pbCrop.Height)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.X = pbCrop.Width - canvas.Width;
                _coordframe.Y = pbCrop.Height - canvas.Height;

                DrawCanvas(canvas, new Point(pbCrop.Width - canvas.Width - 1, pbCrop.Height - canvas.Height - 1));

                return true;
            }

            // Bottom left corner
            if (_coordframe.X < 0 && _coordframe.Y + canvas.Height > pbCrop.Height)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.X = 0;
                _coordframe.Y = pbCrop.Height - canvas.Height;

                DrawCanvas(canvas, new Point(0, pbCrop.Height - canvas.Height - 1));

                return true;
            }

            // Top
            if (_coordframe.Y < 0)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.Y = 0;

                DrawCanvas(canvas, new Point(_coordframe.X, 0));

                return true;
            }

            // Left
            if(_coordframe.X < 0)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.X = 0;

                DrawCanvas(canvas, new Point(0, _coordframe.Y));

                return true;
            }

            // Bottom
            if (_coordframe.Y + canvas.Height > pbCrop.Height)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.Y = pbCrop.Height - canvas.Height;

                DrawCanvas(canvas, new Point(_coordframe.X, pbCrop.Height - canvas.Height));

                return true;
            }

            // right
            if (_coordframe.X + canvas.Width > pbCrop.Width)
            {
                // Make sure the coordinates are fixed on the outer edges, else the mouse's location will change the frame coordinate
                _coordframe.X = pbCrop.Width - canvas.Width;

                DrawCanvas(canvas, new Point(pbCrop.Width - canvas.Width - 1, _coordframe.Y));

                return true;
            }

            return false;
        }

        /// <summary>
        /// Draw a rectangle when moving the mouse
        /// </summary>
        private void pbCrop_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = $"X1: {_coordframe.X}; X2: {_coordframe.X + _canvas.Width}; Xt: {pbCrop.Width}";
            lblY.Text = $"Y1: { _coordframe.Y}; Y2: { _coordframe.Y + _canvas.Height}; Xy: {pbCrop.Height}";

            // When the canvas boolean is toggled draw a canvas
            if (_toggle)
            {
                // Make sure the frame is centered around the mouse cursor
                _coordframe.X = e.X - (_canvas.Width / 2);
                _coordframe.Y = e.Y - (_canvas.Height / 2);

                // Draw a frame when no collision with the outlined border is detected
                if (!Collision(_canvas)) DrawCanvas(_canvas, new Point(_coordframe.X, _coordframe.Y));
            }
        }

        /// <summary>
        /// Crop and save image
        /// </summary>
        private void btnCrop_Click(object sender, EventArgs e)
        {
            var memory = new MemoryStream();

            using (var img = new ImageFactory())
            {
                // Load the cropped bitmap into the imageFactory object
                img.Load((Image)_bmpCropped);
                // Crop and save the cropped image in memory
                img.Crop(new Rectangle(_coordframe.X, _coordframe.Y, _coordframe.X + _canvas.Width, _coordframe.Y + _canvas.Height)).Save(memory);

                // File is currently saved to the Instagram flow
                //img.Save(Picture.Instagram(_config, _filepath));

                // Update all the picture boxes on the main form
                //this._mainForm.UpdateBaseListBox();
                // Close the current activated form
                this.Close();
            }
        }

        /// <summary>
        /// Calculate the new width of the cropped picture
        /// </summary>
        /// <param name="height">Height of the canvas frame</param>
        /// <returns>Returns the calculated width</returns>
        private int CalculateNewWidth(int height)
        {
            double width = ((double)pbCrop.Width / (double)pbCrop.Height) *(double)height;
            return Convert.ToInt32(Math.Floor(width));
        }

        /// <summary>
        /// Calculate the new height of the cropped picture
        /// </summary>
        /// <param name="width">Width of the canvas frame</param>
        /// <returns>Returns the calculated height</returns>
        private int CalculateNewHeight(int width)
        {
            double height = ((double)pbCrop.Height / (double)pbCrop.Width) * (double)width;
            return Convert.ToInt32(Math.Floor(height));
        }

        /// <summary>
        /// Resize the original image
        /// </summary>
        /// <param name="canvas">Dimensions of the canvas frame</param>
        /// <param name="imagePath">Path to the image</param>
        /// <returns></returns>
        public static Image resizeImage(Canvas canvas, string imagePath)
        {
            var imageFactory = new ImageFactory();
            
            // Load a new image into the image factory object
            var image = imageFactory.Load(imagePath).Image;
            //  Resize the loaded image
            image = imageFactory.Resize(new Size(canvas.Width, canvas.Height)).Image;

            return image;
        }

        /// <summary>
        /// Select another frame ratio
        /// </summary>
        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Canvas canPicture;

            // Square 1080x1080 frame
            if(combo.SelectedIndex == 0)
            {
                _canvas = new Canvas(1080, 1080);

                canPicture = new Canvas(CalculateNewWidth(_canvas.Height), _canvas.Height);

                Image img = resizeImage(canPicture, _filepath);
                Bitmap bmp = new Bitmap(img);

                pbCrop.Image = (Image)bmp;

                _bmpCropped = bmp;

                lbPictureBox.Text = $"n {pbCrop.Width}x{pbCrop.Height}";
                lblPicture.Text = $"n {_bitmap.Width}x{_bitmap.Height}";
            }

            // Landscape 1080x566 frame
            else if (combo.SelectedIndex == 1)
            {
                _canvas = new Canvas(1080, 566);

                canPicture = new Canvas(_canvas.Width, CalculateNewHeight(_canvas.Width));

                Image img = resizeImage(canPicture, _filepath);
                Bitmap bmp = new Bitmap(img);

                pbCrop.Image = (Image)bmp;

                _bmpCropped = bmp;

                lbPictureBox.Text = $"n {pbCrop.Width}x{pbCrop.Height}";
                lblPicture.Text = $"n {_bitmap.Width}x{_bitmap.Height}";
            }

            // Portrait 1080x1350 frame
            else if (combo.SelectedIndex == 2)
            {
                _canvas = new Canvas(1080, 1350);

                canPicture = new Canvas(CalculateNewWidth(_canvas.Height), _canvas.Height);

                Image img = resizeImage(canPicture, _filepath);
                Bitmap bmp = new Bitmap(img);

                pbCrop.Image = (Image)bmp;

                _bmpCropped = bmp;

                lbPictureBox.Text = $"n {pbCrop.Width}x{pbCrop.Height}";
                lblPicture.Text = $"n {_bitmap.Width}x{_bitmap.Height}";
            }
        }
    }
}
