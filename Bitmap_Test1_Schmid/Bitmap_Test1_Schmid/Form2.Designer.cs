
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
            this.beenden = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1078);
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
            this.bestätigen.Location = new System.Drawing.Point(45, 56);
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
            // beenden
            // 
            this.beenden.BackColor = System.Drawing.Color.Black;
            this.beenden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.beenden.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.beenden.ForeColor = System.Drawing.Color.White;
            this.beenden.Location = new System.Drawing.Point(1735, 958);
            this.beenden.Name = "beenden";
            this.beenden.Size = new System.Drawing.Size(157, 71);
            this.beenden.TabIndex = 7;
            this.beenden.Text = "Beenden";
            this.beenden.UseVisualStyleBackColor = false;
            this.beenden.Click += new System.EventHandler(this.beenden_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.beenden);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bestätigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox steps;
        private System.Windows.Forms.Button beenden;
    }
}