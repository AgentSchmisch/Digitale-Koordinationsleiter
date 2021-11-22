using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        public int steps_kinect = 0; // schritte von form1
        int count = 0;
        int i = 0;
        double[] durchschnitt=new double[99];

        retrieve_Kinect kinect = new retrieve_Kinect();

        private Form2 _form2;
        public Form2 form2
        {
            set { this._form2 = value; }
        }
        private Form1 _form1;
        public Form1 form1
        {
            set { this._form1 = value; }
        }
        public KinectMonitor()
        {
            InitializeComponent();

        }
        public void DrawLineFloat(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Red, 3);

            e.Graphics.DrawLine(blackPen, (int)(_form1.ir.erg_x[0] / 2), (int)(_form1.ir.erg_y[0] / 2), (int)(_form1.ir.erg_x[1] / 2), (int)(_form1.ir.erg_y[1] / 2));// ro ru
            e.Graphics.DrawLine(blackPen, (int)(_form1.ir.erg_x[0] / 2), (int)(_form1.ir.erg_y[0] / 2), (int)(_form1.ir.erg_x[3] / 2), (int)(_form1.ir.erg_y[3] / 2));// ro lo
            e.Graphics.DrawLine(blackPen, (int)(_form1.ir.erg_x[2] / 2), (int)(_form1.ir.erg_y[2] / 2), (int)(_form1.ir.erg_x[3] / 2), (int)(_form1.ir.erg_y[3] / 2));// lu lo
            e.Graphics.DrawLine(blackPen, (int)(_form1.ir.erg_x[2] / 2), (int)(_form1.ir.erg_y[2] / 2), (int)(_form1.ir.erg_x[1] / 2), (int)(_form1.ir.erg_y[1] / 2));// lu ru
        }
        private void KinectMonitor_Load(object sender, EventArgs e)
        {

            #region kalibrierungspunkte einzeichnen
            //k1.Left = (int)_form1.ir.erg_x[0] / 2;
            //k1.Top = (int)_form1.ir.erg_y[0] / 2;
            //k1.Text = "ro:" + _form1.ir.erg_x[0] + " " + _form1.ir.erg_y[0];

            //k2.Left = (int)_form1.ir.erg_x[1] / 2;
            //k2.Top = (int)_form1.ir.erg_y[1] / 2;
            //k2.Text = "ru:" + _form1.ir.erg_x[1] + " " + _form1.ir.erg_y[1];

            //k3.Left = (int)_form1.ir.erg_x[2] / 2;
            //k3.Top = (int)_form1.ir.erg_y[2] / 2;
            //k3.Text = "lu:" + _form1.ir.erg_x[2] + " " + _form1.ir.erg_y[2];

            //k4.Left = (int)_form1.ir.erg_x[3] / 2;
            //k4.Top = (int)_form1.ir.erg_y[3] / 2;
            //k4.Text = "lo:" + _form1.ir.erg_x[3] + " " + _form1.ir.erg_y[3];

            pictureBox1.Paint += DrawLineFloat;
            #endregion
            //Task thread = Task.Run(() =>
            //{  
            // mySensor = KinectSensor.GetDefault();

            //if (mySensor != null)
            //{
            //    mySensor.Open();
            //}
            //    myReader = mySensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color);
            //    myReader.MultiSourceFrameArrived += myReader_MultiSourceFrameArrived;
            //    bodyFrameReader = mySensor.BodyFrameSource.OpenReader();
            //    if (bodyFrameReader != null)
            //    {
            //        bodyFrameReader.FrameArrived += reader_FrameArrived;
            //    }

            //});
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

                    filter.Red = new AForge.IntRange(0, 255);
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

                        float rf_distance_x = ((FootRight.Position.X * 100) +256) * (375 / 100);
                        float rf_distance_y = FootRight.Position.Y * 1000;
                        float rf_distance_z = FootRight.Position.Z;

                        float lf_distance_x = ((FootLeft.Position.X * 100) + 256) * (375 / 100);
                        float lf_distance_y = FootLeft.Position.Y * 1000;
                        float lf_distance_z = FootLeft.Position.Z;

                        Xlinks.Text = lf_distance_x.ToString("###");
                        Ylinks.Text = lf_distance_y.ToString("###");
                        Zlinks.Text = lf_distance_z.ToString("#.##");

                        Xrechts.Text = rf_distance_x.ToString("###");
                        Yrechts.Text = rf_distance_y.ToString("###");
                        Zrechts.Text = rf_distance_z.ToString("#.##");
                        //if (Convert.ToInt32(Xlinks.Text) >= _form1.ir.erg_x[0] && Convert.ToInt32(Xlinks.Text) <= _form1.ir.erg_x[3])
                        //{// erst wenns innerhalb vom anzeigefeld ist soll er tracken
                            #region tracking
                            tracker_xrechts[0] = Convert.ToDouble(Xrechts.Text);
                            tracker_xlinks[0] = Convert.ToDouble(Xlinks.Text);

                            for (int i = 0; i < 9; i++)
                            {
                                tracker_xrechts[i + 1] = zw_tracker_xrechts[i];         //zwischenvariable für Werte -- beginnt array bei 0
                                tracker_xlinks[i + 1] = zw_tracker_xlinks[i];
                            }
                                schritt_rechts[0] = Math.Round((tracker_xrechts[0] + tracker_xrechts[1] + tracker_xrechts[2]) / 3);
                                schritt_links[0] = Math.Round((tracker_xlinks[0] + tracker_xlinks[1] + tracker_xlinks[2]) / 3);

                                //text.Text = (tracker_xrechts[0] + " " + tracker_xrechts[1] +" "+ tracker_xrechts[2] +" ="+schritt_rechts[0]);

                                for (int i = 0; i < 9; i++)
                                {
                                    schritt_rechts[i + 1] = zw_schritt_rechts[i];
                                    schritt_links[i + 1] = zw_schritt_links[i];
                                }
                                if (schritt_rechts[2] != 0)//wartet bis 3 werte vorhanden sind
                                {
                                    if (count == 1 && Math.Abs(schritt_rechts[0] - schritt_rechts[1]) >= 50 && Math.Abs(schritt_rechts[1] - schritt_rechts[2]) >= 50 && Math.Abs(schritt_rechts[0] - schritt_rechts[2]) >= 50)
                                    {
                                        text.Text = "bewegt";
                                        // MessageBox.Show(schritt_rechts[0] + " + " + schritt_rechts[1] + " + " + schritt_rechts[2]);
                                        count = 0;
                                    }

                                    if (count == 0 && Math.Abs(schritt_rechts[0] - schritt_rechts[1]) <= 50 && Math.Abs(schritt_rechts[1] - schritt_rechts[2]) <= 50 && Math.Abs(schritt_rechts[0] - schritt_rechts[2]) <= 5)
                                    {
                                        durchschnitt[i] = (Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - _form1.ir.erg_x[0]);// * _form1.ir.multiplikator;
                                        //text.Text = schritt_rechts[0] + " + " + schritt_rechts[1] + " + " + schritt_rechts[2] + " = " + durchschnitt.ToString();
                                        text.Text = "Position: " + durchschnitt[i] + "   Schrittnummer: " + i.ToString();
                                        //für Fußabdruck: Schritt 1 bei Koordinate 0; letzter schritt bei 1920
                                        #region Fußabdruck zeichnen
                                        if (durchschnitt[0] != 0 && steps_kinect >= 1)
                                        {
                                            _form1.screen.right_one.Left = Convert.ToInt32(durchschnitt[0]) - (_form1.screen.right_one.Size.Width / 2); _form1.screen.right_one.Show();
                                        }
                                        if (durchschnitt[1] != 0 && steps_kinect >= 2)
                                        {
                                            _form1.screen.left_one.Left = Convert.ToInt32(durchschnitt[1]) - (_form1.screen.left_one.Size.Width / 2); _form1.screen.left_one.Show();
                                        }
                                        if (durchschnitt[2] != 0 && steps_kinect >= 3)
                                        {
                                            _form1.screen.right_two.Left = Convert.ToInt32(durchschnitt[2]) - (_form1.screen.right_one.Size.Width / 2); _form1.screen.right_two.Show();
                                        }
                                        if (durchschnitt[3] != 0 && steps_kinect >= 4)
                                        {
                                            _form1.screen.left_two.Left = Convert.ToInt32(durchschnitt[3]) - (_form1.screen.left_one.Size.Width / 2); _form1.screen.left_two.Show();
                                        }
                                        if (durchschnitt[4] != 0 && steps_kinect >= 5)
                                        {
                                            _form1.screen.right_three.Left = Convert.ToInt32(durchschnitt[4]) - (_form1.screen.right_one.Size.Width / 2); _form1.screen.right_three.Show();
                                        }
                                        if (durchschnitt[5] != 0 && steps_kinect >= 6)
                                        {
                                            _form1.screen.left_three.Left = Convert.ToInt32(durchschnitt[5]) - (_form1.screen.left_one.Size.Width / 2); _form1.screen.left_three.Show();
                                        }
                                        if (durchschnitt[6] != 0 && steps_kinect >= 7)
                                        {
                                            _form1.screen.right_four.Left = Convert.ToInt32(durchschnitt[6]) - (_form1.screen.right_one.Size.Width / 2); _form1.screen.right_four.Show();
                                        }
                                        if (durchschnitt[7] != 0 && steps_kinect >= 8)
                                        {
                                            _form1.screen.left_four.Left = Convert.ToInt32(durchschnitt[7]) - (_form1.screen.left_one.Size.Width / 2); _form1.screen.left_four.Show();
                                        }
                                        if (durchschnitt[8] != 0 && steps_kinect >= 9)
                                        {
                                            _form1.screen.right_five.Left = Convert.ToInt32(durchschnitt[8]) - (_form1.screen.right_one.Size.Width / 2); _form1.screen.right_five.Show();
                                        }
                                        if (durchschnitt[9] != 0 && steps_kinect >= 10)
                                        {
                                            _form1.screen.left_five.Left = Convert.ToInt32(durchschnitt[9]) - (_form1.screen.left_one.Size.Width / 2); _form1.screen.left_five.Show();
                                        }
                                        if (durchschnitt[10] != 0 && steps_kinect >= 11)
                                        {
                                            _form1.screen.right_six.Left = Convert.ToInt32(durchschnitt[10]) - (_form1.screen.right_one.Size.Width / 2); _form1.screen.right_six.Show();
                                        }
                                        if (durchschnitt[11] != 0 && steps_kinect >= 12)
                                        {
                                            _form1.screen.left_six.Left = Convert.ToInt32(durchschnitt[11]) - (_form1.screen.left_one.Size.Width / 2); _form1.screen.left_six.Show();
                                        }
                                        #endregion
                                        //_form2.übertragung();
                                        for (int i = 0; i < 10000; i++) { }
                                        count = 1;
                                        i++;
                                    }
                                    if (i >= 99)
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
                        #endregion
                        //}
                    }
                }
            }
        }
    }
}
