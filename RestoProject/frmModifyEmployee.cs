using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RestoProject
{
    public partial class frmModifyEmployee : Form
    {
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ContactNumber { get; set; }
        public string UserID { get; set; }
        public frmModifyEmployee()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            try
            {
                db.Open();

                string query = "UPDATE employees SET FullName=@name, Position=@position, ContactNumber=@contact, UserID=@userid WHERE EmployeeID=@id";

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPosition.Text) ||
                    string.IsNullOrWhiteSpace(txtContact.Text) ||
                    string.IsNullOrWhiteSpace(txtUserID.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@position", txtPosition.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@userid", txtUserID.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Employee updated successfully!");
                this.Close();
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

        private void frmModifyEmployee_Load(object sender, EventArgs e)
        {
            txtID.Text = EmployeeID;
            txtName.Text = FullName;
            txtPosition.Text = Position;
            txtContact.Text = ContactNumber;
            txtUserID.Text = UserID;
            txtID.Enabled = false;
        }
    }
}
