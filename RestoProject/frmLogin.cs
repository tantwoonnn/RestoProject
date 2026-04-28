using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Diagnostics.Eventing.Reader;

namespace RestoProject
{
    public partial class frmLogin : MaterialForm
    {
        public frmLogin()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
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
                    string roleQuery = "SELECT role FROM users WHERE Username = @username AND Password = @password";
                    MySql.Data.MySqlClient.MySqlCommand roleCmd = new MySql.Data.MySqlClient.MySqlCommand(roleQuery, db.Connection);
                    roleCmd.Parameters.AddWithValue("@username", username);
                    roleCmd.Parameters.AddWithValue("@password", password);

                    string role = roleCmd.ExecuteScalar().ToString().ToLower();
                    roleCmd.Dispose();

                    if (role == "admin")
                    {
                        MessageBox.Show("Login Successful!", "Welcome Admin " + username);
                    }
                    else if (role == "manager")
                    {
                        MessageBox.Show("Login Successful!", "Welcome Manager " + username);
                    }
                    else
                    {
                        MessageBox.Show("Login Successful!", "Welcome Staff " + username);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.", "Login Failed");
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
    }
}
