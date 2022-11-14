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
    public partial class frmSach : Form
    {
        DataTable tblSach;
        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            string sql, sql1,sql2, sql3;
            sql = "SELECT * from THELOAI";
            sql1 = "SELECT * from NXB";
            sql2 = "update SACH set TrangThai = N'Hết hàng' where SLKe = 0 and SLKho = 0";
            Functions.exeData(sql2);
            sql2 = "update SACH set TrangThai = N'' where SLKe != 0 or SLKho != 0";
            Functions.exeData(sql2);
            sql3 = "UPDATE SACH SET GiamGia = 10 WHERE MaSach in (Select CHITIETHDXUAT.MaSach from SACH , CHITIETHDXUAT, HOADONXUAT " +
                "where CHITIETHDXUAT.MaXuat = HOADONXUAT.MaXuat " +
                "and CHITIETHDXUAT.MaSach = SACH.MaSach " +
                "and HOADONXUAT.KieuXuat = N'Xuất kệ sách' and DATEDIFF(month, NgayXuat, GETDATE()) > 4) ";
            Functions.exeData(sql3);
            txtMaSach.Enabled = false;
            btnLuu.Enabled = false;
            btnBo.Enabled = false;
            Functions.FillCombo(sql, cboTheLoai, "MaTheLoai", "TenTheLoai");
            Functions.FillCombo(sql1, cboNXB, "MaNXB", "TenNXB");
            cboTheLoai.SelectedIndex = -1;
            cboNXB.SelectedIndex = -1;
            LoadDataGridView();
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            cboNXB.Text = "";
            cboTheLoai.Text = "";
            txtNamXB.Text = "";
            txtGiaNhap.Text = "0";
            txtGia.Text = "0";
            txtTacGia.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM SACH";
            tblSach = Functions.GetData(sql); //Đọc dữ liệu từ bảng
            dgvSach.DataSource = tblSach; //Nguồn dữ liệu            
            dgvSach.Columns[0].HeaderText = "Mã";
            dgvSach.Columns[1].HeaderText = "Sách";
            dgvSach.Columns[2].HeaderText = "Giá bán";
            dgvSach.Columns[3].HeaderText = "Tác giả";
            dgvSach.Columns[4].HeaderText = "Thể loại";
            dgvSach.Columns[5].HeaderText = "NXB";
            dgvSach.Columns[6].HeaderText = "Năm XB";
            dgvSach.Columns[7].HeaderText = "Ảnh";
            dgvSach.Columns[8].HeaderText = "Giá nhập";
            dgvSach.Columns[9].HeaderText = "Trên kệ";
            dgvSach.Columns[10].HeaderText = "Trong kho";
            dgvSach.Columns[11].HeaderText = "Trạng thái";
            dgvSach.Columns[12].HeaderText = "Giảm giá hàng tồn";

            dgvSach.Columns[7].Width = 100;

            dgvSach.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvSach.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvSach_Click(object sender, EventArgs e)
        {
            string sql,sql1, sql2, MaTheLoai, MaNXB;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblSach.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvSach.CurrentRow.Selected = true;
            txtMaSach.Text = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dgvSach.CurrentRow.Cells["TenSach"].Value.ToString();
            txtTacGia.Text = dgvSach.CurrentRow.Cells["TacGia"].Value.ToString();
            txtGia.Text = dgvSach.CurrentRow.Cells["Gia"].Value.ToString();
            txtGiaNhap.Text = dgvSach.CurrentRow.Cells["GiaNhap"].Value.ToString();
            MaTheLoai = dgvSach.CurrentRow.Cells["MaTheLoai"].Value.ToString();
            sql = "SELECT TenTheLoai FROM THELOAI WHERE MaTheLoai=N'" + MaTheLoai + "'";
            cboTheLoai.Text = Functions.GeMaLonNhat(sql);
            MaNXB = dgvSach.CurrentRow.Cells["MaNXB"].Value.ToString();
            sql1 = "SELECT TenNXB FROM NXB WHERE MaNXB=N'" + MaNXB + "'";
            cboNXB.Text = Functions.GeMaLonNhat(sql1);
            txtNamXB.Text = dgvSach.CurrentRow.Cells["NamXuatBan"].Value.ToString();
            sql2 = "SELECT Anh FROM SACH WHERE MaSach=N'" + txtMaSach.Text + "'";
            txtAnh.Text = Functions.GeMaLonNhat(sql2);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBo.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            string  MaCu, TienTo;
            int HauTo;//Lưu lệnh sql
            if (Functions.GetFieldValues("select top 1 MaSach from SACH order by MaSach desc").Length > 0)
            {
                MaCu = Functions.GetFieldValues("select top 1 MaSach from SACH order by MaSach desc");
                TienTo = MaCu.Substring(0, 1);
                HauTo = int.Parse(MaCu.Substring(1).ToString());
                HauTo++;
                if (HauTo < 10)
                {
                    txtMaSach.Text = string.Concat(TienTo, "000", HauTo.ToString());
                }
                else if (HauTo < 100)
                {
                    txtMaSach.Text = string.Concat(TienTo, "00", HauTo.ToString());
                }
                else if (HauTo < 1000)
                {
                    txtMaSach.Text = string.Concat(TienTo, "0", HauTo.ToString());
                }
                else if (HauTo < 10000)
                {
                    txtMaSach.Text = string.Concat(TienTo, HauTo.ToString());
                }
            }
            else
            {
                txtMaSach.Text = "S0001";
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtTenSach.Focus();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập tên Sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSach.Focus();
                return;
            }
            if (txtGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Giá Bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return;
            }
            if (txtGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Giá Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaNhap.Focus();
                return;
            }
            if (txtTacGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tác Giả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTacGia.Focus();
                return;
            }
            if (cboTheLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Thể Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTheLoai.Focus();
                return;
            }

            if (cboNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập NXB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNXB.Focus();
                return;
            }

            if (int.Parse(txtNamXB.Text.ToString()) < 1900 || int.Parse(txtNamXB.Text.ToString()) > 2021 || txtNamXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại Năm Xuất Bản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNamXB.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn Ảnh minh hoạ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }

            string sql = "INSERT INTO SACH(MaSach,TenSach,Gia,TacGia, MaTheLoai,MaNXB,NamXuatBan,Anh,GiaNhap,SLKe,SLKho,TrangThai,GiamGia) VALUES(N'"
                 + txtMaSach.Text + "',N'" + txtTenSach.Text.Trim() +
                 "',"+txtGia.Text+",N'" + txtTacGia.Text.Trim() +
                 "',N'" + cboTheLoai.SelectedValue.ToString() +
                 "',N'" + cboNXB.SelectedValue.ToString() +
                 "'," + txtNamXB.Text + ",N'" + txtAnh.Text.Trim() + "',"+txtGiaNhap.Text+",0,0,N'',0)";

            Functions.exeData(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBo.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho Sách";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSach.Focus();
                return;
            }
            if (txtTenSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSach.Focus();
                return;
            }
            if (txtGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Giá Bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Focus();
                return;
            }
            if (txtGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Giá Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaNhap.Focus();
                return;
            }
            if (txtTacGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tác Giả ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTacGia.Focus();
                return;
            }
            if (cboTheLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Thể Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTheLoai.Focus();
                return;
            }
            if (cboNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập NXB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNXB.Focus();
                return;
            }
           
            if (int.Parse(txtNamXB.Text.ToString()) < 1900 || int.Parse(txtNamXB.Text.ToString()) > 2021)
            {
                MessageBox.Show("Bạn phải nhập lại năm xuất bản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNamXB.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            sql = "UPDATE SACH SET TenSach=N'" + txtTenSach.Text.Trim().ToString() +
                "',Gia=" + txtGia.Text +
                ",TacGia=N'" + txtTacGia.Text.Trim().ToString() +
                "',MaTheLoai=N'" + cboTheLoai.SelectedValue.ToString() +
                "',MaNXB=N'" + cboNXB.SelectedValue.ToString() +
                "',NamXuatBan=" + txtNamXB.Text +
                ",Anh=N'" + txtAnh.Text + "',GiaNhap="+txtGiaNhap.Text+" WHERE MaSach=N'" + txtMaSach.Text + "'";
            Functions.exeData(sql);
            LoadDataGridView();
            ResetValues();
            btnBo.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSach.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE SACH WHERE MaSach=N'" + txtMaSach.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            ResetValues();
            txtMaSach.Text = "";
            btnBo.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql;
            if ( (txtTenSach.Text == "") && (cboTheLoai.Text == "") && (txtTacGia.Text == "") && (cboNXB.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from SACH WHERE 1=1";
            
            if (txtTenSach.Text != "")
                sql += " AND TenSach LIKE N'%" + txtTenSach.Text + "%'";
            if (txtTacGia.Text != "")
                sql += " AND TacGia LIKE N'%" + txtTacGia.Text + "%'";
            if (cboTheLoai.Text != "")
                sql += " AND MaTheLoai LIKE N'%" + cboTheLoai.SelectedValue + "%'";
            if (cboNXB.Text != "")
                sql += " AND MaNXB LIKE N'%" + cboNXB.SelectedValue + "%'";
            if (txtNamXB.Text != "")
                sql += " AND NamXuatBan =" + txtNamXB.Text ;
            tblSach = Functions.GetData(sql);
            if (tblSach.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblSach.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvSach.DataSource = tblSach;
            ResetValues();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM SACH";
            tblSach = Functions.GetData(sql);
            dgvSach.DataSource = tblSach;
        }

        private void txtNamXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }


        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
  