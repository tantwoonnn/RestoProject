using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            this.Size = new Size(724, 472);

            // Start of AI generated code to make mouse scrolling smooth and add padding at the bottom
            this.VerticalScroll.SmallChange = 1;
            this.VerticalScroll.LargeChange = 5;
            this.DoubleBuffered = true;

            Panel bottomPadding = new Panel();
            bottomPadding.Size = new Size(1, 50);
            bottomPadding.Location = new Point(0, this.Controls
                .OfType<Control>()
                .Max(c => c.Bottom) + 20);
            this.Controls.Add(bottomPadding);

        }
        // End of AI generated code

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucSettings_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string tokenFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"Google.Apis.Auth");

            if (Directory.Exists(tokenFolder))
            {
                Directory.Delete(tokenFolder, true);
            }
            Properties.Settings.Default.IsLoggedIn = false;
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Role = "";
            Properties.Settings.Default.Save();

            Form parentForm = this.FindForm();
            parentForm.Close();
            new frmLogin().Show();
        }

        private void pnlAccount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (oldPassword == "" || newPassword == "" || confirmPassword == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (oldPassword == newPassword)
            {
                MessageBox.Show("New password cannot be the same as old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBConnect db = new DBConnect();
            try
            {
                db.Open();

                string checkQuery = "SELECT COUNT(*) FROM users WHERE Username = @username AND Password = @oldPassword";
                MySql.Data.MySqlClient.MySqlCommand checkCmd = new MySql.Data.MySqlClient.MySqlCommand(checkQuery, db.Connection);
                checkCmd.Parameters.AddWithValue("@username", Properties.Settings.Default.Username);
                checkCmd.Parameters.AddWithValue("@oldPassword", oldPassword);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                checkCmd.Dispose();

                if (count == 1)
                {
                    string updateQuery = "UPDATE users SET Password = @newPassword WHERE Username = @username";
                    MySql.Data.MySqlClient.MySqlCommand updateCmd = new MySql.Data.MySqlClient.MySqlCommand(updateQuery, db.Connection);
                    updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                    updateCmd.Parameters.AddWithValue("@username", Properties.Settings.Default.Username);

                    updateCmd.ExecuteNonQuery();
                    updateCmd.Dispose();

                    txtOldPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";

                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Close();
            }
        }
    }
}
