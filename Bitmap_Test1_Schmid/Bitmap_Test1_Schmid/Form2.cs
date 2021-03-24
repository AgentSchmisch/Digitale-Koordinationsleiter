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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            
        }
        Bitmap image1;
        private void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                image1 = new Bitmap(1920,1080);

                int x, y;


                // Loop through the images pixels to reset color.
                for (x = 0; x < image1.Width; x++)
                {

                    for (y = 245; y < 250; y++)
                    {


                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(169, 20, 20);
                        image1.SetPixel(x, y, newColor);
                    }
                }
                // Loop through the images pixels to reset color.
                for (x = 0; x < image1.Width; x++)
                {

                    for (y = 95; y < 100; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(169, 20, 20);
                        image1.SetPixel(x, y, newColor);
                    }
                }

                for (x = 150; x < 300; x++)
                {

                    for (y = 90; y < 260; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        Color newColor = Color.FromArgb(150, 100, 20, 160);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }


    
}
