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
    public partial class frmModifyProduct : Form
    {
        public string ProductID;
        public string ProductName;
        public string Category;
        public string Quantity;
        public string Price;
        public frmModifyProduct()
        {
            InitializeComponent();
        }

        private void frmModifyProduct_Load(object sender, EventArgs e)
        {
            txtID.Text = ProductID;
            txtName.Text = ProductName;
            txtCategory.Text = Category;
            txtQuantity.Text = Quantity;
            txtPrice.Text = Price;
            txtID.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            try
            {
                db.Open();

                string query = "UPDATE products SET ProductName=@name, Category=@category, Quantity=@quantity, Price=@price WHERE ProductID=@id";

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);

                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtCategory.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Product updated successfully!");
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
    }
}
