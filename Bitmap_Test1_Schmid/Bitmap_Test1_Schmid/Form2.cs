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
                for (x = 460; x < 1460; x++)
                {

                    for (y = 145; y < 150; y++)
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

                for (x = 50; x < 100; x++)
                {

                    for (y = 90; y < 160; y++)
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
    }


    
}
