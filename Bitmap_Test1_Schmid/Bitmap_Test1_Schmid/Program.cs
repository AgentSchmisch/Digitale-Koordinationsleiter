using System;
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
                //Application.Run(new Form1());
                Application.Run(new Analyse());
            }
            catch
            {
                if (MessageBox.Show("Fatal Error", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }
    }
}
