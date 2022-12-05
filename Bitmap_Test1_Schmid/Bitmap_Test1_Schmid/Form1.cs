using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class Form1 : Form
    {
        public Form2 screen = new Form2();
        Einstellungen einstellungen = new Einstellungen();
        public Patientendatenbank Patientendatenbank = new Patientendatenbank();
        public Analyse analyse = new Analyse();
        public KinectMonitor kinectM = new KinectMonitor();
        public IR ir = new IR();
        public Laufwerk usb = new Laufwerk();

        public static int schritt = 0;

        public int defaultsize_f1_x = 660; //fenstergröße
        public int defaultsize_f1_y = 424;

        public double schrittdurchschnitt = 0;
        public double kleinsterabstand = 500;
        public double größterabstand = 0;

        public int sollabstände=0;

        public int soll_größterabstand = 0;
        public int soll_kleinsterabstand = 100;
        public double soll_mittelwert = 0;
        public int soll_anzahl = 0;

        bool keinschritt=false; 
        bool etwas_geändert=true;

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
                if (steps.Text.Length > 2)//im Fall einer 3 stelligen zahl
                {
                    steps.Text = "99";
                }
                screen.sendvar = Convert.ToInt32(steps.Value);
                regler.Maximum = Convert.ToInt32(steps.Value) - 1;
                screen.regler.Maximum = Convert.ToInt32(steps.Value) - 1;
                längebox.Maximum = Convert.ToInt32(steps.Value) - regler.Value;
                screen.bestätigen.PerformClick();

                regler.Enabled = true; //entfernt den ausgegrauten look
                längebox.Enabled = true;
                fläche.Enabled = true;
                reglertext.ForeColor = Color.White;
                länge.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                //if (steps.Value == Convert.ToInt32(Patientendatenbank.projektionslaenge)) { }
                //else
                //{
                //    sollabstände += Convert.ToInt32(steps.Value.ToString());
                //    soll_anzahl++;
                //}
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
                if (!check_autoobjekt.Checked)
                {
                    längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                    screen.längebox.Maximum = längebox.Maximum;
                    if (etwas_geändert)
                    {
                        screen.fläche.PerformClick();
                        fläche.Text = "Entfernen";
                        etwas_geändert = !etwas_geändert;
                    }
                    else if (!etwas_geändert)
                    {
                        screen.deletebox();
                        fläche.Text = "Bestätigen";
                        etwas_geändert = !etwas_geändert;
                    }
                }
                if (check_autoobjekt.Checked)
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
                etwas_geändert = true;
                fläche.Text = "bestätigen";
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
                etwas_geändert = true;
                fläche.Text = "bestätigen";
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
        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //öffnen der Form für die Patientendatenbank, 
                //auslesen der werte in der Form, wenn die Form geschlossen wird, die werte in die Label in der UI übergeben
                Cursor.Current = Cursors.WaitCursor;
                Patientendatenbank.haupt = this;
                Patientendatenbank.ShowDialog();

                if (Patientendatenbank.vorname != null && Patientendatenbank.nachname != null && Patientendatenbank.letzteBehandlung != null)
                {
                    int step = Convert.ToInt32(Patientendatenbank.projektionslaenge.Replace("cm", "")) / Convert.ToInt32(Patientendatenbank.letzteSchrittanzahl);

                    lblName.Text = Patientendatenbank.vorname+" "+Patientendatenbank.nachname;
                    lblLezteTherapie.Text = Patientendatenbank.letzteBehandlung;
                    lblSteps.Text = step.ToString();
                    lblProjektionslaenge.Text = Patientendatenbank.projektionslaenge;


                    if (Patientendatenbank.letzteSchrittanzahl.All(char.IsDigit))
                        steps.Text = step.ToString();

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


        private void BtnSitzungBeenden_Click(object sender, EventArgs e)
        {

            soll_mittelwert = (soll_mittelwert) / (soll_anzahl);
            //übergabe der aktuellen schrittweite nach abschließen der Behandlungssitzung
            Patientendatenbank.wertuebergabe = steps.Value.ToString(); 

            //Patientendatenbank.wertuebergabe = 
            //    soll_mittelwert+ "," +
            //    analyse.kleinsterabstand.ToString()+","+
            //    analyse.größterabstand.ToString()+","+
            //    analyse.schrittdurchschnitt.ToString()+
            //    ";";

            x = 0;
            animation = 1;
            timer.Start();
            soll_anzahl = 0;
        }
        bool einaus = true;
        private void kinectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (einaus)
            {
                kinectM = new KinectMonitor();
                kinectM.form1_schritt = this;
                kinectM.steps_kinect = Convert.ToInt32(steps.Text);
                kinectToolStripMenuItem.BackColor = Color.Red;
                check_autoobjekt.Enabled = true;
                screen.fuß_zurücksetzen.Visible = true;
                //Task kinectmon = Task.Run(() => kinectM.ShowDialog());
                kinectM.WindowState = FormWindowState.Minimized;
                kinectM.Show();
                kinectM.Hide();
            }
            if (!einaus)
            {
                check_autoobjekt.Enabled = false;
                check_autoobjekt.Checked = false;
                screen.fuß_zurücksetzen.Visible = false;

                kinectM.Close();
                kinectToolStripMenuItem.BackColor = Color.Transparent;
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

            kinectM.lf_rf_vergleich = true;
            delsteps.Visible = false;
            kinectM.schrittzähler = 0;
            Array.Clear(kinectM.schritt_rechts, 0, kinectM.schritt_rechts.Length);//arays clearn um Fehler zu vermeiden in der Schritterkennung
            Array.Clear(kinectM.schritt_links, 0, kinectM.schritt_links.Length);
            Array.Clear(kinectM.zw_schritt_rechts, 0, kinectM.zw_schritt_rechts.Length);
            Array.Clear(kinectM.zw_schritt_links, 0, kinectM.zw_schritt_links.Length);
            analyseToolStripMenuItem.Visible = false;
            screen.fuß_zurücksetzen.Visible = false;
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
            schrittdurchschnitt = 0;
            for (int i = 1; i < kinectM.schrittzähler-1; i++)
            {
                schrittdurchschnitt += kinectM.durchschnitt[i] - kinectM.durchschnitt[i-1];

                if (Math.Abs(kinectM.durchschnitt[i] - kinectM.durchschnitt[i-1]) < kleinsterabstand)
                {
                    kleinsterabstand = Math.Abs(kinectM.durchschnitt[i] - kinectM.durchschnitt[i-1]);
                }

                if (Math.Abs(kinectM.durchschnitt[i] - kinectM.durchschnitt[i-1]) > größterabstand)
                {
                    größterabstand = Math.Abs(kinectM.durchschnitt[i] - kinectM.durchschnitt[i-1]);
                }
            }
          
            schrittdurchschnitt = schrittdurchschnitt / (kinectM.schrittzähler);

            Math.Round(schrittdurchschnitt);
            Math.Round(kleinsterabstand);
            Math.Round(schrittdurchschnitt);

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


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                label9.Location = new Point(446, label9.Location.Y);
                label9.Text = "sehr früh";
                kinectM.empfindlichkeit = 700;
            }

            if (trackBar1.Value == 2)
            {
                label9.Location = new Point(490, label9.Location.Y);
                label9.Text = "früh";
                kinectM.empfindlichkeit = 600;
            }

            if (trackBar1.Value == 3)
            {
                label9.Location = new Point(505, label9.Location.Y);
                label9.Text = "mittel";
                kinectM.empfindlichkeit = 500;
            }

            if (trackBar1.Value == 4)
            {
                label9.Location = new Point(525, label9.Location.Y);
                label9.Text = "spät";
                kinectM.empfindlichkeit = 400;
            }

            if (trackBar1.Value == 5)
            {
                label9.Location = new Point(540, label9.Location.Y);
                label9.Text = "sehr spät";
                kinectM.empfindlichkeit = 300;
            }
            screen.fläche.PerformClick();
        }

        private void chech_autoobjekt_CheckedChanged(object sender, EventArgs e)
        {
            if (check_autoobjekt.Checked == true)//wenn aktiviert
            {
                bestätigen.PerformClick();
                zufall.Visible = true;
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
                zufall.Checked = false;
                zufall.Visible = false;
                kinectM.autobox = false;
                fläche.Text = "bestätigen";
                trackBar1.Enabled = false;
                label7.ForeColor = Patientendatenbank.color_on_leave;
                label9.ForeColor = Patientendatenbank.color_on_leave;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Patientendatenbank.neustart = true;
        }

        private void steps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        int anzahl = 1;
        private void steps_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bestätigen.PerformClick();
            }
        }

        private void steps_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back && anzahl > 0)
                anzahl = anzahl - 2;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            if (anzahl >= 2)
            {
                e.Handled = true;
                anzahl = 1;
            }
            anzahl++;
        }        

        private void zufall_CheckedChanged(object sender, EventArgs e)
        {
            if (zufall.Checked == true)//wenn aktiviert
            {
                label2.Text = "Anzahl der Objekte";
                längebox.Maximum = 2;
                screen.längebox.Maximum = 3;
                screen.steps.Text = steps.Text;
                fläche.Enabled = false;
                regler.Enabled = false;
                kinectM.zufall_objekt = true;
                screen.zufallbox();
                kinectM.autobox = false;
            }
            if (zufall.Checked == false)// wenn deaktiviert
            {
                label2.Text = "Länge des Objektes:";
                längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
                screen.längebox.Maximum = längebox.Maximum;
                fläche.Enabled = true;
                regler.Enabled = true;
                kinectM.zufall_objekt = false;
                screen.linienladen();
                bestätigen.PerformClick();
                screen.objekte_generiert = false;
                kinectM.autobox = true;
            }
        }

        private void himmelHölleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            screen.himmel_hölle();
        }

        private void rotblauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            screen.rnd_dots();
        }
        bool erstesmal = true;
        private void startstopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void unendlichToolStripMenuItem_Click(object sender, EventArgs e)
        {
            screen.unendlich_();
        }
        public bool blockklick = false;
        private void blöckeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!blockklick)
            {
                if (einaus)
                {
                    kinectToolStripMenuItem.PerformClick();
                }
                kinectM.übsülon = true;
                kinectM.puh = 0;
                kinectM.imquadrat = false;
            }
            if (blockklick)
            {
                kinectM.übsülon = false;
                screen.block_one.Visible = false;
                screen.block_two.Visible = false;
                screen.block_three.Visible = false;
                screen.block_four.Visible = false;
                screen.block_five.Visible = false;
                screen.block_six.Visible = false;
            }
            blockklick = !blockklick;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (erstesmal)
            {
                try
                {
                    if (!screen.klick)
                    {
                        screen.himmelhölle.Visible = false;
                        screen.bestätigen.PerformClick();
                        screen.klick = !screen.klick;
                    }
                    screen.linienladen();
                    kinectM.startstop = true;
                    erstesmal = false;
                    if (einaus)
                    {
                        kinectToolStripMenuItem.PerformClick();
                    }
                }
                catch
                {
                    MessageBox.Show("Irgendwas ist schiefgelaufen! :(", "hmm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!erstesmal)
            {
                erstesmal = true;
                kinectM.startstop = false;
                screen.strich_rechts.Visible = false;
                screen.linienladen();
                if (!einaus)
                {
                    kinectToolStripMenuItem.PerformClick();
                }
            }
        }
        public bool userchanged = true;
        private void multiplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            screen.form1_main = this;
            if (erstesmal)
            {
                try
                {
                    if (einaus)
                    {
                        kinectToolStripMenuItem.PerformClick();
                    }
                    if (!screen.klick)
                    {
                        screen.himmelhölle.Visible = false;
                        screen.bestätigen.PerformClick();
                        screen.klick = !screen.klick;
                    }
                    screen.linienladen();
                    kinectM.startstop = true;
                    kinectM.startstop_multiplayer = true;
                    screen.time_left.Visible = true;
                    screen.time_left.Text = "Verbleibende Zeit: 20,0 sek.";
                    screen.time_left.Location = new Point(screen.Auflösung_Projektor_x / 2 - screen.time_left.Size.Width / 2, screen.waagrechtoben - screen.time_left.Height - 10);
                    erstesmal = false;
                    screen.user1.Visible = true;
                    screen.user2.Visible = true;
                    screen.user1.Location = new Point(screen.Auflösung_Projektor_x / 3 - screen.user2.Size.Width / 2, screen.waagrechtunten + 20);
                    screen.user2.Location = new Point(2 * (screen.Auflösung_Projektor_x / 3) - screen.user2.Size.Width/2, screen.waagrechtunten + 20);
                }
                catch
                {
                    MessageBox.Show("Irgendwas ist schiefgelaufen! :(", "hmm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (!erstesmal)
            {
                screen.player.Stop();
                erstesmal = true;
                kinectM.startstop = false;
                screen.time_left.Visible = false;
                kinectM.startstop_multiplayer = false;
                screen.Multiplayer_timer.Stop();
                screen.time_left.Visible = false;
                screen.linienladen();
                screen.user1.Visible = false;
                screen.user1.Text = "Spieler 1: ";
                screen.user2.Text = "Spieler 2: ";
                screen.user2.Visible = false;
                screen.strich_rechts.Visible = false;
                if (einaus)
                {
                    kinectToolStripMenuItem.PerformClick();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            screen.unendlich2.Visible = false;
            screen.var = false;
            screen.himmelhölle.Visible = false;
            screen.klick = false;
            screen.linienladen();
        }

        private void reset_MouseEnter(object sender, EventArgs e)
        {
            reset.BackColor = Color.Red;
        }

        private void reset_MouseLeave(object sender, EventArgs e)
        {
            reset.BackColor = Color.Transparent;
        }
    }
}