using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class Patientendatenbank : Form
    {
        /* TODO: erstellen der Tabellen nach Schema: Patientennummer_Vorname_Nachname
        * TODO: überarbeiten aller SQL Queries um fehler auszuschließen die von vorherigen versionen übrig sind
        * TODO: Felder mit der eigenschaft not null schon im hauptprogramm abfragen
        */

        string SQLServer = "server = koordinationsleiter.ddns.net; user id = Klinikum;password=koordinationsleiter; database=Patienten; sslmode=None;port=3306; persistsecurityinfo=True";

        string query1;
        string query2;
        string query3;
        string record;

        //Variablen für die verschiedenen Patientendaten die später von der UI geholt werden
        public string Patientenname;
        string PatNr_aktuell;
        public string Nameaktuell;
        public string letzteBehandlung;
        public string letzteSchrittanzahl;
        public string BehandlungsnummerMax;

        //variablen die aus verschiedenen gründen global sind
        int[] tabs = new int[5];

        //Parameter für die Datenbank
        MySqlConnection conn = new MySqlConnection();

        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable tbl;  //datatable für Abfragenergebnisse aus der Patientensuche
        public Patientendatenbank() //constructuor
        {
            InitializeComponent();
            conn.ConnectionString = SQLServer;
        }

        private void Patientendatenbank_Load(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = Color.White;
            try
            {
                conn.Open();
                labelHinweis.Text = "Verbindung zur Datenbank hergestellt";

                lblEditStatus.BackColor = Color.Lime;
            }
            catch
            {
                labelHinweis.Text = "Verbindung zur Datenbank fehlgeschlagen";
                lblEditStatus.BackColor = Color.Red;

            }
            finally
            {
                conn.Close();
            }

        }

        private void sucheBtn_Click(object sender, EventArgs e)
        {

            query1 = "select Patientennummer, Vorname, Nachname, PLZ, Ort, Geburtsdatum from Patientenliste where " +
                "(Vorname in ('" + TbName.Text + "') and Nachname in ('" + TbNachname.Text + "')) " +
                "or (PLZ in('" + TbPLZ.Text + "')) or (Ort in('" + TbOrt.Text + "'));"; //TODO:  or (Patientennummer in('" + Convert.ToInt32(TbPatNr.Text) + "')) einbauen Fehler Abfrage Schlägt fehl weil leeres feld auch als text in int abgefragt wird -> Patientennr. ist hier kein string

            try
            {
                cmd = new MySqlCommand(query1, conn);
                conn.Open();
                da = new MySqlDataAdapter(cmd);
                tbl = new DataTable();
                da.Fill(tbl);
            }
            catch (MySqlException ex)
            {
                labelHinweis.Text = "Abfrage fehlgeschlagen " + ex;
                return;
            }
            finally
            {

                conn.Close();
            }

            #region Befüllen der Listbox "Patienten" mit den Informationen aus der Datenbank
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                record = "";
                DataRow row = tbl.Rows[i];
                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Patientennummer")
                    {

                        record += row[j] + ";";
                        continue;
                    }
                }

                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Vorname")
                    {

                        record += row[j] + ";";
                        continue;
                    }
                }
                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Nachname")
                    {
                        record += row[j] + ";";
                        continue;
                    }
                }

                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Postleitzahl")
                    {
                        record += row[j] + ";";
                        continue;
                    }
                }

                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Ort")
                    {
                        record += row[j] + ";";
                        continue;
                    }
                }
                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Geburtsdatum")
                    {
                        record += row[j] + ";";

                        continue;
                    }
                }

                //Alle übereinstimmenden Patienten in der ListBox anzeigen um dem Betreuer die Auswahl zu ermöglichen
                //Uhzeit die ans Geburtsdatum bei der Abfrage angehängt wird entfernen
                record = record.Replace(" 00:00:00", "");
                Patienten.Items.Add(record.Replace(";", "\t"));


            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e) //auswahlBtn
        {
            //TODO: wenn kein Patient ausgewählt = Fehler
            string s = Patienten.SelectedItem.ToString();
            for (int i = tabs[0]; i < tabs[2]; i++)
            {
                if (i == tabs[1])
                {
                    Patientenname += " ";
                }
                Patientenname += s[i];
            }

            DataTable tbl2;
            labelHinweis.Text = PatNr_aktuell + " " + Patientenname;
            Patientenname = Patientenname.Replace("\t", "");
            query3 = "select Behandlungsnummer, Vorname, Nachname, Behandlungsdatum, Schrittweite from " + Patientenname.Replace(" ", "_") + "_" + PatNr_aktuell + ";"; //Vorname_Nachname_Patientennummer     Convert.ToInt32(PatNr_aktuell)
            try
            {
                cmd = new MySqlCommand(query3, conn);
                conn.Open();
                da = new MySqlDataAdapter(cmd);
                tbl2 = new DataTable();
                da.Fill(tbl2);
            }
            catch (MySqlException ex)
            {
                labelHinweis.Text = "Abfrage fehlgeschlagen " + ex;
                return;
            }
            finally
            {

                conn.Close();
            }

            record = "";
            //Daten nur aus der Letzten Zeile auslesen um so das aktuellste Behandlungsdatum zu bekommen
            DataRow row = tbl2.Rows[tbl2.Rows.Count - 1];
            #region Befüllen der Variablen mit den Patientendaten
            for (int j = 0; j < tbl2.Columns.Count; j++)
            {
                if (tbl2.Columns[j].ColumnName == "Vorname")
                {

                    Nameaktuell += row[j] + " ";
                    continue;
                }
            }
            for (int j = 0; j < tbl2.Columns.Count; j++)
            {
                if (tbl2.Columns[j].ColumnName == "Nachname")
                {

                    Nameaktuell += row[j];
                    continue;
                }
            }

            for (int k = 0; k < tbl2.Columns.Count; k++)
            {
                if (tbl2.Columns[k].ColumnName == "Behandlungsdatum")
                {
                    letzteBehandlung += row[k];
                    letzteBehandlung = letzteBehandlung.Replace(" 00:00:00", "");
                    continue;
                }
            }

            for (int l = 0; l < tbl2.Columns.Count; l++)
            {
                if (tbl2.Columns[l].ColumnName == "Schrittweite")
                {
                    letzteSchrittanzahl += row[l];
                    continue;
                }
            }

            for (int l = 0; l < tbl2.Columns.Count; l++)
            {
                if (tbl2.Columns[l].ColumnName == "Behandlungsnummer")
                {
                    BehandlungsnummerMax += row[l];
                    continue;
                }
            }

            #endregion
            this.Close();
        }


        #region leeren der Textbox beim anklicken, Text schwarz färben wenn hinengeschrieben wird

        //TODO: Konzept DatenbankEdit: wenn man die Daten editieren will wird auch ein Click Event aufgerufen

        private void TbName_Enter(object sender, EventArgs e)
        {
            if (TbName.Text == "Vorname")
            {
                TbName.Text = "";
                TbName.ForeColor = Color.Black;
            }
        }
        private void TbAdresse_Enter(object sender, EventArgs e)
        {
            if (TbAdresse.Text == "Adresse")
            {
                TbAdresse.Text = "";
                TbAdresse.ForeColor = Color.Black;
            }
        }
        private void TbGeburtsdatum_Enter(object sender, EventArgs e)
        {
            if (TbGeburtsdatum.Text == "Geburtsdatum")
            {
                TbGeburtsdatum.Text = "";
                TbGeburtsdatum.ForeColor = Color.Black;
            }
        }
        private void TbOrt_Enter(object sender, EventArgs e)
        {
            if (TbOrt.Text == "Ort")
            {
                TbOrt.Text = "";
                TbOrt.ForeColor = Color.Black;
            }
        }
        private void TbPLZ_Enter(object sender, EventArgs e)
        {
            if (TbPLZ.Text == "PLZ")
            {
                TbPLZ.Text = "";
                TbPLZ.ForeColor = Color.Black;
            }
        }
        private void TbTelefonnummer_Enter(object sender, EventArgs e)
        {
            if (TbTelefonnummer.Text == "Telefonnummer")
            {
                TbTelefonnummer.Text = "";
                TbTelefonnummer.ForeColor = Color.Black;
            }
        }
        private void TbNachname_Enter(object sender, EventArgs e)
        {
            if (TbNachname.Text == "Nachname")
            {
                TbNachname.Text = "";
                TbNachname.ForeColor = Color.Black;
            }
        }

        private void TbPatNr_Enter(object sender, EventArgs e)
        {
            if (TbPatNr.Text == "Patientennr.")
            {
                TbPatNr.Text = "";
                TbPatNr.ForeColor = Color.Black;
            }
        }
        //-----------------------------------------------------------------------------------
        private void TbName_Leave(object sender, EventArgs e)
        {
            if (TbName.Text == "")
            {
                TbName.ForeColor = Color.Gray;
                TbName.Text = "Vorname";
            }
        }
        private void TbNachname_Leave(object sender, EventArgs e)
        {
            if (TbNachname.Text == "")
            {
                TbNachname.ForeColor = Color.Gray;
                TbNachname.Text = "Nachname";
            }
        }
        private void TbAdresse_Leave(object sender, EventArgs e)
        {
            if (TbAdresse.Text == "")
            {
                TbAdresse.ForeColor = Color.Gray;
                TbAdresse.Text = "Adresse";
            }
        }
        private void TbTelefonnummer_Leave(object sender, EventArgs e)
        {
            if (TbTelefonnummer.Text == "")
            {
                TbTelefonnummer.ForeColor = Color.Gray;
                TbTelefonnummer.Text = "Telefonnummer";
            }
        }
        private void TbOrt_Leave(object sender, EventArgs e)
        {
            if (TbOrt.Text == "")
            {
                TbOrt.ForeColor = Color.Gray;
                TbOrt.Text = "Ort";
            }
        }
        private void TbGeburtsdatum_Leave(object sender, EventArgs e)
        {
            if (TbGeburtsdatum.Text == "")
            {
                TbGeburtsdatum.ForeColor = Color.Gray;
                TbGeburtsdatum.Text = "Geburtsdatum";
            }
        }
        private void TbPLZ_Leave(object sender, EventArgs e)
        {
            if (TbPLZ.Text == "")
            {
                TbPLZ.ForeColor = Color.Gray;
                TbPLZ.Text = "PLZ";
            }
        }
        private void TbPatNr_Leave(object sender, EventArgs e)
        {
            if (TbPatNr.Text == "")
            {
                TbPatNr.ForeColor = Color.Gray;
                TbPatNr.Text = "Patientennr.";
            }
        }
        #endregion

        // Methode für die Übertragung der Daten aus der UI beim schließen der Sitzung
        public string wertuebergabe
        {
            set
            {

                Nameaktuell = Nameaktuell.Replace(" ", "_");
                query3 = "Insert Into " + Patientenname.Replace(" ", "_") + "_" + PatNr_aktuell + "(Vorname,Nachname,Behandlungsdatum,Schrittweite,Geburtsdatum) Values" + Nameaktuell + ","
                    + DateTime.Now.ToString("yyyy-mm-dd") + "," + value + ";";
                try
                {
                    cmd = new MySqlCommand(query3, conn);
                    conn.Open();

                }
                catch
                {
                    labelHinweis.Text = "Abfrage fehlgeschlagen";
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }
            //TODO: Werte für Name,Schrittweite und letzte Behandlung in die UI übergeben um sie dort anzeigen zu lassen
            //TODO: überarbeiten dieser Abfrage
        }




        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string patientennummer = "";
            //BUG: Autoincrement erhöht den wert auch wenn die Position danach wieder gelöscht wird
            //-> Autoincrement daher möglicherweise höher als Max(Patientennummer)
            #region SQL Verbindung um die höchste Patientennummer abzurufen
            try
            {
                cmd = new MySqlCommand("select Max(Patientennummer) from Patientenliste", conn);
                conn.Open();
                da = new MySqlDataAdapter(cmd);
                tbl = new DataTable();
                da.Fill(tbl);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Fehler" + ex);
            }

            finally
            {
                conn.Close();
            }
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    patientennummer += row[j];
                }
            }

            int patientennummer_ = Convert.ToInt32(patientennummer);
            patientennummer_++;


            #endregion
            TbPatNr.Text = patientennummer_.ToString();
            TbPatNr.ForeColor = Color.Black;
            TbPatNr.ReadOnly = true;
            lblEditStatus.BackColor = Color.Orange;
            NeuAbbrechenBtn.Visible = true;
            NeuSpeichernBtn.Visible = true;

            sucheBtn.Visible = false;
            Patienten.Visible = false;
            auswahlBtn.Visible = false;

        }

        private void eintragungLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = Patienten.SelectedItem.ToString();
            for (int i = tabs[0]; i < tabs[2]; i++)
            {
                if (i == tabs[1])
                {
                    Patientenname += "_";
                }

                Patientenname += s[i];

            }
            string query4 = " drop Table " + Patientenname;

            //TODO: löschen von angelegten Patienten
            labelHinweis.Text = Patienten.SelectedItem.ToString();
        }

        private void Patienten_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatNr_aktuell = "";
            string s_ = Patienten.SelectedItem.ToString();
            for (int i = 0; i < 10; i++)
            {

                if (Char.IsDigit(s_[i]))
                {
                    PatNr_aktuell += s_[i];
                }
            }

            //auslesen der Tabulatoren aus dem ausgewählten String
            int x = 0;
            for (int i = 0; i < s_.Length; i++)
            {

                if (s_[i].ToString() == "\t")
                {
                    // schreiben der index der tabs in ein array um sie später wieder abrufen zu können
                    //einführen einer 2.Variable "x" um so das Array so klein wie möglich zu halten
                    tabs[x] = i;
                    x++;
                }
            }
        }

        private void Patientendatenbank_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        void messagebox_leerfeld()
        {
            MessageBox.Show("Die Felder Vorname und Nachname dürfen nicht freigelassen werden.", "Achtung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void NeuAbbrechenBtn_Click(object sender, EventArgs e)
        {

            TbPatNr.Text = "Patientennr.";
            TbPatNr.ForeColor = Color.Gray;
            TbPatNr.ReadOnly = false;


            NeuAbbrechenBtn.Visible = false;
            sucheBtn.Visible = true;
            Patienten.Visible = true;
            auswahlBtn.Visible = true;
            NeuSpeichernBtn.Visible = false;
            lblEditStatus.BackColor = Color.Lime;
        }

        private void NeuSpeichernBtn_Click(object sender, EventArgs e)
        {
            string geburtsdat;
            //überprüfen ob die Felder Vorname und Nachname ausgefüllt wurden
            //ansonsten die Messagebox anzeigen
            if (TbName.Text == "Vorname" || TbName.Text == "")
            {
                messagebox_leerfeld();
                return;
            }
            if (TbNachname.Text == "Vorname" || TbNachname.Text == "")
            {
                messagebox_leerfeld();
                return;
            }
            if (TbGeburtsdatum.Text == "Geburtsdatum")
            {
                TbGeburtsdatum.Text = "";
            }

            string[] PatName_ = new string[2];
            Patientenname = TbName.Text.ToString();
            PatName_ = Patientenname.Split('_');
            //erstellen der Datenbank für den jeweiligen Patienten(Schema Vorname_Nachname_Patientennummer), Füllen der tablle Patientenliste mit Informationen für die Suche
            query2 = "create Table " + TbName.Text + "_" + TbNachname.Text + "_" + TbPatNr.Text + "(Behandlungsnummer int(11) not null auto_increment," +
                                                                                                    "Vorname varchar(50)not null," +
                                                                                                    "Nachname varchar(50)not null," +
                                                                                                    "Schrittweite int(50)not null," +
                                                                                                    "Behandlungsdatum varchar(10) not null," +
                                                                                                    "Primary Key(Behandlungsnummer)); " +
                "insert into Patientenliste(Vorname,Nachname,Geburtsdatum,Adresse,PLZ,Ort,Telefonnummer) Values ('" + TbName.Text + "','" + TbNachname.Text + "','" +
                 TbGeburtsdatum.Text + "','" + TbAdresse.Text + "','" + TbOrt.Text + "','" + TbPLZ.Text + "','" + TbTelefonnummer.Text + "') ;";


            try
            {
                conn.Open();

                cmd = new MySqlCommand(query2, conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient erfolgreich hinzugefügt!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TbPatNr.Text = "Patientennr.";
                TbPatNr.ForeColor = Color.Gray;
                TbPatNr.ReadOnly = false;
                lblEditStatus.BackColor = Color.Lime;

                NeuAbbrechenBtn.Visible = false;
                sucheBtn.Visible = true;
                Patienten.Visible = true;
                auswahlBtn.Visible = true;
                NeuSpeichernBtn.Visible = false;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Fehler" + ex);

            }

            finally
            {

                conn.Close();
            }

        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
