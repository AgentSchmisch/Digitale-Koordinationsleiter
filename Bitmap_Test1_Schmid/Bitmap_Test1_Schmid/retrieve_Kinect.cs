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

namespace Bitmap_Test1_Schmid
{
    class retrieve_Kinect
    {
        #region variables for the positions of the Tracking markers
        int ecken1_x;
        int ecken1_y;
        int ecken2_x;
        int ecken2_y;
        int ecken3_x;
        int ecken3_y;
        int ecken4_x;
        int ecken4_y;
        #endregion

        KinectSensor kinectSensor = null;
        BodyFrameReader bodyFrameReader = null;
        MultiSourceFrameReader reader = null;
        Body[] bodies = null;
        BlobCounter counter = null;

        public Bitmap bitmap;
        public Bitmap bmp;

        private string footright;
        private string footleft;
        public retrieve_Kinect()
        {

        }
        public void InitializeKinect()
        {
            kinectSensor = KinectSensor.GetDefault();
            //check whether a kinect Sensor is connected to the PC
            if (kinectSensor != null)
            {
                kinectSensor.Open();  //establish a connection to the sensor
            }
        }


        public void BodyFrameReader()
        {

            bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
            if (reader != null)
            {
                bodyFrameReader.FrameArrived += reader_BodyFrameArrived;
            }
        }

        public void RGBFrameReader()
        {
            reader = kinectSensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color);
            reader.MultiSourceFrameArrived += reader_RGBFrameArrived;
        }

        public void IRFrameReader()
        {
            reader = kinectSensor.OpenMultiSourceFrameReader(FrameSourceTypes.Infrared);
            reader.MultiSourceFrameArrived += reader_IRFrameArrived;
        }

        private void reader_BodyFrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataRecieved = false;
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
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
                        Dictionary<JointType, AForge.Point> jointPoints = new Dictionary<JointType, AForge.Point>();

                        Joint FootRight = joints[JointType.FootRight];
                        Joint FootLeft = joints[JointType.FootLeft];

                        #region Variables for Tracking the feet
                        float rf_distance_x = ((FootRight.Position.X * 100) + 256) * (375 / 100);
                        float rf_distance_y = FootRight.Position.Y * 1000;
                        float rf_distance_z = FootRight.Position.Z;

                        float lf_distance_x = ((FootLeft.Position.X * 100) + 256) * (375 / 100);
                        float lf_distance_y = FootLeft.Position.Y * 1000;
                        float lf_distance_z = FootLeft.Position.Z;
                        #endregion
                    }
                }
            }
        }

        private void reader_RGBFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
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

                    bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);


                    Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
                    bitmap.UnlockBits(bitmapData);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                    //access the Data here via retrieve_Kinect kinect=new retrieve_Kinect();
                    //                          pictureBox.Image=kinect.bitmap;
                }
            }
        }

        private void reader_IRFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
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


                    frame.CopyFrameDataToArray(data);
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
                    filter.FillOutside = false;
                    filter.FillColor = new RGB(Color.White); //Replacement Color

                    bmp = filter.Apply(bitmap);

                    filter2.Apply(bmp);

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
                    }
                }
            }
        }


        public int TrackerRechtsOben
        {
            get
            {
                int x = 0;
                return x;
            }
            set
            {

            }
        }

        //Properties zur berechnung der Koordinaten des Rechten und linken Fußes
        public string RightFoot
        {
            //Hier verarbeitung der Daten zur übergabe an den zweiten Thread im Hauptprogramm
            get
            {

                return footright;
            }
            set
            {
                footright = value;
            }
        }
        public string LeftFoot
        {
            get
            {
                return footleft;
            }
            set
            {
                footleft = value;
            }
        }
    }


}
