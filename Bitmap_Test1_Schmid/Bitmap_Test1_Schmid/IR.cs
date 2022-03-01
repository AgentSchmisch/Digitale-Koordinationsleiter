using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class IR : Form
    {
        public IR()
        {
            InitializeComponent();
        }
        KinectSensor sensor = null;
        KinectSensor rgbsensor = null;
        MultiSourceFrameReader reader = null;
        MultiSourceFrameReader rgb = null;
        BlobCounter counter = null;

        private Form1 _form1_2;
        public Form1 form1_2
        {
            set { this._form1_2 = value; }
        }

        string[] possibleTracker;
        double[] ecken_x = new double[4];
        double[] ecken_y = new double[4];

        int mode = 0;
        public double multiplikator;

        public double mittelpunkt_links = 0;
        public double mittelpunkt_rechts = 0;

        public double mittelpunkt_links_y = 0;
        public double mittelpunkt_rechts_y = 0;//unwichtig: das wurde geändert

        int kreise = 0;

        private void IR_Load_1(object sender, EventArgs e)
        {
            error.Text = "        Kalibrierung abgeschlossen!\nSie können das Fenster nun schließen";

            sensor = KinectSensor.GetDefault();
            //rgbsensor = KinectSensor.GetDefault();

            if (sensor != null)
            {
                sensor.Open();
            }
            reader = sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Infrared);
            reader.MultiSourceFrameArrived += reader_IRFrameArrived;
        }

        void reader_IRFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            if (mode == 1)
            {
                return;
            }

            var reference = e.FrameReference.AcquireFrame();
            using (InfraredFrame frame = reference.InfraredFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    warten.Visible = false;
                    kal.Enabled = true;
                    int width = frame.FrameDescription.Width;
                    int height = frame.FrameDescription.Height;
                    ushort[] data = new ushort[width * height];
                    byte[] pixelData = new byte[width * height * 4];
                    possibleTracker = new string[width * height * 4];
                    int xcoord = 0;
                    int ycoord = 0;

                    frame.CopyFrameDataToArray(data);
                    int akt = 0;
                    Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                    for (int infraredIndex = 0; infraredIndex < data.Length; infraredIndex++)
                    {
                        ushort ir = data[infraredIndex];
                        byte intensity = (byte)(ir >> 8);

                        pixelData[infraredIndex * 4] = intensity; // Blue
                        pixelData[infraredIndex * 4 + 1] = intensity; // Green   
                        pixelData[infraredIndex * 4 + 2] = intensity; // Red
                        pixelData[infraredIndex * 4 + 3] = 255;//Brightness
                    }
                    var bitmapdata = bitmap.LockBits(
                        new Rectangle(0, 0, width, height),
                        ImageLockMode.WriteOnly,
                        bitmap.PixelFormat
                    );
                    IntPtr ptr = bitmapdata.Scan0;

                    Marshal.Copy(pixelData, 0, ptr, pixelData.Length);
                    bitmap.UnlockBits(bitmapdata);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);

                    counter = new BlobCounter();
                    EuclideanColorFiltering filter = new EuclideanColorFiltering();
                    filter.CenterColor = new RGB(Color.White); //Pure White
                    filter.Radius = (short)trackBar1.Value; //Increase this to allow off-whites
                    filter.FillOutside = false;
                    filter.FillColor = new RGB(Color.White); //Replacement Color

                    Bitmap bmp = filter.Apply(bitmap);

                    counter.MinWidth = 100;
                    counter.MinHeight = 100;
                    counter.BackgroundThreshold = Color.Gray;
                    counter.ProcessImage(bmp);
                    Blob[] blobs = counter.GetObjectsInformation();
                    Pen redPen = new Pen(Color.Red, 20);//Kreisradius
                    Graphics g = Graphics.FromImage(bmp);
                    SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

                    for (int i = 0; i < blobs.Length; i++)
                    {
                        List<IntPoint> edgePoints = counter.GetBlobsEdgePoints(blobs[i]);

                        AForge.Point center;
                        float radius;

                        if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                        {
                            g.DrawEllipse(redPen,
                                (int)(center.X - radius),
                                (int)(center.Y - radius),
                                (int)(radius * 2),
                                (int)(radius * 2));
                            if (kreise == 0)
                            {
                                ecken_x[0] = (int)center.X;
                                ecken_y[0] = (int)center.Y;
                            }
                            if (kreise ==1)
                            {
                                ecken_x[1] = (int)center.X;
                                ecken_y[1] = (int)center.Y;
                            }
                            if (kreise == 2)
                            {
                                ecken_x[2] = (int)center.X;
                                ecken_y[2] = (int)center.Y;
                            }
                            if (kreise == 3)
                            {
                                ecken_x[3] = (int)center.X;
                                ecken_y[3] = (int)center.Y;
                                kreise = 0;

                                for (int z = 0; z < 4; z++)
                                {
                                    for (int j = i + 1; j < 4; j++)
                                    {
                                        if (ecken_x[z] == ecken_x[j])
                                        {
                                            //timer1.Start();
                                            //error.Visible = true;
                                            return;
                                        }
                                    }
                                }//doppelte x werte löschen

                                if (Array.Exists(ecken_x, element => element == 0) && Array.Exists(ecken_y, element => element == 0))//wenn eine Koordinate "0" ist --> bricht das Kalibrieren ab
                                {
                                    //timer1.Start();
                                    //error.Visible = true;
                                    return;
                                }
                                kal.PerformClick();
                            }
                            kreise++;
                        }
                    }
                    pictureBox1.Image = bmp;
                }
                else
                {
                    warten.Visible = true;
                    kal.Enabled = false;
                }
            }
        }
        public double[] erg_x = new double[4];
        public double[] erg_y = new double[4];

        private void kal_Click_1(object sender, EventArgs e)
        {
            double[] vergleich_x = new double[4];
            double[] vergleich2_x = new double[4];
            double[] vergleich_y = new double[4];//y=0 == oben; y=max == unten
            double rechts_max = 0;
            double links_max = 0;

            vergleich_x[0] = Math.Round(ecken_x[0]);
            vergleich_x[1] = Math.Round(ecken_x[1]);
            vergleich_x[2] = Math.Round(ecken_x[2]);
            vergleich_x[3] = Math.Round(ecken_x[3]);

            vergleich_y[0] = ecken_y[0];
            vergleich_y[1] = ecken_y[1];
            vergleich_y[2] = ecken_y[2];
            vergleich_y[3] = ecken_y[3];

            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (vergleich_x[i] == vergleich_x[j])
                    {
                            return;
                    }
                }
            }//doppelte x werte löschen

            if (Array.Exists(vergleich_x, element => element == 0) && Array.Exists(vergleich_y, element => element == 0))//wenn eine Koordinate "0" ist --> bricht das Kalibrieren ab
            {
                return;
            }

            vergleich2_x[0] = vergleich_x[0];
            vergleich2_x[1] = vergleich_x[1];
            vergleich2_x[2] = vergleich_x[2];
            vergleich2_x[3] = vergleich_x[3];
            Array.Sort(vergleich2_x);

            int h1 = 5;
            int h2 = 5;
            #region rechts oben
            for (int i = 0; i < 4; i++)//die zwei punkte die am weitesten rechts sind
            {
                if (vergleich2_x[3] == vergleich_x[i])//überprüft auf welcher stelle die höchste Zahl im Original array ist.
                {
                    h1 = i;
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (vergleich2_x[2] == vergleich_x[i])
                {
                    h2 = i;
                    break;
                }
            }
            rechts_max = vergleich_x[h1];
            //MessageBox.Show(vergleich_x[h1] + "[" + h1 + "]" + "  " + vergleich_x[h2] + "[" + h2 + "]");
            if (vergleich_y[h1] > vergleich_y[h2])//rechts oben berechnen
            {
                erg_x[0] = vergleich_x[h2];
                erg_y[0] = vergleich_y[h2];
                //MessageBox.Show(vergleich_x[h2] + " " + vergleich_y[h2]);
            }
            if (vergleich_y[h1] < vergleich_y[h2])
            {
                erg_x[0] = vergleich_x[h1];
                erg_y[0] = vergleich_y[h1];
                //MessageBox.Show(vergleich_x[h1] + " " + vergleich_y[h1]);
            }
            #endregion

            #region rechts unten        
            h1 = 5;
            h2 = 5;

            for (int i = 0; i < 4; i++)//die zwei punkte die am weitesten rechts sind
            {
                if (vergleich2_x[3] == vergleich_x[i])//überprüft auf welcher stelle die höchste Zahl im Original array ist.
                {
                    h1 = i;
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (vergleich2_x[2] == vergleich_x[i])
                {
                    h2 = i;
                    break;
                }
            }
            //MessageBox.Show(vergleich_x[h1] + "[" + h1 + "]" + "  " + vergleich_x[h2] + "[" + h2 + "]");
            if (vergleich_y[h1] > vergleich_y[h2])//rechts unten berechnen
            {
                erg_x[1] = vergleich_x[h1];
                erg_y[1] = vergleich_y[h1];
                //MessageBox.Show(vergleich_x[h1] + " " + vergleich_y[h1]);
            }
            if (vergleich_y[h1] < vergleich_y[h2])
            {
                erg_x[1] = vergleich_x[h2];
                erg_y[1] = vergleich_y[h2];
                //MessageBox.Show(vergleich_x[h2] + " " + vergleich_y[h2]);
            }
            #endregion

            #region links unten        
            h1 = 5;
            h2 = 5;

            for (int i = 0; i < 4; i++)//die zwei punkte die am weitesten rechts sind
            {
                if (vergleich2_x[0] == vergleich_x[i])//überprüft auf welcher stelle die höchste Zahl im Original array ist.
                {
                    h1 = i;
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (vergleich2_x[1] == vergleich_x[i])
                {
                    h2 = i;
                    break;
                }
            }
            links_max = vergleich_x[h1];
            //MessageBox.Show(vergleich_x[h1] + "[" + h1 + "]" + "  " + vergleich_x[h2] + "[" + h2 + "]");
            if (vergleich_y[h1] > vergleich_y[h2])//links unten berechnen
            {
                erg_x[2] = vergleich_x[h1];
                erg_y[2] = vergleich_y[h1];
                //MessageBox.Show(vergleich_x[h1] + " " + vergleich_y[h1]);
            }
            if (vergleich_y[h1] < vergleich_y[h2])
            {
                erg_x[2] = vergleich_x[h2];
                erg_y[2] = vergleich_y[h2];
                //MessageBox.Show(vergleich_x[h2] + " " + vergleich_y[h2]);
            }
            #endregion

            #region links oben        
            h1 = 5;
            h2 = 5;

            for (int i = 0; i < 4; i++)//die zwei punkte die am weitesten rechts sind
            {
                if (vergleich2_x[0] == vergleich_x[i])//überprüft auf welcher stelle die höchste Zahl im Original array ist.
                {
                    h1 = i;
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (vergleich2_x[1] == vergleich_x[i])
                {
                    h2 = i;
                    break;
                }
            }
            //MessageBox.Show(vergleich_x[h1] + "[" + h1 + "]" + "  " + vergleich_x[h2] + "[" + h2 + "]");
            if (vergleich_y[h1] > vergleich_y[h2])//links unten berechnen
            {
                erg_x[3] = vergleich_x[h2];
                erg_y[3] = vergleich_y[h2];
                //MessageBox.Show(vergleich_x[h2] + " " + vergleich_y[h2]);
            }
            if (vergleich_y[h1] < vergleich_y[h2])
            {
                erg_x[3] = vergleich_x[h1];
                erg_y[3] = vergleich_y[h1];
                //MessageBox.Show(vergleich_x[h1] + " " + vergleich_y[h1]);
            }
            #endregion

            if (Math.Abs(erg_y[0] - erg_y[3]) > 20 || Math.Abs(erg_y[1] - erg_y[2]) > 20)
            {
                return;
            }

            k1.Left = (int)Math.Round(erg_x[0]) + pictureBox1.Location.X;
            k1.Top = (int)(erg_y[0]) + pictureBox1.Location.Y;
            k1.Text = "rechts oben";

            k2.Left = (int)Math.Round(erg_x[1]) + pictureBox1.Location.X;
            k2.Top = (int)(erg_y[1]) + pictureBox1.Location.Y;
            k2.Text = "rechts unten";

            k3.Left = (int)Math.Round(erg_x[2]) + pictureBox1.Location.X;
            k3.Top = (int)(erg_y[2]) + pictureBox1.Location.Y;
            k3.Text = "links unten";

            k4.Left = (int)Math.Round(erg_x[3]) + pictureBox1.Location.X;
            k4.Top = (int)(erg_y[3]) + pictureBox1.Location.Y;
            k4.Text = "links oben";

            try
            {
                mittelpunkt_links = erg_x[2] + ((erg_x[3] - erg_x[2]) / 2); //"linkster" punkt plus hälfte der beiden
                mittelpunkt_rechts = erg_x[1] + ((erg_x[0] - erg_x[1]) / 2); //"rechtster" punkt plus hälfte der beiden
                mittelpunkt_links_y = erg_y[2] + ((erg_y[3] - erg_y[2]) / 2); //"linkster" punkt plus hälfte der beiden
                mittelpunkt_rechts_y = erg_y[1] + ((erg_y[0] - erg_y[1]) / 2); //"rechtster" punkt plus hälfte der beiden
                pictureBox1.Paint += DrawEllipseFloat;

                multiplikator = Math.Round(_form1_2.screen.Auflösung_Projektor_x / (mittelpunkt_rechts - mittelpunkt_links));

                Properties.Settings.Default.mittelpunkt_links = mittelpunkt_links;
                Properties.Settings.Default.mittelpunkt_rechts = mittelpunkt_rechts;
                Properties.Settings.Default.mittelpunkt_linksy = mittelpunkt_links_y;
                Properties.Settings.Default.mittelpunkt_rechtsy = mittelpunkt_rechts_y;
                Properties.Settings.Default.weg_oben = erg_y[0];
                Properties.Settings.Default.weg_unten = erg_y[1];
                Properties.Settings.Default.multiplikator = multiplikator;
                Properties.Settings.Default.Save();
                timer1.Start();
                error.Visible = true;
            }
            catch
            {
                MessageBox.Show("Es wurden nicht 4 Punkte gefunden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void IR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
            }

            if (sensor != null)
            {
                sensor.Close();
            }
        }
        bool drawn = true;
        private void DrawEllipseFloat(object sender, PaintEventArgs g)
        {
                Pen blackPen = new Pen(Color.Red, 1);

                g.Graphics.DrawLine(blackPen, (int)(Math.Round(Convert.ToDouble(k1.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k1.Top) - pictureBox1.Location.Y), (int)(Math.Round(Convert.ToDouble(k2.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k2.Top) - pictureBox1.Location.Y));// ro ru
                g.Graphics.DrawLine(blackPen, (int)(Math.Round(Convert.ToDouble(k1.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k1.Top) - pictureBox1.Location.Y), (int)(Math.Round(Convert.ToDouble(k4.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k4.Top) - pictureBox1.Location.Y));// ro lo
                g.Graphics.DrawLine(blackPen, (int)(Math.Round(Convert.ToDouble(k3.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k3.Top) - pictureBox1.Location.Y), (int)(Math.Round(Convert.ToDouble(k4.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k4.Top) - pictureBox1.Location.Y));// lu lo
                g.Graphics.DrawLine(blackPen, (int)(Math.Round(Convert.ToDouble(k3.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k3.Top) - pictureBox1.Location.Y), (int)(Math.Round(Convert.ToDouble(k2.Left) - pictureBox1.Location.X)), (int)(Convert.ToDouble(k2.Top) - pictureBox1.Location.Y));// lu ru

                g.Graphics.DrawLine(blackPen, (int)Math.Round(mittelpunkt_links), (int)mittelpunkt_links_y, (int)Math.Round(mittelpunkt_rechts), (int)mittelpunkt_rechts_y);

        }

        private void IR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kal.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            error.Visible = false;
            timer1.Stop();
        }
    }
}