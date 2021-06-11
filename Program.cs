using System;
using System.Windows.Forms;
using XBLMarketplace_For_PC.Forms;

namespace XBLMarketplace_For_PC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
