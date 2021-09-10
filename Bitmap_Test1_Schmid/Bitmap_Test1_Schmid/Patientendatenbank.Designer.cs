
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
            this.labelHinweis = new System.Windows.Forms.Label();
            this.TbNachname = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(607, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.eintragungLöschenToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.patientToolStripMenuItem.Text = "Patient";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // eintragungLöschenToolStripMenuItem
            // 
            this.eintragungLöschenToolStripMenuItem.Name = "eintragungLöschenToolStripMenuItem";
            this.eintragungLöschenToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.eintragungLöschenToolStripMenuItem.Text = "Eintragung löschen";
            this.eintragungLöschenToolStripMenuItem.Click += new System.EventHandler(this.eintragungLöschenToolStripMenuItem_Click);
            // 
            // sucheBtn
            // 
            this.sucheBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucheBtn.Location = new System.Drawing.Point(16, 252);
            this.sucheBtn.Margin = new System.Windows.Forms.Padding(4);
            this.sucheBtn.Name = "sucheBtn";
            this.sucheBtn.Size = new System.Drawing.Size(105, 39);
            this.sucheBtn.TabIndex = 1;
            this.sucheBtn.Text = "Suchen";
            this.sucheBtn.UseVisualStyleBackColor = true;
            this.sucheBtn.Click += new System.EventHandler(this.sucheBtn_Click);
            // 
            // Patienten
            // 
            this.Patienten.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Patienten.FormattingEnabled = true;
            this.Patienten.ItemHeight = 26;
            this.Patienten.Location = new System.Drawing.Point(21, 319);
            this.Patienten.Margin = new System.Windows.Forms.Padding(4);
            this.Patienten.Name = "Patienten";
            this.Patienten.Size = new System.Drawing.Size(573, 134);
            this.Patienten.TabIndex = 2;
            // 
            // auswahlBtn
            // 
            this.auswahlBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auswahlBtn.Location = new System.Drawing.Point(417, 470);
            this.auswahlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.auswahlBtn.Name = "auswahlBtn";
            this.auswahlBtn.Size = new System.Drawing.Size(177, 46);
            this.auswahlBtn.TabIndex = 3;
            this.auswahlBtn.Text = "Auswählen";
            this.auswahlBtn.UseVisualStyleBackColor = true;
            this.auswahlBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // TbName
            // 
            this.TbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbName.ForeColor = System.Drawing.Color.Gray;
            this.TbName.Location = new System.Drawing.Point(16, 92);
            this.TbName.Margin = new System.Windows.Forms.Padding(4);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(213, 32);
            this.TbName.TabIndex = 4;
            this.TbName.Text = "Vorname";
            this.TbName.Click += new System.EventHandler(this.TbName_Click);
            this.TbName.Leave += new System.EventHandler(this.TbName_Leave);
            // 
            // TbAdresse
            // 
            this.TbAdresse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAdresse.ForeColor = System.Drawing.Color.Gray;
            this.TbAdresse.Location = new System.Drawing.Point(16, 172);
            this.TbAdresse.Margin = new System.Windows.Forms.Padding(4);
            this.TbAdresse.Name = "TbAdresse";
            this.TbAdresse.Size = new System.Drawing.Size(213, 32);
            this.TbAdresse.TabIndex = 5;
            this.TbAdresse.Text = "Adresse";
            this.TbAdresse.Click += new System.EventHandler(this.TbAdresse_Click);
            this.TbAdresse.Leave += new System.EventHandler(this.TbAdresse_Leave);
            // 
            // TbPLZ
            // 
            this.TbPLZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPLZ.ForeColor = System.Drawing.Color.Gray;
            this.TbPLZ.Location = new System.Drawing.Point(437, 172);
            this.TbPLZ.Margin = new System.Windows.Forms.Padding(4);
            this.TbPLZ.Name = "TbPLZ";
            this.TbPLZ.Size = new System.Drawing.Size(157, 32);
            this.TbPLZ.TabIndex = 6;
            this.TbPLZ.Text = "PLZ";
            this.TbPLZ.Click += new System.EventHandler(this.TbPLZ_Click);
            this.TbPLZ.Leave += new System.EventHandler(this.TbPLZ_Leave);
            // 
            // TbOrt
            // 
            this.TbOrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbOrt.ForeColor = System.Drawing.Color.Gray;
            this.TbOrt.Location = new System.Drawing.Point(237, 172);
            this.TbOrt.Margin = new System.Windows.Forms.Padding(4);
            this.TbOrt.Name = "TbOrt";
            this.TbOrt.Size = new System.Drawing.Size(187, 32);
            this.TbOrt.TabIndex = 7;
            this.TbOrt.Text = "Ort";
            this.TbOrt.Click += new System.EventHandler(this.TbOrt_Click);
            this.TbOrt.Leave += new System.EventHandler(this.TbOrt_Leave);
            // 
            // TbGeburtsdatum
            // 
            this.TbGeburtsdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbGeburtsdatum.ForeColor = System.Drawing.Color.Gray;
            this.TbGeburtsdatum.Location = new System.Drawing.Point(16, 132);
            this.TbGeburtsdatum.Margin = new System.Windows.Forms.Padding(4);
            this.TbGeburtsdatum.Name = "TbGeburtsdatum";
            this.TbGeburtsdatum.Size = new System.Drawing.Size(157, 32);
            this.TbGeburtsdatum.TabIndex = 8;
            this.TbGeburtsdatum.Text = "Geburtsdatum";
            this.TbGeburtsdatum.Click += new System.EventHandler(this.TbGeburtsdatum_Click);
            this.TbGeburtsdatum.Leave += new System.EventHandler(this.TbGeburtsdatum_Leave);
            // 
            // TbTelefonnummer
            // 
            this.TbTelefonnummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTelefonnummer.ForeColor = System.Drawing.Color.Gray;
            this.TbTelefonnummer.Location = new System.Drawing.Point(16, 212);
            this.TbTelefonnummer.Margin = new System.Windows.Forms.Padding(4);
            this.TbTelefonnummer.Name = "TbTelefonnummer";
            this.TbTelefonnummer.Size = new System.Drawing.Size(213, 32);
            this.TbTelefonnummer.TabIndex = 9;
            this.TbTelefonnummer.Text = "Telefonnummer";
            this.TbTelefonnummer.Click += new System.EventHandler(this.TbTelefonnummer_Click);
            this.TbTelefonnummer.Leave += new System.EventHandler(this.TbTelefonnummer_Leave);
            // 
            // labelHinweis
            // 
            this.labelHinweis.AutoSize = true;
            this.labelHinweis.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelHinweis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHinweis.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelHinweis.Location = new System.Drawing.Point(16, 52);
            this.labelHinweis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHinweis.Name = "labelHinweis";
            this.labelHinweis.Size = new System.Drawing.Size(261, 24);
            this.labelHinweis.TabIndex = 10;
            this.labelHinweis.Text = "Verbindungsstatus Datenbank";
            // 
            // TbNachname
            // 
            this.TbNachname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbNachname.ForeColor = System.Drawing.Color.Gray;
            this.TbNachname.Location = new System.Drawing.Point(237, 92);
            this.TbNachname.Margin = new System.Windows.Forms.Padding(4);
            this.TbNachname.Name = "TbNachname";
            this.TbNachname.Size = new System.Drawing.Size(187, 32);
            this.TbNachname.TabIndex = 11;
            this.TbNachname.Text = "Nachname";
            this.TbNachname.Click += new System.EventHandler(this.TbNachname_Click);
            this.TbNachname.Leave += new System.EventHandler(this.TbNachname_Leave);
            // 
            // Patientendatenbank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(607, 553);
            this.Controls.Add(this.TbNachname);
            this.Controls.Add(this.labelHinweis);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Patientendatenbank";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Patientendatenbank";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Patientendatenbank_FormClosing);
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
        private System.Windows.Forms.Label labelHinweis;
        private System.Windows.Forms.TextBox TbNachname;
    }
}