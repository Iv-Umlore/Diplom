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
    public partial class ChangePass : Form
    {
        string _login;
        string _pass;

        public ChangePass(string login, string pass)
        {
            _login = login;
            _pass = pass;
            TopMost = true;
            InitializeComponent();
            
        }

        private int IsCorrect(string str)
        {
            if (str.Length == 0) return 3;
            if (str.Length >= 100) return 1; // строка слишком длинная
            for (int i = 0; i < str.Length-2; i++)
            {
                if (str[i] == '&' && str[i + 1] == '*' && str[i + 2] == '&') return 2; // запрещённые символы
            }
            return 0;
        }
        
        private void AutorizationLogin_Load(object sender, EventArgs e)
        {

        }

        private void Change_Click(object sender, EventArgs e)
        {
            string pass1 = Password1.Text;
            string pass2 = Password2.Text;
            if (pass1 == pass2)
            {
                int code = IsCorrect(pass1);


                if (code == 0)
                {
                    Bridge.ChangePassword(_login, pass1);
                    Close();
                }
                else
                {
                    if (code == 1) Result.Text = "Логин и пароль не должны превышать 100 символов.";
                    if (code == 2) Result.Text = "Нельзя использовать &&*&& в логине или пароле";
                    if (code == 3) Result.Text = "Пароль должен содержать хоть что-то";
                }
            }
            else
            {
                Result.Text = "Пароли не совпадают";
            }
        }
    }
}
