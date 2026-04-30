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

        private void LoadInventory()
        {
            string search = txtSearch.Text.Trim();

            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = @"SELECT ProductID, ProductName, Category, Quantity, Price FROM products WHERE ProductID LIKE @search OR ProductName LIKE @search OR Category LIKE @search OR Quantity LIKE @search OR Price LIKE @search";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                System.Data.DataTable table = new System.Data.DataTable();

                adapter.Fill(table);

                dgvInventory.DataSource = table;

                dgvInventory.Columns["ProductID"].HeaderText = "Product ID";
                dgvInventory.Columns["ProductName"].HeaderText = "First Name";
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
        }

        private void ucInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }
    }
}
