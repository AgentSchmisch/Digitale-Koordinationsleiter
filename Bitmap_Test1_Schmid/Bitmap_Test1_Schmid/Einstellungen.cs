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
            this._form1.screen.dicke = bar_dicke.Value;
            if (colorpicker.Color.R == 0 && colorpicker.Color.G == 0 && colorpicker.Color.B == 0)
            {
                this._form1.screen.color_r = 255;
                this._form1.screen.color_g = 255;
                this._form1.screen.color_b = 255;
            }
            else
            {
                this._form1.screen.color_r = colorpicker.Color.R;
                this._form1.screen.color_g = colorpicker.Color.G;
                this._form1.screen.color_b = colorpicker.Color.B;
            }
            if(this._form1.screen.color_box_r==0 && this._form1.screen.color_box_g==0 && this._form1.screen.color_box_b == 0)
            {
                this._form1.screen.color_box_r = 180;
                this._form1.screen.color_box_g = 150;
                this._form1.screen.color_box_b = 0;
            }
            else
            {
                this._form1.screen.color_box_r = colorpicker2.Color.R;
                this._form1.screen.color_box_g = colorpicker2.Color.G;
                this._form1.screen.color_box_b = colorpicker2.Color.B;
            }
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
