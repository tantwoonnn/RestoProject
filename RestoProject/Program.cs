using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Loading loading = new Loading();
            loading.ShowDialog();

            if (Properties.Settings.Default.IsLoggedIn)
            {
                string username = Properties.Settings.Default.Username;
                string role = Properties.Settings.Default.Role;

                Application.Run(new frmDashboard(username, role));
            }
            else
            {
                Application.Run(new frmLogin());
            }
        }
    }
}
