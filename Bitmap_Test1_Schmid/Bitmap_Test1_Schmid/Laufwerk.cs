using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Bitmap_Test1_Schmid
{

    [StructLayout(LayoutKind.Sequential)]
    public struct DevBroadcastVolume
    {
        public int Size;
        public int DeviceType;
        public int Reserved;
        public int Mask;
        public Int16 Flags;
    }

    public partial class Laufwerk : Form
    {
        //private const int WM_DEVICECHANGE = 0x219;
        //private const int DBT_DEVICEARRIVAL = 0x8000;
        //private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        //private const int DBT_DEVTYP_VOLUME = 0x00000002;
        //public string[] alpha = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        //string output = "100000";
        //public string letter;
        public Laufwerk()
        {
            InitializeComponent();
        }

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    try
        //    {

        //        switch (m.Msg)
        //        {

        //            case WM_DEVICECHANGE:
        //                switch ((int)m.WParam)
        //                {
        //                    case DBT_DEVICEARRIVAL:

        //                        int devType = Marshal.ReadInt32(m.LParam, 4);
        //                        if (devType == DBT_DEVTYP_VOLUME)
        //                        {
        //                            DevBroadcastVolume vol;
        //                            vol = (DevBroadcastVolume)
        //                               Marshal.PtrToStructure(m.LParam,
        //                               typeof(DevBroadcastVolume));
        //                            output = Convert.ToString(vol.Mask, 2);


        //                            DriveInfo[] diLocalDrives = DriveInfo.GetDrives();

        //                            foreach (DriveInfo diLogicalDrive in diLocalDrives)
        //                            {
        //                                if (diLogicalDrive.Name.ToString().Contains(alpha[output.Length - 1]))
        //                                {
        //                                    listBox1.Items.Add("USB: " + diLogicalDrive.VolumeLabel + " (" + alpha[output.Length - 1] + ":), " + diLogicalDrive.AvailableFreeSpace/ 1000000000 + "/" + diLogicalDrive.TotalSize/1000000000 + " GB");
        //                                }
        //                            }
        //                        }

        //                        break;

        //                    case DBT_DEVICEREMOVECOMPLETE:
        //                        listBox1.Items.Clear();
        //                        break;
        //                }
        //                break;
        //        }
        //    }
        //    catch 
        //    {
        //    }

        //}

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //letter = alpha[output.Length - 1];
                Properties.Settings.Default.Laufwerk = usbname[listBox1.SelectedIndex];
                Properties.Settings.Default.Save();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Bitte schneller klicken!", "schneller klicken!", MessageBoxButtons.OK , MessageBoxIcon.Asterisk);
            }
        }

        private void Laufwerk_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listBox1.Items.Clear();
            usbfinder();
        }
        int i = 0;
        string[] usbname = new string[10];
        public void usbfinder()
        {
            try
            {
                i = 0;
                Array.Clear(usbname, 0, usbname.Length);
                listBox1.Items.Clear();

                DriveInfo[] diLocalDrives = DriveInfo.GetDrives();

                foreach (DriveInfo diLogicalDrive in diLocalDrives)
                {
                    if (diLogicalDrive.DriveType.ToString() == "Removable")
                    {
                        listBox1.Enabled = true;
                        listBox1.Items.Add(diLogicalDrive.Name + " " + diLogicalDrive.VolumeLabel + " (" + diLogicalDrive.AvailableFreeSpace / 1000000000 + "/" + diLogicalDrive.TotalSize / 1000000000 + " GB)");
                        usbname[i] = diLogicalDrive.Name;
                        i++;
                        listBox1.SelectedIndex = 0;
                    }
                }
                if (i == 0)
                {
                    listBox1.Items.Add("kein USB-Gerät erkannt!");
                    listBox1.Enabled = false;
                }
            }
            catch 
            {
                MessageBox.Show("Es ist ein Fehler aufgetreten");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            usbfinder();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Properties.Settings.Default.Laufwerk = usbname[listBox1.SelectedIndex];
                    Properties.Settings.Default.Save();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Bitte schneller klicken!", "schneller klicken!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
