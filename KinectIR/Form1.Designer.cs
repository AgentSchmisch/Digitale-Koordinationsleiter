
namespace KinectIR
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.anzeige = new System.Windows.Forms.Label();
            this.kal = new System.Windows.Forms.Button();
            this.k1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.k2 = new System.Windows.Forms.Label();
            this.k3 = new System.Windows.Forms.Label();
            this.k4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(822, 646);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(71, 654);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(193, 45);
            this.trackBar1.TabIndex = 1;
            // 
            // anzeige
            // 
            this.anzeige.AutoSize = true;
            this.anzeige.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.anzeige.Location = new System.Drawing.Point(823, 187);
            this.anzeige.Name = "anzeige";
            this.anzeige.Size = new System.Drawing.Size(16, 24);
            this.anzeige.TabIndex = 2;
            this.anzeige.Text = "-";
            // 
            // kal
            // 
            this.kal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.kal.Location = new System.Drawing.Point(823, 616);
            this.kal.Name = "kal";
            this.kal.Size = new System.Drawing.Size(127, 42);
            this.kal.TabIndex = 3;
            this.kal.Text = "Kalibrieren";
            this.kal.UseVisualStyleBackColor = true;
            this.kal.UseWaitCursor = true;
            this.kal.Click += new System.EventHandler(this.kal_Click);
            // 
            // k1
            // 
            this.k1.AutoSize = true;
            this.k1.BackColor = System.Drawing.Color.Transparent;
            this.k1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.k1.Location = new System.Drawing.Point(986, 33);
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(51, 20);
            this.k1.TabIndex = 4;
            this.k1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(819, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "-";
            // 
            // k2
            // 
            this.k2.AutoSize = true;
            this.k2.BackColor = System.Drawing.Color.Transparent;
            this.k2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.k2.Location = new System.Drawing.Point(986, 53);
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(51, 20);
            this.k2.TabIndex = 6;
            this.k2.Text = "label1";
            // 
            // k3
            // 
            this.k3.AutoSize = true;
            this.k3.BackColor = System.Drawing.Color.Transparent;
            this.k3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.k3.Location = new System.Drawing.Point(986, 73);
            this.k3.Name = "k3";
            this.k3.Size = new System.Drawing.Size(51, 20);
            this.k3.TabIndex = 7;
            this.k3.Text = "label1";
            // 
            // k4
            // 
            this.k4.AutoSize = true;
            this.k4.BackColor = System.Drawing.Color.Transparent;
            this.k4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.k4.Location = new System.Drawing.Point(986, 93);
            this.k4.Name = "k4";
            this.k4.Size = new System.Drawing.Size(51, 20);
            this.k4.TabIndex = 8;
            this.k4.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 704);
            this.Controls.Add(this.k4);
            this.Controls.Add(this.k3);
            this.Controls.Add(this.k2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.k1);
            this.Controls.Add(this.kal);
            this.Controls.Add(this.anzeige);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label anzeige;
        private System.Windows.Forms.Button kal;
        public System.Windows.Forms.Label k1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label k2;
        public System.Windows.Forms.Label k3;
        public System.Windows.Forms.Label k4;
    }
}

