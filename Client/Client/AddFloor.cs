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
    public partial class AddFloor : Form
    {
        List<floore> unvFloors;
        int _NN;
        public AddFloor(int NextNumber)
        {
            InitializeComponent();
            _NN = NextNumber;
            unvFloors = Bridge.GiveUnvalidFloor();
            for (int i = 0; i < unvFloors.Count; i++)
            {
                UnvalidFloors.Items.Add(unvFloors[i].name);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string value = UnvalidFloors.SelectedItem.ToString();
            if (value != "Создайте новый этаж для отображения его в списке")
            {
                for (int i = 0; i < unvFloors.Count; i++)
                {
                    if (unvFloors[i].name == value) Bridge.AddFloorToValid(unvFloors[i].id, _NN);
                    break;
                }
            }
            this.Close();
        }
    }
}
