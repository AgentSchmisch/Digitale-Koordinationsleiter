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

namespace KinectIR
{
    public partial class Form1 : Form
    {

        KinectSensor sensor = null;
        MultiSourceFrameReader reader = null;
        BlobCounter counter = null;
        string[] possibleTracker;
        int ecken1_x;
        int ecken1_y;
        int ecken2_x;
        int ecken2_y;
        int ecken3_x;
        int ecken3_y;
        int ecken4_x;
        int ecken4_y;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sensor = KinectSensor.GetDefault();

            if (sensor != null)
            {
                sensor.Open();
            }
            reader = sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Infrared);
            reader.MultiSourceFrameArrived += reader_IRFrameArrived;

        }
        void reader_IRFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();
            using (InfraredFrame frame = reference.InfraredFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
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
                    ResizeNearestNeighbor filter2 = new ResizeNearestNeighbor(1920, 1080);
                    filter.CenterColor = new RGB(Color.White); //Pure White
                    filter.Radius = (short)trackBar1.Value; //Increase this to allow off-whites
                    filter.FillOutside = false;
                    filter.FillColor = new RGB(Color.White); //Replacement Color

                    Bitmap bmp = filter.Apply(bitmap);

                    filter2.Apply(bmp);
                    //filter3.Apply(bmp);

                    //filter.CenterColor = new RGB(0, 0, 0);
                    //filter.Radius = 100;
                    //filter.ApplyInPlace(bmp);
                    //counter.MinWidth = 100;
                    //counter.MinHeight = 100;
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
                            //TODO: überprüfen ob mehr als 4 punkte sichtbar sind
                                if (i == 1)
                                {
                                    ecken1_x = (int)center.X;
                                    ecken1_y = (int)center.Y;
                                }
                                if (i == 2)
                                {
                                    ecken2_x = (int)center.X;
                                    ecken2_y = (int)center.Y;
                                }
                                if (i == 3)
                                {
                                    ecken3_x = (int)center.X;
                                    ecken3_y = (int)center.Y;
                                }
                                if (i == 4)
                                {
                                    ecken4_x = (int)center.X;
                                    ecken4_y = (int)center.Y;
                                }
                            
                        }

                        //anzeige.Text = center.X.ToString() + " " + center.Y.ToString();
                        //anzeige.Text = ecken_x[z].ToString() + " " + ecken_x[z].ToString();
                        anzeige.Text = "Punkt 1: " + ecken1_x + " " + ecken1_y + "\n" + "Punkt 2: " + ecken2_x + " " + ecken2_y + "\n" + "Punkt 3: " + ecken3_x + " " + ecken3_y + "\n" + "Punkt 4: " + ecken4_x + " " + ecken4_y;

                    }
                    pictureBox1.Image = bmp;
                }
            }
        }
        public int[] erg_x = new int[4];
        public int[] erg_y = new int[4];
        private void kal_Click(object sender, EventArgs e)
        {
            int[] vergleich_x = new int[4];
            int[] vergleich2_x = new int[4];
            int[] vergleich_y = new int[4];//y=0 == oben; y=max == unten
            int rechts_max = 0;
            int links_max = 0;

            vergleich_x[0] = ecken1_x;
            vergleich_x[1] = ecken2_x;
            vergleich_x[2] = ecken3_x;
            vergleich_x[3] = ecken4_x;

            vergleich_y[0] = ecken1_y;
            vergleich_y[1] = ecken2_y;
            vergleich_y[2] = ecken3_y;
            vergleich_y[3] = ecken4_y;
            if (Array.Exists(vergleich_x, element => element == 0) && Array.Exists(vergleich_y, element => element == 0))//wenn eine Koordinate "0" ist --> bricht das Kalibrieren ab
            {
                MessageBox.Show("Es wurden nicht 4 Punkte gefunden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label2.Text = "Punkt 1: " + ecken1_x + " " + ecken1_y + "\n" + "Punkt 2: " + ecken2_x + " " + ecken2_y + "\n" + "Punkt 3: " + ecken3_x + " " + ecken3_y + "\n" + "Punkt 4: " + ecken4_x + " " + ecken4_y;

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
            
            k1.Left = erg_x[0];
            k1.Top = erg_y[0];
            k1.Text = "ro:" + erg_x[0] + " " + erg_y[0];

            k2.Left = erg_x[1];
            k2.Top = erg_y[1];
            k2.Text = "ru:" + erg_x[1] + " " + erg_y[1];

            k3.Left = erg_x[2];
            k3.Top = erg_y[2];
            k3.Text = "lu:" + erg_x[2] + " " + erg_y[2];

            k4.Left = erg_x[3];
            k4.Top = erg_y[3];
            k4.Text = "lo:" + erg_x[3] + " " + erg_y[3];

            //skalierung auf 1920; linker punkt=0; rechter punkt=1920
            int zw_var;
            int multiplikator;
            zw_var=rechts_max - links_max;
            multiplikator = 1920 / zw_var;
            // jetzt werden alle schritte die die Kamera vom benutzer erkennt -"links_max" gerechnet und dann mal "multipplikator"
            //bsp.: (schrittlänge[0]-links_max)*multiplikator

        }
    }
}
