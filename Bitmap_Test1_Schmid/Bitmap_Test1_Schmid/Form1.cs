using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap image1;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                image1 = new Bitmap(600,400);
                
                int x=Convert.ToInt32(textBox1.Text);
                int y=Convert.ToInt32(textBox2.Text);

                // Loop through the images pixels to reset color.
                for (x = Convert.ToInt32(textBox1.Text);  x < image1.Width; x++)
                {

                    for (y = Convert.ToInt32(textBox2.Text); y<image1.Height;y++)
                    {


                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(169, 20, 20);
                        image1.SetPixel(x, y, newColor);
                    }
                }

                // Set the PictureBox to display the image.
                pictureBox1.Image = image1;

                // Display the pixel format in Label1.
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Fehler");
            }
        }




    }
}
