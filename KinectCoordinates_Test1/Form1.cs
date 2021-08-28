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
using System.Windows.Forms;

namespace KinectCoordinates_Test1
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
                label2.Text = "Kinect gefunden";
            }
            else
                label2.Text = "Kinect nicht gefunden";
            {
                bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
                if (bodyFrameReader!=null)

                {
                    bodyFrameReader.FrameArrived += reader_FrameArrived;
                }
            }
        }

        private void reader_FrameArrived(object sender,BodyFrameArrivedEventArgs e)
        {
            bool dataRecieved = false;
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame!=null)
                {
                    if (bodies == null)
                    {
                        bodies = new Body[bodyFrame.BodyCount];
                    }
                    bodyFrame.GetAndRefreshBodyData(bodies);


                }
                
                dataRecieved = true;
            }
            if (dataRecieved)
            {
                foreach (Body body in bodies)
                {
                    if (body.IsTracked)
                    {
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                        Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();

                        Joint HandRight = joints[JointType.HandRight];
                        
                        float rh_distance_x = HandRight.Position.X;
                        float rh_distance_y = HandRight.Position.Y;
                        float rh_distance_z = HandRight.Position.Z;

                        lblX.Text = rh_distance_x.ToString("#.##");
                        lblY.Text = rh_distance_y.ToString("#.##");
                        lblZ.Text = rh_distance_z.ToString("#.##");
                        //valuechanged(rh_distance_x, rh_distance_y, rh_distance_z);
                        label1.Text = body.HandRightState.ToString();

                    }

                }
            }
        }

        //test der wertermittlung und durchschnittsberechnung
        public double[,] valuechanged(double x,double y,double z)
        {
            double[,] values = new double[30, 3]; //array mit 
            for (int i = 0; i < 31; i++)
            {
                for (int j= 0; j < 3; j++)
                {
                    if (j==1)
                    {
                        values[i, j] += x;
                    }
                    if (j == 2)
                    {
                        values[i, j] += y;
                    }
                    if (j == 3)
                    {
                        values[i, j] += z;
                    }
                    double val_x = values[0, 0] / 30 ;
                    lblX.Text = val_x.ToString();
                    double val_y = values[0, 0] / 30;
                    lblX.Text = val_y.ToString();
                    double val_z = values[0, 0] / 30;
                    lblX.Text = val_z.ToString();
                }
                
            }
            return values;
        }


    }
}
