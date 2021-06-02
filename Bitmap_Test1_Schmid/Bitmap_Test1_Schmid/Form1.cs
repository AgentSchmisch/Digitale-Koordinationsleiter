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

        private void fläche_Click(object sender, EventArgs e)
        {
            längebox.Maximum = Convert.ToInt32(steps.Text) - regler.Value;
            screen.längebox.Maximum = längebox.Maximum;
            screen.fläche.PerformClick();
        }

        private void längebox_ValueChanged(object sender, EventArgs e)
        {
            länge.Text = längebox.Value.ToString();
            screen.längebox.Value = Convert.ToInt32(länge.Text);
            screen.längelabel.Text = länge.Text;
        }

        private void regler_ValueChanged(object sender, EventArgs e)
        {
            reglertext.Text = regler.Value.ToString();
            screen.regler.Value = Convert.ToInt32(reglertext.Text);
            screen.reglertext.Text = reglertext.Text;
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
        }  
    }
}
