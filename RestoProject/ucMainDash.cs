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
            this.Size = new Size(724, 472);
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
                string queryTodayCount = "SELECT COUNT(*) FROM logs WHERE DATE(LogDate) = CURDATE()";
                string queryTodayLogs = "SELECT User, ChangesApplied, LogDate FROM logs WHERE DATE(LogDate) = CURDATE() ORDER BY LogDate DESC";

                MySql.Data.MySqlClient.MySqlCommand cmdProd = new MySql.Data.MySqlClient.MySqlCommand(queryProd, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdEmp = new MySql.Data.MySqlClient.MySqlCommand(queryEmp, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdStock = new MySql.Data.MySqlClient.MySqlCommand(queryStock, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdStockAlert = new MySql.Data.MySqlClient.MySqlCommand(queryStockAlert, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdTodayCount = new MySql.Data.MySqlClient.MySqlCommand(queryTodayCount, db.Connection);
                MySql.Data.MySqlClient.MySqlCommand cmdTodayLogs = new MySql.Data.MySqlClient.MySqlCommand(queryTodayLogs, db.Connection);

                MySql.Data.MySqlClient.MySqlDataAdapter adapterAlert = new MySql.Data.MySqlClient.MySqlDataAdapter(cmdStockAlert);
                MySql.Data.MySqlClient.MySqlDataAdapter adapterTodayLogs = new MySql.Data.MySqlClient.MySqlDataAdapter(cmdTodayLogs);

                DataTable dtStock = new DataTable();
                adapterAlert.Fill(dtStock);
                dgvStock.DataSource = dtStock;

                DataTable dtLogs = new DataTable();
                adapterTodayLogs.Fill(dtLogs);
                dgvRecentActivities.DataSource = dtLogs;

                int countProd = Convert.ToInt32(cmdProd.ExecuteScalar());
                cmdProd.Dispose();
                int countEmp = Convert.ToInt32(cmdEmp.ExecuteScalar());
                cmdEmp.Dispose();
                int stock = Convert.ToInt32(cmdStock.ExecuteScalar());
                cmdStock.Dispose();
                int todayCount = Convert.ToInt32(cmdTodayCount.ExecuteScalar());
                cmdTodayCount.Dispose();
                cmdStockAlert.Dispose();
                cmdTodayLogs.Dispose();
                adapterAlert.Dispose();
                adapterTodayLogs.Dispose();

                lblProductCount.Text = countProd.ToString();
                lblEmployeeCount.Text = countEmp.ToString();
                lblStock.Text = stock.ToString();
                lblTodayActivities.Text = todayCount.ToString();

                if (stock != 0)
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
            dgvFormatter(dgvRecentActivities);

            if (dgvRecentActivities.Columns.Count > 0)
            {
                dgvRecentActivities.Columns[0].FillWeight = 20;
                dgvRecentActivities.Columns[1].FillWeight = 60;
                dgvRecentActivities.Columns[2].FillWeight = 20;
            }
        }
    }
}
