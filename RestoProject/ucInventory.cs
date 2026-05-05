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
    public partial class ucInventory : UserControl
    {
        public ucInventory()
        {
            InitializeComponent();
        }
        private bool HasSelectedRow()
        {
            return dgvInventory.CurrentRow != null && dgvInventory.CurrentRow.Index >= 0;
        }

        private void LoadInventory()
        {
            string search = txtSearch.Text.Trim();

            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "SELECT ProductID, ProductName, Category, Quantity, Price FROM products WHERE ProductID LIKE @search OR ProductName LIKE @search OR Category LIKE @search OR Quantity LIKE @search OR Price LIKE @search";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                System.Data.DataTable table = new System.Data.DataTable();

                adapter.Fill(table);

                dgvInventory.DataSource = table;

                dgvInventory.Columns["ProductID"].HeaderText = "Product ID";
                dgvInventory.Columns["ProductName"].HeaderText = "Product Name";
                dgvInventory.Columns["Category"].HeaderText = "Category";
                dgvInventory.Columns["Quantity"].HeaderText = "Quantity";
                dgvInventory.Columns["Price"].HeaderText = "Price";

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

            dgvFormatter(dgvInventory);
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

        private void ucInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
            dgvInventory.CellClick += dgvInventory_CellClick;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            frmAddProduct form = new frmAddProduct();
            form.ShowDialog();
            LoadInventory();
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvInventory.ClearSelection();
                dgvInventory.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a product first.");
                return;
            }

            DataGridViewRow row = dgvInventory.CurrentRow;

            frmModifyProduct form = new frmModifyProduct();

            form.ProductID = row.Cells["ProductID"].Value.ToString();
            form.ProductName = row.Cells["ProductName"].Value.ToString();
            form.Category = row.Cells["Category"].Value.ToString();
            form.Quantity = row.Cells["Quantity"].Value.ToString();
            form.Price = row.Cells["Price"].Value.ToString();

            form.ShowDialog();

            LoadInventory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!HasSelectedRow())
            {
                MessageBox.Show("Please select a product first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this product?","Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            DBConnect db = new DBConnect();

            try
            {
                db.Open();

                string query = "DELETE FROM products WHERE ProductID=@id";
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                cmd.Parameters.AddWithValue("@id", dgvInventory.CurrentRow.Cells["ProductID"].Value.ToString());

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

            LoadInventory();
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRow = dgvInventory.CurrentRow != null;

            btnModify.Enabled = hasRow;
            btnDelete.Enabled = hasRow;
        }

    }
}
