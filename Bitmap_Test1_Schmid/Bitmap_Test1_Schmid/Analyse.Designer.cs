
namespace Bitmap_Test1_Schmid
{
    partial class Analyse
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Analyse));
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lab_steps = new System.Windows.Forms.Label();
            this.lab_durchs = new System.Windows.Forms.Label();
            this.lab_klein = new System.Windows.Forms.Label();
            this.lab_groß = new System.Windows.Forms.Label();
            this.steps = new System.Windows.Forms.Label();
            this.groß = new System.Windows.Forms.Label();
            this.klein = new System.Windows.Forms.Label();
            this.durchs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Analyse";
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lab_steps
            // 
            this.lab_steps.AutoSize = true;
            this.lab_steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lab_steps.ForeColor = System.Drawing.Color.White;
            this.lab_steps.Location = new System.Drawing.Point(22, 102);
            this.lab_steps.Name = "lab_steps";
            this.lab_steps.Size = new System.Drawing.Size(195, 31);
            this.lab_steps.TabIndex = 1;
            this.lab_steps.Text = "Schritteanzahl:";
            // 
            // lab_durchs
            // 
            this.lab_durchs.AutoSize = true;
            this.lab_durchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lab_durchs.ForeColor = System.Drawing.Color.White;
            this.lab_durchs.Location = new System.Drawing.Point(22, 152);
            this.lab_durchs.Name = "lab_durchs";
            this.lab_durchs.Size = new System.Drawing.Size(255, 31);
            this.lab_durchs.TabIndex = 2;
            this.lab_durchs.Text = "Durchschnittslänge:";
            // 
            // lab_klein
            // 
            this.lab_klein.AutoSize = true;
            this.lab_klein.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lab_klein.ForeColor = System.Drawing.Color.White;
            this.lab_klein.Location = new System.Drawing.Point(22, 202);
            this.lab_klein.Name = "lab_klein";
            this.lab_klein.Size = new System.Drawing.Size(209, 31);
            this.lab_klein.TabIndex = 3;
            this.lab_klein.Text = "kleinster Schritt:";
            // 
            // lab_groß
            // 
            this.lab_groß.AutoSize = true;
            this.lab_groß.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lab_groß.ForeColor = System.Drawing.Color.White;
            this.lab_groß.Location = new System.Drawing.Point(22, 251);
            this.lab_groß.Name = "lab_groß";
            this.lab_groß.Size = new System.Drawing.Size(195, 31);
            this.lab_groß.TabIndex = 4;
            this.lab_groß.Text = "größter Schritt:";
            // 
            // steps
            // 
            this.steps.AutoSize = true;
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.steps.ForeColor = System.Drawing.Color.White;
            this.steps.Location = new System.Drawing.Point(290, 102);
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(23, 31);
            this.steps.TabIndex = 5;
            this.steps.Text = "-";
            // 
            // groß
            // 
            this.groß.AutoSize = true;
            this.groß.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groß.ForeColor = System.Drawing.Color.White;
            this.groß.Location = new System.Drawing.Point(290, 251);
            this.groß.Name = "groß";
            this.groß.Size = new System.Drawing.Size(23, 31);
            this.groß.TabIndex = 6;
            this.groß.Text = "-";
            // 
            // klein
            // 
            this.klein.AutoSize = true;
            this.klein.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.klein.ForeColor = System.Drawing.Color.White;
            this.klein.Location = new System.Drawing.Point(290, 202);
            this.klein.Name = "klein";
            this.klein.Size = new System.Drawing.Size(23, 31);
            this.klein.TabIndex = 7;
            this.klein.Text = "-";
            // 
            // durchs
            // 
            this.durchs.AutoSize = true;
            this.durchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.durchs.ForeColor = System.Drawing.Color.White;
            this.durchs.Location = new System.Drawing.Point(290, 152);
            this.durchs.Name = "durchs";
            this.durchs.Size = new System.Drawing.Size(23, 31);
            this.durchs.TabIndex = 8;
            this.durchs.Text = "-";
            // 
            // Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(528, 257);
            this.Controls.Add(this.durchs);
            this.Controls.Add(this.klein);
            this.Controls.Add(this.groß);
            this.Controls.Add(this.steps);
            this.Controls.Add(this.lab_groß);
            this.Controls.Add(this.lab_klein);
            this.Controls.Add(this.lab_durchs);
            this.Controls.Add(this.lab_steps);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Analyse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analyse";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Analyse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lab_steps;
        private System.Windows.Forms.Label lab_durchs;
        private System.Windows.Forms.Label lab_klein;
        private System.Windows.Forms.Label lab_groß;
        private System.Windows.Forms.Label steps;
        private System.Windows.Forms.Label groß;
        private System.Windows.Forms.Label klein;
        private System.Windows.Forms.Label durchs;
    }
}