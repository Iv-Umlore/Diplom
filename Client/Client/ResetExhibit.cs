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
    public partial class ResetExhibit : Form
    {
        private ExhibitSpace _ES;
        public ResetExhibit(ExhibitSpace ES)
        {
            InitializeComponent();
            _ES = ES;           
            for (int i = 0; i < _ES.GetExhibits().Count; i++)
                ThisPoint.Items.Add(_ES.GetExhibits()[i].exhibit_name);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            string name = ThisPoint.SelectedItem.ToString();
            Bridge.ResetExhibit(search(name).exhibit_id);
            Close();
        }

        private exh search(string name)
        {
            for (int i = 0; i < _ES.GetExhibits().Count; i++)
            {
                if (name == _ES.GetExhibits()[i].exhibit_name)
                    return _ES.GetExhibits()[i];
            }
            return new exh();
        }

    }
}
