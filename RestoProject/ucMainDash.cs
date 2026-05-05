using System;
using System.Collections;
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
    public partial class ucMainDash : UserControl
    {
        public ucMainDash()
        {
            InitializeComponent();
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
            dgvStyle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStyle.RowTemplate.Height = 30;
            dgvStyle.ColumnHeadersHeight = 35;
        }
        private void ucMainDash_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string queryProd = "SELECT COUNT(*) FROM products";
                string queryEmp = "SELECT COUNT(*) FROM employees";
                string queryStock = "SELECT COUNT(*) FROM products WHERE quantity <= 10";
                string queryStockAlert = "SELECT ProductName, Quantity FROM products WHERE Quantity <= 10";

                MySql.Data.MySqlClient.MySqlCommand cmdProd = new MySql.Data.MySqlClient.MySqlCommand(queryProd, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdEmp = new MySql.Data.MySqlClient.MySqlCommand(queryEmp, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdStock = new MySql.Data.MySqlClient.MySqlCommand(queryStock, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdStockAlert = new MySql.Data.MySqlClient.MySqlCommand(queryStockAlert, db.Connection);
                MySql.Data.MySqlClient.MySqlDataAdapter adapterAlert = new MySql.Data.MySqlClient.MySqlDataAdapter(cmdStockAlert);

                DataTable dt = new DataTable();
                adapterAlert.Fill(dt);

                dgvStock.DataSource = dt;

                cmdStockAlert.Dispose();
                int countProd = Convert.ToInt32(cmdProd.ExecuteScalar());
                cmdProd.Dispose();
                int countEmp = Convert.ToInt32(cmdEmp.ExecuteScalar());
                cmdEmp.Dispose();
                int Stock = Convert.ToInt32(cmdStock.ExecuteScalar());
                cmdStock.Dispose();
                cmdStockAlert.Dispose();
                adapterAlert.Dispose();


                lblProductCount.Text = countProd.ToString();
                lblEmployeeCount.Text = countEmp.ToString();
                lblStock.Text = Stock.ToString();

                if (Stock != 0)
                {
                    lblStock.ForeColor = Color.Red;
                }
                else
                {
                    lblStock.ForeColor = Color.Green;
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

            dgvFormatter(dgvStock);
        }
    }
}
