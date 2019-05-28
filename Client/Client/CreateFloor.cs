using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateFloor : Form
    {
        Bitmap currentimage;
        Floor curfloor;

        int firstX, firstY;
        bool flag = false;
        bool delete = false;

        const int linewidth = 3;

        public CreateFloor(Floor Floor = null, Bitmap scheme = null)
        {
            InitializeComponent();
            curfloor = Floor;
            Bitmap image;
            if (Floor == null)
            {
                image = new Bitmap(580, 340);
                for (int i = 0; i < 580; i++)
                    for (int j = 0; j < 340; j++)
                        image.SetPixel(i, j, Color.Black);
            }
            else
            {
                image = scheme;
                textBox1.Text = Floor.FloorName;
                Result.Text = "Вы можете отредактировать \n схему и название.";
            }
            currentimage = image;
            pictureBox1.Image = currentimage;
        }

        private int IsCorrect(string str)
        {
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == '&' && str[i + 1] == '*' && str[i + 2] == '&') return 1; // запрещённые символы
            }
            return 0;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (text.Length != 0) {
                int value = IsCorrect(text);
                if (value == 0)
                {
                    if (curfloor == null)
                    {
                        Bridge.CreateNewScheme(currentimage, currentimage.Width, currentimage.Height);
                        Bridge.AddNewFloor(text);
                        this.Close();
                    }
                    else
                    {
                        Bridge.ChangeFloor(curfloor.GetId(), text);
                        Bridge.ChangeScheme(currentimage, curfloor.SchemeId);
                        this.Close();
                    }
                }
                else Result.Text = "Нельзя использовать \nсочетание &&*&& в названии";
            }
            else Result.Text = "Введите название этажа";
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!delete)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                Pen pen = new Pen(Color.Aqua, linewidth);
                g.DrawLine(pen, firstX, firstY, e.X, e.Y);
                g.Save();
                currentimage = (Bitmap)pictureBox1.Image;
            }
            currentimage = (Bitmap)pictureBox1.Image;
            flag = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                if (!delete)
                {
                    pictureBox1.Image = currentimage;
                    Graphics g = pictureBox1.CreateGraphics();

                    Pen pen = new Pen(Color.Aqua, linewidth);
                    g.DrawLine(pen, firstX, firstY, e.X, e.Y);                    

                }
                else
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    g.FillRectangle(Brushes.Black, e.X - linewidth - 2, e.Y - linewidth - 2, 2 * linewidth + 4, 2 * linewidth + 4);
                    g.Dispose();
                    pictureBox1.Invalidate();
                                        
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!delete)
                pictureBox1.Image = currentimage;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (delete)
            {
                button.Text = "Ластик";
                delete = false;
            }
            else
            {
                button.Text = "Отмена";
                delete = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstX = e.X;
            firstY = e.Y;
            flag = true;
        }
        
    }
}
