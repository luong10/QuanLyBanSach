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
    public partial class frmBaoCao : Form
    {
        DataTable tblBaoCao, tblThongtinHang;
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
            btnIn.Enabled = true;
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT SACH.TenSach, CHITIETHDBAN.GiaBan,CHITIETHDBAN.GiamGia,sum(SoLuong) as Soluong,sum(ThanhTien) as ThanhTien " +
                "FROM HOADONBAN, CHITIETHDBAN, SACH WHERE CHITIETHDBAN.MaHoaDonBan = HOADONBAN.MaHoaDonBan " +
                "and CHITIETHDBAN.MaSach = SACH.MaSach And NgayBan BETWEEN '"+ txtTuNgay.Value.ToShortDateString()+"' AND '"+txtDenNgay.Value.ToShortDateString()+"' " +
                "group by CHITIETHDBAN.GiaBan,SACH.TenSach,CHITIETHDBAN.GiamGia";
                tblBaoCao = Functions.GetData(sql);
                dgvBaoCao.DataSource = tblBaoCao;
                dgvBaoCao.Columns[0].HeaderText = "Tên sách";
                dgvBaoCao.Columns[1].HeaderText = "Giá bán";
                dgvBaoCao.Columns[2].HeaderText = "Giảm giá";
                dgvBaoCao.Columns[3].HeaderText = "Số lượng";
                dgvBaoCao.Columns[4].HeaderText = "Doanh thu";

                dgvBaoCao.Columns[0].Width = 250;

                dgvBaoCao.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
                dgvBaoCao.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
            sql = "SELECT sum(ThanhTien) FROM HOADONBAN, CHITIETHDBAN, SACH " +
                "WHERE CHITIETHDBAN.MaHoaDonBan = HOADONBAN.MaHoaDonBan and CHITIETHDBAN.MaSach = SACH.MaSach " +
                "And NgayBan BETWEEN '" + txtTuNgay.Value.ToShortDateString() + "' AND '" + txtDenNgay.Value.ToShortDateString() + "'";
            txtTongTien.Text = Functions.GetFieldValues(sql);
            sql = "SELECT top 1 SACH.TenSach FROM HOADONBAN, CHITIETHDBAN, SACH " +
                "WHERE CHITIETHDBAN.MaHoaDonBan = HOADONBAN.MaHoaDonBan and CHITIETHDBAN.MaSach = SACH.MaSach " +
                "And NgayBan BETWEEN '"+txtTuNgay.Value.ToShortDateString()+ "' AND '" + txtDenNgay.Value.ToShortDateString() + "' " +
                "group by CHITIETHDBAN.GiaBan,SACH.TenSach,CHITIETHDBAN.GiamGia " +
                "order by sum(SoLuong) desc";
            lbSachChayNhat.Text = Functions.GetFieldValues(sql);
            sql = "SELECT top 1 HOADONBAN.MaHoaDonBan FROM HOADONBAN " +
                "WHERE NgayBan BETWEEN '" + txtTuNgay.Value.ToShortDateString() + "' AND '" + txtDenNgay.Value.ToShortDateString() + "' " +
                "order by TongTien desc";
            lbHoaDon.Text = Functions.GetFieldValues(sql);

        }
        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            btnIn.Enabled = false;
            txtTongTien.ReadOnly = true;
            LoadDataGridView();
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


            exRange.Range["C2:E2"].Value = "BÁO CÁO DOANH THU "  ;
            exRange.Range["B5:B5"].Value = "Từ ngày:";
            exRange.Range["C5:C5"].Font.Bold = true;
            exRange.Range["C5:C5"].Value = txtTuNgay.Value.ToShortDateString();

            exRange.Range["E5:E5"].Value = "Đến ngày:";
            exRange.Range["F5:F5"].Font.Bold = true;
            exRange.Range["F5:F5"].Value = txtDenNgay.Value.ToShortDateString();

            sql = "SELECT SACH.TenSach, CHITIETHDBAN.GiaBan,CHITIETHDBAN.GiamGia,sum(SoLuong) as Soluong,sum(ThanhTien) as ThanhTien " +
                "FROM HOADONBAN, CHITIETHDBAN, SACH WHERE CHITIETHDBAN.MaHoaDonBan = HOADONBAN.MaHoaDonBan " +
                "and CHITIETHDBAN.MaSach = SACH.MaSach And NgayBan BETWEEN '" + txtTuNgay.Value.ToShortDateString() + "' AND '" + txtDenNgay.Value.ToShortDateString() + "' " +
                "group by CHITIETHDBAN.GiaBan,SACH.TenSach,CHITIETHDBAN.GiamGia";
            tblThongtinHang = Functions.GetData(sql);

            //Tạo dòng tiêu đề bảng
            exRange.Range["A7:F7"].Font.Bold = true;
            exRange.Range["A7:F7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C7:F7"].ColumnWidth = 12;
            exRange.Range["A7:A7"].Value = "STT";
            exRange.Range["B7:B7"].Value = "Tên sách";
            exRange.Range["C7:C7"].Value = "Giá bán";
            exRange.Range["D7:D7"].Value = "Giảm giá";
            exRange.Range["E7:E7"].Value = "Số lượng";
            exRange.Range["F7:F7"].Value = "Doanh thu";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                exSheet.Cells[1][hang + 8] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 2][hang + 8] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }

            exRange = exSheet.Cells[3][hang + 12];
            exRange.Font.Bold = true;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Value2 = "Tổng doanh thu:";
            exRange = exSheet.Cells[5][hang + 12];
            exRange.Font.Bold = true;
            exRange.Value2 = txtTongTien.Text;

            exRange = exSheet.Cells[3][hang + 14];
            exRange.Font.Bold = true;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Value2 = "Sách bán chạy nhất:";
            exRange = exSheet.Cells[5][hang + 14];
            exRange.Range["A1:C1"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Font.Bold = true;
            exRange.Value2 = lbSachChayNhat.Text;

            exRange = exSheet.Cells[3][hang + 16];
            exRange.Font.Bold = true;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Value2 = "Hóa đơn lớn nhất:";
            exRange = exSheet.Cells[5][hang + 16];
            exRange.Range["A1:C1"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Font.Bold = true;
            exRange.Value2 = lbHoaDon.Text;

            exRange = exSheet.Cells[4][hang + 18]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Hà Nam, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exSheet.Name = "báo cáo doanh thu";
            exApp.Visible = true;
        }
    }
}
