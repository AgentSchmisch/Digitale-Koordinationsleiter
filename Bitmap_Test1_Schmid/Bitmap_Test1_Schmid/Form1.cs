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
    public partial class Form1 : Form
    {
        public Form2 screen = new Form2();
        Einstellungen einstellungen = new Einstellungen();
        public Patientendatenbank Patientendatenbank = new Patientendatenbank();
        retrieve_Kinect kinect = new retrieve_Kinect();
        public KinectMonitor kinectM = new KinectMonitor();

        public static int schritt = 0;

        public Form1()
        {
            InitializeComponent();
            screen.Show();
        }
        private void bestätigen_Click(object sender, EventArgs e)
        {
            try
            {
                //schritt=Convert.ToInt32(steps.Text);
                screen.sendvar = Convert.ToInt32(steps.Text);
                regler.Maximum = Convert.ToInt32(steps.Text)-1;
                screen.regler.Maximum = Convert.ToInt32(steps.Text)-1;
                längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                screen.bestätigen.PerformClick();

                regler.Enabled = true; //entfernt den ausgegrauten look
                längebox.Enabled = true;
                fläche.Enabled = true;
                reglertext.ForeColor = Color.White;
                länge.ForeColor = Color.White;
                label2.ForeColor = Color.White;

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
                längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                screen.längebox.Maximum = längebox.Maximum;
                screen.fläche.PerformClick();
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
                reglertext.Text = regler.Value.ToString();
                screen.regler.Value = Convert.ToInt32(reglertext.Text);
                screen.reglertext.Text = reglertext.Text;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                //öffnen der Form für die Patientendatenbank, 
                //auslesen der werte in der Form, wenn die Form geschlossen wird, die werte in die Label in der UI übergeben
                // Patientendatenbank p = new Patientendatenbank();
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                Patientendatenbank.ShowDialog();
                lblName.Text = Patientendatenbank.Patientenname;
                lblLezteTherapie.Text = Patientendatenbank.letzteBehandlung;
                lblSteps.Text = Patientendatenbank.letzteSchrittanzahl;

                if (Patientendatenbank.auswahl) {
                    Size = new Size(1139, 409);                //vergrößern der UI um die aktuellen Patientenwerte auszulesen
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fehlgeschlagen" +ex);
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
            //TODO: einfügen der daten in die Datenbank über die Form "Patientendatenbank"
        }

        private void kinectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kinectM.form1 = this;
            kinectM.Show();
            kinectM.steps_kinect = Convert.ToInt32(steps.Text);
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            einstellungen.form1 = this;
            einstellungen.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = Color.White;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void kantenerkennungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            screen.Kantenerkennung();
        }
    }
}
