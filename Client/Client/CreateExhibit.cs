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
        public CreateExhibitWindows()
        {
            InitializeComponent();
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
            // Поиск и загрука изображений в Bitmap[]
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
                    // Загрузка изображений
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
