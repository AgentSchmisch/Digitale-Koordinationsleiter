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
        string[] possibleTracker;
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
            { byte threshold=200;
                if (frame != null)
                {
                    int width = frame.FrameDescription.Width;
                    int height = frame.FrameDescription.Height;
                    ushort[] data = new ushort[width * height];
                    byte[] pixelData = new byte[width * height*4];
                    possibleTracker = new string[width * height * 4];
                    int xcoord=0;

                    frame.CopyFrameDataToArray(data);
                    int schleife = 0;
                    Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                    for (int infraredIndex = 0; infraredIndex < data.Length; infraredIndex++)
                    {
                        ushort ir = data[infraredIndex];
                        byte intensity = (byte)(ir >> 8);

                        pixelData[infraredIndex * 4] = intensity; // Blue
                        pixelData[infraredIndex * 4 + 1] = intensity; // Green   
                        pixelData[infraredIndex * 4 + 2] = intensity; // Red
                        pixelData[infraredIndex * 4 + 3] = 255;//Brightness

                        //während des einlesens alle pixel die einen RGB wert zwischen 200 und 255 in ein Array schreiben und 
                        if(pixelData[infraredIndex*4]>=threshold && pixelData[infraredIndex * 4] <= 255 && pixelData[infraredIndex * 4+1] >= threshold && pixelData[infraredIndex * 4+1] <= 255 && pixelData[infraredIndex * 4+2] >= threshold && pixelData[infraredIndex * 4+2] <= 255)
                        {

                            schleife++;
                            possibleTracker[schleife] = xcoord.ToString() + (infraredIndex / 4).ToString();
                        }
                        xcoord++;
                        if (xcoord == 512 * 4)
                        {
                            xcoord = 0;
                        }
                        bitmap.SetPixel(xcoord,infraredIndex / 4 , Color.Red);
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
