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
        Form2 screen=new Form2();
        public static int schritt = 0;

        public Form1()
        {
            InitializeComponent();
            screen.Show();

    }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void bestätigen_Click(object sender, EventArgs e)
        {
            //schritt=Convert.ToInt32(steps.Text);
            Form2.sendvar = Convert.ToInt32(steps.Text);
            screen.bestätigen.PerformClick();
        }
    }
}
