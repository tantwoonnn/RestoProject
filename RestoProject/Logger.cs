using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoProject
{
    public class Logger
    {
        public static void Log(string changesApplied)
        {
            DBConnect db = new DBConnect();
            try
            {
                db.Open();
                string query = "INSERT INTO logs (User, ChangesApplied, LogDate) VALUES (@user, @changes, @date)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, db.Connection);
                cmd.Parameters.AddWithValue("@user", Properties.Settings.Default.Username);
                cmd.Parameters.AddWithValue("@changes", changesApplied);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
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
    }
}
