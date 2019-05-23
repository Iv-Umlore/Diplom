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
    public partial class SetExhibit : Form
    {
        exh[] free;
        int currentPoint;
        public SetExhibit(int idP)
        {
            InitializeComponent();
            currentPoint = idP;
            free = Bridge.GetFreeExh();
            for (int i = 0; i < free.Length;i++)
                FreeExhibits.Items.Add(free[i].exhibit_name);
        }

        private void Set_Click(object sender, EventArgs e)
        {
            string name = FreeExhibits.SelectedItem.ToString();
            Bridge.SetExhibit(currentPoint, search(name).exhibit_id);
            Close();
        }

        private exh search(string name)
        {
            for (int i = 0; i < free.Length; i++)
            {
                if (name == free[i].exhibit_name)
                    return free[i];
            }
            return new exh();
        }
    }
}
