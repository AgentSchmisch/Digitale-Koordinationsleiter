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
using System.Drawing.Imaging;
using Microsoft.Kinect;

namespace KinectIR
{
    public partial class Form1 : Form
    {
        KinectSensor sensor = null;
        MultiSourceFrameReader reader = null;

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
                    byte[] pixelData = new byte[width * height*4];

                    frame.CopyFrameDataToArray(data);

                    Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                    for (int infraredIndex = 0; infraredIndex < data.Length; infraredIndex++)
                    {
                        ushort ir = data[infraredIndex];
                        byte intensity = (byte)(ir >> 8);

                        pixelData[infraredIndex * 4] = intensity; // Blue
                        pixelData[infraredIndex * 4 + 1] = intensity; // Green   
                        pixelData[infraredIndex * 4 + 2] = intensity; // Red
                        pixelData[infraredIndex * 4 + 3] = 255;
                    }

                    var bitmapdata = bitmap.LockBits(
                        new Rectangle(0, 0, width, height),
                        ImageLockMode.WriteOnly,
                        bitmap.PixelFormat
                    );
                    IntPtr ptr = bitmapdata.Scan0;

                    Marshal.Copy(pixelData, 0, ptr, pixelData.Length);
                    bitmap.UnlockBits(bitmapdata);
                    pictureBox1.Image = bitmap;
                }
            }
        }
    }
}
