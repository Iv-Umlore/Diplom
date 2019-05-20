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
    public partial class Client : Form
    {
        bool isManager;
        bool isAdmin;
        public Client()
        {
            isManager = false;
            isAdmin = false;
            InitializeComponent();
            ManagerPanel.Hide();
            AdministratorPanel.Hide();
            GoodFloorList.Items.Add("тестовая строка");
            
        }

        private void Autorization_Click(object sender, EventArgs e)
        {
            UseRoot(2);
        }

        private void UseRoot(int root)
        {
            switch (root)
            {
                case 0:
                    {
                        Autorization.Show();
                        AdministratorPanel.Hide();
                        ManagerPanel.Hide();
                        isManager = false;
                        isAdmin = false;
                        break;
                    }
                case 1:
                    {
                        Autorization.Hide();
                        AdministratorPanel.Hide();
                        ManagerPanel.Show();
                        isManager = true;
                        isAdmin = false;
                        break;
                    }
                case 2:
                    {
                        Autorization.Hide();
                        AdministratorPanel.Show();
                        ManagerPanel.Show();
                        isManager = true;
                        isAdmin = true;
                        break;
                    }
                default:
                    {
                        Autorization.Show();
                        AdministratorPanel.Hide();
                        ManagerPanel.Hide();
                        isManager = false;
                        isAdmin = false;
                        break;
                    }
            }

        }

        private void DeleteFloor_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            UseRoot(0);
        }
    }
}
