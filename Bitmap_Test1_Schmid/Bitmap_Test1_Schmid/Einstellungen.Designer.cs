
namespace Bitmap_Test1_Schmid
{
    partial class Einstellungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Einstellungen));
            this.colorpicker = new System.Windows.Forms.ColorDialog();
            this.bar_dicke = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.anzeige = new System.Windows.Forms.Label();
            this.but_ändern = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colorpicker2 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bar_dicke)).BeginInit();
            this.SuspendLayout();
            // 
            // colorpicker
            // 
            this.colorpicker.AllowFullOpen = false;
            this.colorpicker.AnyColor = true;
            this.colorpicker.SolidColorOnly = true;
            // 
            // bar_dicke
            // 
            this.bar_dicke.LargeChange = 1;
            this.bar_dicke.Location = new System.Drawing.Point(14, 67);
            this.bar_dicke.Maximum = 15;
            this.bar_dicke.Minimum = 3;
            this.bar_dicke.Name = "bar_dicke";
            this.bar_dicke.Size = new System.Drawing.Size(192, 45);
            this.bar_dicke.TabIndex = 0;
            this.bar_dicke.Value = 5;
            this.bar_dicke.ValueChanged += new System.EventHandler(this.bar_dicke_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dicke der Linien:";
            // 
            // anzeige
            // 
            this.anzeige.AutoSize = true;
            this.anzeige.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.anzeige.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.anzeige.Location = new System.Drawing.Point(182, 27);
            this.anzeige.Name = "anzeige";
            this.anzeige.Size = new System.Drawing.Size(24, 26);
            this.anzeige.TabIndex = 3;
            this.anzeige.Text = "5";
            // 
            // but_ändern
            // 
            this.but_ändern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ändern.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_ändern.ForeColor = System.Drawing.Color.White;
            this.but_ändern.Location = new System.Drawing.Point(225, 16);
            this.but_ändern.Name = "but_ändern";
            this.but_ändern.Size = new System.Drawing.Size(234, 46);
            this.but_ändern.TabIndex = 5;
            this.but_ändern.Text = "Farbe der Linie ändern";
            this.but_ändern.UseVisualStyleBackColor = true;
            this.but_ändern.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(225, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Farbe der Box ändern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // colorpicker2
            // 
            this.colorpicker2.AllowFullOpen = false;
            this.colorpicker2.AnyColor = true;
            this.colorpicker2.SolidColorOnly = true;
            // 
            // Einstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(475, 143);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.but_ändern);
            this.Controls.Add(this.anzeige);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bar_dicke);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Einstellungen";
            this.ShowInTaskbar = false;
            this.Text = "Einstellungen";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Einstellungen_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Einstellungen_FormClosed);
            this.Load += new System.EventHandler(this.Einstellungen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar_dicke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar bar_dicke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label anzeige;
        private System.Windows.Forms.Button but_ändern;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ColorDialog colorpicker;
        public System.Windows.Forms.ColorDialog colorpicker2;
    }
}