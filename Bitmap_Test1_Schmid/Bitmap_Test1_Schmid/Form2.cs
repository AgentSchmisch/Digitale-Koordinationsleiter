using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Bitmap_Test1_Schmid
{
    public partial class Form2 : Form
    {
        //Einstellungen einstellungen = new Einstellungen();

        public double[] schrittlänge = new double[500];
        public double schrittlängealt = 100;
        int x, y;

        public System.Media.SoundPlayer player;
        public string audio_mac = "mac_bong.wav";
        public string audio_game = "fight_theme.wav";

        public int color_r = 255;//linienfarbe
        public int color_g = 255;
        public int color_b = 255;
        
        public int color_box_r = 150;//objektfarbe
        public int color_box_g = 0;
        public int color_box_b = 180;

        public int zähler = 0;
        public int dicke = 5;//dicke der Linien
        public int sendvar = 6;
        public int count = 0;
        public int count2 = 0;
        public string reglerwertalt;
        public int längewertalt;

        public int[] objektposition = new int[3];
        public bool objekte_generiert = false;

        public int Auflösung_Projektor_x = 1280; //Auflösung Projektor ----- zeile 230 wird die Zahl 1280.0 verwendet
        public int Auflösung_Projektor_y = 800;

        public int waagrechtoben = 100;
        public int waagrechtunten = 700;

        private Form1 _form1_main;
        public Form1 form1_main
        {
            set { this._form1_main = value; }
        }

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
            fuß_zurücksetzen.Location = new Point(0, Auflösung_Projektor_y-fuß_zurücksetzen.Size.Height);

            next_player.Location = new Point(Auflösung_Projektor_x / 2 - next_player.Width/2, Auflösung_Projektor_y / 2 - next_player.Height/2);

            color_box_r = Properties.Settings.Default.colorbox_r;
            color_box_g = Properties.Settings.Default.colorbox_g;
            color_box_b = Properties.Settings.Default.colorbox_b;
            color_r = Properties.Settings.Default.color_r;
            color_g = Properties.Settings.Default.color_g;//ruft Farbwerte ab
            color_b = Properties.Settings.Default.color_b;

            int rightfoot = waagrechtunten - 215 - right_one.Height / 2;//fußabdruck y position definieren
            int leftfoot = waagrechtoben + 215 + right_one.Height / 2;

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

            timer1.Start(); //ohne animation das kommentieren
            //linienladen(); //ohne animation das auskommentieren

            //zu "linieladen()" verschoben !!!
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
                        for (y = waagrechtoben + 5; y < waagrechtunten - dicke; y++)
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
                    for (x = Convert.ToInt32(schrittlänge[Convert.ToInt32(reglerwertalt)]) + dicke + 5; x < schrittlänge[Convert.ToInt32(reglerwertalt) + längewertalt]; x++) //fläche
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
                schrittlänge[1] = 1280.0 / sendvar;
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
                        for (y = waagrechtoben + 5; y < waagrechtunten - dicke; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(color_r, color_g, color_b);
                            image1.SetPixel(x, y, newColor);
                        }
                    }
                    schrittlänge[zähler + 1] = schrittlänge[zähler] + schrittlängealt;
                }//senkrecht
                for (x = image1.Width - dicke - 5; x < image1.Width; x++) //senkrecht ende
                {
                    for (y = waagrechtoben; y < waagrechtunten; y++)
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
        int neu = 0;
        int delay = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            koordinaten_left.Location = new Point(Auflösung_Projektor_x/2 - koordinaten_left.Width/2, Auflösung_Projektor_y - 100 );
            koordinaten_left.Visible = true;
            if (neu + Auflösung_Projektor_x / 2 < Auflösung_Projektor_x)
            {
                neu += 10;

                for (x = 630 + neu; x < 630 + neu + 10; x++)
                {
                    for (y = 0; y < Auflösung_Projektor_y; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
                        image1.SetPixel(x, y, newColor);
                    }
                }
                for (x = 650 - neu; x > 650 - neu - 10; x--)
                {
                    for (y = 0; y < Auflösung_Projektor_y; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(color_r, color_g, color_b);
                        image1.SetPixel(x, y, newColor);
                    }
                }
                pictureBox1.Image = image1;
            }

            else
            {
                delay++;
                kur.Location = new Point(Auflösung_Projektor_x / 2 - kur.Width / 2, Auflösung_Projektor_y / 2 - kur.Height / 2);
                if (delay > 10 && delay < 12)
                {
                    kur.Visible = true;
                    player = new System.Media.SoundPlayer(audio_mac);
                    //player.Play();
                }
                if (delay == 100 || delay == 200)
                {
                    koordinaten_left.Text = "Loading ";
                }
                if (delay == 10 || delay == 40 || delay == 70 || delay == 100 || delay == 140 || delay == 170 || delay == 200)
                {
                    koordinaten_left.Text += ".";
                }
                if (delay > 200)
                {
                    linienladen();
                    timer1.Stop();
                    koordinaten_left.Visible = false;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            pictureBox1.Image = image1;
        }
        public void linienladen()
        {
            try
            {
                kur.Visible = false;
                for (x = 0; x < image1.Width; x++)
                {
                    for (y = 0; y < image1.Height; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(0, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//alles löschen

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
        public bool klick = true;
        public void himmel_hölle()
        {
            if (klick)
            {
                var = false;
                for (x = 0; x < image1.Width; x++) //alles löschen
                {
                    for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(0, 0, 0);
                        image1.SetPixel(x, y, newColor);
                    }
                }//Alles löschen
                himmelhölle.Visible = true;
                himmelhölle.Location = new Point(0, Auflösung_Projektor_y / 2 - himmelhölle.Height / 2);
                pictureBox1.Image = image1;
            }
            if (!klick)
            {
                himmelhölle.Visible = false;
                bestätigen.PerformClick();
            }

            klick = !klick;
        }
        public void rnd_dots()
        {
            if (klick)
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
                var = true;
                pictureBox1.Paint += drawcircle;
                pictureBox1.Image = image1;
            }
            if (!klick)
            {
                var = false;
                himmelhölle.Visible = false;
                pictureBox1.Image = image1;
                //bestätigen.PerformClick();
            }

            klick = !klick;
        }
        public bool var = true;
        public void drawcircle(object sender, PaintEventArgs g)
        {
            if (var)
            {
                int radius = 10;
                Random rnd = new Random();
                Random rnd2 = new Random();
                rnd2.Next(Auflösung_Projektor_y / 2, waagrechtunten);
                Pen redPen = new Pen(Color.Red, 20);//Kreisradius
                Pen bluePen = new Pen(Color.Blue, 20);//Kreisradius
                for (int i = 0; i < 5; i++)
                {
                    g.Graphics.DrawEllipse(bluePen, (int)(130 + (i * 270) - radius), (int)(rnd.Next(waagrechtoben+100, Auflösung_Projektor_y / 2) - radius), (int)(radius * 2), (int)(radius * 2));
                }
                for (int i = 0; i < 5; i++)
                {
                    g.Graphics.DrawEllipse(redPen, (int)(30 + (i * 270) - radius), (int)(rnd2.Next(Auflösung_Projektor_y / 2, waagrechtunten-100) - radius), (int)(radius * 2), (int)(radius * 2));
                }
            }
            if (!var)
            {
                int radius = 20;
                Random rnd = new Random();
                Random rnd2 = new Random();
                rnd2.Next(Auflösung_Projektor_y / 2, waagrechtunten);
                Pen redPen = new Pen(Color.Transparent, 20);//Kreisradius
                Pen bluePen = new Pen(Color.Transparent, 20);//Kreisradius
                for (int i = 0; i < 5; i++)
                {
                    g.Graphics.DrawEllipse(bluePen, (int)(130 + (i * 270) - radius), (int)(rnd.Next(waagrechtoben+100, Auflösung_Projektor_y / 2) - radius), (int)(radius * 2), (int)(radius * 2));
                }
                for (int i = 0; i < 5; i++)
                {
                    g.Graphics.DrawEllipse(redPen, (int)(30 + (i * 270) - radius), (int)(rnd2.Next(Auflösung_Projektor_y / 2, waagrechtunten-100) - radius), (int)(radius * 2), (int)(radius * 2));
                }
            }
        }
        public void kantenerkennung()
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

            for (x = 0; x < 16; x++)                                                    //links oben
            {
                for (y = waagrechtoben - 8; y < waagrechtoben + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(color_r, color_g, color_b);
                    image1.SetPixel(x, y, newColor);
                }
            }
            for (x = Auflösung_Projektor_x - 16; x < Auflösung_Projektor_x; x++)        //rechts oben
            {
                for (y = waagrechtoben - 8; y < waagrechtoben + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(color_r, color_g, color_b);
                    image1.SetPixel(x, y, newColor);
                }
            }
            for (x = 0; x < 16; x++)                                                    //links unten
            {
                for (y = waagrechtunten - 8; y < waagrechtunten + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(color_r, color_g, color_b);
                    image1.SetPixel(x, y, newColor);
                }
            }
            for (x = Auflösung_Projektor_x - 16; x < Auflösung_Projektor_x; x++)        //rechts unten
            {
                for (y = waagrechtunten - 8; y < waagrechtunten + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(color_r, color_g, color_b);
                    image1.SetPixel(x, y, newColor);
                }
            }
            kanten.Visible = true;
            kanten.Location = new Point(Auflösung_Projektor_x / 2 - kanten.Width / 2, Auflösung_Projektor_y / 2 - kanten.Height / 2);

            pictureBox1.Paint += DrawLineFloat;

            pictureBox1.Image = image1;
        }
        public bool draw = true;
        public void DrawLineFloat(object sender, PaintEventArgs e)
        {
            if (draw)
            {
                Pen blackPen = new Pen(Color.White, 1);

                e.Graphics.DrawLine(blackPen, kanten.Location.X + kanten.Width, kanten.Location.Y, Auflösung_Projektor_x - 21, waagrechtoben + 18); //ro
                e.Graphics.DrawLine(blackPen, kanten.Location.X + kanten.Width, kanten.Location.Y + kanten.Height, Auflösung_Projektor_x - 21, waagrechtunten - 18); //ru
                e.Graphics.DrawLine(blackPen, kanten.Location.X, kanten.Location.Y, 21, waagrechtoben + 18); //lo
                e.Graphics.DrawLine(blackPen, kanten.Location.X, kanten.Location.Y + kanten.Height, 21, waagrechtunten - 18); //lu
                draw = false;
            }
            if (!draw)
            {
                Pen blackPen = new Pen(Color.Transparent, 1);

                e.Graphics.DrawLine(blackPen, kanten.Location.X + kanten.Width, kanten.Location.Y, Auflösung_Projektor_x - 21, waagrechtoben + 18); //ro
                e.Graphics.DrawLine(blackPen, kanten.Location.X + kanten.Width, kanten.Location.Y + kanten.Height, Auflösung_Projektor_x - 21, waagrechtunten - 18); //ru
                e.Graphics.DrawLine(blackPen, kanten.Location.X, kanten.Location.Y, 21, waagrechtoben + 18); //lo
                e.Graphics.DrawLine(blackPen, kanten.Location.X, kanten.Location.Y + kanten.Height, 21, waagrechtunten - 18); //lu
            }
        }

        public void endkanten()
        {
            for (x = 0; x < 16; x++)                                                    //links oben
            {
                for (y = waagrechtoben - 8; y < waagrechtoben + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }
            for (x = Auflösung_Projektor_x - 16; x < Auflösung_Projektor_x; x++)        //rechts oben
            {
                for (y = waagrechtoben - 8; y < waagrechtoben + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }
            for (x = 0; x < 16; x++)                                                    //links unten
            {
                for (y = waagrechtunten - 8; y < waagrechtunten + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }
            for (x = Auflösung_Projektor_x - 16; x < Auflösung_Projektor_x; x++)        //rechts unten
            {
                for (y = waagrechtunten - 8; y < waagrechtunten + 8; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }

            kanten.Visible = false;
            bestätigen.PerformClick();
        }
        public void zufallbox()
        {
            if (!objekte_generiert)
            {
                Array.Clear(objektposition, 0, objektposition.Length);
                Random objekt = new Random();
                objektposition.ToString();
                for (int i = 0; i < längebox.Value; i++)
                {

                    do objektposition[i] = objekt.Next(1, Convert.ToInt32(steps.Text));
                    while (objektposition[0] == objektposition[1]);
                    //while (objektposition[i].ToString().Contains(number.ToString()));

                    //objektposition[i] = objekt.Next(2, Convert.ToInt32(steps.Text) - 1);
                }
                objekte_generiert = !objekte_generiert;
            }
            if (objekte_generiert)
            {
                for (int i = 0; i < längebox.Value; i++)
                {
                    for (x = Convert.ToInt32(schrittlänge[objektposition[i]]) + dicke + 5; x < schrittlänge[objektposition[i] + 1]; x++)                 //fläche
                    {
                        for (y = waagrechtoben - 50; y < waagrechtunten + 50; y++)
                        {
                            Color pixelColor = image1.GetPixel(x, y);
                            Color newColor = Color.FromArgb(color_box_r, color_box_g, color_box_b);
                            image1.SetPixel(x, y, newColor);
                        }
                    } //box 
                }
                pictureBox1.Image = image1;
            }
        }
        bool unendlich = true;
        public double timervalue = 0;
        public double startzeit = 20;
        private void Multiplayer_timer_Tick(object sender, EventArgs e)
        {
            timervalue = Math.Round(timervalue + 0.1, 2);
            time_left.Text = "Verbleibende Zeit: " + Math.Round((startzeit - timervalue), 2) + " sek.";
            if(startzeit - timervalue <= 0)
            {
                Multiplayer_timer.Stop();
                //_form1_main.kinectToolStripMenuItem.PerformClick();
                player.Stop();
                player = new System.Media.SoundPlayer(audio_mac);
                player.Play();
                //_form1_main.kinectToolStripMenuItem.PerformClick();
                strich_rechts.Visible = false;
                _form1_main.kinectM.startstop_multiplayer = true;
                _form1_main.userchanged = !_form1_main.userchanged;
                _form1_main.kinectM.schongestartet = false;
                _form1_main.screen.timervalue = 0;
                _form1_main.kinectM.wieviel_geschafft = 0;
                neuerwert();
                next_player.Visible = true;
                Thread.Sleep(3000);
                next_player.Visible = false;
            }
        }

        public void unendlich_()
        {
            if (unendlich)
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

                unendlich2.Visible = true; 
                unendlich2.Location = new Point(0, Auflösung_Projektor_y / 2 - unendlich2.Height / 2);
            }
            if (!unendlich)
            {
                unendlich2.Visible = false;
            }
            unendlich = !unendlich;
        }
        public void neuerwert()
        {
            if (_form1_main.userchanged)
            {
                user2.BackColor = Color.Transparent;
                user1.BackColor = Color.Green;
                user1.Text = "Spieler 1: " + _form1_main.kinectM.wieviel_geschafft;
            }
            if (!_form1_main.userchanged)
            {
                user2.BackColor = Color.Green;
                user1.BackColor = Color.Transparent;
                user2.Text = "Spieler 2: " + _form1_main.kinectM.wieviel_geschafft;
            }
        }

    }
}
