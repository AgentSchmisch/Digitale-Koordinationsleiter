namespace kinecttest
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
            this.Xlinks = new System.Windows.Forms.Label();
            this.Ylinks = new System.Windows.Forms.Label();
            this.Zlinks = new System.Windows.Forms.Label();
            this.Zrechts = new System.Windows.Forms.Label();
            this.Yrechts = new System.Windows.Forms.Label();
            this.Xrechts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Xlinks
            // 
            this.Xlinks.AutoSize = true;
            this.Xlinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xlinks.Location = new System.Drawing.Point(34, 35);
            this.Xlinks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Xlinks.Name = "Xlinks";
            this.Xlinks.Size = new System.Drawing.Size(147, 54);
            this.Xlinks.TabIndex = 5;
            this.Xlinks.Text = "label1";
            // 
            // Ylinks
            // 
            this.Ylinks.AutoSize = true;
            this.Ylinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ylinks.Location = new System.Drawing.Point(34, 109);
            this.Ylinks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Ylinks.Name = "Ylinks";
            this.Ylinks.Size = new System.Drawing.Size(147, 54);
            this.Ylinks.TabIndex = 6;
            this.Ylinks.Text = "label2";
            // 
            // Zlinks
            // 
            this.Zlinks.AutoSize = true;
            this.Zlinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zlinks.Location = new System.Drawing.Point(34, 184);
            this.Zlinks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Zlinks.Name = "Zlinks";
            this.Zlinks.Size = new System.Drawing.Size(147, 54);
            this.Zlinks.TabIndex = 7;
            this.Zlinks.Text = "label3";
            // 
            // Zrechts
            // 
            this.Zrechts.AutoSize = true;
            this.Zrechts.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zrechts.Location = new System.Drawing.Point(292, 184);
            this.Zrechts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Zrechts.Name = "Zrechts";
            this.Zrechts.Size = new System.Drawing.Size(147, 54);
            this.Zrechts.TabIndex = 11;
            this.Zrechts.Text = "label3";
            // 
            // Yrechts
            // 
            this.Yrechts.AutoSize = true;
            this.Yrechts.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yrechts.Location = new System.Drawing.Point(292, 109);
            this.Yrechts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Yrechts.Name = "Yrechts";
            this.Yrechts.Size = new System.Drawing.Size(147, 54);
            this.Yrechts.TabIndex = 10;
            this.Yrechts.Text = "label2";
            // 
            // Xrechts
            // 
            this.Xrechts.AutoSize = true;
            this.Xrechts.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xrechts.Location = new System.Drawing.Point(292, 35);
            this.Xrechts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Xrechts.Name = "Xrechts";
            this.Xrechts.Size = new System.Drawing.Size(147, 54);
            this.Xrechts.TabIndex = 9;
            this.Xrechts.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 268);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 54);
            this.label1.TabIndex = 12;
            this.label1.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 349);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zrechts);
            this.Controls.Add(this.Yrechts);
            this.Controls.Add(this.Xrechts);
            this.Controls.Add(this.Zlinks);
            this.Controls.Add(this.Ylinks);
            this.Controls.Add(this.Xlinks);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Xlinks;
        private System.Windows.Forms.Label Ylinks;
        private System.Windows.Forms.Label Zlinks;
        private System.Windows.Forms.Label Zrechts;
        private System.Windows.Forms.Label Yrechts;
        private System.Windows.Forms.Label Xrechts;
        private System.Windows.Forms.Label label1;
    }
}

