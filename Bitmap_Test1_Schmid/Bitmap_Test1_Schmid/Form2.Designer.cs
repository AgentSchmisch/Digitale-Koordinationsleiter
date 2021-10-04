
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.bestätigen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.steps = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.regler = new System.Windows.Forms.TrackBar();
            this.reglertext = new System.Windows.Forms.Label();
            this.fläche = new System.Windows.Forms.Button();
            this.längebox = new System.Windows.Forms.TrackBar();
            this.längelabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.left_one = new System.Windows.Forms.PictureBox();
            this.right_one = new System.Windows.Forms.PictureBox();
            this.right_two = new System.Windows.Forms.PictureBox();
            this.left_two = new System.Windows.Forms.PictureBox();
            this.right_three = new System.Windows.Forms.PictureBox();
            this.left_three = new System.Windows.Forms.PictureBox();
            this.right_four = new System.Windows.Forms.PictureBox();
            this.left_four = new System.Windows.Forms.PictureBox();
            this.right_five = new System.Windows.Forms.PictureBox();
            this.left_five = new System.Windows.Forms.PictureBox();
            this.right_six = new System.Windows.Forms.PictureBox();
            this.left_six = new System.Windows.Forms.PictureBox();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            ((System.ComponentModel.ISupportInitialize)(this.regler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.längebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_one)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_one)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_two)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_two)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_three)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_three)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_four)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_four)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_five)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_five)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_six)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_six)).BeginInit();
            this.SuspendLayout();
            // 
            // bestätigen
            // 
            this.bestätigen.BackColor = System.Drawing.Color.Black;
            this.bestätigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bestätigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.bestätigen.ForeColor = System.Drawing.Color.Black;
            this.bestätigen.Location = new System.Drawing.Point(80, 96);
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
            this.label1.Location = new System.Drawing.Point(53, 51);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Schritte:";
            this.label1.Visible = false;
            // 
            // steps
            // 
            this.steps.BackColor = System.Drawing.Color.Black;
            this.steps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.steps.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.steps.ForeColor = System.Drawing.Color.White;
            this.steps.Location = new System.Drawing.Point(174, 49);
            this.steps.MaxLength = 2;
            this.steps.Name = "steps";
            this.steps.Size = new System.Drawing.Size(78, 38);
            this.steps.TabIndex = 4;
            this.steps.Text = "10";
            this.steps.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.button1.Location = new System.Drawing.Point(1845, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // regler
            // 
            this.regler.BackColor = System.Drawing.Color.Black;
            this.regler.Location = new System.Drawing.Point(367, 51);
            this.regler.Maximum = 20;
            this.regler.Name = "regler";
            this.regler.Size = new System.Drawing.Size(273, 45);
            this.regler.TabIndex = 9;
            this.regler.Value = 1;
            this.regler.Visible = false;
            this.regler.Scroll += new System.EventHandler(this.regler_Scroll);
            this.regler.ValueChanged += new System.EventHandler(this.regler_ValueChanged);
            // 
            // reglertext
            // 
            this.reglertext.AutoSize = true;
            this.reglertext.BackColor = System.Drawing.Color.Black;
            this.reglertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.reglertext.ForeColor = System.Drawing.SystemColors.Control;
            this.reglertext.Location = new System.Drawing.Point(489, 99);
            this.reglertext.Name = "reglertext";
            this.reglertext.Size = new System.Drawing.Size(24, 26);
            this.reglertext.TabIndex = 10;
            this.reglertext.Text = "0";
            this.reglertext.Visible = false;
            // 
            // fläche
            // 
            this.fläche.BackColor = System.Drawing.Color.Black;
            this.fläche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fläche.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.fläche.ForeColor = System.Drawing.Color.Black;
            this.fläche.Location = new System.Drawing.Point(610, 96);
            this.fläche.Name = "fläche";
            this.fläche.Size = new System.Drawing.Size(156, 70);
            this.fläche.TabIndex = 11;
            this.fläche.Text = "bestätigen";
            this.fläche.UseVisualStyleBackColor = false;
            this.fläche.Click += new System.EventHandler(this.button2_Click);
            // 
            // längebox
            // 
            this.längebox.BackColor = System.Drawing.Color.Black;
            this.längebox.Location = new System.Drawing.Point(750, 51);
            this.längebox.Minimum = 1;
            this.längebox.Name = "längebox";
            this.längebox.Size = new System.Drawing.Size(273, 45);
            this.längebox.TabIndex = 12;
            this.längebox.Value = 1;
            this.längebox.Visible = false;
            this.längebox.ValueChanged += new System.EventHandler(this.längebox_ValueChanged);
            // 
            // längelabel
            // 
            this.längelabel.AutoSize = true;
            this.längelabel.BackColor = System.Drawing.Color.Black;
            this.längelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.längelabel.ForeColor = System.Drawing.SystemColors.Control;
            this.längelabel.Location = new System.Drawing.Point(881, 109);
            this.längelabel.Name = "längelabel";
            this.längelabel.Size = new System.Drawing.Size(24, 26);
            this.längelabel.TabIndex = 13;
            this.längelabel.Text = "1";
            this.längelabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(785, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "Länge des Objektes:";
            this.label2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1078);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // left_one
            // 
            this.left_one.BackColor = System.Drawing.Color.Transparent;
            this.left_one.Cursor = System.Windows.Forms.Cursors.Default;
            this.left_one.Image = global::Bitmap_Test1_Schmid.Properties.Resources.left;
            this.left_one.InitialImage = null;
            this.left_one.Location = new System.Drawing.Point(25, 148);
            this.left_one.Name = "left_one";
            this.left_one.Size = new System.Drawing.Size(155, 73);
            this.left_one.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_one.TabIndex = 15;
            this.left_one.TabStop = false;
            // 
            // right_one
            // 
            this.right_one.BackColor = System.Drawing.Color.Black;
            this.right_one.Image = ((System.Drawing.Image)(resources.GetObject("right_one.Image")));
            this.right_one.InitialImage = ((System.Drawing.Image)(resources.GetObject("right_one.InitialImage")));
            this.right_one.Location = new System.Drawing.Point(25, 227);
            this.right_one.Name = "right_one";
            this.right_one.Size = new System.Drawing.Size(155, 73);
            this.right_one.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_one.TabIndex = 16;
            this.right_one.TabStop = false;
            // 
            // right_two
            // 
            this.right_two.BackColor = System.Drawing.Color.Black;
            this.right_two.Image = ((System.Drawing.Image)(resources.GetObject("right_two.Image")));
            this.right_two.InitialImage = ((System.Drawing.Image)(resources.GetObject("right_two.InitialImage")));
            this.right_two.Location = new System.Drawing.Point(186, 227);
            this.right_two.Name = "right_two";
            this.right_two.Size = new System.Drawing.Size(155, 73);
            this.right_two.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_two.TabIndex = 18;
            this.right_two.TabStop = false;
            // 
            // left_two
            // 
            this.left_two.BackColor = System.Drawing.Color.Black;
            this.left_two.Image = ((System.Drawing.Image)(resources.GetObject("left_two.Image")));
            this.left_two.InitialImage = ((System.Drawing.Image)(resources.GetObject("left_two.InitialImage")));
            this.left_two.Location = new System.Drawing.Point(186, 148);
            this.left_two.Name = "left_two";
            this.left_two.Size = new System.Drawing.Size(155, 73);
            this.left_two.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_two.TabIndex = 17;
            this.left_two.TabStop = false;
            // 
            // right_three
            // 
            this.right_three.BackColor = System.Drawing.Color.Black;
            this.right_three.Image = ((System.Drawing.Image)(resources.GetObject("right_three.Image")));
            this.right_three.InitialImage = ((System.Drawing.Image)(resources.GetObject("right_three.InitialImage")));
            this.right_three.Location = new System.Drawing.Point(347, 227);
            this.right_three.Name = "right_three";
            this.right_three.Size = new System.Drawing.Size(155, 73);
            this.right_three.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_three.TabIndex = 20;
            this.right_three.TabStop = false;
            // 
            // left_three
            // 
            this.left_three.BackColor = System.Drawing.Color.Black;
            this.left_three.Image = ((System.Drawing.Image)(resources.GetObject("left_three.Image")));
            this.left_three.InitialImage = ((System.Drawing.Image)(resources.GetObject("left_three.InitialImage")));
            this.left_three.Location = new System.Drawing.Point(347, 148);
            this.left_three.Name = "left_three";
            this.left_three.Size = new System.Drawing.Size(155, 73);
            this.left_three.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_three.TabIndex = 19;
            this.left_three.TabStop = false;
            // 
            // right_four
            // 
            this.right_four.BackColor = System.Drawing.Color.Black;
            this.right_four.Image = ((System.Drawing.Image)(resources.GetObject("right_four.Image")));
            this.right_four.InitialImage = ((System.Drawing.Image)(resources.GetObject("right_four.InitialImage")));
            this.right_four.Location = new System.Drawing.Point(508, 227);
            this.right_four.Name = "right_four";
            this.right_four.Size = new System.Drawing.Size(155, 73);
            this.right_four.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_four.TabIndex = 22;
            this.right_four.TabStop = false;
            // 
            // left_four
            // 
            this.left_four.BackColor = System.Drawing.Color.Black;
            this.left_four.Image = ((System.Drawing.Image)(resources.GetObject("left_four.Image")));
            this.left_four.InitialImage = ((System.Drawing.Image)(resources.GetObject("left_four.InitialImage")));
            this.left_four.Location = new System.Drawing.Point(508, 148);
            this.left_four.Name = "left_four";
            this.left_four.Size = new System.Drawing.Size(155, 73);
            this.left_four.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_four.TabIndex = 21;
            this.left_four.TabStop = false;
            // 
            // right_five
            // 
            this.right_five.BackColor = System.Drawing.Color.Black;
            this.right_five.Image = ((System.Drawing.Image)(resources.GetObject("right_five.Image")));
            this.right_five.InitialImage = ((System.Drawing.Image)(resources.GetObject("right_five.InitialImage")));
            this.right_five.Location = new System.Drawing.Point(669, 227);
            this.right_five.Name = "right_five";
            this.right_five.Size = new System.Drawing.Size(155, 73);
            this.right_five.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_five.TabIndex = 24;
            this.right_five.TabStop = false;
            // 
            // left_five
            // 
            this.left_five.BackColor = System.Drawing.Color.Black;
            this.left_five.Image = ((System.Drawing.Image)(resources.GetObject("left_five.Image")));
            this.left_five.InitialImage = ((System.Drawing.Image)(resources.GetObject("left_five.InitialImage")));
            this.left_five.Location = new System.Drawing.Point(669, 148);
            this.left_five.Name = "left_five";
            this.left_five.Size = new System.Drawing.Size(155, 73);
            this.left_five.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_five.TabIndex = 23;
            this.left_five.TabStop = false;
            // 
            // right_six
            // 
            this.right_six.BackColor = System.Drawing.Color.Black;
            this.right_six.Image = ((System.Drawing.Image)(resources.GetObject("right_six.Image")));
            this.right_six.InitialImage = ((System.Drawing.Image)(resources.GetObject("right_six.InitialImage")));
            this.right_six.Location = new System.Drawing.Point(830, 227);
            this.right_six.Name = "right_six";
            this.right_six.Size = new System.Drawing.Size(155, 73);
            this.right_six.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_six.TabIndex = 26;
            this.right_six.TabStop = false;
            // 
            // left_six
            // 
            this.left_six.BackColor = System.Drawing.Color.Black;
            this.left_six.Image = ((System.Drawing.Image)(resources.GetObject("left_six.Image")));
            this.left_six.InitialImage = ((System.Drawing.Image)(resources.GetObject("left_six.InitialImage")));
            this.left_six.Location = new System.Drawing.Point(830, 148);
            this.left_six.Name = "left_six";
            this.left_six.Size = new System.Drawing.Size(155, 73);
            this.left_six.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_six.TabIndex = 25;
            this.left_six.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1455, 894);
            this.Controls.Add(this.right_six);
            this.Controls.Add(this.left_six);
            this.Controls.Add(this.right_five);
            this.Controls.Add(this.left_five);
            this.Controls.Add(this.right_four);
            this.Controls.Add(this.left_four);
            this.Controls.Add(this.right_three);
            this.Controls.Add(this.left_three);
            this.Controls.Add(this.right_two);
            this.Controls.Add(this.left_two);
            this.Controls.Add(this.right_one);
            this.Controls.Add(this.left_one);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.längelabel);
            this.Controls.Add(this.längebox);
            this.Controls.Add(this.fläche);
            this.Controls.Add(this.reglertext);
            this.Controls.Add(this.regler);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bestätigen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.steps);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Virtuelle Oberfläche";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.regler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.längebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_one)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_one)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_two)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_two)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_three)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_three)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_four)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_four)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_five)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_five)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_six)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_six)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox steps;
        public System.Windows.Forms.Button fläche;
        public System.Windows.Forms.TrackBar regler;
        public System.Windows.Forms.TrackBar längebox;
        public System.Windows.Forms.Label reglertext;
        public System.Windows.Forms.Label längelabel;
        public System.Windows.Forms.Button bestätigen;
        private System.Windows.Forms.PictureBox left_one;
        private System.Windows.Forms.PictureBox right_one;
        private System.Windows.Forms.PictureBox right_two;
        private System.Windows.Forms.PictureBox left_two;
        private System.Windows.Forms.PictureBox right_three;
        private System.Windows.Forms.PictureBox left_three;
        private System.Windows.Forms.PictureBox right_four;
        private System.Windows.Forms.PictureBox left_four;
        private System.Windows.Forms.PictureBox right_five;
        private System.Windows.Forms.PictureBox left_five;
        private System.Windows.Forms.PictureBox right_six;
        private System.Windows.Forms.PictureBox left_six;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
    }
}