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
        //Einstellungen einstellungen = new Einstellungen();

        public double[] schrittlänge = new double[500];
        public double schrittlängealt = 100;
        int x, y;
        public int waagrechtoben = 280;
        public int waagrechtunten = 880;

        public int color_r = 255;
        public int color_g = 0;
        public int color_b = 0;

        public int color_box_r = 180;
        public int color_box_g = 150;
        public int color_box_b = 0;

        public int zähler = 0;
        public int dicke = 5;//dicke der Roten Linien
        public static int sendvar = 0;
        public int count = 0;
        public int count2 = 0;
        public string reglerwertalt;
        public int längewertalt;
        Bitmap image1 = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            int rightfoot = waagrechtunten - 250;
            int leftfoot = waagrechtoben + 150;

            right_one.Hide();
            right_two.Hide();
            right_three.Hide();
            right_four.Hide();
            right_five.Hide();
            right_six.Hide();
            left_one.Hide();
            left_two.Hide();
            left_three.Hide();
            left_four.Hide();
            left_five.Hide();
            left_six.Hide();

            right_one.Top = rightfoot;
            right_two.Top = rightfoot;
            right_three.Top = rightfoot;
            right_four.Top = rightfoot;
            right_five.Top = rightfoot;
            right_six.Top = rightfoot;

            left_one.Top = leftfoot;
            left_two.Top = leftfoot;
            left_three.Top = leftfoot;
            left_four.Top = leftfoot;
            left_five.Top = leftfoot;
            left_six.Top = leftfoot;

            image1 = new Bitmap(1920, 1080); //1920 entspricht 5m = 500cm
            try
            {
                for (x = 0; x < image1.Width; x++)               //waagrecht unten
                {

                    for (y = waagrechtunten - dicke; y < waagrechtunten + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrachte unten
                for (x = 0; x < image1.Width; x++)              //waagrecht oben
                {

                    for (y = waagrechtoben - dicke; y < waagrechtoben + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
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
                            Color newColor = Color.FromArgb(0,0,0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //box
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //fläche
                    {
                        for (y = waagrechtunten - dicke; y < waagrechtunten + 5; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(color_r, color_g, color_b);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //waagrecht unten sektion
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //fläche
                    {
                        for (y = waagrechtoben - dicke; y < waagrechtoben + 5; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(color_r, color_g, color_b);
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
                                Color newColor = Color.FromArgb(color_r, color_g, color_b);
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
                            Color newColor = Color.FromArgb(color_box_r, color_box_g, color_box_b);
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
            right_one.Hide();
            right_two.Hide();
            right_three.Hide();
            right_four.Hide();
            right_five.Hide();
            right_six.Hide();
            left_one.Hide();
            left_two.Hide();
            left_three.Hide();
            left_four.Hide();
            left_five.Hide();
            left_six.Hide();

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

                    for (y = waagrechtunten - dicke; y < waagrechtunten + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrecht unten
                for (x = 0; x < image1.Width; x++)              //waagrecht unten
                {

                    for (y = waagrechtoben - dicke; y < waagrechtoben + 5; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
                        image1.SetPixel(x, y, newColor);
                    }
                }//waagrecht oben
                for (zähler = 0; zähler < Convert.ToDouble(steps.Text); zähler++)
                {
                    for (x = Convert.ToInt32(schrittlänge[zähler]); x < schrittlänge[zähler] + dicke + 5; x++) //senkrecht
                    {
                        for (y = waagrechtoben; y < waagrechtunten; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(color_r, color_g, color_b);
                            image1.SetPixel(x, y, newColor);
                        }
                    }
                    schrittlänge[zähler + 1] = schrittlänge[zähler] + schrittlängealt;
                }//senkrecht
                for (x = 1920 - dicke - 5; x < 1920; x++) //senkrecht ende
                {
                    for (y = waagrechtoben; y < waagrechtunten; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
                        image1.SetPixel(x, y, newColor);
                    }
                }//senkrechte am schluss automatisch

                //für Fußabdruck: Schritt 1 bei Koordinate 0; letzter schritt bei 1920
                if (schrittlänge[1] != null)
                    right_one.Left = Convert.ToInt32(schrittlänge[1]) - (right_one.Size.Width / 2); right_one.Show();
                if (schrittlänge[2] != null)
                    left_one.Left = Convert.ToInt32(schrittlänge[2]) - (left_one.Size.Width / 2); left_one.Show();
                if (schrittlänge[3] != null)
                    right_two.Left = Convert.ToInt32(schrittlänge[3]) - (right_one.Size.Width / 2); right_two.Show();
                if (schrittlänge[4] != null)
                    left_two.Left = Convert.ToInt32(schrittlänge[4]) - (left_one.Size.Width / 2); left_two.Show();
                if (schrittlänge[5] != null)
                    right_three.Left = Convert.ToInt32(schrittlänge[5]) - (right_one.Size.Width / 2); right_three.Show();
                if (schrittlänge[6] != null)
                    left_three.Left = Convert.ToInt32(schrittlänge[6]) - (left_one.Size.Width / 2); left_three.Show();
                if (schrittlänge[7] != null)
                    right_four.Left = Convert.ToInt32(schrittlänge[7]) - (right_one.Size.Width / 2); right_four.Show();
                if (schrittlänge[8] != null)
                    left_four.Left = Convert.ToInt32(schrittlänge[8]) - (left_one.Size.Width / 2); left_four.Show();
                if (schrittlänge[9] != null)
                    right_five.Left = Convert.ToInt32(schrittlänge[9]) - (right_one.Size.Width / 2); right_five.Show();
                if (schrittlänge[10] != null)
                    left_five.Left = Convert.ToInt32(schrittlänge[10]) - (left_one.Size.Width / 2); left_five.Show();
                if (schrittlänge[11] != null)
                    right_six.Left = Convert.ToInt32(schrittlänge[11]) - (right_one.Size.Width / 2); right_six.Show();
                if (schrittlänge[12] != null)
                    left_six.Left = Convert.ToInt32(schrittlänge[12]) - (left_one.Size.Width / 2); left_six.Show();



                //Array.Clear(schrittlänge,0,schrittlänge.Length);
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
                    return "Bitte überprüfen Sie eingegebene Werte, wenn das Problem ohne Grund auftritt kontaktieren Sie bitte die Entwickler";
                }
            }
        }
        public Ex1 e001 = new Ex1();
        public void feet()
        {
            int[] step_right = new int[5];
            if (step_right[0] != null)
            {
                right_one.Top = waagrechtoben + 20;
                right_one.Show();
            }
        }
    }
}
