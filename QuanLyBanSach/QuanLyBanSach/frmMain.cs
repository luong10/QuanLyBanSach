using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class frmMain : Form
    {
        string quyen = "";
        public frmMain(string quyen)
        {
            InitializeComponent();
            this.quyen = quyen;
        }

        private void MenuClick(object sender, EventArgs e)
        {

                Button btn = sender as Button;
                foreach (Control item in pnl_ButtonMenu.Controls)
                {
                    item.BackColor = pnl_ButtonMenu.BackColor;
                    btn.BackColor = Color.FromArgb(255, 192, 128);
                }
            foreach (Control item in panel4.Controls)
            {
                item.BackColor = pnl_ButtonMenu.BackColor;
                btn.BackColor = Color.FromArgb(255, 192, 128);
            }
            foreach (Control item in panel5.Controls)
            {
                item.BackColor = pnl_ButtonMenu.BackColor;
                btn.BackColor = Color.FromArgb(255, 192, 128);
            }
            switch (btn.Text)
                {
                 case "Bán Hàng":
                    Change(new frmHoaDonBan());
                    ptn_Sub2.Visible = false;
                    pnlSub3.Visible = false;

                    break;
                case "Danh Mục":
                    if (quyen == "admin")
                    {
                        btn_NhanVien.Visible = true;
                    }
                    else
                    {
                        btn_NhanVien.Visible = false;
                        ptn_Sub2.Height = 160;
                    }
                    ptn_Sub2.Visible = true;
                    pnlSub3.Visible = false;
                    break;
                    
                case "Nhân Viên":
                        Change(new frmNhanVien());
                        break;
                case "Sách":
                    Change(new frmSach());
                    break;
                case "Khách hàng":
                        Change(new frmKhach());
                        break;
                case "NXB":
                    Change(new frmNXB());
                    break;
                case "Thể Loại":
                        Change(new frmTheLoai());
                        break;
                    case "Báo Cáo":
                        Change(new frmBaoCao());
                    ptn_Sub2.Visible = false;
                    pnlSub3.Visible = false;
                    break;
                case "Kho":
                    Change(new frmThongTinKho());
                    pnlSub3.Visible = true;
                    ptn_Sub2.Visible = false;
                    break;
                case "Nhập kho":
                    Change(new frmNhapSach());
                    break;
                case "Xuất kho":
                    Change(new frmXuatSach());

                    break;
                default:

                        break;

                }
            
        }

        private void Change(object change)
        {
            if (this.pnl_Change.Controls.Count > 0)
                this.pnl_Change.Controls.RemoveAt(0);
            Form fh = change as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnl_Change.Controls.Add(fh);
            this.pnl_Change.Tag = fh;
            fh.Show();
        }
            private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_MiniSize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           btn_Ban.PerformClick();
        }

        private void pnl_ButtonMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_NXB_Click(object sender, EventArgs e)
        {
            btn_NXB.BackColor = Color.FromArgb(255, 192, 128);
            btn_Sach.BackColor = Color.White;
            btn_TheLoai.BackColor = Color.White;
            Change(new frmNXB());
        }

        private void btn_TheLoai_Click(object sender, EventArgs e)
        {
            btn_NXB.BackColor = Color.White;
            btn_Sach.BackColor = Color.White;
           btn_TheLoai.BackColor = Color.FromArgb(255, 192, 128);
            Change(new frmTheLoai());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            Login f = new Login();
            f.Show();
        }

    }
}
