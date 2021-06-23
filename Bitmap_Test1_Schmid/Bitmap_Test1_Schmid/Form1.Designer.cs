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
            this.steps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bestätigen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.längelabel = new System.Windows.Forms.Label();
            this.längebox = new System.Windows.Forms.TrackBar();
            this.fläche = new System.Windows.Forms.Button();
            this.reglertext = new System.Windows.Forms.Label();
            this.regler = new System.Windows.Forms.TrackBar();
            this.länge = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.längebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // steps
            // 
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.steps.Location = new System.Drawing.Point(154, 120);
            this.steps.MaxLength = 2;
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(71, 38);
            this.steps.TabIndex = 1;
            this.steps.Text = "10";
            this.steps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.steps_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(33, 127);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Schritte:";
            // 
            // bestätigen
            // 
            this.bestätigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bestätigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.bestätigen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bestätigen.Location = new System.Drawing.Point(55, 179);
            this.bestätigen.Name = "bestätigen";
            this.bestätigen.Size = new System.Drawing.Size(160, 56);
            this.bestätigen.TabIndex = 3;
            this.bestätigen.Text = "bestätigen";
            this.bestätigen.UseVisualStyleBackColor = true;
            this.bestätigen.Click += new System.EventHandler(this.bestätigen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(343, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 26);
            this.label2.TabIndex = 20;
            this.label2.Text = "Länge des Objektes:";
            // 
            // längelabel
            // 
            this.längelabel.Location = new System.Drawing.Point(0, 0);
            this.längelabel.Name = "längelabel";
            this.längelabel.Size = new System.Drawing.Size(100, 23);
            this.längelabel.TabIndex = 21;
            // 
            // längebox
            // 
            this.längebox.BackColor = System.Drawing.Color.DimGray;
            this.längebox.Enabled = false;
            this.längebox.LargeChange = 2;
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
            this.fläche.BackColor = System.Drawing.Color.DimGray;
            this.fläche.Enabled = false;
            this.fläche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fläche.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.fläche.ForeColor = System.Drawing.Color.White;
            this.fläche.Location = new System.Drawing.Point(357, 269);
            this.fläche.Name = "fläche";
            this.fläche.Size = new System.Drawing.Size(156, 70);
            this.fläche.TabIndex = 17;
            this.fläche.Text = "bestätigen";
            this.fläche.UseVisualStyleBackColor = false;
            this.fläche.Click += new System.EventHandler(this.fläche_Click);
            // 
            // reglertext
            // 
            this.reglertext.AutoSize = true;
            this.reglertext.BackColor = System.Drawing.Color.DimGray;
            this.reglertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.reglertext.ForeColor = System.Drawing.Color.Gray;
            this.reglertext.Location = new System.Drawing.Point(427, 87);
            this.reglertext.Name = "reglertext";
            this.reglertext.Size = new System.Drawing.Size(24, 26);
            this.reglertext.TabIndex = 16;
            this.reglertext.Text = "0";
            // 
            // regler
            // 
            this.regler.BackColor = System.Drawing.Color.DimGray;
            this.regler.Enabled = false;
            this.regler.LargeChange = 2;
            this.regler.Location = new System.Drawing.Point(305, 39);
            this.regler.Name = "regler";
            this.regler.Size = new System.Drawing.Size(273, 45);
            this.regler.TabIndex = 15;
            this.regler.ValueChanged += new System.EventHandler(this.regler_ValueChanged);
            this.regler.KeyDown += new System.Windows.Forms.KeyEventHandler(this.regler_KeyDown);
            // 
            // länge
            // 
            this.länge.AutoSize = true;
            this.länge.BackColor = System.Drawing.Color.DimGray;
            this.länge.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.länge.ForeColor = System.Drawing.Color.Gray;
            this.länge.Location = new System.Drawing.Point(427, 228);
            this.länge.Name = "länge";
            this.länge.Size = new System.Drawing.Size(24, 26);
            this.länge.TabIndex = 22;
            this.länge.Text = "1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bitmap_Test1_Schmid.Properties.Resources.HTLMI_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.ForeColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(584, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button2.ForeColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(584, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 40);
            this.button2.TabIndex = 25;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(650, 370);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.länge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.längelabel);
            this.Controls.Add(this.längebox);
            this.Controls.Add(this.fläche);
            this.Controls.Add(this.reglertext);
            this.Controls.Add(this.regler);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steps);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digitale Koordinationsleiter";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.längebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        public System.Windows.Forms.TextBox steps;
        public System.Windows.Forms.TrackBar regler;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label reglertext;
        public System.Windows.Forms.Label länge;
    }
}

