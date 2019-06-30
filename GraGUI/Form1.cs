using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelGry;

namespace GraGUI
{
    public partial class Form1 : Form
    {
        private Gra g;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNowaGra_Click(object sender, EventArgs e)
        {
            groupBoxLosowanie.Visible = true;
        }

        private void buttonWylosuj_Click(object sender, EventArgs e)
        {
            // try-catch
            int zakresOd = int.Parse( textBoxZakresOd.Text );
            int zakresDo = int.Parse(textBoxZakresDo.Text);

            g = new Gra( zakresOd, zakresDo );
        }
    }
}
