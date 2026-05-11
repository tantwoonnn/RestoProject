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
    public partial class ucReports : UserControl
    {
        public ucReports()
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
            dgvStyle.AllowUserToResizeColumns = false;
            dgvStyle.AllowUserToResizeRows = false;
        }
        private void LoadLogs()
        {
            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "SELECT LogID, User, ChangesApplied, LogDate FROM logs ORDER BY LogID DESC";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);
                MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvLogs.DataSource = dt;
                dgvLogs.Columns["LogID"].FillWeight = 10;
                dgvLogs.Columns["User"].FillWeight = 20;
                dgvLogs.Columns["ChangesApplied"].FillWeight = 60;
                dgvLogs.Columns["LogDate"].FillWeight = 20;

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
            
            dgvFormatter(dgvLogs);
        }

        private void ucReports_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }
    }
}
