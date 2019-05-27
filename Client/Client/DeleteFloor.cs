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
    public partial class DeleteFloor : Form
    {
        List<floore> unvFloors;
        public DeleteFloor()
        {
            InitializeComponent();
            unvFloors = Bridge.GiveValidFloor();
            for (int i = 0; i < unvFloors.Count; i++)
            {
                ValidFloor.Items.Add(unvFloors[i].name);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string value = ValidFloor.SelectedItem.ToString();
            
                for (int i = 0; i < unvFloors.Count; i++)
                {
                if (unvFloors[i].name == value)
                {
                    Bridge.UnvalidFloor(unvFloors[i].id);
                    break;
                }
                    
                }
            this.Close();
        }
    }
}
