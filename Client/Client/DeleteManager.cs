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
    public partial class DeleteManager : Form
    {
        
        public DeleteManager()
        {
            InitializeComponent();
            RefreshManagerList();
        }

        private void RefreshManagerList()
        {
            string[] res = Bridge.GiveAllManager();
            for (int i = 0; i < res.Length; i++)
                AllManagers.Items.Add(res[i]);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Bridge.DeleteManager(AllManagers.SelectedItem.ToString());
            this.Close();
            // RefreshManagerList();
        }
    }
}
