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
    public partial class ucEmployees : UserControl
    {
        public ucEmployees()
        {
            InitializeComponent();
        }
        private void LoadEmployees()
        {
            string search = txtSearch.Text.Trim();

            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "SELECT EmployeeID, FullName, Position, ContactNumber, UserID FROM employees WHERE EmployeeID LIKE @search OR FullName LIKE @search OR Position LIKE @search OR ContactNumber LIKE @search OR UserID LIKE @search";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                System.Data.DataTable table = new System.Data.DataTable();

                adapter.Fill(table);

                dgvEmployees.DataSource = table;

                dgvEmployees.Columns["EmployeeID"].HeaderText = "Employee ID";
                dgvEmployees.Columns["FullName"].HeaderText = "Employee Name";
                dgvEmployees.Columns["Position"].HeaderText = "Position";
                dgvEmployees.Columns["ContactNumber"].HeaderText = "Contact Number";
                dgvEmployees.Columns["UserID"].HeaderText = "User ID";

                adapter.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Close();
            }

            dgvFormatter(dgvEmployees);
        }

        public static void dgvFormatter(DataGridView dgvStyle)
        {
            dgvStyle.RowHeadersVisible = false;
            dgvStyle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStyle.MultiSelect = false;
            dgvStyle.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvStyle.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvStyle.AllowUserToAddRows = false;
            dgvStyle.ReadOnly = true;
            dgvStyle.EnableHeadersVisualStyles = false;
        }

        private void ucEmployees_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEmployee form = new frmAddEmployee();
            form.ShowDialog();
            LoadEmployees();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }

            DataGridViewRow row = dgvEmployees.CurrentRow;

            frmModifyEmployee form = new frmModifyEmployee();

            form.EmployeeID = row.Cells["EmployeeID"].Value.ToString();
            form.FullName = row.Cells["FullName"].Value.ToString();
            form.Position = row.Cells["Position"].Value.ToString();
            form.ContactNumber = row.Cells["ContactNumber"].Value.ToString();
            form.UserID = row.Cells["UserID"].Value.ToString();

            form.ShowDialog();

            LoadEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }

            var confirm = MessageBox.Show("Delete this employee?",
                                          "Confirm",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            DBConnect db = new DBConnect();

            try
            {
                db.Open();

                string query = "DELETE FROM employees WHERE EmployeeID=@id";
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                cmd.Parameters.AddWithValue("@id", dgvEmployees.CurrentRow.Cells["EmployeeID"].Value.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Close();
            }

            LoadEmployees();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvEmployees.ClearSelection();
                dgvEmployees.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
