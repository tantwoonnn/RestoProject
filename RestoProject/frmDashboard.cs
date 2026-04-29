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
    public partial class frmDashboard : Form
    {
        public string CurrentUser { get; set; }
        public string CurrentRole { get; set; }

        public frmDashboard(string username, string role)
        {
            InitializeComponent();
            CurrentUser = username;
            CurrentRole = role;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + CurrentUser + "!";
            label2.Text = "Postion: " + CurrentRole;

            ucMainDash dash = new ucMainDash();
            dash.Dock = DockStyle.Fill;
            pnlTab.Controls.Add(dash);
        }

        private void ShowPanel(UserControl uc)
        {
            pnlTab.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlTab.Controls.Add(uc);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPanel(new ucMainDash());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ShowPanel(new ucInventory());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ShowPanel(new ucEmployees());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowPanel(new ucReports());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowPanel(new ucSettings());
        }
    }
}
