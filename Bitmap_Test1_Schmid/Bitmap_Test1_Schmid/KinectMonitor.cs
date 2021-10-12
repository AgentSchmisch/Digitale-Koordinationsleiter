using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class KinectMonitor : Form
    {
        KinectSensor mySensor = null;
        MultiSourceFrameReader myReader = null;
        BodyFrameReader bodyFrameReader = null;
        Body[] bodies = null;

        double[] tracker_xrechts = new double[10];
        double[] tracker_xlinks = new double[10];

        double[] zw_tracker_xrechts = new double[10];
        double[] zw_tracker_xlinks = new double[10];
        int count = 0;
        int ix = 0;
        public KinectMonitor()
        {
            InitializeComponent();
        }


        private void KinectMonitor_Load(object sender, EventArgs e)
        {
            mySensor = KinectSensor.GetDefault();

            if (mySensor != null)
            {
                mySensor.Open();
            }
            myReader = mySensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color);
            myReader.MultiSourceFrameArrived += myReader_MultiSourceFrameArrived;
            bodyFrameReader = mySensor.BodyFrameSource.OpenReader();
            if (bodyFrameReader != null)
            {
                bodyFrameReader.FrameArrived += reader_FrameArrived;
            }
        }
        void myReader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();
            using (var frame = reference.ColorFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    var width = frame.FrameDescription.Width;
                    var height = frame.FrameDescription.Height;
                    var data = new byte[width * height * 32 / 8];
                    frame.CopyConvertedFrameDataToArray(data, ColorImageFormat.Bgra);

                    var bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);


                    Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
                    bitmap.UnlockBits(bitmapData);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);

                    ColorFiltering filter = new ColorFiltering();
                    BrightnessCorrection filter2 = new BrightnessCorrection(+50);

                    filter.Red = new AForge.IntRange(trackBar1.Value, 255);
                    filter.Green = new AForge.IntRange(0, 75);
                    filter.Blue = new AForge.IntRange(0, 75);
                    //filter2.ApplyInPlace(bitmap);
                    //filter.ApplyInPlace(bitmap);
                    pictureBox1.Image = bitmap;
                }
            }
        }
        private void reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataRecieved = false;
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (bodies == null)
                        bodies = new Body[bodyFrame.BodyCount];

                    bodyFrame.GetAndRefreshBodyData(bodies);

                    dataRecieved = true;

                }
            }
            if (dataRecieved)
            {
                foreach (Body body in bodies)
                {
                    if (body.IsTracked)
                    {
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                        Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();

                        Joint FootRight = joints[JointType.FootRight];
                        Joint FootLeft = joints[JointType.FootLeft];

                        float rf_distance_x = FootRight.Position.X * 1000;
                        float rf_distance_y = FootRight.Position.Y * 1000;
                        float rf_distance_z = FootRight.Position.Z;

                        float lf_distance_x = FootLeft.Position.X * 1000;
                        float lf_distance_y = FootLeft.Position.Y * 1000;
                        float lf_distance_z = FootLeft.Position.Z;

                        Xlinks.Text = lf_distance_x.ToString("###");
                        Ylinks.Text = lf_distance_y.ToString("###");
                        Zlinks.Text = lf_distance_z.ToString("#.##");

                        Xrechts.Text = rf_distance_x.ToString("###");
                        Yrechts.Text = rf_distance_y.ToString("###");
                        Zrechts.Text = rf_distance_z.ToString("#.##");

                        tracker_xrechts[0] = Convert.ToDouble(Xrechts.Text);
                        tracker_xlinks[0] = Convert.ToDouble(Xlinks.Text);
                        //tracker_xrechts[0] = count;
                        //tracker_xlinks[0] = count;


                        for (int i = 0; i < 9; i++)
                        {
                            tracker_xrechts[i + 1] = zw_tracker_xrechts[i];         //zwischenvariable für Werte -- beginnt array bei 0
                            tracker_xlinks[i + 1] = zw_tracker_xlinks[i];
                        }
                        /*
                        text.Text = "";
                        for (int i = 0; i < 10; i++)
                        {
                            text.Text += zw_tracker_xrechts[i] + ",";
                        }
                        text.Text += "\n";
                        for (int i = 0; i < 10; i++)
                        {
                            text.Text += tracker_xrechts[i] + ",";
                        }

                        if (count<10&&ix==0)
                            count++;
                        if (count == 10)
                            ix = 1;
                        if (count > 0 && ix==1)
                            count--;
                        if (count == 0)
                            ix = 0;
                        *///Bsp Code

                        double durchschnitt=(tracker_xrechts[0] + tracker_xrechts[1] + tracker_xrechts[2])/3;
                        text.Text = (tracker_xrechts[0] + " " + tracker_xrechts[1] +" "+ tracker_xrechts[2] +" ="+durchschnitt).ToString();
                        //Hier Code schreiben. Mit tracker_xrechts[] Arbeiten

                        for (int i = 0; i < 10; i++)
                        {
                            zw_tracker_xrechts[i] = tracker_xrechts[i];
                            zw_tracker_xlinks[i] = tracker_xlinks[i];
                        }


                        //Schritterkennung Array mit druchschnittswerten


                    }

                }
            }
        }
    }
}
