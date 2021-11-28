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
            ColorDialog colorpicker2 = new ColorDialog();
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
                this._form1.screen.color_r = Properties.Settings.Default.color_r;
                this._form1.screen.color_g = Properties.Settings.Default.color_g;
                this._form1.screen.color_b = Properties.Settings.Default.color_b;
            }
            else
            {
                this._form1.screen.color_r = colorpicker.Color.R;
                this._form1.screen.color_g = colorpicker.Color.G;
                this._form1.screen.color_b = colorpicker.Color.B;
            }
            if(colorpicker2.Color.R == 0 && colorpicker2.Color.G == 0 && colorpicker2.Color.B == 0)
            {
                this._form1.screen.color_box_r = Properties.Settings.Default.colorbox_r;
                this._form1.screen.color_box_g = Properties.Settings.Default.colorbox_g;
                this._form1.screen.color_box_b = Properties.Settings.Default.colorbox_b;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this._form1.screen.color_box_r = 150;
            this._form1.screen.color_box_g = 0;
            this._form1.screen.color_box_b = 180;

            this._form1.screen.color_r = 255;
            this._form1.screen.color_g = 255;
            this._form1.screen.color_b = 255;

            Properties.Settings.Default.colorbox_r = 150;
            Properties.Settings.Default.colorbox_g =0;
            Properties.Settings.Default.colorbox_b =180;
            Properties.Settings.Default.color_r =255;
            Properties.Settings.Default.color_g = 255;//speichert Farbwerte
            Properties.Settings.Default.color_b = 255;
            Properties.Settings.Default.Save();
        }
    }
}
