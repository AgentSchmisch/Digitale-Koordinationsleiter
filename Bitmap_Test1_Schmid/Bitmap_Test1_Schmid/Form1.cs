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

namespace Bitmap_Test1_Schmid
{
    public partial class Form1 : Form
    {
        public Form2 screen = new Form2();
        Einstellungen einstellungen = new Einstellungen();
        public Patientendatenbank Patientendatenbank = new Patientendatenbank();
        retrieve_Kinect kinect = new retrieve_Kinect();
        public KinectMonitor kinectM;// = new KinectMonitor();
        public IR ir = new IR();
        public Laufwerk usb = new Laufwerk();

        public static int schritt = 0;

        public int defaultsize_f1_x = 660; //fenstergröße
        public int defaultsize_f1_y = 424;

        public double schrittdurchschnitt = 0;
        public double kleinsterabstand = 500;
        public double größterabstand = 0;

        int animation = 0;
        public Form1()
        {
            InitializeComponent();
            try
            {
                screen.Location = Screen.AllScreens[1].WorkingArea.Location; //startet auf 2tem monitor wenn möglich
                screen.StartPosition = FormStartPosition.Manual;
            }
            catch
            {
            }
            screen.Show();
        }
        private void bestätigen_Click(object sender, EventArgs e)
        {
            try
            {
                //schritt=Convert.ToInt32(steps.Text);
                screen.sendvar = Convert.ToInt32(steps.Text);
                regler.Maximum = Convert.ToInt32(steps.Text) - 1;
                screen.regler.Maximum = Convert.ToInt32(steps.Text) - 1;
                längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                screen.bestätigen.PerformClick();

                regler.Enabled = true; //entfernt den ausgegrauten look
                längebox.Enabled = true;
                fläche.Enabled = true;
                reglertext.ForeColor = Color.White;
                länge.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label4.ForeColor = Color.White;

            }
            catch
            {
                MessageBox.Show(screen.e001.Message, "Error", 0, MessageBoxIcon.Error);
            }
        }

