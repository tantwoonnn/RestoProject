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
    public partial class frmSecretSettings : Form
    {
        public frmSecretSettings()
        {
            InitializeComponent();
            this.Size = new Size(400, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Secret Settings";

            txtClientId.Text = Properties.Settings.Default.ClientId;
            txtClientSecret.Text = Properties.Settings.Default.ClientSecret;
        }

        private void frmSecretSettings_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtClientId.Text.Trim() == "" || txtClientSecret.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default.ClientId = txtClientId.Text.Trim();
            Properties.Settings.Default.ClientSecret = txtClientSecret.Text.Trim();
            Properties.Settings.Default.Save();

            MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
