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
    public partial class frmNhapSach : Form
    {
        DataTable tblCTHDN;
        public frmNhapSach()
        {
            InitializeComponent();
        }

        private void frmNhapSach_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            txtMa.ReadOnly = false;
            txtTenSach.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtTongTien.Text = "0";
            txtGia.Text = "0";
            txtNgay.Value = DateTime.Now;
            Functions.FillCombo("SELECT MaNhanVien, TenNhanVien FROM NHANVIEN", cboMaNV, "MaNhanVien", "TenNhanVien");
            cboMaNV.SelectedIndex = -1;
           
            Functions.FillCombo("SELECT MaNXB, TenNXB FROM NXB", cboNXB, "MaNXB", "TenNXB");
            cboNXB.SelectedIndex = -1;
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
            sql = "SELECT a.MaSach, b.TenSach, a.SoLuong, a.GiaNhap,a.ThanhTien FROM CHITIETHDNHAP AS a, SACH AS b WHERE a.MaHoaDonNhap = N'" + txtMa.Text + "' AND a.MaSach=b.MaSach";
            tblCTHDN = Functions.GetData(sql);
            dgvHDNhap.DataSource = tblCTHDN;
            dgvHDNhap.Columns[0].HeaderText = "Mã sách";
            dgvHDNhap.Columns[1].HeaderText = "Tên sách";
            dgvHDNhap.Columns[2].HeaderText = "Số lượng";
            dgvHDNhap.Columns[3].HeaderText = "Giá nhập";
            dgvHDNhap.Columns[4].HeaderText = "Thành tiền";
            dgvHDNhap.Columns[0].Width = 80;
            dgvHDNhap.Columns[1].Width = 130;
            dgvHDNhap.AllowUserToAddRows = false;
            dgvHDNhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayNhap FROM HOADONNHAP WHERE MaHoaDonNHAP = N'" + txtMa.Text + "'";
            txtNgay.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT TenNhanVien FROM NHANVIEN,HOADONNHAP WHERE HOADONNHAP.MaNhanVien = NHANVIEN.MaNhanVien AND MaHoaDonNHAP = N'" + txtMa.Text + "'";
            cboMaNV.Text = Functions.GetFieldValues(str);
            str = "SELECT TenNXB FROM NXB,HOADONNHAP WHERE HOADONNHAP.MaNXB = NXB.MaNXB AND MaHoaDonNHAP = N'" + txtMa.Text + "'";
            cboNXB.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HOADONNHAP WHERE MaHoaDonNHAP = N'" + txtMa.Text + "'";
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
            txtMa.Text = Functions.CreateKey("HDN");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMa.Text = "";
            txtNgay.Value = DateTime.Now;
            cboMaNV.Text = "";
            txtTongTien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHoaDonNhap FROM HOADONNHAP WHERE MaHoaDonNhap=N'" + txtMa.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (cboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNV.Focus();
                    return;
                }
                if (cboNXB.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn NXB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboNXB.Focus();
                    return;
                }
                sql = "INSERT INTO HOADONNHAP(MaHoaDonNHAP,MaNhanVien,NgayNhap,TongTien,MaNXB) VALUES (N'" + txtMa.Text.Trim() + "',N'" + cboMaNV.SelectedValue + "','" +
                        txtNgay.Value.ToShortDateString() + "'," + txtTongTien.Text + ",N'" + cboNXB.SelectedValue + "')";
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
            if ((txtGia.Text.Trim().Length == 0) || (txtGia.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập giá nhập ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGia.Text = "";
                txtSoLuong.Focus();
                return;
            }
          
            sql = "SELECT MaSach FROM CHITIETHDNHAP WHERE MaSach=N'" + cboMaSach.SelectedValue + "' AND MaHoaDonNhap = N'" + txtMa.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaSach.Focus();
                return;
            }
            
            sql = "INSERT INTO CHITIETHDNHAP(MaHoaDonNhap,MaSach,SoLuong,GiaNhap,ThanhTien) VALUES(N'" + txtMa.Text.Trim() + "',N'" + cboMaSach.SelectedValue + "'," + txtSoLuong.Text + "," + txtGia.Text + "," + txtThanhTien.Text + ")";
            if (Functions.exeData(sql))
            {
                LoadDataGridView();
                // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
                sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLKho FROM SACH WHERE MaSach = N'" + cboMaSach.SelectedValue + "'"));
                SLcon = sl + Convert.ToDouble(txtSoLuong.Text);
                sql = "UPDATE SACH SET SLKho =" + SLcon + " WHERE MaSach= N'" + cboMaSach.SelectedValue + "'";
                Functions.exeData(sql);

                //cập nhật lại giá nhập
                sql = "UPDATE SACH SET GiaNhap =" + Convert.ToDouble(txtGia.Text) + " WHERE MaSach= N'" + cboMaSach.SelectedValue + "'";
                Functions.exeData(sql);

                // Cập nhật lại tổng tiền cho hóa đơn nhập
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HOADONNHAP WHERE MaHoaDonNhap = N'" + txtMa.Text + "'"));
                Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
                sql = "UPDATE HOADONNHAP SET TongTien =" + Tongmoi + " WHERE MaHoaDonNhap = N'" + txtMa.Text + "'";
                Functions.exeData(sql);
                txtTongTien.Text = Tongmoi.ToString();
            }
            ResetValuesHang();
            btnHuy.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMaSach.Text = "";
            txtSoLuong.Text = "";
            txtGia.Text = "0";
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
            
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double sl, tt, dg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGia.Text);
            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }

        private void cboTim_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHoaDonNhap FROM HOADONNHAP", cboTim, "MaHoaDonNhap", "MaHoaDonNhao");
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoaDonNhap, a.NgayNhap, a.TongTien,b.TenNXB, c.TenNhanVien FROM HOADONNHAP AS a,NXB as b, NHANVIEN AS c WHERE a.MaHoaDonNhap = N'" + txtMa.Text + "' AND a.MaNhanVien = c.MaNhanVien and a.MaNXB=b.MaNXB";
            tblThongtinHD = Functions.GetData(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "NXB:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSach, a.SoLuong, b.GiaNhap, a.ThanhTien " +
                  "FROM CHITIETHDNHAP AS a , SACH AS b WHERE a.MaHoaDonNhap = N'" +
                  txtMa.Text + "' AND a.MaSach = b.MaSach";
            tblThongtinHang = Functions.GetData(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sách";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá nhập";
            exRange.Range["E11:E11"].Value = "Thành Tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    //if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
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
            exRange.Range["A2:C2"].Value = "Nhân viên";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][4];
            exSheet.Name = "Hóa đơn nhập";
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
                string sql = "SELECT MaSach,SoLuong FROM CHITIETHDNHAP WHERE MaHoaDonNhap = N'" + txtMa.Text + "'";
                DataTable tblSach = Functions.GetData(sql);
                for (int hang = 0; hang <= tblSach.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLKho FROM SACH WHERE MaSach = N'" + tblSach.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblSach.Rows[hang][1].ToString());
                    slcon = sl - slxoa;
                    sql = "UPDATE SACH SET SLKho =" + slcon + " WHERE MaSach= N'" + tblSach.Rows[hang][0].ToString() + "'";
                    Functions.exeData(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE CHITIETHDNHAP WHERE MaHoaDonNhap=N'" + txtMa.Text + "'";
                Functions.exeData(sql);

                //Xóa hóa đơn
                sql = "DELETE HOADONNHAP WHERE MaHoaDonNhap=N'" + txtMa.Text + "'";
                Functions.exeData(sql);
                ResetValues();
                LoadDataGridView();
                btnHuy.Enabled = false;
                btnIn.Enabled = false;
            }
        }

        private void dgvHDNhap_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvHDNhap.CurrentRow.Cells["MaSach"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHDNhap.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHDNhap.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE CHITIETHDNHAP WHERE MaHoaDonNhap=N'" + txtMa.Text + "' AND MaSach = N'" + MaHangxoa + "'";
                if (Functions.exeData(sql))
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SLKho FROM SACH WHERE MaSach = N'" + MaHangxoa + "'"));
                    slcon = sl - SoLuongxoa;
                    sql = "UPDATE SACH SET SLKho =" + slcon + " WHERE MaSach= N'" + MaHangxoa + "'";
                    Functions.exeData(sql);
                    // Cập nhật lại tổng tiền cho hóa đơn bán
                    tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HOADONNHAP WHERE MaHoaDonNhap = N'" + txtMa.Text + "'"));
                    tongmoi = tong - ThanhTienxoa;
                    sql = "UPDATE HOADONNHAP SET TongTien =" + tongmoi + " WHERE MaHoaDonNhap = N'" + txtMa.Text + "'";
                    Functions.exeData(sql);
                    txtTongTien.Text = tongmoi.ToString();
                    LoadDataGridView();
                }
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            double sl, tt, dg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtGia.Text);
            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }

        private void cboNXB_TextChanged(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaSach, TenSach FROM SACH where MaNXB =N'" + cboNXB.SelectedValue+ "'", cboMaSach, "MaSach", "MaSach");
            cboMaSach.SelectedIndex = -1;
        }
    }
}
