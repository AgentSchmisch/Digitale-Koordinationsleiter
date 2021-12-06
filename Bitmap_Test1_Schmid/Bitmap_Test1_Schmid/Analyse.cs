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
    public partial class Analyse : Form
    {
        public Analyse()
        {
            InitializeComponent();
        }
        int x = 0;
        int time = 0;
        int opacity = 0;
        public double schrittdurchschnitt = 0;
        public double kleinsterabstand = 500;
        public double größterabstand = 0;
        public double schritte = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            if (time >= 30)
            {
                x += 15;
                if (x <= 200)
                {
                    Size = new Size(470, 136 + x);
                    this.CenterToScreen();
                }
                if (x > 300)
                {
                    if (opacity <= 190)
                    {
                        Color myColor = Color.FromArgb(40 + opacity, 50 + opacity, 60 + opacity);
                        lab_steps.ForeColor = myColor;
                        steps.ForeColor = myColor;
                    }
                    if (opacity>=20 && opacity <= 210)
                    {
                        Color myColor = Color.FromArgb(20 + opacity, 30 + opacity, 40 + opacity);
                        lab_durchs.ForeColor = myColor;
                        durchs.ForeColor = myColor;
                    }
                    if (opacity >= 40 && opacity <= 230)
                    {
                        Color myColor = Color.FromArgb(opacity, 10 + opacity, 20 + opacity);
                        lab_klein.ForeColor = myColor;
                        klein.ForeColor = myColor;
                    }
                    if (opacity >= 60 && opacity <= 250)
                    {
                        Color myColor = Color.FromArgb(opacity-20, opacity-10, opacity);
                        lab_groß.ForeColor = myColor;
                        groß.ForeColor = myColor;
                    }

                    opacity += 10;
                    if (opacity >= 260)
                        timer.Stop(); return;
                }
            }
        }

        private void Analyse_Load(object sender, EventArgs e)
        {
            Color myColor = Color.FromArgb(40, 50, 60);

            lab_durchs.ForeColor = myColor;
            lab_klein.ForeColor = myColor;
            lab_groß.ForeColor = myColor;
            lab_steps.ForeColor = myColor;
            durchs.ForeColor = myColor;
            klein.ForeColor = myColor;
            groß.ForeColor = myColor;
            steps.ForeColor = myColor;

            steps.Text = schritte.ToString();
            durchs.Text = schrittdurchschnitt.ToString();
            klein.Text = kleinsterabstand.ToString();
            groß.Text = größterabstand.ToString();

            Size = new Size(470, 136);
            this.CenterToScreen();
            timer.Start();


        }
    }
}
