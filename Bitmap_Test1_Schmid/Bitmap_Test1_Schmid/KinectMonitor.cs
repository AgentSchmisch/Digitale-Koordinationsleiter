using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class KinectMonitor : Form
    {
        public KinectMonitor()
        {
            InitializeComponent();
            fillKinect();
        }
        void fillKinect()
        {
            retrieve_Kinect kinect = new retrieve_Kinect();

            label1.Text = kinect.LeftFoot;
            label2.Text = kinect.RightFoot;
        }

    }
}
