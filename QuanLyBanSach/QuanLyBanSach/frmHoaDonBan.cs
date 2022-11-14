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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanSach
{
    public partial class frmHoaDonBan : Form
    {
        DataTable tblCTHDB;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
           // txtMa.ReadOnly = true;
            txtTenSach.ReadOnly = true;
            txtGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            txtNgay.Value = DateTime.Now;
            Functions.FillCombo("SELECT MaKhach, TenKhach FROM KHACH", cboMaKhach, "MaKhach", "TenKhach");
            cboMaKhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien, TenNhanVien FROM NHANVIEN", cboMaNV, "MaNhanVien", "TenNhanVien");
            cboMaNV.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaSach, TenSach FROM SACH", cboMaSach, "MaSach", "MaSach");
            cboMaSach.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMa.Text != "")
            {
                LoadInfoHoaDon();
                btnHuy.Enabled = true;
                btnIn.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaSach, b.TenSach, a.SoLuong, b.Gia, a.GiamGia,a.ThanhTien FROM CHITIETHDBAN AS a, SACH AS b WHERE a.MaHoaDonBan = N'" + txtMa.Text + "' AND a.MaSach=b.MaSach";
            tblCTHDB = Functions.GetData(sql);
            dgvHDBanHang.DataSource = tblCTHDB;
            dgvHDBanHang.Columns[0].HeaderText = "Mã sách";
            dgvHDBanHang.Columns[1].HeaderText = "Tên sách";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Giảm giá %";
            dgvHDBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHDBanHang.Columns[0].Width = 80;
            dgvHDBanHang.Columns[1].Width = 130;
            dgvHDBanHang.Columns[2].Width = 60;
            dgvHDBanHang.Columns[3].Width = 90;
            dgvHDBanHang.Columns[4].Width = 90;
            dgvHDBanHang.Columns[5].Width = 90;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM HOADONBAN WHERE MaHoaDonBan = N'" + txtMa.Text + "'";
            txtNgay.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT TenNhanVien FROM NHANVIEN,HOADONBAN WHERE HOADONBAN.MaNhanVien = NHANVIEN.MaNhanVien AND MaHoaDonBan = N'" + txtMa.Text + "'";
            cboMaNV.Text = Functions.GetFieldValues(str);
            str = "SELECT TenKhach FROM KHACH,HOADONBAN WHERE HOADONBAN.MaKhachHang = KHACH.MaKhach AND MaHoaDonBan = N'" + txtMa.Text + "'";
            cboMaKhach.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HOADONBAN WHERE MaHoaDonBan = N'" + txtMa.Text + "'";
            txtTongTien.Text = Functions.GetFieldValues(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            ResetValuesHang();
            txtMa.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMa.Text = "";
            txtNgay.Value = DateTime.Now;
            cboMaNV.Text = "";
            cboMaKhach.Text = "";
            txtTongTien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHoaDonBan FROM HOADONBAN WHERE MaHoaDonBan=N'" + txtMa.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (cboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNV.Focus();
                    return;
                }
                if (cboMaKhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }
                sql = "INSERT INTO HOADONBAN(MaHoaDonBan,MaNhanVien,MaKhachHang,NgayBan,TongTien) VALUES (N'" + txtMa.Text.Trim() + "',N'" + cboMaNV.SelectedValue + "',N'" +
                        cboMaKhach.SelectedValue + "','" +
                        txtNgay.Value.ToShortDateString() + "'," + txtTongTien.Text + ")";
                Functions.exeData(sql);
               
            }
            // Lưu thông tin của các mặt hàng
            if (cboMaSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSach.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            sql = "SELECT MaSach FROM CHITIETHDBAN WHERE MaSach=N'" + cboMaSach.SelectedValue + "' AND MaHoaDonBan = N'" + txtMa.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaSach.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLKe FROM SACH WHERE MaSach = N'" + cboMaSach.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO CHITIETHDBAN(MaHoaDonBan,MaSach,SoLuong,GiaBan,GiamGia,ThanhTien) VALUES(N'" + txtMa.Text.Trim() + "',N'" + cboMaSach.SelectedValue + "'," + txtSoLuong.Text + "," + txtGia.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            if (Functions.exeData(sql))
            {
                LoadDataGridView();
                // Cập nhật lại số lượng của mặt hàng vào bảng sach
                SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
                sql = "UPDATE SACH SET SLKe =" + SLcon + " WHERE MaSach= N'" + cboMaSach.SelectedValue + "'";
                Functions.exeData(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HOADONBAN WHERE MaHoaDonBan = N'" + txtMa.Text + "'"));
                Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
                sql = "UPDATE HOADONBAN SET TongTien =" + Tongmoi + " WHERE MaHoaDonBan = N'" + txtMa.Text + "'";
                Functions.exeData(sql);
                txtTongTien.Text = Tongmoi.ToString();
                ResetValuesHang();
            }
            btnHuy.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMaSach.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTenSach.Text = "";
        }

        private void cboMaSach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaSach.Text == "")
            {
                txtTenSach.Text = "";
                txtGia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenSach FROM SACH WHERE MaSach =N'" + cboMaSach.Text.Trim() + "'";
            txtTenSach.Text = Functions.GetFieldValues(str);
            str = "SELECT Gia FROM SACH WHERE MaSach =N'" + cboMaSach.Text.Trim() + "'";
            txtGia.Text = Functions.GetFieldValues(str);
            str = "SELECT GiamGia FROM SACH WHERE MaSach =N'" + cboMaSach.Text.Trim() + "'";
            txtGiamGia.Text = Functions.GetFieldValues(str);
        }

        

        

        private void txtSoLuong_TextChanged_1(object sender, EventArgs e)
        {
            double sl, tt, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged_1(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double sl, tt, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void cboTim_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHoaDonBan FROM HOADONBAN", cboTim, "MaHoaDonBan", "MaHoaDonBan");
            cboTim.SelectedIndex = -1;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cboTim.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTim.Focus();
                return;
            }
            txtMa.Text = cboTim.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cboTim.SelectedIndex = -1;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Nhà Sách NAM CAO";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Phủ Lý - Hà Nam";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (034)2059696";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoaDonBan, a.NgayBan, a.TongTien, b.TenKhach, b.DiaChi, b.SoDienThoai, c.TenNhanVien FROM HOADONBAN AS a, KHACH AS b, NHANVIEN AS c WHERE a.MaHoaDonBan = N'" + txtMa.Text + "' AND a.MaKhachHang = b.MaKhach AND a.MaNhanVien = c.MaNhanVien";
            tblThongtinHD = Functions.GetData(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSach, a.SoLuong, b.Gia, a.GiamGia, a.ThanhTien " +
                  "FROM CHITIETHDBAN AS a , SACH AS b WHERE a.MaHoaDonBan = N'" +
                  txtMa.Text + "' AND a.MaSach = b.MaSach";
            tblThongtinHang = Functions.GetData(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sách";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nam, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn";
            exApp.Visible = true;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSach,SoLuong FROM CHITIETHDBAN WHERE MaHoaDonBan = N'" + txtMa.Text + "'";
                DataTable tblSach = Functions.GetData(sql);
                for (int hang = 0; hang <= tblSach.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLKe FROM SACH WHERE MaSach = N'" + tblSach.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblSach.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE SACH SET SLKe =" + slcon + " WHERE MaSach= N'" + tblSach.Rows[hang][0].ToString() + "'";
                    Functions.exeData(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE CHITIETHDBAN WHERE MaHoaDonBan=N'" + txtMa.Text + "'";
                Functions.exeData(sql);

                //Xóa hóa đơn
                sql = "DELETE HOADONBAN WHERE MaHoaDonBan=N'" + txtMa.Text + "'";
                Functions.exeData(sql);
                ResetValues();
                LoadDataGridView();
                btnHuy.Enabled = false;
                btnIn.Enabled = false;
            }

        }
        private void dgvHDBanHang_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvHDBanHang.CurrentRow.Cells["MaSach"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE CHITIETHDBAN WHERE MaHoaDonBan=N'" + txtMa.Text + "' AND MaSach = N'" + MaHangxoa + "'";
                if (Functions.exeData(sql))
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLKe FROM SACH WHERE MaSach = N'" + MaHangxoa + "'"));
                    slcon = sl + SoLuongxoa;
                    sql = "UPDATE SACH SET SLKe =" + slcon + " WHERE MaSach= N'" + MaHangxoa + "'";
                    Functions.exeData(sql);
                    // Cập nhật lại tổng tiền cho hóa đơn bán
                    tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HOADONBAN WHERE MaHoaDonBan = N'" + txtMa.Text + "'"));
                    tongmoi = tong - ThanhTienxoa;
                    sql = "UPDATE HOADONBAN SET TongTien =" + tongmoi + " WHERE MaHoaDonBan = N'" + txtMa.Text + "'";
                    Functions.exeData(sql);
                    txtTongTien.Text = tongmoi.ToString();
                    LoadDataGridView();
                }
            }
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
