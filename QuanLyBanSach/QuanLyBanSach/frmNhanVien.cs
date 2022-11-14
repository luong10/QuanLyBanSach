using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanSach.Class;
using System.Data.SqlClient;


namespace QuanLyBanSach
{
    public partial class frmNhanVien : Form
    {
        DataTable tblNV;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnBo.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NHANVIEN";
            tblNV = Functions.GetData(sql); //Đọc dữ liệu từ bảng
            dgvNV.DataSource = tblNV; //Nguồn dữ liệu            
            dgvNV.Columns[0].HeaderText = "Mã";
            dgvNV.Columns[1].HeaderText = "Tên";
            dgvNV.Columns[2].HeaderText = "Quyền";
            dgvNV.Columns[3].HeaderText = "Mật Khẩu";
            dgvNV.Columns[4].HeaderText = "Địa Chỉ";
            dgvNV.Columns[5].HeaderText = "Điện Thoại";
            dgvNV.Columns[6].HeaderText = "Ảnh";

            dgvNV.Columns[0].Width = 100;
            dgvNV.Columns[1].Width = 170;
            dgvNV.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNV.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblNV.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvNV.CurrentRow.Selected = true;
            txtMaNV.Text = dgvNV.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtTenNV.Text = dgvNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            cboQuyen.Text = dgvNV.CurrentRow.Cells["Quyen"].Value.ToString();
            txtMatKhau.Text = dgvNV.CurrentRow.Cells["MatKhau"].Value.ToString();
            txtDiaChi.Text = dgvNV.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = dgvNV.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            sql = "SELECT Anh FROM NHANVIEN WHERE MaNhanVien=N'" + txtMaNV.Text + "'";
            txtAnh.Text = Functions.GeMaLonNhat(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBo.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            string MaCu, TienTo;
            int HauTo;//Lưu lệnh sql
            if(Functions.GetFieldValues("select top 1 MaNhanVien from NHANVIEN order by MaNhanVien desc").Length > 0)
            {
                MaCu = Functions.GetFieldValues("select top 1 MaNhanVien from NHANVIEN order by MaNhanVien desc");
                TienTo = MaCu.Substring(0, 2);
                HauTo = int.Parse(MaCu.Substring(2).ToString());
                HauTo++;
                if (HauTo < 10)
                {
                    txtMaNV.Text = string.Concat(TienTo, "00", HauTo.ToString());
                }
                else if (HauTo < 100)
                {
                    txtMaNV.Text = string.Concat(TienTo, "0", HauTo.ToString());
                }
                else if (HauTo < 1000)
                {
                    txtMaNV.Text = string.Concat(TienTo, HauTo.ToString());
                }
            }
            else
            {
                txtMaNV.Text = "NV001";
            }
           
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtTenNV.Focus();
        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cboQuyen.Text = "";
            txtMatKhau.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtDienThoai.Text.Trim().Length < 9)
            {
                MessageBox.Show("Bạn phải nhập lại Điện Thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mật Khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Địa Chỉ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (cboQuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn Quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboQuyen.Focus();
                return;
            }

            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            sql = "UPDATE NHANVIEN SET TenNhanVien=N'" + txtTenNV.Text.Trim().ToString() +
                "',Quyen=N'" + cboQuyen.SelectedItem.ToString() +
                "',MatKhau=N'" + txtMatKhau.Text.Trim().ToString() +
                "',DiaChi=N'" + txtDiaChi.Text.Trim().ToString() +
                "',SoDienThoai=N'" + txtDienThoai.Text +
                "',Anh=N'" + txtAnh.Text + "' WHERE MaNhanVien=N'" + txtMaNV.Text + "'";
            Functions.exeData(sql);
            LoadDataGridView();
            ResetValues();
            btnBo.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh Nhân Viên";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (txtDienThoai.Text.Trim().Length < 9)
            {
                MessageBox.Show("Bạn phải nhập lại Điện Thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mật Khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Địa Chỉ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (cboQuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn Quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboQuyen.Focus();
                return;
            }

            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }

            string sql = "INSERT INTO NHANVIEN(MaNhanVien,TenNhanVien,Quyen,MatKhau,DiaChi,SoDienThoai,Anh) VALUES(N'"
                 + txtMaNV.Text + "',N'" + txtTenNV.Text.Trim() +
                 "',N'" + cboQuyen.SelectedItem.ToString() +
                 "',N'" + txtMatKhau.Text.Trim() +
                 "',N'" + txtDiaChi.Text.Trim() +
                 "',N'" + txtDienThoai.Text +
                 "',N'" + txtAnh.Text.Trim() + "')";

            Functions.exeData(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBo.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NHANVIEN WHERE MaNhanVien=N'" + txtMaNV.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBo.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
