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
        Form2 screen = new Form2();
        Patientendatenbank Patientendatenbank = new Patientendatenbank();
        public static int schritt = 0;

        public Form1()
        {
            InitializeComponent();
            screen.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void bestätigen_Click(object sender, EventArgs e)
        {
            try
            {
                //schritt=Convert.ToInt32(steps.Text);
                Form2.sendvar = Convert.ToInt32(steps.Text);
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
                Patientendatenbank.Show();
                lblLezteTherapie.Text = Patientendatenbank.letzteBehandlung;
                Patientendatenbank.FormClosing += Patientendatenbank_Closing;
            }
            catch

            {
                MessageBox.Show("fehlgeschlagen");
            }
        }


        private void Patientendatenbank_Closing(object sender, FormClosingEventArgs e)
        {
            lblName.Text = Patientendatenbank.Nameaktuell;
            lblLezteTherapie.Text = Patientendatenbank.letzteBehandlung;
            lblSteps.Text = Patientendatenbank.letzteSchrittanzahl;
           
        }



        private void BtnSitzungBeenden_Click(object sender, EventArgs e)
        {

            Patientendatenbank.wertuebergabe = steps.Text.ToString();
              //TODO: einfügen der daten in die Datenbank über die Form "Patientendatenbank"
        }
    }
}
