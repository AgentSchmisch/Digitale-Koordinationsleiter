
namespace Bitmap_Test1_Schmid
{
    partial class Form2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bestätigen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.steps = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.regler = new System.Windows.Forms.TrackBar();
            this.reglertext = new System.Windows.Forms.Label();
            this.fläche = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regler)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // bestätigen
            // 
            this.bestätigen.BackColor = System.Drawing.Color.Black;
            this.bestätigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bestätigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.bestätigen.ForeColor = System.Drawing.Color.White;
            this.bestätigen.Location = new System.Drawing.Point(50, 76);
            this.bestätigen.Name = "bestätigen";
            this.bestätigen.Size = new System.Drawing.Size(156, 70);
            this.bestätigen.TabIndex = 6;
            this.bestätigen.Text = "bestätigen";
            this.bestätigen.UseVisualStyleBackColor = false;
            this.bestätigen.Click += new System.EventHandler(this.bestätigen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Schritte:";
            // 
            // steps
            // 
            this.steps.BackColor = System.Drawing.Color.Black;
            this.steps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.steps.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.steps.ForeColor = System.Drawing.Color.White;
            this.steps.Location = new System.Drawing.Point(144, 12);
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(78, 38);
            this.steps.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.button1.Location = new System.Drawing.Point(1822, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // regler
            // 
            this.regler.BackColor = System.Drawing.Color.Black;
            this.regler.Location = new System.Drawing.Point(375, 28);
            this.regler.Name = "regler";
            this.regler.Size = new System.Drawing.Size(273, 45);
            this.regler.TabIndex = 9;
            this.regler.ValueChanged += new System.EventHandler(this.regler_ValueChanged);
            // 
            // reglertext
            // 
            this.reglertext.AutoSize = true;
            this.reglertext.BackColor = System.Drawing.Color.Black;
            this.reglertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.reglertext.ForeColor = System.Drawing.SystemColors.Control;
            this.reglertext.Location = new System.Drawing.Point(497, 76);
            this.reglertext.Name = "reglertext";
            this.reglertext.Size = new System.Drawing.Size(24, 26);
            this.reglertext.TabIndex = 10;
            this.reglertext.Text = "1";
            // 
            // fläche
            // 
            this.fläche.BackColor = System.Drawing.Color.Black;
            this.fläche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fläche.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.fläche.ForeColor = System.Drawing.Color.White;
            this.fläche.Location = new System.Drawing.Point(432, 124);
            this.fläche.Name = "fläche";
            this.fläche.Size = new System.Drawing.Size(156, 70);
            this.fläche.TabIndex = 11;
            this.fläche.Text = "bestätigen";
            this.fläche.UseVisualStyleBackColor = false;
            this.fläche.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.fläche);
            this.Controls.Add(this.reglertext);
            this.Controls.Add(this.regler);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steps);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Virtual Walkway";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bestätigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox steps;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar regler;
        private System.Windows.Forms.Label reglertext;
        private System.Windows.Forms.Button fläche;
    }
}