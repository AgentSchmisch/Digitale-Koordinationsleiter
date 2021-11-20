using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace kinecttest
{
    public partial class Form1 : Form
    {
        KinectSensor kinectSensor = null;
        BodyFrameReader bodyFrameReader = null;
        Body[] bodies = null;
        public Form1()
        {
            InitializeComponent();
            InitializeKinect();

        }

        public void InitializeKinect()
        {
            kinectSensor = KinectSensor.GetDefault();
            if (kinectSensor != null) //turn on kinect
            {
                kinectSensor.Open();
            }
            {
                bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
                if (bodyFrameReader != null)
                {
                    bodyFrameReader.FrameArrived += reader_FrameArrived;
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

                        float rf_distance_x = FootRight.Position.X*1000;
                        float rf_distance_y = FootRight.Position.Y*1000;
                        float rf_distance_z = FootRight.Position.Z;

                        float lf_distance_x = FootLeft.Position.X*1000;
                        float lf_distance_y = FootLeft.Position.Y*1000;
                        float lf_distance_z = FootLeft.Position.Z;

                        Xlinks.Text = lf_distance_x.ToString("###.##");
                        Ylinks.Text = lf_distance_y.ToString("###.##");
                        Zlinks.Text = lf_distance_z.ToString("#.##");

                        Xrechts.Text = rf_distance_x.ToString("###.##");
                        Yrechts.Text = rf_distance_y.ToString("###.##");
                        Zrechts.Text = rf_distance_z.ToString("#.##");

                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}