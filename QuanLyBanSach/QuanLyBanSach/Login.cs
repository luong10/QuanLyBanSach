using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanSach.Class;


namespace QuanLyBanSach
{
    
    public partial class Login : Form
    {
        //Functions conn = new Functions();
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = Functions.GetData("SELECT * FROM NHANVIEN WHERE Quyen = '" + txtUser.Text + "' AND MatKhau = '" + txtPass.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    frmMain main = new frmMain(dt.Rows[0][2].ToString());
                    this.Hide();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nhập đúng thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Clear();
                    txtPass.Clear();
                }
            }
        }
    }
}
