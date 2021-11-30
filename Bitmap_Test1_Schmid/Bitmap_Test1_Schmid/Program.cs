using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitmap_Test1_Schmid
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch 
            {
                if(MessageBox.Show("Fatal Error", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }
    }
}
