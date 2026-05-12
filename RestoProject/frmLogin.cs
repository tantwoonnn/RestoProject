using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoProject
{
    public partial class frmLogin : Form
    {
        private string attemptsFile = "attempts.txt";
        private UserCredential credential;
        private int konIndex = 0;
        private string[] konCode = new string[]{"Up","Up","Down","Down","Left","Right","Left","Right","B","A"};
        public frmLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Size = new Size(1000, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            string key = e.KeyCode.ToString();

            if (key == konCode[konIndex])
            {
                konIndex++;

                if (konIndex == konCode.Length)
                {
                    konIndex = 0;
                    frmSecretSettings secret = new frmSecretSettings();
                    secret.ShowDialog();
                }
            }
            else
            {
                konIndex = 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
        private void CheckGoogleUser(string email, string name)
        {
            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "SELECT role, Username FROM users WHERE email = @email";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);
                cmd.Parameters.AddWithValue("@email", email);

                MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string role = reader["role"].ToString();
                    string username = reader["Username"].ToString();
                    reader.Close();
                    cmd.Dispose();

                    Properties.Settings.Default.IsLoggedIn = true;
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Role = role;
                    Properties.Settings.Default.IsGoogleLogin = true;
                    Properties.Settings.Default.Save();

                    frmDashboard dashboard = new frmDashboard(username, role, credential);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    reader.Close();
                    cmd.Dispose();

                    string tokenFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Google.Apis.Auth");

                    if (Directory.Exists(tokenFolder))
                    {
                        Directory.Delete(tokenFolder, true);
                    }

                    MessageBox.Show("Your Google account is not registered in the system.", "Access Denied");
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // AI Generated : Login Attempt Tracking
            int loginAttempts = File.Exists(attemptsFile) ? Convert.ToInt32(File.ReadAllText(attemptsFile)) : 0;
            // End of AI Generated Code
                
            if (loginAttempts >= 5)
            {
                MessageBox.Show("Too many login attempts. Please contact your admin.", "Login Failed");
                btnLogin.Enabled = false;
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please use a valid username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "SELECT COUNT(*) FROM users WHERE Username = @username AND Password = @password";

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();

                if (count == 1)
                {
                    File.WriteAllText(attemptsFile, "0");

                    string roleQuery = "SELECT role FROM users WHERE Username = @username AND Password = @password";
                    MySql.Data.MySqlClient.MySqlCommand roleCmd = new MySql.Data.MySqlClient.MySqlCommand(roleQuery, db.Connection);
                    roleCmd.Parameters.AddWithValue("@username", username);
                    roleCmd.Parameters.AddWithValue("@password", password);

                    string role = roleCmd.ExecuteScalar().ToString().ToLower();
                    roleCmd.Dispose();

                    Properties.Settings.Default.IsLoggedIn = true;
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Role = role;
                    Properties.Settings.Default.Save();

                    MessageBox.Show($"Login Successful! Welcome {role} {username}");
                    frmDashboard dashboard = new frmDashboard(username, role);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    loginAttempts++;
                    File.WriteAllText(attemptsFile, loginAttempts.ToString());
                    MessageBox.Show("Invalid Username or Password. Attempts: " + loginAttempts + "/5", "Login Failed");

                    if (loginAttempts >= 5)
                    {
                        MessageBox.Show("Too many login attempts. Please contact your admin.", "Login Failed");
                        btnLogin.Enabled = false;
                    }
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

        private void materialLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets{ClientId = Properties.Settings.Default.ClientId, ClientSecret = Properties.Settings.Default.ClientSecret },new[] {"email", "profile" }, "user", CancellationToken.None);

                var oauthService = new Oauth2Service(new BaseClientService.Initializer(){HttpClientInitializer = credential});

                Userinfo userInfo = await oauthService.Userinfo.Get().ExecuteAsync();

                string email = userInfo.Email;
                string name = userInfo.Name;

                CheckGoogleUser(email, name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblNoAccount_Click(object sender, EventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            registerForm.Show();
            this.Hide();
        }
    }
}
