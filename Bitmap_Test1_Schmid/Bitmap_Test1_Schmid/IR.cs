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
        int ecken1_x;
        int ecken1_y;
        int ecken2_x;
        int ecken2_y;
        int ecken3_x;
        int ecken3_y;
        int ecken4_x;
        int ecken4_y;

        int mode = 0;
        int mode2 = 0;
        public double multiplikator;

        public double mittelpunkt_links = 0;
        public double mittelpunkt_rechts = 0;

        public double mittelpunkt_links_y = 0;
        public double mittelpunkt_rechts_y = 0;//unwichtig: das wurde geändert

        int kreise = 1;

        private void IR_Load_1(object sender, EventArgs e)
        {
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
                    //ResizeNearestNeighbor filter2 = new ResizeNearestNeighbor(1920, 1080);
                    filter.CenterColor = new RGB(Color.White); //Pure White
                    filter.Radius = (short)trackBar1.Value; //Increase this to allow off-whites
                    filter.FillOutside = false;
                    filter.FillColor = new RGB(Color.White); //Replacement Color

                    Bitmap bmp = filter.Apply(bitmap);

                    //filter2.Apply(bmp);
                    //filter3.Apply(bmp);

                    //filter.CenterColor = new RGB(0, 0, 0);
                    //filter.Radius = 100;
                    //filter.ApplyInPlace(bmp);
                    counter.MinWidth = 100;
                    counter.MinHeight = 100;
                    //counter.FilterBlobs = true;
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
                            if (kreise == 1)
                            {
                                ecken1_x = (int)center.X;
                                ecken1_y = (int)center.Y;
                            }
                            if (kreise == 2)
                            {
                                ecken2_x = (int)center.X;
                                ecken2_y = (int)center.Y;
                            }
                            if (kreise == 3)
                            {
                                ecken3_x = (int)center.X;
                                ecken3_y = (int)center.Y;
                            }
                            if (kreise == 4)
                            {
                                ecken4_x = (int)center.X;
                                ecken4_y = (int)center.Y;
                                kreise = 0;
                            }
                            kreise++;
                        }

                        //anzeige.Text = center.X.ToString() + " " + center.Y.ToString();
                        //anzeige.Text = ecken_x[z].ToString() + " " + ecken_x[z].ToString();
                        anzeige.Text = "Punkt 1: " + ecken1_x + " " + ecken1_y + "\n" + "Punkt 2: " + ecken2_x + " " + ecken2_y + "\n" + "Punkt 3: " + ecken3_x + " " + ecken3_y + "\n" + "Punkt 4: " + ecken4_x + " " + ecken4_y;

                    }
                    pictureBox1.Image = bmp;
                }
                else
                {
                    warten.Visible = true;
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

            if (checkBox1.Checked)
            {
                ecken1_x = 50;//testzwecke
                ecken2_x = 440;
                ecken3_x = 470;
                ecken4_x = 30;

                ecken1_y = 100;
                ecken2_y = 100;
                ecken3_y = 310;
                ecken4_y = 310;
            }

            double _512_auf_360 = 0.703;
            double _360_auf_512 = 1.422;

            vergleich_x[0] = Math.Round(ecken1_x * _512_auf_360);//scaling auf 360
            vergleich_x[1] = Math.Round(ecken2_x * _512_auf_360);
            vergleich_x[2] = Math.Round(ecken3_x * _512_auf_360);
            vergleich_x[3] = Math.Round(ecken4_x * _512_auf_360);

            vergleich_y[0] = ecken1_y;// * 2.54;
            vergleich_y[1] = ecken2_y;// * 2.54;
            vergleich_y[2] = ecken3_y;// * 2.54;
            vergleich_y[3] = ecken4_y;// * 2.54;

            if (Array.Exists(vergleich_x, element => element == 0) && Array.Exists(vergleich_y, element => element == 0))//wenn eine Koordinate "0" ist --> bricht das Kalibrieren ab
            {
                MessageBox.Show("Es wurden nicht 4 Punkte gefunden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label2.Text = "Punkt 1: " + vergleich_x[0] + " " + ecken1_y + "\n" + "Punkt 2: " + vergleich_x[1] + " " + ecken2_y + "\n" + "Punkt 3: " + vergleich_x[2] + " " + vergleich_x[3] + "\n" + "Punkt 4: " + ecken4_x + " " + ecken4_y;

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

            //MessageBox.Show("rechts oben: " + erg_x[0] + " " + erg_y[0] + "\n" + 
            //                "rechts unten: " + erg_x[1] + " " + erg_y[1] + "\n" + 
            //                "links unten: " + erg_x[2] + " " + erg_y[2] + "\n" + 
            //                "links oben: " + erg_x[3] + " " + erg_y[3]);

            k1.Left = (int)Math.Round(erg_x[0] * _360_auf_512) + pictureBox1.Location.X;
            k1.Top = (int)(erg_y[0]) + pictureBox1.Location.Y;
            //k1.Text = "ro:" + erg_x[0] + " " + erg_y[0];//nur für debugging mit Koordinaten
            k1.Text = "rechts oben";

            k2.Left = (int)Math.Round(erg_x[1] * _360_auf_512) + pictureBox1.Location.X;
            k2.Top = (int)(erg_y[1]) + pictureBox1.Location.Y;
            //k2.Text = "ru:" + erg_x[1] + " " + erg_y[1];//nur für debugging mit Koordinaten
            k2.Text = "rechts unten";

            k3.Left = (int)Math.Round(erg_x[2] * _360_auf_512) + pictureBox1.Location.X;
            k3.Top = (int)(erg_y[2]) + pictureBox1.Location.Y;
            //k3.Text = "lu:" + erg_x[2] + " " + erg_y[2];//nur für debugging mit Koordinaten
            k3.Text = "links unten";

            k4.Left = (int)Math.Round(erg_x[3] * _360_auf_512) + pictureBox1.Location.X;
            k4.Top = (int)(erg_y[3]) + pictureBox1.Location.Y;
            //k4.Text = "lo:" + erg_x[3] + " " + erg_y[3];//nur für debugging mit Koordinaten
            k4.Text = "links oben";

            mittelpunkt_links = erg_x[2] + ((erg_x[3] - erg_x[2]) / 2); //"linkster" punkt plus hälfte der beiden
            mittelpunkt_rechts = erg_x[1] + ((erg_x[0] - erg_x[1]) / 2); //"rechtster" punkt plus hälfte der beiden
            mittelpunkt_links_y = erg_y[2] + ((erg_y[3] - erg_y[2]) / 2); //"linkster" punkt plus hälfte der beiden
            mittelpunkt_rechts_y = erg_y[1] + ((erg_y[0] - erg_y[1]) / 2); //"rechtster" punkt plus hälfte der beiden

            multiplikator = Math.Round(_form1_2.screen.Auflösung_Projektor_x / (mittelpunkt_rechts - mittelpunkt_links)); 

            Properties.Settings.Default.mittelpunkt_links = mittelpunkt_links;
            Properties.Settings.Default.mittelpunkt_rechts = mittelpunkt_rechts;
            Properties.Settings.Default.mittelpunkt_linksy = mittelpunkt_links_y;
            Properties.Settings.Default.mittelpunkt_rechtsy = mittelpunkt_rechts_y;
            Properties.Settings.Default.multiplikator = multiplikator;
            Properties.Settings.Default.Save();

        }
        private void button1_Click(object sender, EventArgs e)
        {
  
        }
        private void pictureBox1_Mouseclick(object sender, MouseEventArgs e)
        {
            //klickanzahl++;
            //if (klickanzahl == 1)
            //{
            //    ecken1_x = e.X;
            //    ecken1_y = e.Y;
            //    r1.Location = new System.Drawing.Point(e.X-4, e.Y-4);
            //}
            //if (klickanzahl == 2)
            //{
            //    ecken2_x = e.X;
            //    ecken2_y = e.Y;
            //    r2.Location = new System.Drawing.Point(e.X - 4, e.Y - 4);
            //}
            //if (klickanzahl == 3)
            //{
            //    ecken3_x = e.X;
            //    ecken3_y = e.Y;
            //    r3.Location = new System.Drawing.Point(e.X - 4, e.Y - 4);
            //}
            //if (klickanzahl == 4)
            //{
            //    ecken4_x = e.X;
            //    ecken4_y = e.Y;
            //    r4.Location = new System.Drawing.Point(e.X - 4, e.Y - 4);
            //    kal.PerformClick();
            //    klickanzahl = 0;
            //}
        }
        private void reset_Click(object sender, EventArgs e)
        {
            ecken1_x = 0;
            ecken2_x = 0;
            ecken3_x = 0;
            ecken4_x = 0;

            ecken1_y = 0;
            ecken2_y = 0;
            ecken3_y = 0;
            ecken4_y = 0;
        }

        private void IR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader != null)//unwichtig: kürzlich geändert
            {
                reader.Dispose();
            }

            if (sensor != null)
            {
                sensor.Close();
            }
        }

        private void IR_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        //private void DrawEllipseFloat(object sender, PaintEventArgs g)
        //{
        //    //Graphics g = CreateGraphics();

        //    Pen blackPen = new Pen(Color.Red, 1);

        //    g.Graphics.DrawLine(blackPen, (int)(Math.Round(erg_x[0] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[0]) + pictureBox1.Location.Y, (int)(Math.Round(erg_x[1] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[1]) + pictureBox1.Location.Y);// ro ru
        //    g.Graphics.DrawLine(blackPen, (int)(Math.Round(erg_x[0] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[0]) + pictureBox1.Location.Y, (int)(Math.Round(erg_x[3] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[3]) + pictureBox1.Location.Y);// ro lo
        //    g.Graphics.DrawLine(blackPen, (int)(Math.Round(erg_x[2] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[2]) + pictureBox1.Location.Y, (int)(Math.Round(erg_x[3] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[3]) + pictureBox1.Location.Y);// lu lo
        //    g.Graphics.DrawLine(blackPen, (int)(Math.Round(erg_x[2] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[2]) + pictureBox1.Location.Y, (int)(Math.Round(erg_x[1] * 1.706)) + pictureBox1.Location.X, (int)(erg_y[1]) + pictureBox1.Location.Y);// lu ru

        //    g.Graphics.DrawLine(blackPen, (int)Math.Round(mittelpunkt_links * 1.706) + pictureBox1.Location.X, (int)mittelpunkt_links_y + pictureBox1.Location.Y, (int)Math.Round(mittelpunkt_rechts * 1.706) + pictureBox1.Location.X, (int)mittelpunkt_rechts_y + pictureBox1.Location.Y);
        //    g.Graphics.DrawLine(blackPen, 1, 1, 500, 500);
        //}
    }
}