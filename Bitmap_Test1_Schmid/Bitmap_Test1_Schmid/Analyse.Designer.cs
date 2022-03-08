
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.hintergrund = new System.Windows.Forms.PictureBox();
            this.text_länge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.hintergrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 58);
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
            this.lab_steps.Location = new System.Drawing.Point(32, 108);
            this.lab_steps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_steps.Name = "lab_steps";
            this.lab_steps.Size = new System.Drawing.Size(242, 39);
            this.lab_steps.TabIndex = 1;
            this.lab_steps.Text = "Schritteanzahl:";
            // 
            // lab_durchs
            // 
            this.lab_durchs.AutoSize = true;
            this.lab_durchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lab_durchs.ForeColor = System.Drawing.Color.White;
            this.lab_durchs.Location = new System.Drawing.Point(32, 170);
            this.lab_durchs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_durchs.Name = "lab_durchs";
            this.lab_durchs.Size = new System.Drawing.Size(316, 39);
            this.lab_durchs.TabIndex = 2;
            this.lab_durchs.Text = "Durchschnittslänge:";
            // 
            // lab_klein
            // 
            this.lab_klein.AutoSize = true;
            this.lab_klein.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lab_klein.ForeColor = System.Drawing.Color.White;
            this.lab_klein.Location = new System.Drawing.Point(32, 231);
            this.lab_klein.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_klein.Name = "lab_klein";
            this.lab_klein.Size = new System.Drawing.Size(258, 39);
            this.lab_klein.TabIndex = 3;
            this.lab_klein.Text = "kleinster Schritt:";
            // 
            // lab_groß
            // 
            this.lab_groß.AutoSize = true;
            this.lab_groß.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lab_groß.ForeColor = System.Drawing.Color.White;
            this.lab_groß.Location = new System.Drawing.Point(32, 292);
            this.lab_groß.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_groß.Name = "lab_groß";
            this.lab_groß.Size = new System.Drawing.Size(240, 39);
            this.lab_groß.TabIndex = 4;
            this.lab_groß.Text = "größter Schritt:";
            // 
            // steps
            // 
            this.steps.AutoSize = true;
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.steps.ForeColor = System.Drawing.Color.White;
            this.steps.Location = new System.Drawing.Point(389, 108);
            this.steps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(28, 39);
            this.steps.TabIndex = 5;
            this.steps.Text = "-";
            // 
            // groß
            // 
            this.groß.AutoSize = true;
            this.groß.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groß.ForeColor = System.Drawing.Color.White;
            this.groß.Location = new System.Drawing.Point(389, 292);
            this.groß.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groß.Name = "groß";
            this.groß.Size = new System.Drawing.Size(28, 39);
            this.groß.TabIndex = 6;
            this.groß.Text = "-";
            // 
            // klein
            // 
            this.klein.AutoSize = true;
            this.klein.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.klein.ForeColor = System.Drawing.Color.White;
            this.klein.Location = new System.Drawing.Point(389, 231);
            this.klein.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.klein.Name = "klein";
            this.klein.Size = new System.Drawing.Size(28, 39);
            this.klein.TabIndex = 7;
            this.klein.Text = "-";
            // 
            // durchs
            // 
            this.durchs.AutoSize = true;
            this.durchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.durchs.ForeColor = System.Drawing.Color.White;
            this.durchs.Location = new System.Drawing.Point(389, 170);
            this.durchs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.durchs.Name = "durchs";
            this.durchs.Size = new System.Drawing.Size(28, 39);
            this.durchs.TabIndex = 8;
            this.durchs.Text = "-";
            // 
            // hintergrund
            // 
            this.hintergrund.Location = new System.Drawing.Point(16, 356);
            this.hintergrund.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hintergrund.Name = "hintergrund";
            this.hintergrund.Size = new System.Drawing.Size(587, 366);
            this.hintergrund.TabIndex = 9;
            this.hintergrund.TabStop = false;
            // 
            // text_länge
            // 
            this.text_länge.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.text_länge.Location = new System.Drawing.Point(496, 356);
            this.text_länge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_länge.Name = "text_länge";
            this.text_länge.Size = new System.Drawing.Size(132, 38);
            this.text_länge.TabIndex = 10;
            this.text_länge.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(131, 356);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Länge der Projektion (cm):";
            this.label2.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(16, 356);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 52);
            this.button1.TabIndex = 12;
            this.button1.Text = "Bestätigen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.AliceBlue;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(596, 18);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.LabelBorderWidth = 5;
            series1.Name = "Soll";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.ErrorBar;
            series2.IsVisibleInLegend = false;
            series2.Name = "Ist";
            series2.YValuesPerPoint = 3;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(552, 369);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1168, 414);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_länge);
            this.Controls.Add(this.hintergrund);
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
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Analyse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analyse";
            this.TopMost = true;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Analyse_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Analyse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hintergrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.PictureBox hintergrund;
        private System.Windows.Forms.TextBox text_länge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}