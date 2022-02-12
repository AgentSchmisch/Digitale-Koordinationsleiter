﻿using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class Patientendatenbank : Form
    {
        /*Alle Patientenspezifischen Tabellen nach dem Schema: Patientennummer_Vorname_Nachname
         * TODO: Patienten neu anlegen: VornameTB wird nicht gecleart beim klicken
         * 
        */

        //Connectionstring für die Verbindung zum Mysql Server
        string SQLServer = "";
        //"server = koordinationsleiter.ddns.net; user id = Klinikum; password = koordinationsleiter; database = Patienten; sslmode=None; port=3306; persistsecurityinfo=True";

        #region alle mySQL Abfragen
        //ausnahme: Abfragen bei denen die werte erst während der Laufzeit eingegeben werden
        string query1;
        string query2;
        string query3;
        string query4 = "select IDENT_CURRENT('Patientenliste');";
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
        public string Datenbankbuchstabe;
        public bool neustart;
        //variablen die aus verschiedenen gründen global sind
        int[] tabs = new int[5];
        string patnr = "", vorname = "", nachname = "", geburtsdatum = "", adresse = "", plz = "", ort = "", telNr = "";
        int telnummerlength = 0;

        public Color color_on_leafe = Color.FromArgb(180, 190, 200);

        //Parameter für die Datenbank
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable tbl;  //datatable für Abfragenergebnisse aus der Patientensuche

        private Form1 _haupt;
        public Form1 haupt
        {
            set { this._haupt = value; }
        }

        public Patientendatenbank() //constructuor
        {
            InitializeComponent();
        }

        private void Patientendatenbank_Load(object sender, EventArgs e)
        {
            if (neustart)
            {
                _haupt.usb.ShowDialog();
                neustart = false;
            }
            Patienten.Enabled = false;
            Patienten.Items.Clear();
            Patienten.Items.Add("\t         Keine Einträge gefunden");

            laufwerkToolStripMenuItem.Text = "Aktuelles Laufwerk: " + Properties.Settings.Default.Laufwerk;
            Datenbankbuchstabe = Properties.Settings.Default.Laufwerk;
            Datenbankbuchstabe.Replace("\\", "");
            SQLServer = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Datenbankbuchstabe + @"Datenbank\Patienten.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(SQLServer);

            #region zurücksetzen der Formelemente
            Size = new Size(471, 383);
            auswahlBtn.Location = new Point(166, 349);
            TbName.Text = "Vorname";
            TbName.ForeColor = color_on_leafe;
            TbName.ReadOnly = false;

            TbNachname.Text = "Nachname";
            TbNachname.ForeColor = color_on_leafe;
            TbNachname.ReadOnly = false;

            TbPatNr.Text = "Patientennr.";
            TbPatNr.ForeColor = color_on_leafe;
            TbPatNr.ReadOnly = false;

            TbGeburtsdatum.Text = "Geburtsdatum";
            TbGeburtsdatum.ForeColor = color_on_leafe;

            TbAdresse.Text = "Adresse";
            TbAdresse.ForeColor = color_on_leafe;

            TbPLZ.Text = "PLZ";
            TbPLZ.ForeColor = color_on_leafe;

            TbOrt.Text = "Ort";
            TbOrt.ForeColor = color_on_leafe;

            TbTelefonnummer.Text = "Telefonnummer";
            TbTelefonnummer.ForeColor = color_on_leafe;

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

                #region durchsuchen der Db
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

                if (TbName.Text == "listall")
                {
                    query1 = "select Patientennummer, Vorname, Nachname, PLZ, Ort, Geburtsdatum from Patientenliste where Vorname != '' ;";
                }

                if (query1 != "select Patientennummer, Vorname, Nachname, PLZ, Ort, Geburtsdatum from Patientenliste where ;")
                {
                    Patienten.Enabled = true;

                    cmd = new SqlCommand(query1, conn);
                    conn.Open();
                    da = new SqlDataAdapter(cmd);
                    tbl = new DataTable();
                    da.Fill(tbl);

                    #region Befüllen der Listbox "Patienten" mit den Informationen aus der Datenbank
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        record = "";
                        DataRow row = tbl.Rows[i];
                        for (int j = 0; j < tbl.Columns.Count; j++)
                        {
                            if (tbl.Columns[j].ColumnName == "Patientennummer")
                            {
                                record += row[j] + ",  ";
                                PatNr_aktuell = row[j].ToString();
                                continue;
                            }
                            if (tbl.Columns[j].ColumnName == "Vorname")
                            {
                                record += row[j] + " ";
                                Patientenname = row[j] + " ";
                                continue;
                            }
                            if (tbl.Columns[j].ColumnName == "Nachname")
                            {
                                record += row[j] + ";";
                                Patientenname += row[j];
                                continue;
                            }
                            if (tbl.Columns[j].ColumnName == "PLZ")
                            {
                                record += row[j] + " ";
                                continue;
                            }
                            if (tbl.Columns[j].ColumnName == "Ort")
                            {
                                record += row[j] + ";";
                                continue;
                            }
                            if (tbl.Columns[j].ColumnName == "Geburtsdatum")
                            {
                                record += row[j] + "";
                                continue;
                            }
                        }

                        //Alle übereinstimmenden Patienten in der ListBox anzeigen um dem Betreuer die Auswahl zu ermöglichen
                        //Uhzeit die ans Geburtsdatum bei der Abfrage angehängt wird entfernen
                        record = record.Replace(" 00:00:00", "");
                        Patienten.Items.Add(record.Replace(";", "\t"));


                    }
                    #endregion

                    if (tbl.Rows.Count == 0)
                    {
                        Patienten.Items.Clear();
                        Patienten.Items.Add("\t         Keine Einträge gefunden");
                        Patienten.Enabled = false;
                    }
                }
                else
                {
                    Patienten.Items.Add("\t         Keine Einträge gefunden");
                    Patienten.Enabled = false;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("keine Datenbank gefunden\nError: " + ex.Number, "Datenbank Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //exception(ex.Number);
                return;
            }
            finally
            {
                conn.Close();
                telnummerlength = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e) //auswahlBtn
        {
            //variablen leeren um bei merfachem drücken des Buttons nicht die selbe information mehrfach im label in der UI zu bekommen
            //Patientenname = ""; //----------------------------------
            letzteBehandlung = "";
            letzteSchrittanzahl = "";

            string s = Patienten.SelectedItem.ToString();

            DataTable tbl2;
            //Patientenname = Patientenname.Replace("\t", "");------------------------------
            query3 = "select Behandlungsnummer, Vorname, Nachname, Behandlungsdatum, Schrittweite from " + Patientenname.Replace(" ", "_") + "_" + PatNr_aktuell + ";"; //Vorname_Nachname_Patientennummer     Convert.ToInt32(PatNr_aktuell)
            try
            {
                cmd = new SqlCommand(query3, conn);
                conn.Open();
                da = new SqlDataAdapter(cmd);
                tbl2 = new DataTable();
                da.Fill(tbl2);

            }
            catch (SqlException ex)
            {
                exception(ex.Number);
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
                    if (tbl2.Columns[j].ColumnName == "Nachname")
                    {
                        Nameaktuell += row[j];
                        continue;
                    }
                    if (tbl2.Columns[j].ColumnName == "Behandlungsdatum")
                    {
                        letzteBehandlung += row[j];
                        letzteBehandlung = letzteBehandlung.Replace(" 00:00:00", "");
                        continue;
                    }
                    if (tbl2.Columns[j].ColumnName == "Behandlungsnummer")
                    {
                        BehandlungsnummerMax += row[j];
                        continue;
                    }
                    if (tbl2.Columns[j].ColumnName == "Schrittweite")
                    {
                        letzteSchrittanzahl += row[j];
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
                TbName.ForeColor = Color.White;
            }
        }

        private void TbAdresse_Enter(object sender, EventArgs e)
        {
            if (TbAdresse.Text == "Adresse")
            {
                TbAdresse.Text = "";
                TbAdresse.ForeColor = Color.White;
            }
        }

        private void TbGeburtsdatum_Enter(object sender, EventArgs e)
        {
            if (TbGeburtsdatum.Text == "Geburtsdatum")
            {
                TbGeburtsdatum.Text = "";
                TbGeburtsdatum.ForeColor = Color.White;
            }
        }

        private void TbOrt_Enter(object sender, EventArgs e)
        {
            if (TbOrt.Text == "Ort")
            {
                TbOrt.Text = "";
                TbOrt.ForeColor = Color.White;
            }
        }

        private void TbPLZ_Enter(object sender, EventArgs e)
        {
            if (TbPLZ.Text == "PLZ")
            {
                TbPLZ.Text = "";
                TbPLZ.ForeColor = Color.White;
            }
        }

        private void TbTelefonnummer_Enter(object sender, EventArgs e)
        {
            if (TbTelefonnummer.Text == "Telefonnummer")
            {
                TbTelefonnummer.Text = "";
                TbTelefonnummer.ForeColor = Color.White;
            }
        }

        private void TbNachname_Enter(object sender, EventArgs e)
        {
            if (TbNachname.Text == "Nachname")
            {
                TbNachname.Text = "";
                TbNachname.ForeColor = Color.White;
            }
        }

        private void TbPatNr_Enter(object sender, EventArgs e)
        {
            if (TbPatNr.Text == "Patientennr.")
            {
                TbPatNr.Text = "";
                TbPatNr.ForeColor = Color.White;
            }
        }
        //-----------------------------------------------------------------------------------
        private void TbName_Leave(object sender, EventArgs e)
        {
            if (TbName.Text == "")
            {
                TbName.ForeColor = color_on_leafe;
                TbName.Text = "Vorname";
            }
        }
        private void TbNachname_Leave(object sender, EventArgs e)
        {
            if (TbNachname.Text == "")
            {
                TbNachname.ForeColor = color_on_leafe;
                TbNachname.Text = "Nachname";
            }
        }
        private void TbAdresse_Leave(object sender, EventArgs e)
        {
            if (TbAdresse.Text == "")
            {
                TbAdresse.ForeColor = color_on_leafe;
                TbAdresse.Text = "Adresse";
            }
        }
        private void TbTelefonnummer_Leave(object sender, EventArgs e)
        {
            if (TbTelefonnummer.Text == "")
            {
                TbTelefonnummer.ForeColor = color_on_leafe;
                TbTelefonnummer.Text = "Telefonnummer";
            }
        }
        private void TbOrt_Leave(object sender, EventArgs e)
        {
            if (TbOrt.Text == "")
            {
                TbOrt.ForeColor = color_on_leafe;
                TbOrt.Text = "Ort";
            }
        }
        private void TbGeburtsdatum_Leave(object sender, EventArgs e)
        {
            if (TbGeburtsdatum.Text == "")
            {
                TbGeburtsdatum.ForeColor = color_on_leafe;
                TbGeburtsdatum.Text = "Geburtsdatum";
            }
        }
        private void TbPLZ_Leave(object sender, EventArgs e)
        {
            if (TbPLZ.Text == "")
            {
                TbPLZ.ForeColor = color_on_leafe;
                TbPLZ.Text = "PLZ";
            }
        }
        private void TbPatNr_Leave(object sender, EventArgs e)
        {
            if (TbPatNr.Text == "")
            {
                TbPatNr.ForeColor = color_on_leafe;
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
                query3 = "Insert Into " + Patientenname.Replace(" ", "_") + "_" + PatNr_aktuell + " (Vorname,Nachname,Behandlungsdatum,Schrittweite) Values ('" + vorname + "','" + nachname + "','"
                    + DateTime.Now.ToString("dd.MM.yyyy") + "','" + value + "');";

                try
                {
                    cmd = new SqlCommand(query3, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Sitzung erfolgreich beendet", "Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (SqlException ex)
                {
                    exception(ex.Number);
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

                if (e.KeyChar == (char)Keys.Back && telnummerlength > 0)
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

        private void laufwerkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _haupt.usb.ShowDialog();
            laufwerkToolStripMenuItem.Text = "Aktuelles Laufwerk: " + Properties.Settings.Default.Laufwerk;
            //todo: hier muss noch der string geändert werden
        }

        private void customInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }

        private void TbPatNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Patienten_DoubleClick(object sender, EventArgs e)
        {
            string s_ = Patienten.SelectedItem.ToString();

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
            query3 = "SELECT Patientennummer, Vorname, Nachname, Geburtsdatum, Adresse, PLZ,Ort,Telefonnummer FROM Patientenliste WHERE Patientennummer = '" + PatNr_aktuell + "';";
            try
            {
                cmd = new SqlCommand(query3, conn);
                conn.Open();
                da = new SqlDataAdapter(cmd);
                tbl3 = new DataTable();
                da.Fill(tbl3);
            }
            catch (SqlException ex)
            {
                exception(ex.Number);
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

            TbName.ForeColor = Color.White;
            TbNachname.ForeColor = Color.White;
            TbPatNr.ForeColor = Color.White;
            TbGeburtsdatum.ForeColor = Color.White;
            TbAdresse.ForeColor = Color.White;
            TbPLZ.ForeColor = Color.White;
            TbOrt.ForeColor = Color.White;
            TbTelefonnummer.ForeColor = Color.White;

            if (TbNachname.Text == "")
            {
                TbNachname.Focus();
            }
            if (TbGeburtsdatum.Text == "")
            {
                TbGeburtsdatum.Focus();
            }
            if (TbPLZ.Text == "")
            {
                TbPLZ.Focus();
            }
            if (TbOrt.Text == "")
            {
                TbOrt.Focus();
            }
            if (TbAdresse.Text == "")
            {
                TbAdresse.Focus();
            }
            if (TbTelefonnummer.Text == "")
            {
                TbTelefonnummer.Focus();
            }
            TbName.Focus();

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

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)//Neu im ToolstripMenu
        {
            Size = new Size(471, 270);
            string patientennummer = "";
            //TODO: wenn letzter patient wieder gelöscht wird, wird autoincrement nicht mehr kleiner also bekommt der maxvalue einen anderen wert als der autoincrement wert

            //Autoincrement erhöht den wert auch wenn die Position danach wieder gelöscht wird
            //-> Autoincrement daher möglicherweise höher als Max(Patientennummer)
            //egal weil so jeder Patient eine individuelle Nummer bekommt
            //falls patienten gelöscht werden wird die alte Patientennummer nicht mehr vergeben

            #region SQL Verbindung um die höchste Patientennummer abzurufen
            //verwendung von query4
            #region zurücksetzen der Oberflächenelemente zur Suchmaske

            //TbName.Text = "Vorname";
            //TbName.ForeColor = color_on_leafe;

            //TbNachname.Text = "Nachname";
            //TbNachname.ForeColor = color_on_leafe;

            //TbPatNr.Text = "Patientennr.";
            //TbPatNr.ForeColor = color_on_leafe;
            //TbPatNr.ReadOnly = false;

            //TbGeburtsdatum.Text = "Geburtsdatum";
            //TbGeburtsdatum.ForeColor = color_on_leafe;

            //TbAdresse.Text = "Adresse";
            //TbAdresse.ForeColor = color_on_leafe;

            //TbPLZ.Text = "PLZ";
            //TbPLZ.ForeColor = color_on_leafe;

            //TbOrt.Text = "Ort";
            //TbOrt.ForeColor = color_on_leafe;

            //TbTelefonnummer.Text = "Telefonnummer";
            //TbTelefonnummer.ForeColor = color_on_leafe;

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
                cmd = new SqlCommand(query4, conn);
                conn.Open();
                da = new SqlDataAdapter(cmd);
                tbl = new DataTable();
                da.Fill(tbl);

            }
            catch (SqlException ex)
            {
                exception(ex.Number);
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
            TbPatNr.ForeColor = Color.White;
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
                string query4 = " DROP TABLE " + vorname + "_" + nachname + "_" + patnr + ";";
                query4 += "DELETE FROM Patientenliste WHERE Patientennummer = '" + patnr + "';";

                try
                {
                    conn.Open();
                    cmd = new SqlCommand(query4, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Eintragung erfolgreich entfernt!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TbPatNr.ForeColor = color_on_leafe;
                    TbPatNr.ReadOnly = false;
                    lblEditStatus.BackColor = Color.Lime;

                    NeuAbbrechenBtn.Visible = false;
                    sucheBtn.Visible = true;
                    Patienten.Visible = true;
                    auswahlBtn.Visible = true;
                    NeuSpeichernBtn.Visible = false;
                    auswahlBtn.Visible = false;
                    Size = new Size(471, 383);

                    cleartext();
                }

                catch (SqlException ex)
                {
                    exception(ex.Number);
                }
                finally
                {
                    conn.Close();
                    sucheBtn.PerformClick();
                }

            }

            else
                MessageBox.Show("Bitte zuerst einen Patienten auswählen", "Fehler");


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
            TbName.ForeColor = color_on_leafe;
            TbName.ReadOnly = false;

            TbNachname.Text = "Nachname";
            TbNachname.ForeColor = color_on_leafe;
            TbNachname.ReadOnly = false;

            TbPatNr.Text = "Patientennr.";
            TbPatNr.ForeColor = color_on_leafe;
            TbPatNr.ReadOnly = false;

            TbGeburtsdatum.Text = "Geburtsdatum";
            TbGeburtsdatum.ForeColor = color_on_leafe;

            TbAdresse.Text = "Adresse";
            TbAdresse.ForeColor = color_on_leafe;

            TbPLZ.Text = "PLZ";
            TbPLZ.ForeColor = color_on_leafe;

            TbOrt.Text = "Ort";
            TbOrt.ForeColor = color_on_leafe;

            TbTelefonnummer.Text = "Telefonnummer";
            TbTelefonnummer.ForeColor = color_on_leafe;

            #endregion

            NeuAbbrechenBtn.Visible = false;
            sucheBtn.Visible = true;
            Patienten.Visible = true;
            auswahlBtn.Visible = true;
            NeuSpeichernBtn.Visible = false;
            lblEditStatus.BackColor = Color.Lime;
            telnummerlength = 0;
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
                if (TbOrt.Text == "Ort")
                {
                    TbOrt.Text = "";
                }
                if (TbPLZ.Text == "PLZ")
                {
                    TbPLZ.Text = "";
                }
                if (TbTelefonnummer.Text == "Telefonnummer")
                {
                    TbTelefonnummer.Text = "";
                }
                if (TbAdresse.Text == "Adresse")
                {
                    TbAdresse.Text = "";
                }

                string[] PatName_ = new string[2];
                Patientenname = TbName.Text.ToString();
                PatName_ = Patientenname.Split('_');
                //erstellen der Datenbank für den jeweiligen Patienten(Schema Vorname_Nachname_Patientennummer), Füllen der tablle Patientenliste mit Informationen für die Suche
                query2 = "CREATE TABLE " + TbName.Text + "_" + TbNachname.Text + "_" + TbPatNr.Text + "(Behandlungsnummer int NOT NULL IDENTITY(1,1)," +
                                                                                                        "Vorname nvarchar(50) NOT NULL," +
                                                                                                        "Nachname nvarchar(50) NOT NULL," +
                                                                                                        "Schrittweite int NOT NULL," +
                                                                                                        "Behandlungsdatum varchar(10) NOT NULL," +
                                                                                                        "Primary Key(Behandlungsnummer)); " +
                    "INSERT INTO Patientenliste(Vorname,Nachname,Geburtsdatum,Adresse,PLZ,Ort,Telefonnummer) VALUES ('" + TbName.Text + "','" + TbNachname.Text + "','" +
                     TbGeburtsdatum.Text + "','" + TbAdresse.Text + "','" + TbOrt.Text + "','" + TbPLZ.Text + "','" + TbTelefonnummer.Text + "') ;";

                try
                {
                    conn.Open();

                    cmd = new SqlCommand(query2, conn);

                    cmd.ExecuteNonQuery();

                    if (TbGeburtsdatum.Text == "")
                    {
                        TbGeburtsdatum.Text = "Geburtsdatum";
                        TbGeburtsdatum.ForeColor = color_on_leafe;
                    }
                    TbPatNr.Text = "Patientennr.";
                    TbPatNr.ForeColor = color_on_leafe;
                    TbPatNr.ReadOnly = false;
                    lblEditStatus.BackColor = Color.Lime;

                    TbNachname.Focus();
                    TbPatNr.Focus();
                    TbGeburtsdatum.Focus();
                    TbOrt.Focus();
                    TbAdresse.Focus();
                    TbTelefonnummer.Focus();
                    TbPLZ.Focus();
                    TbName.Focus();

                    NeuAbbrechenBtn.Visible = false;
                    sucheBtn.Visible = true;
                    Patienten.Visible = true;
                    auswahlBtn.Visible = true;
                    NeuSpeichernBtn.Visible = false;

                    MessageBox.Show("Patient erfolgreich hinzugefügt!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (SqlException ex)
                {
                    exception(ex.Number);
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
                    query2 = "UPDATE Patientenliste Set Geburtsdatum='" + TbGeburtsdatum.Text.Replace(" ", "-") + "'," +
                                                                "Adresse='" + TbAdresse.Text + "'," +
                                                                "PLZ='" + TbPLZ.Text + "'," +
                                                                "Ort='" + TbOrt.Text + "'," +
                                                                "Telefonnummer='" + TbTelefonnummer.Text + "' " +
                                                                "where Patientennummer='" + patnr + "';";
                }
                if (TbName.Text != vorname || TbNachname.Text != nachname)//falls einer der beiden namensteile geändert wurde, alle datensätze außer der Patientennummer updaten
                {
                    query2 = "UPDATE Patientenliste SET Vorname='" + TbName.Text + "'," +
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

                    cmd = new SqlCommand(query2, conn);

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Patient erfolgreich aktualisiert!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region zurücksetzen der Oberflächenelemente zur Suchmaske

                    TbName.Text = "Vorname";
                    TbName.ForeColor = color_on_leafe;

                    TbNachname.Text = "Nachname";
                    TbNachname.ForeColor = color_on_leafe;

                    TbPatNr.Text = "Patientennr.";
                    TbPatNr.ForeColor = color_on_leafe;
                    TbPatNr.ReadOnly = false;

                    TbGeburtsdatum.Text = "Geburtsdatum";
                    TbGeburtsdatum.ForeColor = color_on_leafe;

                    TbAdresse.Text = "Adresse";
                    TbAdresse.ForeColor = color_on_leafe;

                    TbPLZ.Text = "PLZ";
                    TbPLZ.ForeColor = color_on_leafe;

                    TbOrt.Text = "Ort";
                    TbOrt.ForeColor = color_on_leafe;

                    TbTelefonnummer.Text = "Telefonnummer";
                    TbTelefonnummer.ForeColor = color_on_leafe;

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
                catch (SqlException ex)
                {
                    exception(ex.Number);
                }

                finally
                {
                    conn.Close();
                }
            }
            sucheBtn.PerformClick();
            telnummerlength = 0;
        }
        void exception(int Exception)
        {
            //TODO: vollständige Fehlerbehandlung mit schönen Fehlermeldungen
            //https://stackoverflow.com/questions/8138392/make-sql-errors-caught-in-c-sharp-user-friendly
            //https://mariadb.com/kb/en/mariadb-error-codes/
            //https://infocenter.sybase.com/help/index.jsp?topic=/com.sybase.infocenter.dc00729.1500/html/errMessageAdvRes/CHDGFCCJ.htm
            switch (Exception)
            {
                case 1042:
                    MessageBox.Show("Keine Verbindung zur Datenbank möglich\nFehler: " + Exception);
                    return;
                case 0:
                    MessageBox.Show("Schwerer Fehler\nBitte kontaktieren Sie den Entwickler");
                    break;
                case 2714:
                    MessageBox.Show("Dieses Objekt ist bereits in der Datenbank vorhanden\nFehler: " + Exception);
                    return;
                case 3701:
                    MessageBox.Show("Dieses Objekt ist nicht in der Datenbank vorhanden\nFehler: " + Exception);
                    return;
                default:
                    MessageBox.Show("Fehler: " + Exception.ToString());
                    break;
            }
        }
        void cleartext()
        {
            TbName.Clear();
            TbAdresse.Clear();
            TbNachname.Clear();
            TbOrt.Clear();
            TbPLZ.Clear();
            TbTelefonnummer.Clear();
            TbGeburtsdatum.Clear();
            TbPatNr.Clear();

            TbNachname.Focus();
            TbPatNr.Focus();
            TbGeburtsdatum.Focus();
            TbOrt.Focus();
            TbAdresse.Focus();
            TbTelefonnummer.Focus();
            TbPLZ.Focus();
            TbName.Focus();
        }
    }

}
