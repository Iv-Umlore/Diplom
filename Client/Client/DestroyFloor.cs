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
    public partial class DestroyFloor : Form
    {
        List<floore> unvFloors;
        public DestroyFloor()
        {
            InitializeComponent();
            unvFloors = Bridge.GiveUnvalidFloor();
            for (int i = 0; i < unvFloors.Count; i++)
            {
                UnvalidFloors.Items.Add(unvFloors[i].name);
            }
        }

        private void DeleteFloor_Click(object sender, EventArgs e)
        {
            string value = UnvalidFloors.SelectedItem.ToString();
            if (value != "Создайте новый этаж для отображения его в списке")
            {
                for (int i = 0; i < unvFloors.Count; i++)
                {
                    if (unvFloors[i].name == value)
                    {
                        Bridge.DeleteFloor(unvFloors[i].id);
                        break;
                    }
                }
            }
            this.Close();
        }
    }
}
