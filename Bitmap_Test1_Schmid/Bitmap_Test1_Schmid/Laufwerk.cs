using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
        public Laufwerk()
        {
            InitializeComponent();
        }

        
        private void listBox1_DoubleClick(object sender, EventArgs e)
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
