using Carros.Cadastros;
using System;
using System.Windows.Forms;

namespace Carros
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IOC.StructureMapIOC.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMenu());
            Application.Run(new frmLogin());
        }
    }
}
