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
    public partial class frmKhach : Form
    {
        DataTable tblKH;
        public frmKhach()
        {
            InitializeComponent();
        }

        private void frmKhach_Load(object sender, EventArgs e)
        {
            txtMaKhach.Enabled = false;
            btnLuu.Enabled = false;
            btnBo.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM KHACH";
            tblKH = Functions.GetData(sql); //Đọc dữ liệu từ bảng
            dgvKhach.DataSource = tblKH; //Nguồn dữ liệu            
            dgvKhach.Columns[0].HeaderText = "Mã";
            dgvKhach.Columns[1].HeaderText = "Tên";
            dgvKhach.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhach.Columns[3].HeaderText = "Điện Thoại";
           
            dgvKhach.Columns[0].Width = 100;
            dgvKhach.Columns[1].Width = 170;
            dgvKhach.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvKhach.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblKH.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvKhach.CurrentRow.Selected = true;
            txtMaKhach.Text = dgvKhach.CurrentRow.Cells["MaKhach"].Value.ToString();
            txtTenKhach.Text = dgvKhach.CurrentRow.Cells["TenKhach"].Value.ToString();
            txtDiaChi.Text = dgvKhach.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = dgvKhach.CurrentRow.Cells["SoDienThoai"].Value.ToString();
          
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBo.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            string MaCu, TienTo;
            int HauTo;//Lưu lệnh sql
           if(Functions.GetFieldValues("select top 1 MaKhach from KHACH order by MaKhach desc").Length > 0)
            {
                MaCu = Functions.GetFieldValues("select top 1 MaKhach from KHACH order by MaKhach desc");
                TienTo = MaCu.Substring(0, 1);
                HauTo = int.Parse(MaCu.Substring(1).ToString());
                HauTo++;
                if (HauTo < 10)
                {
                    txtMaKhach.Text = string.Concat(TienTo, "000", HauTo.ToString());
                }
                else if (HauTo < 100)
                {
                    txtMaKhach.Text = string.Concat(TienTo, "00", HauTo.ToString());
                }
                else if (HauTo < 1000)
                {
                    txtMaKhach.Text = string.Concat(TienTo, "0", HauTo.ToString());
                }
                else if (HauTo < 10000)
                {
                    txtMaKhach.Text = string.Concat(TienTo, HauTo.ToString());
                }
            }
            else
            {
                txtMaKhach.Text = "K0001";
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtTenKhach.Focus();

        }
        private void ResetValues()
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên Khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhach.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Địa Chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtDienThoai.Text.Trim().Length < 9)
            {
                MessageBox.Show("Bạn phải nhập lại Số Điện Thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }


            string sql = "INSERT INTO KHACH VALUES(N'" +
                txtMaKhach.Text + "',N'" + txtTenKhach.Text + "',N'" + txtDiaChi.Text + "',N'" + txtDienThoai.Text + "')";
            Functions.exeData(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBo.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên Khách ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDienThoai.Text.Trim().Length < 9)
            {
                MessageBox.Show("Bạn phải nhập lại Số Điện Thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE KHACH SET TenKhach=N'" +
                txtTenKhach.Text.ToString() + "',DiaChi=N'" + txtDiaChi.Text.Trim().ToString() +
                "',SoDienThoai=N'" + txtDienThoai.Text.ToString() +
                "' WHERE MaKhach=N'" + txtMaKhach.Text + "'";
            Functions.exeData(sql);
            LoadDataGridView();
            ResetValues();
            btnBo.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE KHACH WHERE MaKhach=N'" + txtMaKhach.Text + "'";
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
