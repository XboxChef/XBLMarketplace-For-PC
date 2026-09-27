using System;
using System.Net;
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
            //.NET Framework allows only 2 connections per host by default, which would serialize parallel link checks
            ServicePointManager.DefaultConnectionLimit = 16;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
