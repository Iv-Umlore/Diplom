using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Exponat : Form
    {
        List<Bitmap> images;
        int count = 0;
        int exhibID;
        bool _isAdmin;

        public Exponat(Exhibit exh, bool isAdmin)
        {
            exhibID = exh._id;
            _isAdmin = isAdmin;
            InitializeComponent();
            label1.Text = "Нажмите на изображение\n      для увеличения";
            if (!_isAdmin) Delete.Hide();
            SetExponat(exh);
        }

        private void SetExponat(Exhibit exh)
        {
            Name.Text = exh._name;
            Description.Text = exh._description;
            images = new List<Bitmap>();
            for (int i = 0; i < exh.images_id.Count; i++)
            {
                Bitmap tmp = Bridge.GiveImage(exh.images_id[i]);
                images.Add(tmp);
            }
            if (images.Count == 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile("1436029898_1190099444.jpg");
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = images[0];
            }
        }

        private void Plus(ref int i)
        {
            i++;
            if (i >= images.Count) i = 0;
        }

        private void Minus(ref int i)
        {
            i--;
            if (i <= -1) i = images.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Plus(ref count);
            pictureBox1.Image = images[count];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Minus(ref count);
            pictureBox1.Image = images[count];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowImage SI = new ShowImage(pictureBox1.Image);
            SI.ShowDialog();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Exhibit exh = new Exhibit(exhibID);
            SetExponat(exh);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Bridge.DeleteExhibitNumber(exhibID);
            Close();
        }
    }
}
