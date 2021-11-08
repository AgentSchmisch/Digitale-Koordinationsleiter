using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Drawing.Imaging;
using Microsoft.Kinect;
using AForge;
using AForge.Math.Geometry;

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


                    counter = new BlobCounter();
                    EuclideanColorFiltering filter = new EuclideanColorFiltering();
                    ResizeNearestNeighbor filter2 = new ResizeNearestNeighbor(1920, 1080);
                    filter.CenterColor = new RGB(Color.White); //Pure White
                    filter.Radius = (short)trackBar1.Value; //Increase this to allow off-whites
                    filter.FillOutside = false;
                    filter.FillColor = new RGB(Color.White); //Replacement Color

                    Bitmap bmp = filter.Apply(bitmap);
                    filter2.Apply(bmp);
                    //filter.CenterColor = new RGB(0, 0, 0);
                    //filter.Radius = 100;
                    //filter.ApplyInPlace(bmp);
                    //counter.MinWidth = 100;
                    //counter.MinHeight = 100;
                    //counter.FilterBlobs = true;
                    counter.BackgroundThreshold = Color.Gray;
                    counter.ProcessImage(bmp);
                    Blob[] blobs = counter.GetObjectsInformation();
                    Pen redPen = new Pen(Color.Red, 10);//Kreisradius
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

                            label1.Left = (int)center.X;
                            label1.Top = (int)center.Y;

                            label1.Text = center.ToString();

                            if (i == 0)
                            {
                                ecken1_x = (int)center.X;
                                ecken1_y = (int)center.Y;
                            }
                            if (i == 1)
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
                        anzeige.Text = center.ToString();

                    }
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void kal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Punkt 1: " + ecken1_x + " " + ecken1_y + "\n" + "Punkt 2: " + ecken2_x + " " + ecken2_y + "\n" + "Punkt 3: " + ecken3_x + " " + ecken3_y + "\n" + "Punkt 4: " + ecken4_x + " " + ecken4_y);
        }
    }
}
