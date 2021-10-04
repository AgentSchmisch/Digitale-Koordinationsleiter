
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
            this.colorpicker = new System.Windows.Forms.ColorDialog();
            this.bar_dicke = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.but_dicke = new System.Windows.Forms.Button();
            this.anzeige = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.but_ändern = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bar_dicke)).BeginInit();
            this.SuspendLayout();
            // 
            // bar_dicke
            // 
            this.bar_dicke.LargeChange = 1;
            this.bar_dicke.Location = new System.Drawing.Point(35, 71);
            this.bar_dicke.Maximum = 15;
            this.bar_dicke.Minimum = 3;
            this.bar_dicke.Name = "bar_dicke";
            this.bar_dicke.Size = new System.Drawing.Size(192, 45);
            this.bar_dicke.TabIndex = 0;
            this.bar_dicke.Value = 3;
            this.bar_dicke.ValueChanged += new System.EventHandler(this.bar_dicke_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dicke der Linien:";
            // 
            // but_dicke
            // 
            this.but_dicke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_dicke.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_dicke.ForeColor = System.Drawing.Color.White;
            this.but_dicke.Location = new System.Drawing.Point(72, 122);
            this.but_dicke.Name = "but_dicke";
            this.but_dicke.Size = new System.Drawing.Size(116, 46);
            this.but_dicke.TabIndex = 2;
            this.but_dicke.Text = "Bestätigen";
            this.but_dicke.UseVisualStyleBackColor = true;
            this.but_dicke.Click += new System.EventHandler(this.but_dicke_Click);
            // 
            // anzeige
            // 
            this.anzeige.AutoSize = true;
            this.anzeige.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.anzeige.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.anzeige.Location = new System.Drawing.Point(203, 31);
            this.anzeige.Name = "anzeige";
            this.anzeige.Size = new System.Drawing.Size(24, 26);
            this.anzeige.TabIndex = 3;
            this.anzeige.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(260, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Farbe der Linien:";
            // 
            // but_ändern
            // 
            this.but_ändern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_ändern.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.but_ändern.ForeColor = System.Drawing.Color.White;
            this.but_ändern.Location = new System.Drawing.Point(286, 71);
            this.but_ändern.Name = "but_ändern";
            this.but_ändern.Size = new System.Drawing.Size(116, 46);
            this.but_ändern.TabIndex = 5;
            this.but_ändern.Text = "Ändern";
            this.but_ändern.UseVisualStyleBackColor = true;
            this.but_ändern.Click += new System.EventHandler(this.button1_Click);
            // 
            // Einstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(468, 197);
            this.Controls.Add(this.but_ändern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anzeige);
            this.Controls.Add(this.but_dicke);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bar_dicke);
            this.Name = "Einstellungen";
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.Einstellungen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar_dicke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorpicker;
        private System.Windows.Forms.TrackBar bar_dicke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_dicke;
        private System.Windows.Forms.Label anzeige;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_ändern;
    }
}