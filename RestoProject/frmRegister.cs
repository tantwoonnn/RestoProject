using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace RestoProject
{
    public partial class frmRegister : Form
    {
        private string verificationCode;
        private bool emailVerified = false;
        public frmRegister()
        {
            InitializeComponent();
            this.Size = new Size(1000, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            btnVerifyCode.Enabled = false;
            txtVerifyCode.Enabled = false;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (!emailVerified)
            {
                MessageBox.Show("Please verify your email first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username == "" || password == "" || confirmPassword == "" || email == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBConnect db = new DBConnect();
            try
            {
                db.Open();

                string checkQuery = "SELECT COUNT(*) FROM users WHERE Username = @username";
                MySql.Data.MySqlClient.MySqlCommand checkCmd = new MySql.Data.MySqlClient.MySqlCommand(checkQuery, db.Connection);
                checkCmd.Parameters.AddWithValue("@username", username);
                int usernameCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                checkCmd.Dispose();

                if (usernameCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                MySql.Data.MySqlClient.MySqlCommand checkEmailCmd = new MySql.Data.MySqlClient.MySqlCommand(checkEmailQuery, db.Connection);
                checkEmailCmd.Parameters.AddWithValue("@email", email);
                int emailCount = Convert.ToInt32(checkEmailCmd.ExecuteScalar());
                checkEmailCmd.Dispose();

                if (emailCount > 0)
                {
                    MessageBox.Show("Email already exists. Please use another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertQuery = "INSERT INTO users (Username, Password, email, role) VALUES (@username, @password, @email, 'staff')";
                MySql.Data.MySqlClient.MySqlCommand insertCmd = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, db.Connection);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password);
                insertCmd.Parameters.AddWithValue("@email", email);

                insertCmd.ExecuteNonQuery();
                insertCmd.Dispose();

                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtEmail.Text = "";

                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
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

        private void label5_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            if (txtVerifyCode.Text.Trim() == verificationCode)
            {
                emailVerified = true;
                lblVerifyStatus.Text = "Email verified!";
                lblVerifyStatus.ForeColor = Color.Green;
                btnVerifyCode.Enabled = false;
                txtVerifyCode.Enabled = false;
                MessageBox.Show("Email verified successfully!", "Success");
            }
            else
            {
                MessageBox.Show("Invalid verification code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                verificationCode = new Random().Next(100000, 999999).ToString();

                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress("Axioma", "kristanerasmo@gmail.com"));
                message.To.Add(new MimeKit.MailboxAddress("", email));
                message.Subject = "Email Verification Code";
                message.Body = new MimeKit.TextPart("plain")
                {
                    Text = "Your verification code is: " + verificationCode + "\n\nDo not share this code with anyone."
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("kristanerasmo@gmail.com", "ywtnhddzhkjinvzu");
                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("Verification code sent to " + email, "Success");
                btnSendCode.Enabled = false;
                btnVerifyCode.Enabled = true;
                txtVerifyCode.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
