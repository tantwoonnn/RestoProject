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
            string role = Properties.Settings.Default.Role.ToLower();

            if (role == "staff" || role == "manager")
            {
                pnlDatabase.Enabled = false;
            }
            if (Properties.Settings.Default.LastBackup != "")
            {
                lblLastBackup.Text = "Last Backup: " + Properties.Settings.Default.LastBackup;
            }
            else
            {
                lblLastBackup.Text = "Last Backup: Never";
            }

            if (Properties.Settings.Default.LastEditedBy != "")
            {
                lblLastEdited.Text = "Last edited by: " + Properties.Settings.Default.LastEditedBy + "\nLast edited at: " + Properties.Settings.Default.LastEditedAt;
            }
            else
            {
                lblLastEdited.Text = "Last edited by: Never";
            }
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "SQL File (*.sql)|*.sql";
            saveFile.FileName = "backup_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".sql";
            saveFile.Title = "Save Database Backup";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = saveFile.FileName;

                    using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(DBConnect.ConnectionString))
                    {
                        conn.Open();
                        using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                        {
                            using (MySql.Data.MySqlClient.MySqlBackup backup = new MySql.Data.MySqlClient.MySqlBackup(cmd))
                            {
                                cmd.Connection = conn;
                                backup.ExportToFile(path);
                            }
                        }
                    }

                    Properties.Settings.Default.LastBackup = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Properties.Settings.Default.Save();
                    lblLastBackup.Text = "Last Backup: " + Properties.Settings.Default.LastBackup;

                    MessageBox.Show("Backup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "SQL File (*.sql)|*.sql";
            openFile.Title = "Select Backup File to Restore";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to restore? This will overwrite your current data.","Confirm Restore",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string path = openFile.FileName;

                        using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(DBConnect.ConnectionString))
                        {
                            conn.Open();
                            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                            {
                                using (MySql.Data.MySqlClient.MySqlBackup backup = new MySql.Data.MySqlClient.MySqlBackup(cmd))
                                {
                                    cmd.Connection = conn;
                                    backup.ImportFromFile(path);
                                }
                            }
                        }

                        MessageBox.Show("Restore successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void lblLastBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            frmManageUsers manageUsers = new frmManageUsers();
            manageUsers.Show();

            if (Properties.Settings.Default.LastEditedBy != "")
            {
                lblLastEdited.Text = "Last edited by: " + Properties.Settings.Default.LastEditedBy + "\nLast edited at: " + Properties.Settings.Default.LastEditedAt;
            }
            else
            {
                lblLastEdited.Text = "Last edited by: Never";
            }
        }
    }
}
