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
        public Client()
        {
            InitializeComponent();
            ManagerPanel.Hide();
            AdministratorPanel.Hide();
            GoodFloorList.Items.Add("тестовая строка");
            
        }

        private void Autorization_Click(object sender, EventArgs e)
        {
            AdministratorPanel.Show();
            ManagerPanel.Show();
        }

        private void DeleteFloor_Click(object sender, EventArgs e)
        {

        }
    }
}
