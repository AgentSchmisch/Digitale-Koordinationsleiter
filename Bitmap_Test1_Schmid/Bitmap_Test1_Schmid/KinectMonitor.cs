using AForge.Imaging.Filters;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
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

        public double[] schritt_rechts = new double[10];
        public double[] schritt_links = new double[10];
        public double[] zw_schritt_rechts = new double[10];
        public double[] zw_schritt_links = new double[10];

        public int steps_kinect = 0; // schritte von form1
        int count = 0;
        public int schrittzähler = 0;//schrittezähler
        public double[] durchschnitt = new double[99];

        int schritterkennungabstand = 3;
        int abstand_zw_zwei_schritten = 40;

        double mittelpunkt_links;
        double mittelpunkt_rechts;
        double mittelpunkt_links_y;
        double mittelpunkt_rechts_y;
        double multiplikator;

        public bool übsülon = false;
        public int puh = 0;
        public bool imquadrat = false;

        public bool lf_rf_vergleich = true;//bei false mit rechtem Fuß starten

        public int timeout = 10;
        public bool startstop=false;
        public bool startstop_multiplayer=false;
        public int wieviel_geschafft = 0;
        bool rechtsvslinks = true;
        bool isschopassiert = false;
        public bool zufall_objekt=false;
        public int[] objektposition = new int[3];
        bool objekte_generiert = false;
        public bool schongestartet=false;

        public bool autobox = false;//für automatische Boxeinblendung
        public bool already_placed = false;
        public int anzeigepunkt;
        public int empfindlichkeit;

        retrieve_Kinect kinect = new retrieve_Kinect();

        private Form1 _form1_schritt;
        public Form1 form1_schritt
        {
            set { this._form1_schritt = value; }
        }
        public KinectMonitor()
        {
            InitializeComponent();

        }
        public void DrawLineFloat(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Red, 1);

            e.Graphics.DrawLine(blackPen, (int)(Math.Round(_form1_schritt.ir.erg_x[0])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[0]) + pictureBox1.Location.Y, (int)(Math.Round(_form1_schritt.ir.erg_x[1])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[1]) + pictureBox1.Location.Y);// ro ru
            e.Graphics.DrawLine(blackPen, (int)(Math.Round(_form1_schritt.ir.erg_x[0])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[0]) + pictureBox1.Location.Y, (int)(Math.Round(_form1_schritt.ir.erg_x[3])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[3]) + pictureBox1.Location.Y);// ro lo
            e.Graphics.DrawLine(blackPen, (int)(Math.Round(_form1_schritt.ir.erg_x[2])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[2]) + pictureBox1.Location.Y, (int)(Math.Round(_form1_schritt.ir.erg_x[3])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[3]) + pictureBox1.Location.Y);// lu lo
            e.Graphics.DrawLine(blackPen, (int)(Math.Round(_form1_schritt.ir.erg_x[2])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[2]) + pictureBox1.Location.Y, (int)(Math.Round(_form1_schritt.ir.erg_x[1])) + pictureBox1.Location.X, (int)(_form1_schritt.ir.erg_y[1]) + pictureBox1.Location.Y);// lu ru

            e.Graphics.DrawLine(blackPen, (int)Math.Round(mittelpunkt_links) + pictureBox1.Location.X, (int)mittelpunkt_links_y + pictureBox1.Location.Y, (int)Math.Round(mittelpunkt_rechts) + pictureBox1.Location.X, (int)mittelpunkt_rechts_y + pictureBox1.Location.Y);
        }
        private void KinectMonitor_Load(object sender, EventArgs e)
        {

            mittelpunkt_links = Properties.Settings.Default.mittelpunkt_links;
            mittelpunkt_rechts = Properties.Settings.Default.mittelpunkt_rechts;
            mittelpunkt_links_y = Properties.Settings.Default.mittelpunkt_linksy;
            mittelpunkt_rechts_y = Properties.Settings.Default.mittelpunkt_rechtsy;

            multiplikator = Properties.Settings.Default.multiplikator;
            multiplikator = multiplikator + 0.5;//korrektur

            pictureBox1.Paint += DrawLineFloat;

            //Task thread = Task.Run(() =>
            //{  
            // mySensor = KinectSensor.GetDefault();

            //if (mySensor != null)
            //{
            //    mySensor.Open();
            //}
            //    myReader = mySensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color);
            //    myReader.MultiSourceFrameArrived += myReader_MultiSourceFrameArrived;         //TODO: extra Thread geht ned
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
            //myReader = mySensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color);//todo: für release kommentieren
            //myReader.MultiSourceFrameArrived += myReader_MultiSourceFrameArrived;

            bodyFrameReader = mySensor.BodyFrameSource.OpenReader();

            //myReader = mySensor.OpenMultiSourceFrameReader(FrameSourceTypes.Infrared);
            //myReader.MultiSourceFrameArrived += reader_IRFrameArrived; //unwichtig: kürzlich geändert
            if (bodyFrameReader != null)
            {
                bodyFrameReader.FrameArrived += reader_FrameArrived;
            }
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
                    byte[] pixelData = new byte[width * height * 4];
                    int xcoord = 0;
                    int ycoord = 0;

                    frame.CopyFrameDataToArray(data);
                    int akt = 0;
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

                    EuclideanColorFiltering filter = new EuclideanColorFiltering();
                    ResizeNearestNeighbor filter2 = new ResizeNearestNeighbor(512, 424);
                    filter.Radius = (short)trackBar1.Value; //Increase this to allow off-whites
                    filter.FillOutside = false;

                    Bitmap bmp = filter.Apply(bitmap);

                    filter2.Apply(bmp);
                    //filter3.Apply(bmp);
                    pictureBox1.Image = bitmap;

                }
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

                    ResizeNearestNeighbor filter3 = new ResizeNearestNeighbor(512, 424);
                    Bitmap newImage = filter3.Apply(bitmap);

                    filter.Red = new AForge.IntRange(0, 255);
                    filter.Green = new AForge.IntRange(0, 75);
                    filter.Blue = new AForge.IntRange(0, 75);
                    //filter2.ApplyInPlace(bitmap);
                    //filter.ApplyInPlace(bitmap);
                    pictureBox1.Image = newImage;
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
                    _form1_schritt.kinectToolStripMenuItem.BackColor = Color.Orange;
                    dataRecieved = true;
                }
            }
            if (dataRecieved)
            {
                foreach (Body body in bodies)
                {
                    if (body.IsTracked)
                    {
                        //Thread.Sleep(timeout);        //für "Versuch 1" notwendig
                        _form1_schritt.kinectToolStripMenuItem.BackColor = Color.Green;
                        IReadOnlyDictionary<JointType, Joint> joints = body.Joints;
                        Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();

                        Joint FootRight = joints[JointType.FootRight];
                        Joint FootLeft = joints[JointType.FootLeft];

                        float rf_distance_x = ((FootRight.Position.X * -100) + 256);
                        float rf_distance_y = FootRight.Position.Y * -100 + 212;
                        float rf_distance_z = FootRight.Position.Z;

                        float lf_distance_x = ((FootLeft.Position.X * -100) + 256);
                        float lf_distance_y = FootLeft.Position.Y * -100 + 212;
                        float lf_distance_z = FootLeft.Position.Z;

                        if ((int)rf_distance_x <= 0)
                            rf_distance_x = 1;
                        if ((int)lf_distance_x <= 0)
                            lf_distance_x = 1;

                        Xlinks.Text = lf_distance_x.ToString("###");//todo entfernen
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
                            schritt_rechts[0] = Math.Round((tracker_xrechts[0] + tracker_xrechts[1] + tracker_xrechts[2]) / 3);
                            schritt_links[0] = Math.Round((tracker_xlinks[0] + tracker_xlinks[1] + tracker_xlinks[2]) / 3);

                            for (int i = 0; i < 9; i++)
                            {
                                schritt_rechts[i + 1] = zw_schritt_rechts[i];
                                schritt_links[i + 1] = zw_schritt_links[i];
                            }
                        #region testzwecke
                        //_form1_schritt.screen.strich_links.Visible = true;//zum testen
                        //_form1_schritt.screen.koordinaten_left.Visible = true;
                        //_form1_schritt.screen.strich_rechts.Visible = true;//zum testen
                        //_form1_schritt.screen.koordinaten_right.Visible = true;

                        //_form1_schritt.screen.strich_links.Location = new Point(Convert.ToInt32((Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator), 300);
                        //_form1_schritt.screen.koordinaten_left.Location = new Point(Convert.ToInt32((Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator), 450);
                        //_form1_schritt.screen.koordinaten_left.Text = ((Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator).ToString();

                        //_form1_schritt.screen.strich_rechts.Location = new Point(Convert.ToInt32((Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - mittelpunkt_links) * multiplikator), 300);
                        //_form1_schritt.screen.koordinaten_right.Location = new Point(Convert.ToInt32((Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - mittelpunkt_links) * multiplikator), 550);
                        //_form1_schritt.screen.koordinaten_right.Text = lf_distance_y.ToString();
                        #endregion

                        #region Versuch 1 (unzuverlässig)
                        //if (Convert.ToInt32(rf_distance_x) >= mittelpunkt_links && Convert.ToInt32(rf_distance_x) <= mittelpunkt_rechts)
                        //{// erst wenns innerhalb vom anzeigefeld ist soll er tracken
                        //    #region tracking rechts

                        //    if (schritt_rechts[2] != 0)//wartet bis 3 werte vorhanden sind
                        //    {
                        //        if (count == 1 && Math.Abs(schritt_rechts[0] - schritt_rechts[1]) > schritterkennungabstand && Math.Abs(schritt_rechts[1] - schritt_rechts[2]) > schritterkennungabstand && Math.Abs(schritt_rechts[0] - schritt_rechts[2]) > schritterkennungabstand)
                        //        {
                        //            text.Text = "bewegt";
                        //            count = 0;
                        //        }

                        //        if (count == 0 && Math.Abs(schritt_rechts[0] - schritt_rechts[1]) <= schritterkennungabstand && Math.Abs(schritt_rechts[1] - schritt_rechts[2]) <= schritterkennungabstand && Math.Abs(schritt_rechts[0] - schritt_rechts[2]) <= schritterkennungabstand)
                        //        {
                        //            durchschnitt[schrittzähler] = (Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - mittelpunkt_links) * multiplikator;
                        //            if (schrittzähler > 0)
                        //            {
                        //                if (Math.Abs(durchschnitt[schrittzähler] - durchschnitt[schrittzähler - 1]) > abstand_zw_zwei_schritten)
                        //                {
                        //                    text.Text = "Position rechts: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                        //                    //für Fußabdruck: Schritt 1 bei Koordinate 0; letzter schritt bei 1280
                        //                    #region Fußabdruck zeichnen rechts
                        //                    if (durchschnitt[0] != 0 && schrittzähler == 0)
                        //                    {
                        //                        _form1_schritt.screen.right_one.Left = Convert.ToInt32(durchschnitt[0]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_one.Show();
                        //                    }
                        //                    if (durchschnitt[2] != 0 && schrittzähler == 2)
                        //                    {
                        //                        _form1_schritt.screen.right_two.Left = Convert.ToInt32(durchschnitt[2]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_two.Show();
                        //                    }
                        //                    if (durchschnitt[4] != 0 && schrittzähler == 4)
                        //                    {
                        //                        _form1_schritt.screen.right_three.Left = Convert.ToInt32(durchschnitt[4]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_three.Show();
                        //                    }
                        //                    if (durchschnitt[6] != 0 && schrittzähler == 6)
                        //                    {
                        //                        _form1_schritt.screen.right_four.Left = Convert.ToInt32(durchschnitt[6]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_four.Show();
                        //                    }
                        //                    if (durchschnitt[8] != 0 && schrittzähler == 8)
                        //                    {
                        //                        _form1_schritt.screen.right_five.Left = Convert.ToInt32(durchschnitt[8]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_five.Show();
                        //                    }
                        //                    if (durchschnitt[10] != 0 && schrittzähler == 10)
                        //                    {
                        //                        _form1_schritt.screen.right_six.Left = Convert.ToInt32(durchschnitt[10]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_six.Show();
                        //                    }
                        //                    if (durchschnitt[11] != 0 && schrittzähler == 12)
                        //                    {
                        //                        _form1_schritt.screen.right_seven.Left = Convert.ToInt32(durchschnitt[11]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_seven.Show();
                        //                    }
                        //                    if (durchschnitt[12] != 0 && schrittzähler == 14)
                        //                    {
                        //                        _form1_schritt.screen.right_eight.Left = Convert.ToInt32(durchschnitt[12]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_eight.Show();
                        //                    }
                        //                    if (durchschnitt[13] != 0 && schrittzähler == 16)
                        //                    {
                        //                        _form1_schritt.screen.right_nine.Left = Convert.ToInt32(durchschnitt[13]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_nine.Show();
                        //                    }
                        //                    if (durchschnitt[14] != 0 && schrittzähler == 18)
                        //                    {
                        //                        _form1_schritt.screen.right_ten.Left = Convert.ToInt32(durchschnitt[14]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_ten.Show();
                        //                    }

                        //                    #endregion
                        //                    schrittzähler++;
                        //                    count = 1;
                        //                    _form1_schritt.delsteps.Visible = true;//aktiviert zurücksetzen button
                        //                    _form1_schritt.analyseToolStripMenuItem.Visible = true;//aktiviert analyse button
                        //                }
                        //            }
                        //            else
                        //            {
                        //                text.Text = "Position rechts: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                        //                //für Fußabdruck: Schritt 1 bei Koordinate 0; letzter schritt bei 1280

                        //                if (durchschnitt[0] != 0 && schrittzähler == 0)
                        //                {
                        //                    _form1_schritt.screen.right_one.Left = Convert.ToInt32(durchschnitt[0]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_one.Show();
                        //                }       
                        //                //for (int i = 0; i < 1000; i++) { count = 1; }

                        //                schrittzähler++;
                        //                count = 1;
                        //                _form1_schritt.delsteps.Visible = true;//aktiviert zurücksetzen button
                        //                _form1_schritt.analyseToolStripMenuItem.Visible = true;//aktiviert analyse button
                        //            }
                        //        }
                        //    }
                        //    #endregion
                        //}
                        ////--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        //if (Convert.ToInt32(lf_distance_x) >= mittelpunkt_links && Convert.ToInt32(lf_distance_x) <= mittelpunkt_rechts)
                        //{// erst wenns innerhalb vom anzeigefeld ist soll er tracken
                        //    #region tracking links
                        //    if (schritt_links[2] != 0)//wartet bis 3 werte vorhanden sind
                        //    {
                        //        if (count == 1 && Math.Abs(schritt_links[0] - schritt_links[1]) > schritterkennungabstand && Math.Abs(schritt_links[1] - schritt_links[2]) > schritterkennungabstand && Math.Abs(schritt_links[0] - schritt_links[2]) > schritterkennungabstand)
                        //        {
                        //            text.Text = "bewegt";
                        //            // MessageBox.Show(schritt_rechts[0] + " + " + schritt_rechts[1] + " + " + schritt_rechts[2]);
                        //            count = 0;
                        //            //for (int i = 0; i < 1000; i++) { count = 0; }
                        //        }

                        //        if (count == 0 && Math.Abs(schritt_links[0] - schritt_links[1]) <= schritterkennungabstand && Math.Abs(schritt_links[1] - schritt_links[2]) <= schritterkennungabstand && Math.Abs(schritt_links[0] - schritt_links[2]) <= schritterkennungabstand)
                        //        {
                        //            durchschnitt[schrittzähler] = (Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator;
                        //            //text.Text = schritt_rechts[0] + " + " + schritt_rechts[1] + " + " + schritt_rechts[2] + " = " + durchschnitt.ToString();

                        //            if (schrittzähler > 0)
                        //            {
                        //                if (Math.Abs(durchschnitt[schrittzähler] - durchschnitt[schrittzähler - 1]) > abstand_zw_zwei_schritten)
                        //                {
                        //                    text.Text = "Position links: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                        //                    //für Fußabdruck: Schritt 1 bei Koordinate 0; letzter schritt bei 1920
                        //                    #region Fußabdruck zeichnen links
                        //                    if (durchschnitt[1] != 0 && schrittzähler == 1)
                        //                    {
                        //                        _form1_schritt.screen.left_one.Left = Convert.ToInt32(durchschnitt[1]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_one.Show();
                        //                    }
                        //                    if (durchschnitt[3] != 0 && schrittzähler == 3)
                        //                    {
                        //                        _form1_schritt.screen.left_two.Left = Convert.ToInt32(durchschnitt[3]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_two.Show();
                        //                    }
                        //                    if (durchschnitt[5] != 0 && schrittzähler == 5)
                        //                    {
                        //                        _form1_schritt.screen.left_three.Left = Convert.ToInt32(durchschnitt[5]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_three.Show();
                        //                    }
                        //                    if (durchschnitt[7] != 0 && schrittzähler == 7)
                        //                    {
                        //                        _form1_schritt.screen.left_four.Left = Convert.ToInt32(durchschnitt[7]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_four.Show();
                        //                    }
                        //                    if (durchschnitt[9] != 0 && schrittzähler == 9)
                        //                    {
                        //                        _form1_schritt.screen.left_five.Left = Convert.ToInt32(durchschnitt[9]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_five.Show();
                        //                    }
                        //                    if (durchschnitt[11] != 0 && schrittzähler == 11)
                        //                    {
                        //                        _form1_schritt.screen.left_six.Left = Convert.ToInt32(durchschnitt[11]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_six.Show();
                        //                    }
                        //                    if (durchschnitt[11] != 0 && schrittzähler == 13)
                        //                    {
                        //                        _form1_schritt.screen.left_seven.Left = Convert.ToInt32(durchschnitt[11]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_seven.Show();
                        //                    }
                        //                    if (durchschnitt[12] != 0 && schrittzähler == 15)
                        //                    {
                        //                        _form1_schritt.screen.left_eight.Left = Convert.ToInt32(durchschnitt[12]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_eight.Show();
                        //                    }
                        //                    if (durchschnitt[13] != 0 && schrittzähler == 17)
                        //                    {
                        //                        _form1_schritt.screen.left_nine.Left = Convert.ToInt32(durchschnitt[13]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_nine.Show();
                        //                    }
                        //                    if (durchschnitt[14] != 0 && schrittzähler == 19)
                        //                    {
                        //                        _form1_schritt.screen.left_ten.Left = Convert.ToInt32(durchschnitt[14]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_ten.Show();
                        //                    }

                        //                    #endregion

                        //                    _form1_schritt.delsteps.Visible = true;//aktiviert zurücksetzen button
                        //                    _form1_schritt.analyseToolStripMenuItem.Visible = true;//aktiviert analyse button
                        //                    //for (int i = 0; i < 1000; i++) { count = 1; }
                        //                    count = 1;
                        //                    schrittzähler++;
                        //                }
                        //            }

                        //            else
                        //            {
                        //                text.Text = "Position links: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                        //                //für Fußabdruck: Schritt 1 bei Koordinate 0; letzter schritt bei 1920
                        //                if (durchschnitt[1] != 0 && schrittzähler == 1)
                        //                {
                        //                    _form1_schritt.screen.left_one.Left = Convert.ToInt32(durchschnitt[1]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_one.Show();
                        //                }

                        //                //_form2.übertragung();
                        //                _form1_schritt.delsteps.Visible = true;//aktiviert zurücksetzen button
                        //                _form1_schritt.analyseToolStripMenuItem.Visible = true;//aktiviert analyse button
                        //                                                               //for (int i = 0; i < 1000; i++) { count = 1; }
                        //                count = 1;
                        //                schrittzähler++;
                        //            }
                        //        }
                        //    }
                        //    #endregion
                        //}
                        #endregion Versuch n1
                        if (!übsülon)
                        {
                            if (!startstop)
                            {
                                _form1_schritt.screen.strich_rechts.Visible = false;
                                if (Properties.Settings.Default.weg_unten >= Convert.ToInt32(rf_distance_y) && Properties.Settings.Default.weg_unten >= Convert.ToInt32(lf_distance_y) && Properties.Settings.Default.weg_oben <= Convert.ToInt32(rf_distance_y) && Properties.Settings.Default.weg_oben <= Convert.ToInt32(lf_distance_y)
                                   && Convert.ToInt32(lf_distance_x) >= mittelpunkt_links && Convert.ToInt32(lf_distance_x) <= mittelpunkt_rechts && Convert.ToInt32(rf_distance_x) >= mittelpunkt_links && Convert.ToInt32(rf_distance_x) <= mittelpunkt_rechts)
                                {
                                    if ((Convert.ToInt32(rf_distance_x) > Convert.ToInt32(lf_distance_x)) && !lf_rf_vergleich)
                                    {
                                        durchschnitt[schrittzähler] = (Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator;

                                        if (schrittzähler > 1 && Math.Abs(durchschnitt[schrittzähler] - durchschnitt[schrittzähler - 2]) > abstand_zw_zwei_schritten)
                                        {
                                            //durchschnitt[schrittzähler] = (Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator;
                                            text.Text = "Position links: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                                            #region Fußabdruck zeichnen links
                                            if (durchschnitt[1] != 0 && schrittzähler == 1)
                                            {
                                                _form1_schritt.screen.left_one.Left = Convert.ToInt32(durchschnitt[1]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_one.Show();
                                            }
                                            if (durchschnitt[3] != 0 && schrittzähler == 3)
                                            {
                                                _form1_schritt.screen.left_two.Left = Convert.ToInt32(durchschnitt[3]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_two.Show();
                                            }
                                            if (durchschnitt[5] != 0 && schrittzähler == 5)
                                            {
                                                _form1_schritt.screen.left_three.Left = Convert.ToInt32(durchschnitt[5]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_three.Show();
                                            }
                                            if (durchschnitt[7] != 0 && schrittzähler == 7)
                                            {
                                                _form1_schritt.screen.left_four.Left = Convert.ToInt32(durchschnitt[7]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_four.Show();
                                            }
                                            if (durchschnitt[9] != 0 && schrittzähler == 9)
                                            {
                                                _form1_schritt.screen.left_five.Left = Convert.ToInt32(durchschnitt[9]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_five.Show();
                                            }
                                            if (durchschnitt[11] != 0 && schrittzähler == 11)
                                            {
                                                _form1_schritt.screen.left_six.Left = Convert.ToInt32(durchschnitt[11]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_six.Show();
                                            }
                                            if (durchschnitt[13] != 0 && schrittzähler == 13)
                                            {
                                                _form1_schritt.screen.left_seven.Left = Convert.ToInt32(durchschnitt[13]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_seven.Show();
                                            }
                                            if (durchschnitt[15] != 0 && schrittzähler == 15)
                                            {
                                                _form1_schritt.screen.left_eight.Left = Convert.ToInt32(durchschnitt[15]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_eight.Show();
                                            }
                                            if (durchschnitt[17] != 0 && schrittzähler == 17)
                                            {
                                                _form1_schritt.screen.left_nine.Left = Convert.ToInt32(durchschnitt[17]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_nine.Show();
                                            }
                                            if (durchschnitt[19] != 0 && schrittzähler == 19)
                                            {
                                                _form1_schritt.screen.left_ten.Left = Convert.ToInt32(durchschnitt[19]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.left_ten.Show();
                                            }

                                            #endregion
                                            schrittzähler++;
                                            lf_rf_vergleich = true;
                                        }
                                        else if (schrittzähler == 1)
                                        {
                                            text.Text = "Position links: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                                            if (durchschnitt[1] != 0 && schrittzähler == 1)
                                            {
                                                _form1_schritt.screen.left_one.Left = Convert.ToInt32(durchschnitt[1]) - (_form1_schritt.screen.left_one.Size.Width / 2); _form1_schritt.screen.left_one.Show();
                                            }
                                            schrittzähler++;
                                            _form1_schritt.delsteps.Visible = true;//aktiviert zurücksetzen button
                                            _form1_schritt.analyseToolStripMenuItem.Visible = true;//aktiviert analyse button
                                            lf_rf_vergleich = true;
                                        }

                                    }

                                    else if ((Convert.ToInt32(rf_distance_x) < Convert.ToInt32(lf_distance_x)) && lf_rf_vergleich)
                                    {
                                        durchschnitt[schrittzähler] = (Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - mittelpunkt_links) * multiplikator;

                                        if (schrittzähler > 1 && Math.Abs(durchschnitt[schrittzähler] - durchschnitt[schrittzähler - 2]) > abstand_zw_zwei_schritten)
                                        {
                                            text.Text = "Position rechts: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                                            #region Fußabdruck zeichnen rechts
                                            if (durchschnitt[0] != 0 && schrittzähler == 0)
                                            {
                                                _form1_schritt.screen.right_one.Left = Convert.ToInt32(durchschnitt[0]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_one.Show();
                                            }
                                            if (durchschnitt[2] != 0 && schrittzähler == 2)
                                            {
                                                _form1_schritt.screen.right_two.Left = Convert.ToInt32(durchschnitt[2]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_two.Show();
                                            }
                                            if (durchschnitt[4] != 0 && schrittzähler == 4)
                                            {
                                                _form1_schritt.screen.right_three.Left = Convert.ToInt32(durchschnitt[4]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_three.Show();
                                            }
                                            if (durchschnitt[6] != 0 && schrittzähler == 6)
                                            {
                                                _form1_schritt.screen.right_four.Left = Convert.ToInt32(durchschnitt[6]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_four.Show();
                                            }
                                            if (durchschnitt[8] != 0 && schrittzähler == 8)
                                            {
                                                _form1_schritt.screen.right_five.Left = Convert.ToInt32(durchschnitt[8]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_five.Show();
                                            }
                                            if (durchschnitt[10] != 0 && schrittzähler == 10)
                                            {
                                                _form1_schritt.screen.right_six.Left = Convert.ToInt32(durchschnitt[10]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_six.Show();
                                            }
                                            if (durchschnitt[12] != 0 && schrittzähler == 12)
                                            {
                                                _form1_schritt.screen.right_seven.Left = Convert.ToInt32(durchschnitt[12]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_seven.Show();
                                            }
                                            if (durchschnitt[14] != 0 && schrittzähler == 14)
                                            {
                                                _form1_schritt.screen.right_eight.Left = Convert.ToInt32(durchschnitt[14]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_eight.Show();
                                            }
                                            if (durchschnitt[16] != 0 && schrittzähler == 16)
                                            {
                                                _form1_schritt.screen.right_nine.Left = Convert.ToInt32(durchschnitt[16]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_nine.Show();
                                            }
                                            if (durchschnitt[18] != 0 && schrittzähler == 18)
                                            {
                                                _form1_schritt.screen.right_ten.Left = Convert.ToInt32(durchschnitt[18]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_ten.Show();
                                            }

                                            #endregion
                                            schrittzähler++;
                                            lf_rf_vergleich = false;
                                        }
                                        else if (schrittzähler == 0)
                                        {
                                            //durchschnitt[schrittzähler] = (Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - mittelpunkt_links) * multiplikator;
                                            text.Text = "Position rechts: " + durchschnitt[schrittzähler] + "   Schrittnummer: " + schrittzähler.ToString();
                                            if (durchschnitt[0] != 0 && schrittzähler == 0)
                                            {
                                                _form1_schritt.screen.right_one.Left = Convert.ToInt32(durchschnitt[0]) - (_form1_schritt.screen.right_one.Size.Width / 2); _form1_schritt.screen.right_one.Show();
                                            }
                                            schrittzähler++;
                                            lf_rf_vergleich = false;
                                            _form1_schritt.delsteps.Visible = true;//aktiviert zurücksetzen button
                                            _form1_schritt.analyseToolStripMenuItem.Visible = true;//aktiviert analyse button
                                        }
                                    }
                                }
                                if (zufall_objekt)
                                {

                                }
                            }
                            if (startstop)
                            {
                                double aktuell_rechts = (Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - mittelpunkt_links) * multiplikator;
                                double aktuell_links = (Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator;
                                Random rnd = new Random();
                                _form1_schritt.screen.strich_rechts.Visible = true;
                                if (rechtsvslinks)
                                {
                                    if (!isschopassiert)
                                    {
                                        _form1_schritt.screen.strich_rechts.Location = new Point(rnd.Next(0, _form1_schritt.screen.Auflösung_Projektor_x / 2 - 10), _form1_schritt.screen.waagrechtoben);
                                        isschopassiert = !isschopassiert;
                                    }
                                    else if (isschopassiert && aktuell_rechts < _form1_schritt.screen.strich_rechts.Location.X || aktuell_links < _form1_schritt.screen.strich_rechts.Location.X)
                                    {
                                        rechtsvslinks = !rechtsvslinks;
                                        isschopassiert = !isschopassiert;
                                        if (startstop_multiplayer)
                                        {
                                            if (schongestartet)
                                            {
                                                wieviel_geschafft++;
                                                _form1_schritt.screen.neuerwert();
                                            }
                                            else
                                            {
                                                _form1_schritt.screen.Multiplayer_timer.Start();
                                                schongestartet = true;
                                                wieviel_geschafft++;
                                                _form1_schritt.screen.neuerwert();
                                            }   
                                        }
                                    }
                                }

                                if (!rechtsvslinks)
                                {
                                    if (!isschopassiert)
                                    {
                                        _form1_schritt.screen.strich_rechts.Location = new Point(rnd.Next(_form1_schritt.screen.Auflösung_Projektor_x / 2 + 10, _form1_schritt.screen.Auflösung_Projektor_x), _form1_schritt.screen.waagrechtoben);
                                        isschopassiert = !isschopassiert;
                                    }
                                    else if (aktuell_rechts > _form1_schritt.screen.strich_rechts.Location.X || aktuell_links > _form1_schritt.screen.strich_rechts.Location.X)
                                    {
                                        rechtsvslinks = !rechtsvslinks;
                                        isschopassiert = !isschopassiert;
                                        if (startstop_multiplayer)
                                        {
                                            if (schongestartet)
                                            {
                                                wieviel_geschafft++;
                                                _form1_schritt.screen.neuerwert();
                                            }
                                            else
                                            {
                                                _form1_schritt.screen.Multiplayer_timer.Start();
                                                schongestartet = true;
                                                wieviel_geschafft++;
                                                _form1_schritt.screen.neuerwert();
                                            }
                                        }
                                    }
                                }

                            } 
                        }
                        if (übsülon)// die boxen die projiziert werden wenn man auf die vorherige steigt
                        {
                            double aktuell_rechts = (Math.Round((schritt_rechts[0] + schritt_rechts[1] + schritt_rechts[2]) / 3) - mittelpunkt_links) * multiplikator;
                            double aktuell_links = (Math.Round((schritt_links[0] + schritt_links[1] + schritt_links[2]) / 3) - mittelpunkt_links) * multiplikator;
                            Random rnd = new Random();
                            #region blockeinblendung
                            if (puh == 0 && !imquadrat)
                            {
                                _form1_schritt.screen.block_one.Location = new Point(180,(int)(rnd.Next(_form1_schritt.screen.waagrechtoben + 300, _form1_schritt.screen.waagrechtoben - 300)));
                                imquadrat = true;
                                _form1_schritt.screen.block_one.Visible = true;
                            }
                            else if (puh == 0 && imquadrat)
                            {
                                if (aktuell_links <= _form1_schritt.screen.block_one.Location.X + _form1_schritt.screen.block_one.Size.Width && aktuell_links >= _form1_schritt.screen.block_one.Location.X || aktuell_rechts <= _form1_schritt.screen.block_one.Location.X + _form1_schritt.screen.block_one.Size.Width && aktuell_rechts >= _form1_schritt.screen.block_one.Location.X)
                                {
                                    puh = 1;
                                    imquadrat = false;
                                }
                            }
                            if (puh == 1 && !imquadrat)
                            {
                                _form1_schritt.screen.block_two.Location = new Point(360, (int)(rnd.Next(_form1_schritt.screen.waagrechtoben + 300, _form1_schritt.screen.waagrechtoben - 300)));
                                imquadrat = true;
                                _form1_schritt.screen.block_two.Visible = true;
                            }
                            else if (puh == 1 && imquadrat)
                            {
                                if (aktuell_links <= _form1_schritt.screen.block_two.Location.X + _form1_schritt.screen.block_two.Size.Width && aktuell_links >= _form1_schritt.screen.block_two.Location.X || aktuell_rechts <= _form1_schritt.screen.block_two.Location.X + _form1_schritt.screen.block_two.Size.Width && aktuell_rechts >= _form1_schritt.screen.block_two.Location.X)
                                {
                                    puh = 2;
                                    imquadrat = false;
                                }
                            }
                            if (puh == 2 && !imquadrat)
                            {
                                _form1_schritt.screen.block_three.Location = new Point(540, (int)(rnd.Next(_form1_schritt.screen.waagrechtoben + 300, _form1_schritt.screen.waagrechtoben - 300)));
                                imquadrat = true;
                                _form1_schritt.screen.block_three.Visible = true;
                            }
                            else if (puh == 2 && imquadrat)
                            {
                                if (aktuell_links <= _form1_schritt.screen.block_three.Location.X + _form1_schritt.screen.block_three.Size.Width && aktuell_links >= _form1_schritt.screen.block_three.Location.X || aktuell_rechts <= _form1_schritt.screen.block_three.Location.X + _form1_schritt.screen.block_three.Size.Width && aktuell_rechts >= _form1_schritt.screen.block_three.Location.X)
                                {
                                    puh = 3;
                                    imquadrat = false;
                                }
                            }
                            if (puh == 3 && !imquadrat)
                            {
                                _form1_schritt.screen.block_four.Location = new Point(720, (int)(rnd.Next(_form1_schritt.screen.waagrechtoben + 300, _form1_schritt.screen.waagrechtoben - 300)));
                                imquadrat = true;
                                _form1_schritt.screen.block_four.Visible = true;
                            }
                            else if (puh == 3 && imquadrat)
                            {
                                if (aktuell_links <= _form1_schritt.screen.block_four.Location.X + _form1_schritt.screen.block_four.Size.Width && aktuell_links >= _form1_schritt.screen.block_four.Location.X || aktuell_rechts <= _form1_schritt.screen.block_four.Location.X + _form1_schritt.screen.block_four.Size.Width && aktuell_rechts >= _form1_schritt.screen.block_four.Location.X)
                                {
                                    puh = 4;
                                    imquadrat = false;
                                }
                            }
                            if (puh == 4 && !imquadrat)
                            {
                                _form1_schritt.screen.block_five.Location = new Point(900, (int)(rnd.Next(_form1_schritt.screen.waagrechtoben + 300, _form1_schritt.screen.waagrechtoben - 300)));
                                imquadrat = true;
                                _form1_schritt.screen.block_five.Visible = true;
                            }
                            else if (puh == 4 && imquadrat)
                            {
                                if (aktuell_links <= _form1_schritt.screen.block_five.Location.X + _form1_schritt.screen.block_five.Size.Width && aktuell_links >= _form1_schritt.screen.block_five.Location.X || aktuell_rechts <= _form1_schritt.screen.block_five.Location.X + _form1_schritt.screen.block_five.Size.Width && aktuell_rechts >= _form1_schritt.screen.block_five.Location.X)
                                {
                                    puh = 5;
                                    imquadrat = false;
                                }
                            }
                            if (puh == 5 && !imquadrat)
                            {
                                _form1_schritt.screen.block_six.Location = new Point(1080, (int)(rnd.Next(_form1_schritt.screen.waagrechtoben + 300, _form1_schritt.screen.waagrechtoben - 300)));
                                imquadrat = true;
                                _form1_schritt.screen.block_six.Visible = true;
                            }
                            else if (puh == 5 && imquadrat)
                            {
                                if (aktuell_links <= _form1_schritt.screen.block_six.Location.X + _form1_schritt.screen.block_six.Size.Width && aktuell_links >= _form1_schritt.screen.block_six.Location.X || aktuell_rechts <= _form1_schritt.screen.block_six.Location.X + _form1_schritt.screen.block_six.Size.Width && aktuell_rechts >= _form1_schritt.screen.block_six.Location.X)
                                {
                                    puh = 0;
                                    übsülon = false;
                                    imquadrat = false;
                                }
                            }
                            #endregion
                        }


                        if (schrittzähler > 19)
                                    schrittzähler = 0;

                                if (autobox && !already_placed)
                                {
                                    if (Convert.ToInt32(rf_distance_x) >= 0 || Convert.ToInt32(lf_distance_x) >= 0)
                                    {
                                        if (Convert.ToInt32((rf_distance_x - mittelpunkt_links) * multiplikator) >= anzeigepunkt - empfindlichkeit || Convert.ToInt32((lf_distance_x - mittelpunkt_links) * multiplikator) >= anzeigepunkt - empfindlichkeit)
                                        {
                                            _form1_schritt.screen.fläche.PerformClick();
                                            already_placed = !already_placed;
                                        }
                                    }
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

        private void KinectMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myReader != null)
            {
                myReader.Dispose();
            }

            if (mySensor != null)
            {
                mySensor.Close();
            }
        }
    }
}
