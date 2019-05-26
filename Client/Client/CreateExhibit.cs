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
    public partial class CreateExhibitWindows : Form
    {
        List<Bitmap> BitList;
        public CreateExhibitWindows()
        {
            InitializeComponent();
            BitList = new List<Bitmap>();
        }

        private int IsCorrect(string str)
        {
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == '&' && str[i + 1] == '*' && str[i + 2] == '&') return 2; // запрещённые символы
            }
            return 0;
        }
        
        private void SearchAndDownloadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();// Поиск и загрука изображений в Bitmap[]

            openFile.Filter = "Image Files(*.JPG;*.PNG;*.BMP)|*.JPG;*.PNG;*.BMP|All files (*.*)|*.*";            

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap result = new Bitmap(openFile.FileName);
                    BitList.Add(result);
                    AllDownloadFiles.Text += openFile.FileName + ";\n";
                    Console.Write(result.ToString());
                }
                catch { MessageBox.Show("Не удалось открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }                        
            
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string description = Descript.Text;

            int code1 = IsCorrect(name);
            int code2 = IsCorrect(description);

            if (name == "" || description == "")
                Result.Text = "Заполните все поля";
            else
            {
                if (code1 == 0 && code2 == 0)
                {
                    Bridge.AddExhibit(name, description);
                    for (int i = 0; i < BitList.Count; i++)
                    {
                        Bridge.SendImage(BitList[i],BitList[i].Width, BitList[i].Height);
                    }
                    this.Close();
                }
                else
                {
                    if (code1 == 2 || code2 == 2) Result.Text = "Нельзя использовать &&*&& в названии и описании";
                }
            }
           
        }
    }
}
