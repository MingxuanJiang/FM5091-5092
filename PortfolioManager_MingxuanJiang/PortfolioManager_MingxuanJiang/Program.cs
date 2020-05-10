using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortfolioManager_MingxuanJiang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static PortfolioManagerContainer PMC;
        [STAThread]
        static void Main()
        {
            PMC = new PortfolioManagerContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}
