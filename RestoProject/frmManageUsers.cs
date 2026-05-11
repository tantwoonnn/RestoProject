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
    public partial class frmManageUsers : Form
    {
        private int selectedUserId = -1;
        public frmManageUsers()
        {
            InitializeComponent();
            this.Size = new Size(724, 472);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            cmbRole.Items.Add("admin");
            cmbRole.Items.Add("manager");
            cmbRole.Items.Add("staff");
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
        private void LoadUsers()
        {
            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "SELECT UserID, Username, role FROM users";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);
                MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUsers.Columns["UserID"].Visible = false;

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

            dgvFormatter(dgvUsers);
        }
        private void ClearFields()
        {
            selectedUserId = -1;
            lblUsername.Text = "User: ";
            cmbRole.SelectedIndex = -1;
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
            dgvUsers.CellClick += dgvUsers_CellClick;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRole.Text == "")
            {
                MessageBox.Show("Please select a role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "UPDATE users SET role = @role WHERE UserID = @id";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);
                cmd.Parameters.AddWithValue("@role", cmbRole.Text);
                cmd.Parameters.AddWithValue("@id", selectedUserId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                Properties.Settings.Default.LastEditedBy = Properties.Settings.Default.Username;
                Properties.Settings.Default.LastEditedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Properties.Settings.Default.Save();

                MessageBox.Show("Role updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Log("Changed role of " + lblUsername.Text + " to " + cmbRole.Text);  
                LoadUsers();
                ClearFields();
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

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);
                lblUsername.Text = "User: " + row.Cells["Username"].Value.ToString();
                cmbRole.Text = row.Cells["role"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRow = dgvUsers.CurrentRow != null;

            btnUpdate.Enabled = hasRow;
            btnClear.Enabled = hasRow;
        }
    }
}
