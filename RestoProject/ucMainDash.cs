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
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStockAlert, db.Connection);
                MySql.Data.MySqlClient.MySqlDataAdapter adapterAlert = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapterAlert.Fill(dt);

                dgvLowStock.DataSource = dt;
                cmd.Dispose();

                int countProd = Convert.ToInt32(cmdProd.ExecuteScalar());
                cmdProd.Dispose();
                int countEmp = Convert.ToInt32(cmdEmp.ExecuteScalar());
                cmdEmp.Dispose();
                int Stock = Convert.ToInt32(cmdStock.ExecuteScalar());
                cmdStock.Dispose();


                lblProductCount.Text = countProd.ToString();
                lblEmployeeCount.Text = countEmp.ToString();
                lblStock.Text = Stock.ToString();

                if (Stock > 10)
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


        }
    }
}
