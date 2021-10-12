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

        public Einstellungen()
        {
            InitializeComponent();
        }

        private Form1 _form1;
        public Form1 form1
        {
            set { this._form1 = value; }
        }

        private void Einstellungen_Load(object sender, EventArgs e)
        {
            ColorDialog colorpicker = new ColorDialog();

        }

        private void but_dicke_Click(object sender, EventArgs e)
        {

        }

        private void bar_dicke_ValueChanged(object sender, EventArgs e)
        {
            anzeige.Text = bar_dicke.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorpicker.ShowDialog();
        }

        private void Einstellungen_FormClosed(object sender, FormClosedEventArgs e)
        {
            screen.color_r = colorpicker.Color.R;
            screen.color_g = colorpicker.Color.G;
            screen.color_b = colorpicker.Color.B;

            screen.color_box_r = colorpicker2.Color.R;
            screen.color_box_g = colorpicker2.Color.G;
            screen.color_box_b = colorpicker2.Color.B;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            colorpicker2.ShowDialog();
        }

        private void Einstellungen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Speichern_Click(object sender, EventArgs e)
        {

        }
    }
}
