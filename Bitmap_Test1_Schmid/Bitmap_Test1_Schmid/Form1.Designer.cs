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
            this.SuspendLayout();
            // 
            // steps
            // 
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.steps.Location = new System.Drawing.Point(116, 22);
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(71, 32);
            this.steps.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Schritte:";
            // 
            // bestätigen
            // 
            this.bestätigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bestätigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bestätigen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bestätigen.Location = new System.Drawing.Point(70, 72);
            this.bestätigen.Name = "bestätigen";
            this.bestätigen.Size = new System.Drawing.Size(96, 40);
            this.bestätigen.TabIndex = 3;
            this.bestätigen.Text = "bestätigen";
            this.bestätigen.UseVisualStyleBackColor = true;
            this.bestätigen.Click += new System.EventHandler(this.bestätigen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(235, 124);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exit";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox steps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bestätigen;
    }
}

