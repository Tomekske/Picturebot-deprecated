using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PicturebotGUI.src.POCO;

namespace PicturebotGUI
{
    public partial class FormPreview : Form
    {
        private int count = 0;
        private int index = 0;
        private string _path = string.Empty;
        private Config config;
        private List<string> _lst = new List<string>();

        public FormPreview(Config _config, string path, List<string> lst)
        {
            InitializeComponent();
            _path = path;
            config = _config;
            pbPicture.ImageLocation = path;

            _lst = lst;
            count = lst.Count;
            index = Convert.ToInt32(Picture.Index(path));

            UpdateMetaData(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index += 1;

            UpdatePicture();
        }

        private void UpdateMetaData(string path)
        {
            string msg = $"{index}/{count}";
            this.Text = pbPicture.ImageLocation;
            lblIndex.Text = msg;
        }

        private void UpdatePicture()
        {
            string fileName = Picture.FileName(_path);
            _path = fileName;

            Regex re = new Regex(@"([a-zA-z]+_\d+-\d+-\d+_)\d+.[a-zA-Z]+");
            Match match = re.Match(fileName);

            
            if (index > count)
            {
                index = 1;
            }

            else if (index < 1)
            {
                index = count;
            }

            Console.WriteLine($"index: {index}");

            pbPicture.ImageLocation = _lst[index - 1];

            UpdateMetaData(Picture.Preview(config, _lst[index-1]));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            index -= 1;
            UpdatePicture();
        }

        private void FormPreview_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: index -= 1; UpdatePicture(); break;
                case Keys.D: index += 1; UpdatePicture(); break;
                case Keys.Escape: this.Close(); break;
            }
        }
    }
}
