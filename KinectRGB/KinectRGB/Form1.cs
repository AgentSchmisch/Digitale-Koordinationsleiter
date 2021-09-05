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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace KinectRGB
{
    public partial class Form1 : Form
    {
        KinectSensor mySensor = null;
        MultiSourceFrameReader myReader = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mySensor = KinectSensor.GetDefault();

            if (mySensor!=null)
            {
                mySensor.Open();

            }
            myReader = mySensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color);
            myReader.MultiSourceFrameArrived += myReader_MultiSourceFrameArrived;
        }

        void myReader_MultiSourceFrameArrived(object sender,MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();
            using (var frame = reference.ColorFrameReference.AcquireFrame())
            {
                if(frame != null)
                {
                    var width = frame.FrameDescription.Width;
                    var height = frame.FrameDescription.Height;
                    var data = new byte[width * height * 32 / 8];
                    frame.CopyConvertedFrameDataToArray(data, ColorImageFormat.Bgra);

                    var bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),ImageLockMode.WriteOnly,bitmap.PixelFormat);


                    Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
                    bitmap.UnlockBits(bitmapData);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                    pictureBox1.Image = bitmap;
                }
            }
        }
    }
}
