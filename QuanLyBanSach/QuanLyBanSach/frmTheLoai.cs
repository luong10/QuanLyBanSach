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
    public partial class frmTheLoai : Form
    {
        DataTable tblTheLoai;
        public frmTheLoai()
        {
            InitializeComponent();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            txtMaTheLoai.Enabled = false;
            btnLuu.Enabled = false;
            btnBo.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM THELOAI";
            tblTheLoai = Functions.GetData(sql); //Đọc dữ liệu từ bảng
            dgvTheLoai.DataSource = tblTheLoai; //Nguồn dữ liệu            
            dgvTheLoai.Columns[0].HeaderText = "Mã ";
            dgvTheLoai.Columns[1].HeaderText = "Thể Loại";
            dgvTheLoai.Columns[2].HeaderText = "Ghi Chú";
            dgvTheLoai.Columns[0].Width = 100;
            dgvTheLoai.Columns[1].Width = 160;
            dgvTheLoai.Columns[2].Width = 110;
            dgvTheLoai.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTheLoai.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

       
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            string  MaCu, TienTo;
            int HauTo;//Lưu lệnh sql
            if(Functions.GetFieldValues("select top 1 MaTheLoai from THELOAI order by MaTheLoai desc").Length > 0)
            {
                MaCu = Functions.GetFieldValues("select top 1 MaTheLoai from THELOAI order by MaTheLoai desc");
                TienTo = MaCu.Substring(0, 2);
                HauTo = int.Parse(MaCu.Substring(2).ToString());
                HauTo++;
                if (HauTo < 10)
                {
                    txtMaTheLoai.Text = string.Concat(TienTo, "00", HauTo.ToString());
                }
                else
                {
                    if (HauTo < 100)
                    {
                        txtMaTheLoai.Text = string.Concat(TienTo, "0", HauTo.ToString());
                    }
                    else
                    {
                        txtMaTheLoai.Text = string.Concat(TienTo, HauTo.ToString());
                    }
                }
            }
            else
            {
                txtMaTheLoai.Text = "TL001";
            }
            
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }
        private void ResetValue()
        {
            txtMaTheLoai.Text = "";
            txtTheLoai.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTheLoai.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập Thể Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTheLoai.Focus();
                return;
            }
           
            string sql = "INSERT INTO THELOAI VALUES(N'" +
                txtMaTheLoai.Text + "',N'" + txtTheLoai.Text.Trim() + "',N'" + txtGhiChu.Text.Trim() +  "')";
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
            if (tblTheLoai.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTheLoai.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTheLoai.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn chưa nhập Thể Loại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            sql = "UPDATE THELOAI SET TenTheLoai=N'" +
                txtTheLoai.Text.Trim()+ "',GhiChu=N'" + txtGhiChu.Text.Trim() +
                "' WHERE MaTheLoai=N'" + txtMaTheLoai.Text + "'";
            Functions.exeData(sql);
            LoadDataGridView();
            ResetValue();
            btnBo.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTheLoai.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTheLoai.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE THELOAI WHERE MaTheLoai=N'" + txtMaTheLoai.Text + "'";
                Functions.exeData(sql);
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

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblTheLoai.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTheLoai.Text = dgvTheLoai.CurrentRow.Cells["MaTheLoai"].Value.ToString();
            txtTheLoai.Text = dgvTheLoai.CurrentRow.Cells["TenTheLoai"].Value.ToString();
            txtGhiChu.Text = dgvTheLoai.CurrentRow.Cells["GhiChu"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBo.Enabled = true;
        }
    }
}
