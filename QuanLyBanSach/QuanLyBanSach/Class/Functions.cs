using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanSach.Class
{
    class Functions
    {
        public static SqlConnection ketnoi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True");
            con.Open();
            return con;
        }

        public static DataTable GetData(string sql)
        {
            SqlConnection con = ketnoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        public static string GeMaLonNhat(string sql)
        {
            SqlConnection con = ketnoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
        
                string MaLN = dt.Rows[0][0].ToString();

            con.Close();
            return MaLN;
        }
      
        public static bool exeData(string sql)
        {
            SqlConnection con = ketnoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }



        }
        public static void RunSqlDel(string sql)
        {
            SqlConnection con = ketnoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               // MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlConnection con = ketnoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            cbo.DataSource = dt;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string [] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("_{0}/{1}/{2}_", partsDay[1], partsDay[0], partsDay[2]);
            key = key + d;
            string partsTime;
            partsTime =  DateTime.Now.ToLongTimeString();
            //partsTime[2] = partsTime[2].Remove(1, 2);
            //string t;
            //t = String.Format("_{0}:{1}:{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + partsTime;
            return key;
        }
        public static bool CheckKey(string sql)
        {
            SqlConnection con = ketnoi();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlConnection con = ketnoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
    }
}
