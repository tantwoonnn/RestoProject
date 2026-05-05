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
    public partial class frmAddEmployee : Form
    {
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            try
            {
                db.Open();

                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPosition.Text) ||
                    string.IsNullOrWhiteSpace(txtContact.Text) ||
                    string.IsNullOrWhiteSpace(txtUserID.Text))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                string query = "INSERT INTO employees (FullName, Position, ContactNumber, UserID)VALUES(@name, @position, @contact, @userid)";

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@position", txtPosition.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@userid", Convert.ToInt32(txtUserID.Text));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Employee added successfully!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                db.Close();
            }
        }
    }
}
