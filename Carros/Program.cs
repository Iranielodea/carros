using Carros.Cadastros;
using Carros.CrosPlataform;
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
            CompositionRoot.Wire(new ApplicationModule());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMenu());
            Application.Run(CompositionRoot.Resolve<frmLogin>());
           // Application.Run(new frmLogin());
        }
    }
}
