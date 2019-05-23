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
    public partial class Exponat : Form
    {
        public Exponat(Exhibit exh)
        {
            InitializeComponent();
            Name.Text = exh._name;
            Description.Text = exh._description;
            // image
        }
    }
}