        private void fläche_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_autoobjekt.Checked == false)
                {
                    längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                    screen.längebox.Maximum = längebox.Maximum;
                    screen.fläche.PerformClick();
                }
                if (check_autoobjekt.Checked == true)
                {
                    screen.deletebox();
                    kinectM.already_placed = false; // für automatische Boxplatzierung
                }
            }
            catch
            {
                MessageBox.Show(screen.e001.Message, "Error", 0, MessageBoxIcon.Error);
            }
        }

        private void längebox_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                länge.Text = längebox.Value.ToString();
                screen.längebox.Value = Convert.ToInt32(länge.Text);
                screen.längelabel.Text = länge.Text;
            }
            catch
            {
                MessageBox.Show(screen.e001.Message, "Error", 0, MessageBoxIcon.Error);
            }
        }

        private void regler_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                länge.Text = längebox.Value.ToString();
                reglertext.Text = regler.Value.ToString();
                screen.regler.Value = Convert.ToInt32(reglertext.Text);
                screen.reglertext.Text = reglertext.Text;
                if (!einaus)//nur wenn schritterkennung aktiv
                {
                    kinectM.anzeigepunkt = Convert.ToInt32(screen.schrittlänge[regler.Value]);
                }
            }
            catch
            {
                MessageBox.Show(screen.e001.Message, "Error", 0, MessageBoxIcon.Error);
            }
        }
        private void steps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bestätigen.PerformClick();
            }
        }

        private void regler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fläche.PerformClick();
            }
        }

        private void längebox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fläche.PerformClick();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Mit diesem Regler können Sie auswählen, bei welchem Schritt (von links beginnend) ein Objekt eingeblendet werden soll.", "Hilfe", 0, MessageBoxIcon.Question);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wählen Sie, wie lang das Objekt sein soll.", "Hilfe", 0, MessageBoxIcon.Question);
        }

        private void steps_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UInt16 Variable = Convert.ToUInt16(steps.Text);
            }
            catch (FormatException)
            {
                steps.Clear();
            }
        }
        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //öffnen der Form für die Patientendatenbank, 
                //auslesen der werte in der Form, wenn die Form geschlossen wird, die werte in die Label in der UI übergeben
                // Patientendatenbank p = new Patientendatenbank();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                Patientendatenbank.haupt = this;
                Patientendatenbank.ShowDialog();

                if (Patientendatenbank.Patientenname != null && Patientendatenbank.letzteBehandlung != null) {
                    lblName.Text = Patientendatenbank.Patientenname;
                    lblLezteTherapie.Text = Patientendatenbank.letzteBehandlung;
                    lblSteps.Text = Patientendatenbank.letzteSchrittanzahl;

                    if (Patientendatenbank.letzteSchrittanzahl.All(char.IsDigit))
                        steps.Text = Patientendatenbank.letzteSchrittanzahl;

                    if (Patientendatenbank.auswahl)
                    {
                        x = 0;
                        animation = 0;
                        timer.Start();
                    }
                    bestätigen.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehlgeschlagen" + ex);
            }

        }
        private void Patientendatenbank_Closing(object sender, FormClosingEventArgs e)
        {
            //wenn die Form geschlossen wird die Werte aus der Patientendatenbank übernehmen und im Label anzeigen
            lblName.Text = Patientendatenbank.Patientenname;
            lblLezteTherapie.Text = Patientendatenbank.letzteBehandlung;
            lblSteps.Text = Patientendatenbank.letzteSchrittanzahl;
        }

        private void BtnSitzungBeenden_Click(object sender, EventArgs e)
        {
            //übergabe der aktuellen schrittweite nach abschließen der Behandlungssitzung
            Patientendatenbank.wertuebergabe = steps.Text.ToString();
            x = 0;
            animation = 1;
            timer.Start();
            //Size = new Size(defaultsize_f1_x, defaultsize_f1_y);
            //this.CenterToScreen();
        }
        bool einaus = true;
        private void kinectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (einaus)
            {
                kinectM = new KinectMonitor();
                kinectM.form1_schritt = this;
                //ir.form1_2 = this;
                kinectM.steps_kinect = Convert.ToInt32(steps.Text);
                kinectToolStripMenuItem.BackColor = Color.Red;
                check_autoobjekt.Enabled = true;
                //Task kinectmon = Task.Run(() => kinectM.ShowDialog());
                kinectM.WindowState = FormWindowState.Minimized;
                kinectM.Show();//TODO: Muss noch vor release geändert werden
                kinectM.Hide();

                               //kinectM.Hide();
            }
            if (!einaus)
            {
                check_autoobjekt.Enabled = false;
                check_autoobjekt.Checked = false;
                kinectM.Close();
                kinectToolStripMenuItem.BackColor = Color.Black;
            }
            einaus = !einaus;
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            einstellungen.form1 = this;
            einstellungen.ShowDialog();
            if (einstellungen.dickeanders)
            {
                screen.deleteall();
                einstellungen.dickeanders = false;
            }
        }
        private void kantenerkennungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Task infrared = Task.Run(() => ir.ShowDialog());
            screen.kantenerkennung();
            screen.draw = true;
            ir.form1_2 = this;
            ir.ShowDialog();
            screen.endkanten();
            
            //ir.ShowDialog();
            //this.Show();
        }

        private void delsteps_Click(object sender, EventArgs e)
        {
            screen.right_one.Hide();
            screen.right_two.Hide();
            screen.right_three.Hide();
            screen.right_four.Hide();
            screen.right_five.Hide();
            screen.right_six.Hide();
            screen.right_seven.Hide();
            screen.right_eight.Hide();
            screen.right_nine.Hide();
            screen.right_ten.Hide();
            screen.left_one.Hide();
            screen.left_two.Hide();
            screen.left_three.Hide();
            screen.left_four.Hide();
            screen.left_five.Hide();
            screen.left_six.Hide();
            screen.left_seven.Hide();
            screen.left_eight.Hide();
            screen.left_nine.Hide();
            screen.left_ten.Hide();

            kinectM.schrittzähler = 0;
        }
        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Wollen Sie wirklich neustarten?", "Neustart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Restart();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.colorbox_r = screen.color_box_r;
            Properties.Settings.Default.colorbox_g = screen.color_box_g;
            Properties.Settings.Default.colorbox_b = screen.color_box_b;
            Properties.Settings.Default.color_r = screen.color_r;
            Properties.Settings.Default.color_g = screen.color_g;//speichert Farbwerte
            Properties.Settings.Default.color_b = screen.color_b;
            Properties.Settings.Default.Save();
        }

        private void analyseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < kinectM.schrittzähler; i++)
            {
                schrittdurchschnitt += kinectM.durchschnitt[i];
                if (i > 0)
                {
                    if (Math.Abs(kinectM.durchschnitt[i + 1] - kinectM.durchschnitt[i]) < kleinsterabstand)
                    {
                        kleinsterabstand = Math.Abs(kinectM.durchschnitt[i + 1] - kinectM.durchschnitt[i]);
                    }

                    if (Math.Abs(kinectM.durchschnitt[i + 1] - kinectM.durchschnitt[i]) > größterabstand)
                    {
                        größterabstand = Math.Abs(kinectM.durchschnitt[i + 1] - kinectM.durchschnitt[i]);
                    }
                }

            }
            schrittdurchschnitt = schrittdurchschnitt / (kinectM.schrittzähler - 1);

            Math.Round(schrittdurchschnitt);
            Math.Round(kleinsterabstand);
            Math.Round(schrittdurchschnitt);

            Analyse analyse = new Analyse();
            analyse.form1_anal = this;
            analyse.schrittdurchschnitt = schrittdurchschnitt;
            analyse.kleinsterabstand = kleinsterabstand;
            analyse.größterabstand = größterabstand;
            analyse.schritte = kinectM.schrittzähler;
            analyse.ShowDialog();

        }

        int x = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            x += 100;
            if (animation == 0)
            {
                Size = new Size(defaultsize_f1_x + x, defaultsize_f1_y);                //vergrößern der UI um die aktuellen Patientenwerte auszulesen
                this.CenterToScreen();
                if (x >= 499)
                    timer.Stop(); return;
            }
            if (animation == 1)
            {
                Size = new Size(defaultsize_f1_x + 500 - x, defaultsize_f1_y);                //vergrößern der UI um die aktuellen Patientenwerte auszulesen
                this.CenterToScreen();
                if (x >= 499)
                    timer.Stop(); return;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                label9.Location = new Point(446, label9.Location.Y);
                label9.Text = "sehr früh";
                kinectM.empfindlichkeit = 500; 
            }

            if (trackBar1.Value == 2) 
            {
                label9.Location = new Point(490, label9.Location.Y);
                label9.Text = "früh";
                kinectM.empfindlichkeit = 400;
            }

            if (trackBar1.Value == 3)
            {
                label9.Location = new Point(505, label9.Location.Y);
                label9.Text = "mittel";
                kinectM.empfindlichkeit = 300;
            }

            if (trackBar1.Value == 4)
            {
                label9.Location = new Point(525, label9.Location.Y);
                label9.Text = "spät";
                kinectM.empfindlichkeit = 200;
            }

            if (trackBar1.Value == 5)
            {
                label9.Location = new Point(540, label9.Location.Y);
                label9.Text = "sehr spät";
                kinectM.empfindlichkeit = 100;
            }
            screen.fläche.PerformClick();
        }

        private void chech_autoobjekt_CheckedChanged(object sender, EventArgs e)
        {
            if (check_autoobjekt.Checked == true)//wenn aktiviert
            {
                fläche.Text = "Entfernen";
                trackBar1.Enabled = true;
                label9.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                kinectM.autobox = true;
                kinectM.anzeigepunkt = Convert.ToInt32(screen.schrittlänge[regler.Value]);
                trackBar1.Value = 3;
                kinectM.empfindlichkeit = 300;
            }
            if (check_autoobjekt.Checked == false)// wenn deaktiviert
            {
                kinectM.autobox = false;
                fläche.Text = "bestätigen";
                trackBar1.Enabled = false;
                label7.ForeColor = Color.Gray;
                label9.ForeColor = Color.Gray;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hier können Sie einstellen, wie weit vor dem Ziel eine Box eingeblendet werden soll.", "Hilfe", 0, MessageBoxIcon.Question);//hilfeanzeige
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            screen.himmel_hölle();
        }

        private void regler_Scroll(object sender, EventArgs e)
        {

        }
    }
}
