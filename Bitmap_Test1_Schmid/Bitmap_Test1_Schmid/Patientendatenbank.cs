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
        /*Alle Patientenspezifischen Tabellen nach dem Schema: Patientennummer_Vorname_Nachname
         * 
        */
         
        //Connectionstring für die Verbindung zum Mysql Server
        string SQLServer = "server = koordinationsleiter.ddns.net; user id = Klinikum; password = koordinationsleiter; database = Patienten; sslmode=None; port=3306; persistsecurityinfo=True";

        #region alle mySQL Abfragen
        //ausnahme: Abfragen bei denen die werte erst während der Laufzeit eingegeben werden
        string query1;
        string query2;
        string query3;
        string query4 = "select Max(Patientennummer) from Patienten.Patientenliste";
        string query5;
        #endregion
        string record;
        bool bearbeitung = false;
        public bool auswahl = false;
        //Variablen für die verschiedenen Patientendaten die später von der UI geholt werden

        public string Patientenname;
        string PatNr_aktuell;
        public string Nameaktuell;
        public string letzteBehandlung;
        public string letzteSchrittanzahl;
        public string BehandlungsnummerMax;

        //variablen die aus verschiedenen gründen global sind
        int[] tabs = new int[5];
        string patnr = "", vorname = "", nachname = "", geburtsdatum = "", adresse = "", plz = "", ort = "", telNr = "";
        int telnummerlength = 0;

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
            #region zurücksetzen der Formelemente
            Size = new Size(471, 383);
            auswahlBtn.Location = new Point(166, 349);
            TbName.Text = "Vorname";
            TbName.ForeColor = Color.Gray;
            TbName.ReadOnly = false;

            TbNachname.Text = "Nachname";
            TbNachname.ForeColor = Color.Gray;
            TbNachname.ReadOnly = false;

            TbPatNr.Text = "Patientennr.";
            TbPatNr.ForeColor = Color.Gray;
            TbPatNr.ReadOnly = false;

            TbGeburtsdatum.Text = "Geburtsdatum";
            TbGeburtsdatum.ForeColor = Color.Gray;

            TbAdresse.Text = "Adresse";
            TbAdresse.ForeColor = Color.Gray;

            TbPLZ.Text = "PLZ";
            TbPLZ.ForeColor = Color.Gray;

            TbOrt.Text = "Ort";
            TbOrt.ForeColor = Color.Gray;

            TbTelefonnummer.Text = "Telefonnummer";
            TbTelefonnummer.ForeColor = Color.Gray;

            #endregion

            NeuAbbrechenBtn.Visible = false;
            sucheBtn.Visible = true;
            Patienten.Visible = true;
            auswahlBtn.Visible = true;
            NeuSpeichernBtn.Visible = false;

            menuStrip1.ForeColor = Color.White;
            //überprüfen ob eine Verbindung zur datenbank hergestellt werden kann, wenn dies erfolgreich ist, den Balken in der UI
            //grün färben, falls keine Verbindung hergestellt werden konnte, wird der Balken rot gefärbt
            try
            {
                conn.Open();

                lblEditStatus.BackColor = Color.Lime;
            }
            catch
            {
                lblEditStatus.BackColor = Color.Red;

            }
            finally
            {
                conn.Close();
            }

        }

        private void sucheBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Patienten.Items.Clear();
            int ix = 0;
            query1 = "select Patientennummer, Vorname, Nachname, PLZ, Ort, Geburtsdatum from Patientenliste where ";
           
            # region durchsuchen der Db
            if (TbName.Text != "Vorname")   
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += "Vorname in ('" + TbName.Text + "')"; 
            }
            if (TbNachname.Text != "Nachname")
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += "(Nachname in ('" + TbNachname.Text + "'))";
            }
            if (TbPLZ.Text != "PLZ")
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += "(PLZ in('" + TbPLZ.Text + "'))";
            }
            if (TbOrt.Text != "Ort")
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += "(Ort in('" + TbOrt.Text + "'))";
            }
            if (TbAdresse.Text != "Adresse")
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += "(Adresse in ('" + TbAdresse.Text + "'))";
            }
            if (TbTelefonnummer.Text != "Telefonnummer")
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += " (Telefonnummer in ('" + TbTelefonnummer.Text + "'))";
            }
            if (TbGeburtsdatum.Text != "Geburtsdatum")
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += "(Geburtsdatum in('" + TbGeburtsdatum.Text + "'))";
            }
            if (TbPatNr.Text != "Patientennr.")
            {
                if (ix == 1)
                    query1 += "or ";
                ix = 1;
                query1 += "(Patientennummer in('" + TbPatNr.Text + "'))";
            }
            query1 += ";";
            #endregion  
            
                cmd = new MySqlCommand(query1, conn);
                conn.Open();
                da = new MySqlDataAdapter(cmd);
                tbl = new DataTable();
                da.Fill(tbl);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Bitte Daten eingeben!", "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (tbl.Columns[j].ColumnName == "Vorname")
                    {

                        record += row[j] + ";";
                        continue;
                    }
                    if (tbl.Columns[j].ColumnName == "Nachname")
                    {
                        record += row[j] + ";";
                        continue;
                    }
                    if (tbl.Columns[j].ColumnName == "Postleitzahl")
                    {
                        record += row[j] + ";";
                        continue;
                    }
                    if (tbl.Columns[j].ColumnName == "Ort")
                    {
                        record += row[j] + ";";
                        continue;
                    }
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
            //variablen leeren um bei merfachem drücken des Buttons nicht die selbe information mehrfach im label in der UI zu bekommen
            Patientenname = "";
            letzteBehandlung = "";
            letzteSchrittanzahl = "";

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
                exception(ex.ToString());
                return;
            }
            finally
            {

                conn.Close();
            }

            record = "";
            //Daten nur aus der letzten Zeile auslesen um so das aktuellste Behandlungsdatum zu erhalten
            if (tbl2.Rows.Count == 0)
            {

                Nameaktuell = vorname + " " + nachname;
                letzteBehandlung = "keine Sitzungen vorhanden";
                letzteSchrittanzahl = "keine Daten vorhanden";
                this.Close();
                auswahl = true;
                return;
            }
            else
            {
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
                auswahl = true;
            }
        }


        #region leeren der Textbox beim anklicken, Text schwarz färben wenn hinengeschrieben wird


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
        //-----------------------------------------------------------------------------------------------
        private void TbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }
        }

        private void TbNachname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }
        }

        private void TbPatNr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }
        }

        private void TbGeburtsdatum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }
        }

        private void TbAdresse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }
        }

        private void TbOrt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }
        }

        private void TbPLZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }
        }

        private void TbTelefonnummer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sucheBtn.PerformClick();
            }

        }
