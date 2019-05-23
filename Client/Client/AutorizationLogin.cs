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
    public partial class AutorizationLogin : Form
    {
        public int root;
        public AutorizationLogin()
        {
            root = 0;
            TopMost = true;
            InitializeComponent();
            
        }

        private int IsCorrect(string str)
        {
            if (str.Length >= 100) return 1; // строка слишком длинная
            for (int i = 0; i < str.Length-2; i++)
            {
                if (str[i] == '&' && str[i + 1] == '*' && str[i + 2] == '&') return 2; // запрещённые символы
            }
            return 0;
        }

        private void Autorization_Click(object sender, EventArgs e)
        {
            string login = Login.Text;
            string pass = Password.Text;

            int code1 = IsCorrect(login);
            int code2 = IsCorrect(pass);

            if ( code1 == 0 && code2 == 0)
            {
                root = Bridge.Autorization(login, pass);
                if (root == 1 || root == 2) this.Close();
                else
                {
                    if (root == 0) Result.Text = "Неверная пара Логин - Пароль";    // Пароль неверный
                    if (root == -1) Result.Text = "Ошибка Сервера";                 // Проблема с конектом к базе данных
                    if (root == -2) Result.Text = "Неверная пара Логин - Пароль";   // Логин не существует
                }
            }
            else
            {
                if (code1 == 1 || code2 == 1) Result.Text = "Логин и пароль не должны превышать 100 символов.";
                if (code1 == 2 || code2 == 2) Result.Text = "Нельзя использовать &&*&& в логине или пароле";
            }
                /*проверки*/
        }

        private void AutorizationLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
