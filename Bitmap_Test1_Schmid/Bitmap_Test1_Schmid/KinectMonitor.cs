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

        double[] schritt_rechts = new double[10];
        double[] schritt_links = new double[10];
        double[] zw_schritt_rechts = new double[10];
        double[] zw_schritt_links = new double[10];

        int count = 0;
        int i = 0;
        double[] durchschnitt=new double[99];

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

                            schritt_rechts[0] = Math.Round((tracker_xrechts[0] + tracker_xrechts[1] + tracker_xrechts[2]) / 3);
                            schritt_links[0] = Math.Round((tracker_xlinks[0] + tracker_xlinks[1] + tracker_xlinks[2]) / 3);

                            //text.Text = (tracker_xrechts[0] + " " + tracker_xrechts[1] +" "+ tracker_xrechts[2] +" ="+schritt_rechts[0]);

                            for (int i = 0; i < 9; i++)
                            {
                                schritt_rechts[i + 1] = zw_schritt_rechts[i];
                                schritt_links[i + 1] = zw_schritt_links[i];
                            }
                                if(schritt_rechts[2]!=0)
                                {
                                        if (count == 1 && Math.Abs(schritt_rechts[0] - schritt_rechts[1]) >= 50 && Math.Abs(schritt_rechts[1] - schritt_rechts[2]) >= 50 && Math.Abs(schritt_rechts[0] - schritt_rechts[2]) >= 50)
                                        {
                                            text.Text = "bewegt";
                                            // MessageBox.Show(schritt_rechts[0] + " + " + schritt_rechts[1] + " + " + schritt_rechts[2]);
                                            count = 0;
                                        }

                                        if (count == 0 && Math.Abs(schritt_rechts[0] - schritt_rechts[1]) <= 50 && Math.Abs(schritt_rechts[1] - schritt_rechts[2]) <= 50 && Math.Abs(schritt_rechts[0] - schritt_rechts[2]) <= 5)
                                        {
                                            durchschnitt[i] = Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3);
                                            for(int i = 0; i < 10000; i++) { } //delay
                                            //text.Text = schritt_rechts[0] + " + " + schritt_rechts[1] + " + " + schritt_rechts[2] + " = " + durchschnitt.ToString();
                                            text.Text= "Stehen: " + durchschnitt[i].ToString() + "   Schrittnummer: " + i.ToString();
                                                for (int i = 0; i < 1000; i++) { }
                                            count = 1;
                                            i++;
                                        }
                                        if (i == 99)
                                            text.Text = "Ende Gelände";
                                    /*
                                    else if (count == 1 && ((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) > (durchschnitt + 30) && ((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) < (durchschnitt - 30))
                                    {
                                        text.Text = "bewegt";
                                        count = 0;
                                    }*/
                                }


                        for (int i = 0; i < 10; i++)
                            {
                                zw_schritt_rechts[i] = schritt_rechts[i];
                                zw_schritt_links[i] = schritt_links[i];
                            }


                        for (int i = 0; i < 10; i++)
                        {
                            zw_tracker_xrechts[i] = tracker_xrechts[i];
                            zw_tracker_xlinks[i] = tracker_xlinks[i];
                        }
                    }
                }
            }
        }
    }
}
