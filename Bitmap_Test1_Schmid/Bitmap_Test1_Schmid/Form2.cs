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
        public int count=0;
        public int count2 = 0;
        public string reglerwertalt;
        public int längewertalt;


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
                MessageBox.Show(e001.Message, "Error", 0, MessageBoxIcon.Error);
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
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                //längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                schrittlängealt = schrittlänge[1];
                schrittlänge[0] = 0;

                /*
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

                                        for (y = waagrechtunten - dicke; y < waagrechtunten + 5; y++)
                                        {
                                            Color pixelColor = image1.GetPixel(x, y);
                                            Color newColor = Color.FromArgb(255, 0, 0);
                                            image1.SetPixel(x, y, newColor);
                                        }
                                    }//waagrachte unten
                                    for (x = 0; x < image1.Width; x++)              //waagrecht oben
                                    {

                                        for (y = waagrechtoben - dicke; y < waagrechtoben + 5; y++)
                                        {
                                            Color pixelColor = image1.GetPixel(x, y);
                                            Color newColor = Color.FromArgb(255, 0, 0);
                                            image1.SetPixel(x, y, newColor);
                                        }
                                    }//waagrechte oben
                                    for (zähler = 0; zähler < Convert.ToDouble(steps.Text); zähler++)
                                    {
                                        for (x = Convert.ToInt32(schrittlänge[zähler]); x < schrittlänge[zähler] + dicke + 5; x++) //senkrecht
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
                                    }//senkrechte am schluss automatisch*/ //nicht gebraucht

                
                if (count == 1) //entfernt nur die bisherige Box und erneuert die waagrechte oben und unten
                {
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //fläche
                    {
                        for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(0, 0, 0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //box
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //fläche
                    {
                        for (y = waagrechtunten - dicke; y < waagrechtunten + 5; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(255, 0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //waagrecht unten sektion
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //fläche
                    {
                        for (y = waagrechtoben - dicke; y < waagrechtoben + 5; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(255, 0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //waagrecht oben sektion
                    count = 0;
                }
                if (längewertalt >= 2) //setzt die schrittlinien ein, wenn welche verschwinden (nur wenn länger als 2 Kästchen)
                {
                    for (zähler = Convert.ToInt32(reglerwertalt); zähler < Convert.ToDouble(reglerwertalt) + längewertalt; zähler++)
                    {
                        for (x = Convert.ToInt32(schrittlänge[zähler]); x < schrittlänge[zähler] + dicke + 5; x++) //senkrecht
                        {
                            for (y = waagrechtoben; y < waagrechtunten; y++)
                            {
                                Color pixelColor = image1.GetPixel(x, y);
                                Color newColor = Color.FromArgb(255, 0, 0);
                                image1.SetPixel(x, y, newColor);
                            }
                        }
                        schrittlänge[zähler + 1] = schrittlänge[zähler] + schrittlängealt;
                    } //setzt die senkrechten ein, durch ein längeres Objekt verschwunden sind
                }
                if (count == 0)//Einblendung der Box
                {
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglertext.Text)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglertext.Text) + längebox.Value]; x++)                 //fläche
                    {
                        for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(150, 150, 20, 255);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //box
                    count = 1;
                }
                
                reglerwertalt = reglertext.Text;
                längewertalt = längebox.Value;

                pictureBox1.Image = image1;

            }
            catch (ArgumentException)
            {
                MessageBox.Show(e001.Message, "Error", 0, MessageBoxIcon.Error);
            }
        }

        private void längebox_ValueChanged(object sender, EventArgs e)
        {
            längelabel.Text = längebox.Value.ToString();
        }

        private void regler_Scroll(object sender, EventArgs e)
        {

        }

        private void bestätigen_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;//warte cursor für visuelles Feedback
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
                MessageBox.Show(e001.Message, "Error", 0, MessageBoxIcon.Error);
            }
        }
        public class Ex1 : Exception // für personalisierte Fehlermeldungen
        {
            
            public override string Message
            {
                get
                {
                    return "Bitte üerprüfen Sie eingegebene Werte, wenn das Problem ohne Grund auftritt kontaktieren Sie bitte die Entwickler";
                }
            }
        }
        public Ex1 e001 = new Ex1();
    }
}
