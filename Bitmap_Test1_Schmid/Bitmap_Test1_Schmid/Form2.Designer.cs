
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
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
            this.bestätigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bestätigen.Location = new System.Drawing.Point(48, 44);
            this.bestätigen.Name = "bestätigen";
            this.bestätigen.Size = new System.Drawing.Size(96, 40);
            this.bestätigen.TabIndex = 6;
            this.bestätigen.Text = "bestätigen";
            this.bestätigen.UseVisualStyleBackColor = true;
            this.bestätigen.Click += new System.EventHandler(this.bestätigen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Schritte:";
            // 
            // steps
            // 
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.steps.Location = new System.Drawing.Point(110, 6);
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(71, 32);
            this.steps.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steps);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}