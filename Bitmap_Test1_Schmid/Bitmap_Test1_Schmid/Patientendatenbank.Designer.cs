
namespace Bitmap_Test1_Schmid
{
    partial class Patientendatenbank
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patientendatenbank));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eintragungLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucheBtn = new System.Windows.Forms.Button();
            this.Patienten = new System.Windows.Forms.ListBox();
            this.auswahlBtn = new System.Windows.Forms.Button();
            this.TbName = new System.Windows.Forms.TextBox();
            this.TbAdresse = new System.Windows.Forms.TextBox();
            this.TbPLZ = new System.Windows.Forms.TextBox();
            this.TbOrt = new System.Windows.Forms.TextBox();
            this.TbGeburtsdatum = new System.Windows.Forms.TextBox();
            this.TbTelefonnummer = new System.Windows.Forms.TextBox();
            this.TbNachname = new System.Windows.Forms.TextBox();
            this.TbPatNr = new System.Windows.Forms.TextBox();
            this.lblEditStatus = new System.Windows.Forms.Label();
            this.NeuAbbrechenBtn = new System.Windows.Forms.Button();
            this.NeuSpeichernBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(455, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.eintragungLöschenToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.patientToolStripMenuItem.Text = "Patient";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // eintragungLöschenToolStripMenuItem
            // 
            this.eintragungLöschenToolStripMenuItem.Name = "eintragungLöschenToolStripMenuItem";
            this.eintragungLöschenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eintragungLöschenToolStripMenuItem.Text = "Eintragung löschen";
            this.eintragungLöschenToolStripMenuItem.Click += new System.EventHandler(this.eintragungLöschenToolStripMenuItem_Click);
            // 
            // sucheBtn
            // 
            this.sucheBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sucheBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.sucheBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.sucheBtn.Location = new System.Drawing.Point(12, 184);
            this.sucheBtn.Name = "sucheBtn";
            this.sucheBtn.Size = new System.Drawing.Size(161, 38);
            this.sucheBtn.TabIndex = 0;
            this.sucheBtn.Text = "Suchen";
            this.sucheBtn.UseVisualStyleBackColor = true;
            this.sucheBtn.Click += new System.EventHandler(this.sucheBtn_Click);
            // 
            // Patienten
            // 
            this.Patienten.BackColor = System.Drawing.SystemColors.Menu;
            this.Patienten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Patienten.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Patienten.FormattingEnabled = true;
            this.Patienten.ItemHeight = 20;
            this.Patienten.Location = new System.Drawing.Point(12, 233);
            this.Patienten.Name = "Patienten";
            this.Patienten.Size = new System.Drawing.Size(435, 100);
            this.Patienten.TabIndex = 9;
            this.Patienten.SelectedIndexChanged += new System.EventHandler(this.Patienten_SelectedIndexChanged);
            // 
            // auswahlBtn
            // 
            this.auswahlBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.auswahlBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.auswahlBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.auswahlBtn.Location = new System.Drawing.Point(166, 349);
            this.auswahlBtn.Name = "auswahlBtn";
            this.auswahlBtn.Size = new System.Drawing.Size(133, 41);
            this.auswahlBtn.TabIndex = 10;
            this.auswahlBtn.Text = "Auswählen";
            this.auswahlBtn.UseVisualStyleBackColor = true;
            this.auswahlBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // TbName
            // 
            this.TbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbName.ForeColor = System.Drawing.Color.Gray;
            this.TbName.Location = new System.Drawing.Point(12, 45);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(161, 27);
            this.TbName.TabIndex = 1;
            this.TbName.Text = "Vorname";
            this.TbName.Enter += new System.EventHandler(this.TbName_Enter);
            this.TbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbName_KeyDown);
            this.TbName.Leave += new System.EventHandler(this.TbName_Leave);
            // 
            // TbAdresse
            // 
            this.TbAdresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAdresse.ForeColor = System.Drawing.Color.Gray;
            this.TbAdresse.Location = new System.Drawing.Point(12, 110);
            this.TbAdresse.Name = "TbAdresse";
            this.TbAdresse.Size = new System.Drawing.Size(161, 27);
            this.TbAdresse.TabIndex = 5;
            this.TbAdresse.Text = "Adresse";
            this.TbAdresse.Enter += new System.EventHandler(this.TbAdresse_Enter);
            this.TbAdresse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbAdresse_KeyDown);
            this.TbAdresse.Leave += new System.EventHandler(this.TbAdresse_Leave);
            // 
            // TbPLZ
            // 
            this.TbPLZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPLZ.ForeColor = System.Drawing.Color.Gray;
            this.TbPLZ.Location = new System.Drawing.Point(328, 110);
            this.TbPLZ.Name = "TbPLZ";
            this.TbPLZ.Size = new System.Drawing.Size(119, 27);
            this.TbPLZ.TabIndex = 7;
            this.TbPLZ.Text = "PLZ";
            this.TbPLZ.Enter += new System.EventHandler(this.TbPLZ_Enter);
            this.TbPLZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbPLZ_KeyDown);
            this.TbPLZ.Leave += new System.EventHandler(this.TbPLZ_Leave);
            // 
            // TbOrt
            // 
            this.TbOrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbOrt.ForeColor = System.Drawing.Color.Gray;
            this.TbOrt.Location = new System.Drawing.Point(178, 110);
            this.TbOrt.Name = "TbOrt";
            this.TbOrt.Size = new System.Drawing.Size(141, 27);
            this.TbOrt.TabIndex = 6;
            this.TbOrt.Text = "Ort";
            this.TbOrt.Enter += new System.EventHandler(this.TbOrt_Enter);
            this.TbOrt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbOrt_KeyDown);
            this.TbOrt.Leave += new System.EventHandler(this.TbOrt_Leave);
            // 
            // TbGeburtsdatum
            // 
            this.TbGeburtsdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbGeburtsdatum.ForeColor = System.Drawing.Color.Gray;
            this.TbGeburtsdatum.Location = new System.Drawing.Point(12, 77);
            this.TbGeburtsdatum.Name = "TbGeburtsdatum";
            this.TbGeburtsdatum.Size = new System.Drawing.Size(119, 27);
            this.TbGeburtsdatum.TabIndex = 4;
            this.TbGeburtsdatum.Text = "Geburtsdatum";
            this.TbGeburtsdatum.Enter += new System.EventHandler(this.TbGeburtsdatum_Enter);
            this.TbGeburtsdatum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbGeburtsdatum_KeyDown);
            this.TbGeburtsdatum.Leave += new System.EventHandler(this.TbGeburtsdatum_Leave);
            // 
            // TbTelefonnummer
            // 
            this.TbTelefonnummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTelefonnummer.ForeColor = System.Drawing.Color.Gray;
            this.TbTelefonnummer.Location = new System.Drawing.Point(12, 142);
            this.TbTelefonnummer.Name = "TbTelefonnummer";
            this.TbTelefonnummer.Size = new System.Drawing.Size(161, 27);
            this.TbTelefonnummer.TabIndex = 8;
            this.TbTelefonnummer.Text = "Telefonnummer";
            this.TbTelefonnummer.Enter += new System.EventHandler(this.TbTelefonnummer_Enter);
            this.TbTelefonnummer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbTelefonnummer_KeyDown);
            this.TbTelefonnummer.Leave += new System.EventHandler(this.TbTelefonnummer_Leave);
            // 
            // TbNachname
            // 
            this.TbNachname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbNachname.ForeColor = System.Drawing.Color.Gray;
            this.TbNachname.Location = new System.Drawing.Point(178, 45);
            this.TbNachname.Name = "TbNachname";
            this.TbNachname.Size = new System.Drawing.Size(141, 27);
            this.TbNachname.TabIndex = 2;
            this.TbNachname.Text = "Nachname";
            this.TbNachname.Enter += new System.EventHandler(this.TbNachname_Enter);
            this.TbNachname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbNachname_KeyDown);
            this.TbNachname.Leave += new System.EventHandler(this.TbNachname_Leave);
            // 
            // TbPatNr
            // 
            this.TbPatNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPatNr.ForeColor = System.Drawing.Color.Gray;
            this.TbPatNr.Location = new System.Drawing.Point(328, 45);
            this.TbPatNr.Name = "TbPatNr";
            this.TbPatNr.Size = new System.Drawing.Size(118, 27);
            this.TbPatNr.TabIndex = 3;
            this.TbPatNr.Text = "Patientennr.";
            this.TbPatNr.Enter += new System.EventHandler(this.TbPatNr_Enter);
            this.TbPatNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbPatNr_KeyDown);
            this.TbPatNr.Leave += new System.EventHandler(this.TbPatNr_Leave);
            // 
            // lblEditStatus
            // 
            this.lblEditStatus.AutoSize = true;
            this.lblEditStatus.BackColor = System.Drawing.Color.Lime;
            this.lblEditStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditStatus.Location = new System.Drawing.Point(-3, 24);
            this.lblEditStatus.Name = "lblEditStatus";
            this.lblEditStatus.Size = new System.Drawing.Size(458, 4);
            this.lblEditStatus.TabIndex = 11;
            this.lblEditStatus.Text = resources.GetString("lblEditStatus.Text");
            // 
            // NeuAbbrechenBtn
            // 
            this.NeuAbbrechenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NeuAbbrechenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NeuAbbrechenBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NeuAbbrechenBtn.Location = new System.Drawing.Point(293, 184);
            this.NeuAbbrechenBtn.Name = "NeuAbbrechenBtn";
            this.NeuAbbrechenBtn.Size = new System.Drawing.Size(150, 38);
            this.NeuAbbrechenBtn.TabIndex = 12;
            this.NeuAbbrechenBtn.Text = "Abbrechen";
            this.NeuAbbrechenBtn.UseVisualStyleBackColor = true;
            this.NeuAbbrechenBtn.Visible = false;
            this.NeuAbbrechenBtn.Click += new System.EventHandler(this.NeuAbbrechenBtn_Click);
            // 
            // NeuSpeichernBtn
            // 
            this.NeuSpeichernBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NeuSpeichernBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NeuSpeichernBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NeuSpeichernBtn.Location = new System.Drawing.Point(12, 184);
            this.NeuSpeichernBtn.Name = "NeuSpeichernBtn";
            this.NeuSpeichernBtn.Size = new System.Drawing.Size(161, 38);
            this.NeuSpeichernBtn.TabIndex = 13;
            this.NeuSpeichernBtn.Text = "Speichern";
            this.NeuSpeichernBtn.UseVisualStyleBackColor = true;
            this.NeuSpeichernBtn.Visible = false;
            this.NeuSpeichernBtn.Click += new System.EventHandler(this.NeuSpeichernBtn_Click);
            // 
            // Patientendatenbank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(455, 410);
            this.Controls.Add(this.NeuSpeichernBtn);
            this.Controls.Add(this.NeuAbbrechenBtn);
            this.Controls.Add(this.lblEditStatus);
            this.Controls.Add(this.TbPatNr);
            this.Controls.Add(this.TbNachname);
            this.Controls.Add(this.TbTelefonnummer);
            this.Controls.Add(this.TbGeburtsdatum);
            this.Controls.Add(this.TbOrt);
            this.Controls.Add(this.TbPLZ);
            this.Controls.Add(this.TbAdresse);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.auswahlBtn);
            this.Controls.Add(this.Patienten);
            this.Controls.Add(this.sucheBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Patientendatenbank";
            this.ShowInTaskbar = false;
            this.Text = "Patientendatenbank";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Patientendatenbank_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eintragungLöschenToolStripMenuItem;
        private System.Windows.Forms.Button sucheBtn;
        private System.Windows.Forms.ListBox Patienten;
        private System.Windows.Forms.Button auswahlBtn;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.TextBox TbAdresse;
        private System.Windows.Forms.TextBox TbPLZ;
        private System.Windows.Forms.TextBox TbOrt;
        private System.Windows.Forms.TextBox TbGeburtsdatum;
        private System.Windows.Forms.TextBox TbTelefonnummer;
        private System.Windows.Forms.TextBox TbNachname;
        private System.Windows.Forms.TextBox TbPatNr;
        private System.Windows.Forms.Label lblEditStatus;
        private System.Windows.Forms.Button NeuAbbrechenBtn;
        private System.Windows.Forms.Button NeuSpeichernBtn;
    }
}