#endregion

        // Methode für die Übertragung der Daten aus der UI beim schließen der Sitzung 
        //value entspricht dabei der letzten Sollschrittweite
        public string wertuebergabe
        {
            set
            {
                Nameaktuell = Nameaktuell.Replace(" ", "_");
                query3 = "Insert Into " + Patientenname.Replace(" ", "_") + "_" + PatNr_aktuell + " (Vorname,Nachname,Behandlungsdatum,Schrittweite) Values ('" +vorname+ "','"+nachname + "','"
                    + DateTime.Now.ToString("dd.MM.yyyy") + "','" + value + "');";

                try
                {
                    cmd = new MySqlCommand(query3, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sitzung erfolgreich beendet", "Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(""+ex);
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void TbTelefonnummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            } //nur zahlen in der Textbox zulassen
            
            else
            {
                if (e.KeyChar != (char)Keys.Back)
                    telnummerlength++;

                if (e.KeyChar == (char)Keys.Back && telnummerlength>0)
                    telnummerlength--;

                if (telnummerlength >= 14)
                {
                    MessageBox.Show("Die Telefonnummer darf nicht länger als 14 Zeichen sein", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TbTelefonnummer.Text = TbTelefonnummer.Text.Remove(telnummerlength - 1);
                    telnummerlength = 14;
                    e.Handled = true;
                }
            }
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)//Neu im ToolstripMenu
        {
            Size = new Size(471, 270);
            string patientennummer = "";
            //Autoincrement erhöht den wert auch wenn die Position danach wieder gelöscht wird
            //-> Autoincrement daher möglicherweise höher als Max(Patientennummer)
            //egal weil so jeder Patient eine individuelle Nummer bekommt
            //falls patienten gelöscht werden wird die alte Patientennummer nicht mehr vergeben
#region SQL Verbindung um die höchste Patientennummer abzurufen
            //verwendung von query4
#region zurücksetzen der Oberflächenelemente zur Suchmaske

            TbName.Text = "Vorname";
            TbName.ForeColor = Color.Gray;

            TbNachname.Text = "Nachname";
            TbNachname.ForeColor = Color.Gray;

            TbPatNr.Text = "Patientennr.";
            TbPatNr.ForeColor = Color.Gray;
            TbPatNr.ReadOnly = false;

            TbGeburtsdatum.Text = "Geburtsdatum";
            TbGeburtsdatum.ForeColor = Color.Gray;

            TbAdresse.Text = "Adresse";
            TbAdresse.ForeColor = Color.Gray;

            TbPLZ.Text = "PLZ";
            TbPLZ.ForeColor = Color.Gray;

            TbOrt.Text = "Ort";
            TbOrt.ForeColor = Color.Gray;

            TbTelefonnummer.Text = "Telefonnummer";
            TbTelefonnummer.ForeColor = Color.Gray;

            lblEditStatus.BackColor = Color.Lime;

            NeuAbbrechenBtn.Visible = false;
            sucheBtn.Visible = true;
            Patienten.Visible = true;
            auswahlBtn.Visible = true;
            NeuSpeichernBtn.Visible = false;

            auswahlBtn.Location = new Point(166, 349);
            Patienten.Items.Clear();
#endregion;
            try
            {
                cmd = new MySqlCommand(query4, conn);
                conn.Open();
                da = new MySqlDataAdapter(cmd);
                tbl = new DataTable();
                da.Fill(tbl);

            }
            catch (MySqlException ex)
            {
                exception(ex.ToString());
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
            if (bearbeitung)
            {
                string query4 = " drop Table " + vorname + "_" + nachname + "_" + patnr + ";";
                query4 += "Delete From Patienten.Patientenliste where Patientennummer='" + patnr + "';";

                try
                {
                    conn.Open();

                    cmd = new MySqlCommand(query4, conn);

                    cmd.ExecuteNonQuery();

                }

                catch (MySqlException ex)
                {
                    exception(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }

            }

            else
                MessageBox.Show("Bitte zuerst einen Patienten auswählen", "Fehler");


        }

        private void Patienten_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatNr_aktuell = "";
            string s_ = Patienten.SelectedItem.ToString();
            for (int i = 0; i < 10; i++)
            {
                //die ersten 10 stellen des ausgewählten index auslesen und in die Variable schreiben solange sie eine Zahl ist
                if (Char.IsDigit(s_[i]))
                {
                    PatNr_aktuell += s_[i];
                }

            }

            //auslesen der Tabulatoren aus dem ausgewählten string um bei der auswahl den Patientennamen herauslesen zu können
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


            DataTable tbl3;
            query3 = "select Patientennummer, Vorname, Nachname, Geburtsdatum, Adresse, PLZ,Ort,Telefonnummer from Patienten.Patientenliste where Patientennummer = '" + PatNr_aktuell + "';"; //Vorname_Nachname_Patientennummer     Convert.ToInt32(PatNr_aktuell)
            try
            {
                cmd = new MySqlCommand(query3, conn);
                conn.Open();
                da = new MySqlDataAdapter(cmd);
                tbl3 = new DataTable();
                da.Fill(tbl3);
            }
            catch (MySqlException ex)
            {
                exception(ex.ToString());
                return;
            }
            finally
            {

                conn.Close();
            }
            //suchen und befüllen aller textboxen mit den gefundenen Informationen um sie, falls nötig, bearbeiten zu können
#region Befüllen der Variablen mit den Informationen aus der Datenbank

            for (int i = 0; i < tbl3.Rows.Count; i++)
            {
                record = "";
                DataRow row = tbl3.Rows[i];
                for (int j = 0; j < tbl3.Columns.Count; j++)
                {
                    if (tbl3.Columns[j].ColumnName == "Patientennummer")
                    {
                        record += row[j];
                        patnr = row[j].ToString();
                        continue;
                    }

                    if (tbl3.Columns[j].ColumnName == "Vorname")
                    {
                        record += row[j];
                        vorname = row[j].ToString();
                        continue;
                    }

                    if (tbl3.Columns[j].ColumnName == "Nachname")
                    {
                        record += row[j];
                        nachname = row[j].ToString();
                        continue;
                    }

                    if (tbl3.Columns[j].ColumnName == "Geburtsdatum")
                    {
                        record += row[j];
                        geburtsdatum = row[j].ToString();
                        continue;
                    }

                    if (tbl3.Columns[j].ColumnName == "Adresse")
                    {
                        record += row[j];
                        adresse = row[j].ToString();
                        continue;
                    }

                    if (tbl3.Columns[j].ColumnName == "PLZ")
                    {
                        record += row[j];
                        plz = row[j].ToString();
                        continue;
                    }

                    if (tbl3.Columns[j].ColumnName == "Ort")
                    {
                        record += row[j];
                        ort = row[j].ToString();
                        continue;
                    }

                    if (tbl3.Columns[j].ColumnName == "Telefonnummer")
                    {
                        record += row[j];
                        telNr = row[j].ToString();
                        continue;
                    }
                }
            }
            bearbeitung = true; //aktivieren des bearbeitungsmodus
            //Präsentieren der Informationen in der Textbox
            TbName.Text = vorname;
            TbNachname.Text = nachname;
            TbPatNr.Text = patnr;
            TbGeburtsdatum.Text = geburtsdatum.Replace("-", " ");
            TbAdresse.Text = adresse;
            TbPLZ.Text = plz;
            TbOrt.Text = ort;
            TbTelefonnummer.Text = telNr;
#endregion

            TbName.ForeColor = Color.Black;
            TbNachname.ForeColor = Color.Black;
            TbPatNr.ForeColor = Color.Black;
            TbGeburtsdatum.ForeColor = Color.Black;
            TbAdresse.ForeColor = Color.Black;
            TbPLZ.ForeColor = Color.Black;
            TbOrt.ForeColor = Color.Black;
            TbTelefonnummer.ForeColor = Color.Black;

            Patienten.Visible = false;
            sucheBtn.Visible = false;

            TbPatNr.ReadOnly = true;

            lblEditStatus.BackColor = Color.Orange; //anzeigen dass sich die Daten im Bearbeitungsmodus befinden

            NeuSpeichernBtn.Visible = true;
            NeuAbbrechenBtn.Visible = true;

            //Verkleinern des Datenbankfensters
            this.Size = new Size(471, 348);
            auswahlBtn.Location = new Point(167, 244);
        }


        void messagebox_leerfeld()
        {
            MessageBox.Show("Die Felder Vorname und Nachname dürfen nicht freigelassen werden.", "Achtung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void NeuAbbrechenBtn_Click(object sender, EventArgs e)
        {
#region zurücksetzen der Formelemente
            Size = new Size(471, 383);
            auswahlBtn.Location = new Point(166, 349);
            TbName.Text = "Vorname";
            TbName.ForeColor = Color.Gray;
            TbName.ReadOnly = false;

            TbNachname.Text = "Nachname";
            TbNachname.ForeColor = Color.Gray;
            TbNachname.ReadOnly = false;

            TbPatNr.Text = "Patientennr.";
            TbPatNr.ForeColor = Color.Gray;
            TbPatNr.ReadOnly = false;

            TbGeburtsdatum.Text = "Geburtsdatum";
            TbGeburtsdatum.ForeColor = Color.Gray;

            TbAdresse.Text = "Adresse";
            TbAdresse.ForeColor = Color.Gray;

            TbPLZ.Text = "PLZ";
            TbPLZ.ForeColor = Color.Gray;

            TbOrt.Text = "Ort";
            TbOrt.ForeColor = Color.Gray;

            TbTelefonnummer.Text = "Telefonnummer";
            TbTelefonnummer.ForeColor = Color.Gray;

#endregion

            NeuAbbrechenBtn.Visible = false;
            sucheBtn.Visible = true;
            Patienten.Visible = true;
            auswahlBtn.Visible = true;
            NeuSpeichernBtn.Visible = false;
            lblEditStatus.BackColor = Color.Lime;
        }

        private void NeuSpeichernBtn_Click(object sender, EventArgs e)
        {
            if (!bearbeitung)
            {
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
                query2 = "CREATE TABLE " + TbName.Text + "_" + TbNachname.Text + "_" + TbPatNr.Text + "(Behandlungsnummer int(11) not null auto_increment," +
                                                                                                        "Vorname varchar(50)not null," +
                                                                                                        "Nachname varchar(50)not null," +
                                                                                                        "Schrittweite int(50)not null," +
                                                                                                        "Behandlungsdatum varchar(10) not null," +
                                                                                                        "Primary Key(Behandlungsnummer)); " +
                    "INSERT INTO Patientenliste(Vorname,Nachname,Geburtsdatum,Adresse,PLZ,Ort,Telefonnummer) Values ('" + TbName.Text + "','" + TbNachname.Text + "','" +
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
                    exception(ex.ToString());

                }

                finally
                {

                    conn.Close();
                }
            }
            Size = new Size(471, 383);

            if (bearbeitung)
            {
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
                //aktualisieren aller datenbankdaten (Masterliste,Tabellenname,patientenname in spezifischer tabelle) if conditions zur überprüfung welche dinge verändert wurden
                if (TbName.Text == vorname && TbNachname.Text == nachname) //falls sich vor-und Nachname nicht verändert haben, nur die Masterliste Updaten
                {
                    if (TbTelefonnummer.Text == "Telefonnmmer" || TbTelefonnummer.Text == "")
                    {
                        TbTelefonnummer.Text = "";
                    }
                    query2 = "UPDATE Patienten.Patientenliste Set Geburtsdatum='" + TbGeburtsdatum.Text.Replace(" ", "-") + "'," +
                                                                "Adresse='" + TbAdresse.Text + "'," +
                                                                "PLZ='" + TbPLZ.Text + "'," +
                                                                "Ort='" + TbOrt.Text + "'," +
                                                                "Telefonnummer='" + TbTelefonnummer.Text + "' " +
                                                                "where Patientennummer='" + patnr + "';";
                }
                if (TbName.Text != vorname || TbNachname.Text != nachname)//falls einer der beiden namensteile geändert wurde, alle datensätze außer der Patientennummer updaten
                {
                    query2 = "UPDATE Patienten.Patientenliste SET Vorname='" + TbName.Text + "'," +
                                            "Nachname='" + TbNachname.Text + "'," +
                                            "Geburtsdatum='" + TbGeburtsdatum.Text.Replace(" ", "-") + "'," +
                                            "Adresse='" + TbAdresse.Text + "'," +
                                            "PLZ='" + TbPLZ.Text + "'," +
                                            "Ort='" + TbOrt.Text + "'," +
                                            "Telefonnummer='" + TbTelefonnummer.Text + "' " +
                                            "where Patientennummer='" + patnr + "';";
                    query2 += "UPDATE " + vorname + "_" + nachname + "_" + patnr + " SET Vorname ='" + TbName.Text + "'," +
                                                                                        "Nachname='" + TbNachname.Text + "' WHERE Vorname='" + vorname + "'AND Nachname='" + nachname + "';";
                    query2 += "ALTER TABLE " + vorname + "_" + nachname + "_" + patnr + " RENAME TO " + TbName.Text + "_" + TbNachname.Text + "_" + patnr + ";";

                }

                try
                {
                    conn.Open();

                    cmd = new MySqlCommand(query2, conn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient erfolgreich aktualisiert!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);

#region zurücksetzen der Oberflächenelemente zur Suchmaske

                    TbName.Text = "Vorname";
                    TbName.ForeColor = Color.Gray;

                    TbNachname.Text = "Nachname";
                    TbNachname.ForeColor = Color.Gray;

                    TbPatNr.Text = "Patientennr.";
                    TbPatNr.ForeColor = Color.Gray;
                    TbPatNr.ReadOnly = false;

                    TbGeburtsdatum.Text = "Geburtsdatum";
                    TbGeburtsdatum.ForeColor = Color.Gray;

                    TbAdresse.Text = "Adresse";
                    TbAdresse.ForeColor = Color.Gray;

                    TbPLZ.Text = "PLZ";
                    TbPLZ.ForeColor = Color.Gray;

                    TbOrt.Text = "Ort";
                    TbOrt.ForeColor = Color.Gray;

                    TbTelefonnummer.Text = "Telefonnummer";
                    TbTelefonnummer.ForeColor = Color.Gray;

                    lblEditStatus.BackColor = Color.Lime;

                    NeuAbbrechenBtn.Visible = false;
                    sucheBtn.Visible = true;
                    Patienten.Visible = true;
                    auswahlBtn.Visible = true;
                    NeuSpeichernBtn.Visible = false;

                    Size = new Size(471, 449);
                    auswahlBtn.Location = new Point(166, 349);
                    Patienten.Items.Clear();
#endregion;
                }
                catch (MySqlException ex)
                {
                    exception(ex.ToString());
                }

                finally
                {
                    conn.Close();
                }
            }
        }
        void exception(string Exception)
        {
            MessageBox.Show(Exception);
        }
    }

}
