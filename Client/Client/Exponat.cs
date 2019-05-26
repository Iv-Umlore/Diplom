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
        public Exponat(Exhibit exh)
        {
            InitializeComponent();
            Name.Text = exh._name;
            Description.Text = exh._description;
            for (int i = 0; i < exh.images_id.Count; i++)
            {
                Bitmap tmp = Bridge.GiveImage(exh.images_id[i]);
                pictureBox1.Height = tmp.Height;
                pictureBox1.Width = tmp.Width;
                pictureBox1.Image = tmp;
            }
        }
    }
}
