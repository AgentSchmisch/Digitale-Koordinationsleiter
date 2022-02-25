namespace Bitmap_Test1_Schmid
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.steps2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bestätigen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.längelabel = new System.Windows.Forms.Label();
            this.längebox = new System.Windows.Forms.TrackBar();
            this.fläche = new System.Windows.Forms.Button();
            this.reglertext = new System.Windows.Forms.Label();
            this.regler = new System.Windows.Forms.TrackBar();
            this.länge = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kinectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kantenerkennungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSitzungBeenden = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSteps = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLezteTherapie = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.delsteps = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.check_autoobjekt = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lab_schrittgeschw = new System.Windows.Forms.Label();
            this.lab_schrittgeschw_text = new System.Windows.Forms.Label();
            this.schrittgeschw = new System.Windows.Forms.TrackBar();
            this.steps = new System.Windows.Forms.NumericUpDown();
            this.programme = new System.Windows.Forms.DomainUpDown();
            this.programmauswahl = new System.Windows.Forms.Button();
            this.zufall = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.längebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regler)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schrittgeschw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.steps)).BeginInit();
            this.SuspendLayout();
            // 
            // steps2
            // 
            this.steps2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.steps2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.steps2.ForeColor = System.Drawing.Color.White;
            this.steps2.Location = new System.Drawing.Point(154, 149);
            this.steps2.MaxLength = 2;
            this.steps2.Name = "steps2";
            this.steps2.Size = new System.Drawing.Size(57, 38);
            this.steps2.TabIndex = 2;
            this.steps2.Text = "6";
            this.steps2.Visible = false;
            this.steps2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.steps_KeyDown);
            this.steps2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.steps_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(33, 149);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Schritte:";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // bestätigen
            // 
            this.bestätigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bestätigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.bestätigen.ForeColor = System.Drawing.Color.White;
            this.bestätigen.Location = new System.Drawing.Point(51, 206);
            this.bestätigen.Name = "bestätigen";
            this.bestätigen.Size = new System.Drawing.Size(160, 54);
            this.bestätigen.TabIndex = 3;
            this.bestätigen.Text = "bestätigen";
            this.bestätigen.UseVisualStyleBackColor = true;
            this.bestätigen.Click += new System.EventHandler(this.bestätigen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.label2.Location = new System.Drawing.Point(343, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 26);
            this.label2.TabIndex = 20;
            this.label2.Text = "Länge des Objektes:";
            // 
            // längelabel
            // 
            this.längelabel.BackColor = System.Drawing.Color.White;
            this.längelabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.längelabel.Location = new System.Drawing.Point(267, 36);
            this.längelabel.Name = "längelabel";
            this.längelabel.Size = new System.Drawing.Size(1, 340);
            this.längelabel.TabIndex = 21;
            // 
            // längebox
            // 
            this.längebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.längebox.Enabled = false;
            this.längebox.LargeChange = 1;
            this.längebox.Location = new System.Drawing.Point(305, 190);
            this.längebox.Minimum = 1;
            this.längebox.Name = "längebox";
            this.längebox.Size = new System.Drawing.Size(273, 45);
            this.längebox.TabIndex = 18;
            this.längebox.Value = 1;
            this.längebox.ValueChanged += new System.EventHandler(this.längebox_ValueChanged);
            this.längebox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.längebox_KeyDown);
            // 
            // fläche
            // 
            this.fläche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.fläche.Enabled = false;
            this.fläche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fläche.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.fläche.ForeColor = System.Drawing.Color.White;
            this.fläche.Location = new System.Drawing.Point(290, 304);
            this.fläche.Name = "fläche";
            this.fläche.Size = new System.Drawing.Size(156, 54);
            this.fläche.TabIndex = 17;
            this.fläche.Text = "bestätigen";
            this.fläche.UseVisualStyleBackColor = false;
            this.fläche.Click += new System.EventHandler(this.fläche_Click);
            // 
            // reglertext
            // 
            this.reglertext.AutoSize = true;
            this.reglertext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.reglertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.reglertext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.reglertext.Location = new System.Drawing.Point(431, 119);
            this.reglertext.Name = "reglertext";
            this.reglertext.Size = new System.Drawing.Size(24, 26);
            this.reglertext.TabIndex = 16;
            this.reglertext.Text = "0";
            // 
            // regler
            // 
            this.regler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.regler.Enabled = false;
            this.regler.LargeChange = 1;
            this.regler.Location = new System.Drawing.Point(305, 71);
            this.regler.Name = "regler";
            this.regler.Size = new System.Drawing.Size(273, 45);
            this.regler.TabIndex = 15;
            this.regler.ValueChanged += new System.EventHandler(this.regler_ValueChanged);
            this.regler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.regler_KeyDown);
            // 
            // länge
            // 
            this.länge.AutoSize = true;
            this.länge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.länge.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.länge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.länge.Location = new System.Drawing.Point(431, 234);
            this.länge.Name = "länge";
            this.länge.Size = new System.Drawing.Size(24, 26);
            this.länge.TabIndex = 22;
            this.länge.Text = "1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.button1.Location = new System.Drawing.Point(584, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.button2.Location = new System.Drawing.Point(584, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 40);
            this.button2.TabIndex = 25;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem,
            this.kinectToolStripMenuItem,
            this.kantenerkennungToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.analyseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1052, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.patientToolStripMenuItem.Text = "Patient auswählen";
            this.patientToolStripMenuItem.Click += new System.EventHandler(this.patientToolStripMenuItem_Click);
            // 
            // kinectToolStripMenuItem
            // 
            this.kinectToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.kinectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.kinectToolStripMenuItem.Name = "kinectToolStripMenuItem";
            this.kinectToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.kinectToolStripMenuItem.Text = "Schritterkennung";
            this.kinectToolStripMenuItem.Click += new System.EventHandler(this.kinectToolStripMenuItem_Click);
            // 
            // kantenerkennungToolStripMenuItem
            // 
            this.kantenerkennungToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.kantenerkennungToolStripMenuItem.Name = "kantenerkennungToolStripMenuItem";
            this.kantenerkennungToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.kantenerkennungToolStripMenuItem.Text = "Kantenerkennung";
            this.kantenerkennungToolStripMenuItem.Click += new System.EventHandler(this.kantenerkennungToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.analyseToolStripMenuItem.Text = "Analyse";
            this.analyseToolStripMenuItem.Visible = false;
            this.analyseToolStripMenuItem.Click += new System.EventHandler(this.analyseToolStripMenuItem_Click);
            // 
            // BtnSitzungBeenden
            // 
            this.BtnSitzungBeenden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.BtnSitzungBeenden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSitzungBeenden.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.BtnSitzungBeenden.ForeColor = System.Drawing.Color.White;
            this.BtnSitzungBeenden.Location = new System.Drawing.Point(757, 271);
            this.BtnSitzungBeenden.Name = "BtnSitzungBeenden";
            this.BtnSitzungBeenden.Size = new System.Drawing.Size(233, 42);
            this.BtnSitzungBeenden.TabIndex = 28;
            this.BtnSitzungBeenden.Text = "Sitzung beenden";
            this.BtnSitzungBeenden.UseVisualStyleBackColor = false;
            this.BtnSitzungBeenden.Click += new System.EventHandler(this.BtnSitzungBeenden_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(659, 48);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(94, 31);
            this.label3.TabIndex = 29;
            this.label3.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(659, 127);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(180, 31);
            this.label5.TabIndex = 31;
            this.label5.Text = "Schrittanzahl:";
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblSteps.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSteps.Location = new System.Drawing.Point(875, 127);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSteps.Size = new System.Drawing.Size(44, 31);
            this.lblSteps.TabIndex = 32;
            this.lblSteps.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(659, 87);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(202, 31);
            this.label6.TabIndex = 33;
            this.label6.Text = "letzte Therapie:";
            // 
            // lblLezteTherapie
            // 
            this.lblLezteTherapie.AutoSize = true;
            this.lblLezteTherapie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblLezteTherapie.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblLezteTherapie.Location = new System.Drawing.Point(875, 87);
            this.lblLezteTherapie.Name = "lblLezteTherapie";
            this.lblLezteTherapie.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLezteTherapie.Size = new System.Drawing.Size(0, 31);
            this.lblLezteTherapie.TabIndex = 34;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblName.Location = new System.Drawing.Point(875, 48);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblName.Size = new System.Drawing.Size(221, 31);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "Max Mustermann";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(343, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 26);
            this.label4.TabIndex = 36;
            this.label4.Text = "Position des Objektes:";
            // 
            // delsteps
            // 
            this.delsteps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delsteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.delsteps.ForeColor = System.Drawing.Color.White;
            this.delsteps.Location = new System.Drawing.Point(51, 292);
            this.delsteps.Name = "delsteps";
            this.delsteps.Size = new System.Drawing.Size(160, 65);
            this.delsteps.TabIndex = 37;
            this.delsteps.Text = "Fußabdrücke zurücksetzen";
            this.delsteps.UseVisualStyleBackColor = true;
            this.delsteps.Visible = false;
            this.delsteps.Click += new System.EventHandler(this.delsteps_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(645, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(2, 340);
            this.label8.TabIndex = 39;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // check_autoobjekt
            // 
            this.check_autoobjekt.AutoSize = true;
            this.check_autoobjekt.Enabled = false;
            this.check_autoobjekt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.check_autoobjekt.ForeColor = System.Drawing.Color.White;
            this.check_autoobjekt.Location = new System.Drawing.Point(290, 263);
            this.check_autoobjekt.Name = "check_autoobjekt";
            this.check_autoobjekt.Size = new System.Drawing.Size(261, 24);
            this.check_autoobjekt.TabIndex = 40;
            this.check_autoobjekt.Text = "automatische Objekteinblendung";
            this.check_autoobjekt.UseVisualStyleBackColor = true;
            this.check_autoobjekt.CheckedChanged += new System.EventHandler(this.chech_autoobjekt_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.trackBar1.Enabled = false;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(467, 328);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(110, 45);
            this.trackBar1.TabIndex = 41;
            this.trackBar1.Value = 3;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(476, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Erkennung";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(503, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "mittel";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(200)))));
            this.button3.Location = new System.Drawing.Point(584, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 40);
            this.button3.TabIndex = 44;
            this.button3.Text = "?";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Location = new System.Drawing.Point(0, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1144, 2);
            this.label10.TabIndex = 45;
            // 
            // lab_schrittgeschw
            // 
            this.lab_schrittgeschw.AutoSize = true;
            this.lab_schrittgeschw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lab_schrittgeschw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lab_schrittgeschw.ForeColor = System.Drawing.Color.White;
            this.lab_schrittgeschw.Location = new System.Drawing.Point(176, 74);
            this.lab_schrittgeschw.Name = "lab_schrittgeschw";
            this.lab_schrittgeschw.Size = new System.Drawing.Size(41, 17);
            this.lab_schrittgeschw.TabIndex = 48;
            this.lab_schrittgeschw.Text = "mittel";
            this.lab_schrittgeschw.Visible = false;
            // 
            // lab_schrittgeschw_text
            // 
            this.lab_schrittgeschw_text.AutoSize = true;
            this.lab_schrittgeschw_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lab_schrittgeschw_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lab_schrittgeschw_text.ForeColor = System.Drawing.Color.White;
            this.lab_schrittgeschw_text.Location = new System.Drawing.Point(12, 42);
            this.lab_schrittgeschw_text.Name = "lab_schrittgeschw_text";
            this.lab_schrittgeschw_text.Size = new System.Drawing.Size(117, 20);
            this.lab_schrittgeschw_text.TabIndex = 47;
            this.lab_schrittgeschw_text.Text = "Schrittgeschw.:";
            this.lab_schrittgeschw_text.Visible = false;
            // 
            // schrittgeschw
            // 
            this.schrittgeschw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.schrittgeschw.LargeChange = 1;
            this.schrittgeschw.Location = new System.Drawing.Point(140, 42);
            this.schrittgeschw.Maximum = 3;
            this.schrittgeschw.Minimum = 1;
            this.schrittgeschw.Name = "schrittgeschw";
            this.schrittgeschw.Size = new System.Drawing.Size(110, 45);
            this.schrittgeschw.TabIndex = 46;
            this.schrittgeschw.Value = 2;
            this.schrittgeschw.Visible = false;
            this.schrittgeschw.ValueChanged += new System.EventHandler(this.schrittgeschw_ValueChanged);
            // 
            // steps
            // 
            this.steps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.steps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.steps.ForeColor = System.Drawing.Color.White;
            this.steps.Location = new System.Drawing.Point(154, 148);
            this.steps.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.steps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(63, 38);
            this.steps.TabIndex = 49;
            this.steps.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.steps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.steps_KeyDown_1);
            this.steps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.steps_KeyPress_1);
            // 
            // programme
            // 
            this.programme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.programme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.programme.ForeColor = System.Drawing.Color.White;
            this.programme.Items.Add("Himmel/Hölle");
            this.programme.Items.Add("rot/blau");
            this.programme.Items.Add("Start/Stop");
            this.programme.Location = new System.Drawing.Point(39, 42);
            this.programme.Name = "programme";
            this.programme.Size = new System.Drawing.Size(186, 29);
            this.programme.TabIndex = 50;
            this.programme.Text = "Programmauswahl";
            this.programme.SelectedItemChanged += new System.EventHandler(this.programme_SelectedItemChanged);
            // 
            // programmauswahl
            // 
            this.programmauswahl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.programmauswahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.programmauswahl.ForeColor = System.Drawing.Color.White;
            this.programmauswahl.Location = new System.Drawing.Point(73, 90);
            this.programmauswahl.Margin = new System.Windows.Forms.Padding(0);
            this.programmauswahl.Name = "programmauswahl";
            this.programmauswahl.Size = new System.Drawing.Size(112, 35);
            this.programmauswahl.TabIndex = 51;
            this.programmauswahl.Text = "auswählen";
            this.programmauswahl.UseVisualStyleBackColor = true;
            this.programmauswahl.Click += new System.EventHandler(this.programmauswahl_Click);
            // 
            // zufall
            // 
            this.zufall.AutoSize = true;
            this.zufall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.zufall.ForeColor = System.Drawing.Color.White;
            this.zufall.Location = new System.Drawing.Point(567, 263);
            this.zufall.Name = "zufall";
            this.zufall.Size = new System.Drawing.Size(65, 24);
            this.zufall.TabIndex = 52;
            this.zufall.Text = "zufall";
            this.zufall.UseVisualStyleBackColor = true;
            this.zufall.Visible = false;
            this.zufall.CheckedChanged += new System.EventHandler(this.zufall_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(644, 385);
            this.Controls.Add(this.zufall);
            this.Controls.Add(this.programmauswahl);
            this.Controls.Add(this.programme);
            this.Controls.Add(this.steps);
            this.Controls.Add(this.lab_schrittgeschw);
            this.Controls.Add(this.lab_schrittgeschw_text);
            this.Controls.Add(this.schrittgeschw);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.check_autoobjekt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.delsteps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLezteTherapie);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSteps);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnSitzungBeenden);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.länge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.längelabel);
            this.Controls.Add(this.längebox);
            this.Controls.Add(this.fläche);
            this.Controls.Add(this.reglertext);
            this.Controls.Add(this.regler);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steps2);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digitale Koordinationsleiter";
            this.TopMost = true;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.längebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regler)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schrittgeschw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.steps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bestätigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label längelabel;
        private System.Windows.Forms.Button fläche;
        public System.Windows.Forms.TrackBar längebox;
        public System.Windows.Forms.TextBox steps2;
        public System.Windows.Forms.TrackBar regler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label reglertext;
        public System.Windows.Forms.Label länge;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.Button BtnSitzungBeenden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLezteTherapie;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kantenerkennungToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button delsteps;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ToolStripMenuItem analyseToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem kinectToolStripMenuItem;
        private System.Windows.Forms.CheckBox check_autoobjekt;
        public System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lab_schrittgeschw;
        private System.Windows.Forms.Label lab_schrittgeschw_text;
        public System.Windows.Forms.TrackBar schrittgeschw;
        private System.Windows.Forms.DomainUpDown programme;
        private System.Windows.Forms.Button programmauswahl;
        private System.Windows.Forms.CheckBox zufall;
        public System.Windows.Forms.NumericUpDown steps;
    }
}

