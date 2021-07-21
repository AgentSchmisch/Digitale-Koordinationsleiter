using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class Patientendatenbank : Form
    {
        Form1 UI = new Form1();

        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Flori\source\repos\AgentSchmisch\Virtual-Walkway\Bitmap_Test1_Schmid\Bitmap_Test1_Schmid\Database\Patienten.mdf;Integrated Security=True;Connect Timeout=30";
        string query1;
        string query2;
        string record;
        string Patientenname;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable tbl;  //datatable for query results
        public Patientendatenbank() //constructuor
        {
            InitializeComponent();
            conn = new SqlConnection(connString);
        }

        private void Patientendatenbank_Load(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                labelHinweis.Text = "Verbindung zur Datenbank hergestellt";
            }
            catch
            {
                labelHinweis.Text = "Verbindung zur Datenbank fehlgeschlagen";
            }
            finally
            {
                conn.Close();
            }
        }

        private void sucheBtn_Click(object sender, EventArgs e)
        {
            query1 = "select Versicherungsnummer, Name, Postleitzahl, Ort, Geburtsdatum from Patientenliste where Name in ('"+TbName.Text+"')or Versicherungsnummer in('"+TbSVNr.Text+"') order by Name asc ;";

            try
            {
                cmd = new SqlCommand(query1, conn);
                conn.Open();
                da = new SqlDataAdapter(cmd);
                tbl = new DataTable();
                da.Fill(tbl);
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
            //fill listbox with all information
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                record = "";
                DataRow row = tbl.Rows[i];
                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Versicherungsnummer")
                    {
                        if (row[j].ToString() == TbName.Text)
                            MessageBox.Show("erfolgreich");
                        record += row[j] + "\t";
                        continue;
                    }
                }
                for (int j = 0; j < tbl.Columns.Count; j++)
                {
                    if (tbl.Columns[j].ColumnName == "Name")
                    {
                        if (row[j].ToString() == TbName.Text)
                            MessageBox.Show("erfolgreich");
                        record += row[j] + "\t";
                        continue;
                    }
                }


                for (int k = 0; k < tbl.Columns.Count; k++)
                {
                    if (tbl.Columns[k].ColumnName == "Postleitzahl")
                    {
                        record +=  row[k] + "\t";
                        continue;
                    }
                }

                for (int l = 0; l < tbl.Columns.Count; l++)
                {
                    if (tbl.Columns[l].ColumnName == "Ort")
                    {
                        record += row[l] + "\t";
                        continue;
                    }
                }
                for (int m = 0; m < tbl.Columns.Count; m++)
                {
                    if (tbl.Columns[m].ColumnName == "Geburtsdatum")
                    {
                        record +=  row[m] + "\t";
                        continue;
                    }
                }
                //present the information in the listbox
                Patienten.Items.Add(record);
            }
        }

        private void button1_Click(object sender, EventArgs e) //auswahlBtn
        {
            string pickeditem = Patienten.SelectedItem.ToString();
            

            labelHinweis.Text = pickeditem;

        }
        //empty the textbox if clicked
        private void TbName_Click(object sender, EventArgs e)
        {
            TbName.Text = "";
        }
        private void TbAdresse_Click(object sender, EventArgs e)
        {
            TbAdresse.Text = "";
        }
        private void TbGeburtsdatum_Click(object sender, EventArgs e)
        {
            TbGeburtsdatum.Text = "";
        }
        private void TbOrt_Click(object sender, EventArgs e)
        {
            TbOrt.Text = "";
        }
        private void TbPLZ_Click(object sender, EventArgs e)
        {
            TbPLZ.Text = "";
        }
        private void TbTelefonnummer_Click(object sender, EventArgs e)
        {
            TbTelefonnummer.Text = "";
        }
        private void TbSVNr_Click(object sender, EventArgs e)
        {
            TbSVNr.Text = "";
        }


        private void Patientendatenbank_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            //
            //      Fehler beim schließen und wiederöffnen der Form während form1&projetktion geöffnet bleibt
            //   
            //
            //
   
              
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Patientenname=TbName.Text.ToString();
           Patientenname= Patientenname.Replace(' ', '_');
            //erstellen der Datenbank für den jeweiligen Patienten, Füllen der allgemeinen tablle mit Informationen für die Suche
            query2 = "create table " + Patientenname + " (Versicherungsnummer nchar(10) not null primary key , Name nvarchar(50), Behandlungsdatum nvarchar(50),Schrittweite nvarchar(5));" +
                "Insert into Patientenliste(Name,Geburtsdatum,Adresse,Ort,Postleitzahl,Telefonnummer) values('" + Patientenname + "','"+
                TbGeburtsdatum.Text+"','"+TbAdresse.Text+"','"+TbOrt.Text+"','"+TbPLZ.Text+"','"+TbTelefonnummer.Text+"');";
                try
                {
                   conn.Open();
                
                cmd = new SqlCommand(query2, conn);
                
                cmd.ExecuteNonQuery();
                labelHinweis.Text = "erfolgreich";

                }
                 catch
                {
                MessageBox.Show("Fehler");
                }
               

                finally
                {
                    //MessageBox.Show("Patient erfolgreich hinzugefügt", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            
            
        }


    }
}
