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
    public partial class frmNXB : Form
    {
        DataTable tblNXB;
        public frmNXB()
        {
            InitializeComponent();
        }

        private void frmNXB_Load(object sender, EventArgs e)
        {
            txtMaNXB.Enabled = false;
            btnLuu.Enabled = false;
            btnBo.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NXB";
            tblNXB = Functions.GetData(sql); 
            dgvNXB.DataSource = tblNXB;             
            dgvNXB.Columns[0].HeaderText = "Mã NXB";
            dgvNXB.Columns[1].HeaderText = "NXB";
            dgvNXB.Columns[2].HeaderText = "Địa Chỉ";
            dgvNXB.Columns[3].HeaderText = "Điện Thoại";
            dgvNXB.Columns[0].Width = 110;
            dgvNXB.Columns[1].Width = 170;
            dgvNXB.Columns[2].Width = 140;
            dgvNXB.Columns[3].Width = 170;
            dgvNXB.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNXB.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvNXB_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblNXB.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvNXB.CurrentRow.Selected = true;
            txtMaNXB.Text = dgvNXB.CurrentRow.Cells["MaNXB"].Value.ToString();
            txtNXB.Text = dgvNXB.CurrentRow.Cells["TenNXB"].Value.ToString();
            txtDiaChi.Text = dgvNXB.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtDienThoai.Text = dgvNXB.CurrentRow.Cells["SoDienThoai"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBo.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            string MaCu, TienTo;
            int HauTo;//Lưu lệnh sql
            if( Functions.GetFieldValues("select top 1 MaNXB from NXB order by MaNXB desc").Length > 0)
            {
                MaCu = Functions.GetFieldValues("select top 1 MaNXB from NXB order by MaNXB desc");
                TienTo = MaCu.Substring(0, 3);
                HauTo = int.Parse(MaCu.Substring(3).ToString());
                HauTo++;
                if (HauTo < 10)
                {
                    txtMaNXB.Text = string.Concat(TienTo, "0", HauTo.ToString());
                }
                else
                {
                    txtMaNXB.Text = string.Concat(TienTo, HauTo.ToString());
                }
            }
            else
            {
                txtMaNXB.Text = "NXB01";
            }
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }
        private void ResetValue()
        {
            txtMaNXB.Text = "";
            txtNXB.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (txtNXB.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập tên NXB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNXB.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập Địa Chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtDienThoai.Text.Trim().Length < 9 )
            {
                MessageBox.Show("Bạn phải nhập đúng Số Điện Thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
           

            string sql = "INSERT INTO NXB VALUES(N'" +
                txtMaNXB.Text + "',N'" + txtNXB.Text + "',N'" + txtDiaChi.Text + "',N'" + txtDienThoai.Text + "')";
            Functions.exeData(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBo.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNXB.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNXB.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn chưa nhập tên NXB ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn chưa nhập Địa Chỉ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDienThoai.Text.Trim().Length < 9) 
            {
                MessageBox.Show("Bạn phải nhập đúng Số Điện Thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NXB SET TenNXB=N'" +
                txtNXB.Text.ToString() + "',DiaChi=N'" + txtDiaChi.Text.Trim().ToString() +
                "',SoDienThoai=N'" + txtDienThoai.Text.ToString() +
                "' WHERE MaNXB=N'" + txtMaNXB.Text + "'";
            Functions.RunSqlDel(sql);
            LoadDataGridView();
            ResetValue();
            btnBo.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
                string sql;
                if (tblNXB.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtMaNXB.Text == "") //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE NXB WHERE MaNXB=N'" + txtMaNXB.Text + "'";
                    Functions.RunSqlDel(sql);
                    LoadDataGridView();
                    ResetValue();
                }
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            ResetValue();
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
