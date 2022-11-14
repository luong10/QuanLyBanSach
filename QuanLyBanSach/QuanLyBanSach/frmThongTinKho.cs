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
    public partial class frmThongTinKho : Form
    {
        int i = 0;
        DataTable  tblThongtinHang;
        DataTable tblSach;
        public frmThongTinKho()
        {
            InitializeComponent();
        }

        private void frmThongTinKho_Load(object sender, EventArgs e)
        {
            string sql;
            sql =  "SELECT SUM(SLKho + SLKe) FROM SACH";
            lbTongSach.Text = Functions.GetFieldValues(sql);
            sql = "SELECT SUM(SLKho) FROM SACH";
            lbTrongKho.Text = Functions.GetFieldValues(sql);
            sql = "SELECT SUM(SLKe) FROM SACH";
            lbTrenKe.Text = Functions.GetFieldValues(sql);
        }

        private void lbSachSapHet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            i = 1;
            string sql;
            sql = "Select MaSach,TenSach,SLKe,SLKho,GiamGia from SACH where SLKe <=3";
            LoadDataGridView(sql);
           
        }
        private void LoadDataGridView(string sql)
        {
            tblSach = Functions.GetData(sql);
            dgvSach.DataSource = tblSach;
            dgvSach.Columns[0].HeaderText = "Mã sách";
            dgvSach.Columns[1].HeaderText = "Tên sách";
            dgvSach.Columns[2].HeaderText = "SL trên kệ";
            dgvSach.Columns[3].HeaderText = "SL kho";
            dgvSach.Columns[4].HeaderText = "Giảm giá %";

            dgvSach.Columns[0].Width = 80;
            dgvSach.Columns[1].Width = 130;

            dgvSach.AllowUserToAddRows = false;
            dgvSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void lbSachKho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            i = 2;
            string sql;
            sql = "Select MaSach,TenSach,SLKe,SLKho,GiamGia from SACH where SLKho <=3";
            LoadDataGridView(sql);
        }

        private void lbGiamGia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            i = 3;
            string sql;
            sql = "select MaSach,TenSach,SLKe,SLKho,GiamGia from SACH where GiamGia != 0";
            LoadDataGridView(sql);
        }

        private void lbTraNXB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            i = 4;
            string sql;
            sql = "Select CHITIETHDXUAT.MaSach,TenSach,SLKe,SLKho,GiamGia from SACH , CHITIETHDXUAT, HOADONXUAT " +
                "where CHITIETHDXUAT.MaXuat=HOADONXUAT.MaXuat and CHITIETHDXUAT.MaSach = SACH.MaSach " +
                "and HOADONXUAT.KieuXuat = N'Xuất kệ sách' and DATEDIFF(month, NgayXuat, GETDATE()) > 10";
            LoadDataGridView(sql);
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

            if (i == 1 )
            {
                exRange.Range["C2:E2"].Value = lbSachSapHet.Text;
                exSheet.Name = lbSachSapHet.Text;
                sql = "Select MaSach,TenSach,SLKe,SLKho,GiamGia from SACH where SLKe <=3";
                tblThongtinHang = Functions.GetData(sql);
            }
             if (i == 2)
                {
                exSheet.Name = lbSachKho.Text;
                exRange.Range["C2:E2"].Value = lbSachKho.Text;
                sql = "Select MaSach,TenSach,SLKe,SLKho,GiamGia from SACH where SLKho <=3";
                    tblThongtinHang = Functions.GetData(sql);
                }
            if (i == 3)
            {
                exSheet.Name = lbGiamGia.Text;

                exRange.Range["C2:E2"].Value = lbGiamGia.Text;
                sql = "select MaSach,TenSach,SLKe,SLKho,GiamGia from SACH where GiamGia != 0";
                tblThongtinHang = Functions.GetData(sql);
            }
            if(i == 4)
            {
                exSheet.Name = lbTraNXB.Text;

                exRange.Range["C2:E2"].Value = lbTraNXB.Text;
                sql = "Select CHITIETHDXUAT.MaSach,TenSach,SLKe,SLKho,GiamGia from SACH , CHITIETHDXUAT, HOADONXUAT " +
                  "where CHITIETHDXUAT.MaXuat=HOADONXUAT.MaXuat and CHITIETHDXUAT.MaSach = SACH.MaSach " +
                  "and HOADONXUAT.KieuXuat = N'Xuất kệ sách' and DATEDIFF(month, NgayXuat, GETDATE()) > 10";
                tblThongtinHang = Functions.GetData(sql);
            }
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã sách";
            exRange.Range["C11:C11"].Value = "Tên Sách";
            exRange.Range["D11:D11"].Value = "SL Kệ";
            exRange.Range["E11:E11"].Value = "SL kho";
            exRange.Range["F11:F11"].Value = "Giảm giá";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }

            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Hà Nam, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exApp.Visible = true;
        }
    }
}
