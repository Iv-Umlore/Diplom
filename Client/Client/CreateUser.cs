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
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }


        private int IsCorrect(string str)
        {
            if (str.Length == 0) return 1;
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == '&' && str[i + 1] == '*' && str[i + 2] == '&') return 2; // запрещённые символы
            }
            return 0;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string[] parameters = new string[3];
            parameters[0] = Login.Text;
            parameters[1] = Pass1.Text;
            parameters[2] = Pass2.Text;

            if (parameters[1] != parameters[2]) Result.Text = "Пароли не совпадают";
            else
            {
                int[] code = new int[2];
                code[0] = IsCorrect(parameters[0]);
                code[1] = IsCorrect(parameters[1]);

                if (code[0] == 0 && code[1] == 0)
                {
                    Bridge.CreateManager(parameters[0], parameters[1]);
                }
                else
                {
                    if (code[0] == 1 || code[1] == 1) Result.Text = "Логин и пароль не должны быть путыми";
                    if (code[0] == 2 || code[1] == 2) Result.Text = "Нельзя использовать &&*&& в логине или пароле";
                }

            }
        }
    }
}
