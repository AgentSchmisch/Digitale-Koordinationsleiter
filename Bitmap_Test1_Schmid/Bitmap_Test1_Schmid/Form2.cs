﻿using System;
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
        public int waagrechtoben = 100;
        public int waagrechtunten = 600;

        public int color_r = 255;
        public int color_g = 255;
        public int color_b = 255;

        public int color_box_r = 150;
        public int color_box_g = 0;
        public int color_box_b = 180;

        public int zähler = 0;
        public int dicke = 5;//dicke der Linien
        public int sendvar = 10;
        public int count = 0;
        public int count2 = 0;
        public string reglerwertalt;
        public int längewertalt;

        public int Auflösung_Projektor_x = 1280; //Auflösung Projektor
        public int Auflösung_Projektor_y = 800;

        Bitmap image1 = null;
        public KinectMonitor _Kinect;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Auflösung_Projektor_x, Auflösung_Projektor_y);
            pictureBox1.Size = new Size(Auflösung_Projektor_x, Auflösung_Projektor_y);

            color_box_r =Properties.Settings.Default.colorbox_r;
            color_box_g=Properties.Settings.Default.colorbox_g;
            color_box_b=Properties.Settings.Default.colorbox_b;
            color_r=Properties.Settings.Default.color_r;
            color_g=Properties.Settings.Default.color_g;//ruft Farbwerte ab
            color_b=Properties.Settings.Default.color_b;

            int rightfoot = waagrechtunten - 250;//fußabdruck y position definieren
            int leftfoot = waagrechtoben + 150;

            right_one.Top = rightfoot;
            right_two.Top = rightfoot;
            right_three.Top = rightfoot;
            right_four.Top = rightfoot;
            right_five.Top = rightfoot;
            right_six.Top = rightfoot;
            right_seven.Top = rightfoot;
            right_eight.Top = rightfoot;
            right_nine.Top = rightfoot;
            right_ten.Top = rightfoot;

            left_one.Top = leftfoot;
            left_two.Top = leftfoot;
            left_three.Top = leftfoot;
            left_four.Top = leftfoot;
            left_five.Top = leftfoot;
            left_six.Top = leftfoot;
            left_seven.Top = leftfoot;
            left_eight.Top = leftfoot;
            left_nine.Top = leftfoot;
            left_ten.Top = leftfoot;

            image1 = new Bitmap(Auflösung_Projektor_x, Auflösung_Projektor_y);
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
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //waagrechte unten
                    {
                        for (y = waagrechtunten - dicke; y < waagrechtunten + 5; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(color_r, color_g, color_b);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //waagrecht unten sektion
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //waagrechte oben
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
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void längebox_ValueChanged(object sender, EventArgs e)
        {
            längelabel.Text = längebox.Value.ToString();
        }

        private void regler_Scroll(object sender, EventArgs e)
        {

        }
        string stepsalt = "0";
        private void bestätigen_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;//warte cursor für visuelles Feedback
            try
            {
                for (zähler = 0; zähler < Convert.ToDouble(stepsalt); zähler++)
                {
                    for (x = Convert.ToInt32(schrittlänge[zähler]); x < schrittlänge[zähler] + dicke + 5; x++) //senkrecht
                    {
                        for (y = waagrechtoben+5; y < waagrechtunten-dicke; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(0, 0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    }
                    schrittlänge[zähler + 1] = schrittlänge[zähler] + schrittlängealt;
                }//vorherige senkrechte Linien löschen

                if (count == 1) //entfernt die Box wenn eine Vorhanden ist
                {
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //fläche
                    {
                        for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(0, 0, 0, 0);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //box löschen
                }

                regler.Maximum = sendvar - 1;
                schrittlänge[1] = image1.Width / sendvar;
                schrittlängealt = schrittlänge[1];

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
                for (zähler = 0; zähler < sendvar; zähler++)
                {
                    for (x = Convert.ToInt32(schrittlänge[zähler]); x < schrittlänge[zähler] + dicke + 5; x++) //senkrecht
                    {
                        for (y = waagrechtoben +5; y < waagrechtunten - dicke; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(color_r, color_g, color_b);
                            image1.SetPixel(x, y, newColor);
                        }
                    }
                    schrittlänge[zähler + 1] = schrittlänge[zähler] + schrittlängealt;
                }//senkrecht
                for (x = image1.Width-dicke-5; x < image1.Width; x++) //senkrecht ende
                {
                    for (y = waagrechtoben; y < waagrechtunten ; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
                        image1.SetPixel(x, y, newColor);
                    }
                }//senkrechte am schluss automatisch

                pictureBox1.Image = image1;
                stepsalt = sendvar.ToString();// für löschvorgang
            }
            catch (ArgumentException)
            {
                MessageBox.Show(e001.Message, "Error", 0, MessageBoxIcon.Error);
            }
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
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

        public void übertragung()
        {
            //_Kinect.form2 = this;
        }
        public void deleteall()
        {
            for (x = 0; x < image1.Width; x++) //alles löschen
            {
                for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }//Alles löschen
            bestätigen.PerformClick();
        }
        public void deletebox()
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
            for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //waagrechte unten
            {
                for (y = waagrechtunten - dicke; y < waagrechtunten + 5; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(color_r, color_g, color_b);
                    image1.SetPixel(x, y, newColor);
                }
            } //waagrecht unten sektion
            for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++)                 //waagrechte oben
            {
                for (y = waagrechtoben - dicke; y < waagrechtoben + 5; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(color_r, color_g, color_b);
                    image1.SetPixel(x, y, newColor);
                }
            } //waagrecht oben sektion

            pictureBox1.Image = image1;
        }
    }
}
