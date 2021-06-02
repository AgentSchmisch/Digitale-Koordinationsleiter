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
    public partial class Form2 : Form
    {
        public double[] schrittlänge = new double[500];
        public double schrittlängealt = 100;
        int x, y;
        public int waagrechtoben = 280;
        public int waagrechtunten = 880;
        public int zähler = 0;
        public int dicke = 10;
        public static int sendvar = 0;
        
        public Form2()
        {
            InitializeComponent();
            
        }
        Bitmap image1 = new Bitmap(1920, 1080); //1920 entspricht 5m = 500cm
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                for (x = 0; x < image1.Width; x++)               //waagrecht unten
                {

                    for (y = waagrechtunten-dicke; y < waagrechtunten + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrachte unten
                for (x = 0; x < image1.Width; x++)              //waagrecht oben
                {

                    for (y = waagrechtoben-dicke; y < waagrechtoben + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrechte oben

                pictureBox1.Image = image1;

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Fehler");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void regler_ValueChanged(object sender, EventArgs e)
        {
            reglertext.Text = regler.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                

                for (x = 0; x < image1.Width; x++) //alles löschen
                {
                    for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(0, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//Alles löschen
                for (x = 0; x < image1.Width; x++)               //waagrecht unten
                {

                    for (y = waagrechtunten-dicke; y < waagrechtunten + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrachte unten
                for (x = 0; x < image1.Width; x++)              //waagrecht oben
                {

                    for (y = waagrechtoben-dicke; y < waagrechtoben + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrechte oben
                for (zähler = 0; zähler < Convert.ToDouble(steps.Text); zähler++)
                {
                    for (x = Convert.ToInt32(schrittlänge[zähler]); x < schrittlänge[zähler] +dicke+ 5; x++) //senkrecht
                    {
                        for (y = waagrechtoben; y < waagrechtunten; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(255, 0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    }
                    schrittlänge[zähler + 1] = schrittlänge[zähler] + schrittlängealt;
                } //linien erneut anzeigen
                for (x = 1920 - dicke - 5; x < 1920; x++) //senkrecht
                {
                    for (y = waagrechtoben; y < waagrechtunten; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//senkrechte am schluss automatisch
                for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglertext.Text)])+dicke+5; x < schrittlänge[Convert.ToInt32(reglertext.Text) + längebox.Value]; x++)                 //fläche
                {

                    for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(150, 150, 20, 255);
                        image1.SetPixel(x, y, newColor);
                    }
                } //box
                pictureBox1.Image = image1;

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Fehler");
            }
        }

        private void längebox_ValueChanged(object sender, EventArgs e)
        {
            längelabel.Text = längebox.Value.ToString();
        }

        private void bestätigen_Click(object sender, EventArgs e)
        {
            try
            {
                steps.Text = sendvar.ToString();
                regler.Maximum = Convert.ToInt32(steps.Text) - 1;
                schrittlänge[1] = image1.Width / Convert.ToDouble(steps.Text);
                //MessageBox.Show(schrittlänge[1].ToString());
                schrittlängealt = schrittlänge[1];
                schrittlänge[0] = 0;


                for (x = 0; x < image1.Width; x++) //alles löschen
                {
                    for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(0, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//Alles löschen
                for (x = 0; x < image1.Width; x++)               //waagrecht oben
                {

                    for (y = waagrechtunten-dicke; y < waagrechtunten + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrecht unten
                for (x = 0; x < image1.Width; x++)              //waagrecht unten
                {

                    for (y = waagrechtoben-dicke; y < waagrechtoben + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrecht oben

                for (zähler = 0; zähler < Convert.ToDouble(steps.Text); zähler++)
                {
                    for (x = Convert.ToInt32(schrittlänge[zähler]); x < schrittlänge[zähler] + dicke+5; x++) //senkrecht
                    {
                        for (y = waagrechtoben; y < waagrechtunten; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(255, 0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    }
                    schrittlänge[zähler + 1] = schrittlänge[zähler] + schrittlängealt;
                }//senkrecht

                for (x = 1920-dicke-5; x <1920; x++) //senkrecht
                {
                    for (y = waagrechtoben; y < waagrechtunten; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(255, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//senkrechte am schluss automatisch
                pictureBox1.Image = image1;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Fehler");
            }
        }
    }
}
