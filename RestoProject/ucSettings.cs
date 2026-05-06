using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoProject
{
    public partial class ucSettings : UserControl
    {
        public ucSettings()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucSettings_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsLoggedIn = false;
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Role = "";
            Properties.Settings.Default.Save();

            frmDashboard form = (frmDashboard)this.ParentForm;
            form.Hide();
            new frmLogin().Show();
        }
    }
}
