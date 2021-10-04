using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class Einstellungen : Form
    {
        Form2 screen = new Form2();
        public Einstellungen()
        {
            InitializeComponent();
        }

        private void Einstellungen_Load(object sender, EventArgs e)
        {
            ColorDialog colorpicker = new ColorDialog();
            
        }

        private void but_dicke_Click(object sender, EventArgs e)
        {
            int breite = bar_dicke.Value;
            screen.dicke = breite;
        }

        private void bar_dicke_ValueChanged(object sender, EventArgs e)
        {
            anzeige.Text = bar_dicke.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorpicker.ShowDialog();          
            screen.color_r = colorpicker.Color.R;
            screen.color_g = colorpicker.Color.G;
            screen.color_b = colorpicker.Color.B;
        }
    }
}
