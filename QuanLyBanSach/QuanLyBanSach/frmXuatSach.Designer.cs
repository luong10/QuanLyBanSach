namespace QuanLyBanSach
{
    partial class frmXuatSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboKieuXuat = new System.Windows.Forms.ComboBox();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlSoLuong = new System.Windows.Forms.Panel();
            this.txtSLKho = new System.Windows.Forms.TextBox();
            this.txtSLKe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboMaSach = new System.Windows.Forms.ComboBox();
            this.txtGia = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboTim = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvCTHDX = new System.Windows.Forms.DataGridView();
            this.txtTongTien = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlTongTien = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlNXB = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlSoLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDX)).BeginInit();
            this.pnlNXB.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlNXB);
            this.groupBox1.Controls.Add(this.cboKieuXuat);
            this.groupBox1.Controls.Add(this.txtNgay);
            this.groupBox1.Controls.Add(this.cboMaNV);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(757, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // cboKieuXuat
            // 
            this.cboKieuXuat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKieuXuat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKieuXuat.FormattingEnabled = true;
            this.cboKieuXuat.Items.AddRange(new object[] {
            "Xuất kệ sách",
            "Trả NXB"});
            this.cboKieuXuat.Location = new System.Drawing.Point(360, 81);
            this.cboKieuXuat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboKieuXuat.Name = "cboKieuXuat";
            this.cboKieuXuat.Size = new System.Drawing.Size(131, 29);
            this.cboKieuXuat.TabIndex = 47;
            this.cboKieuXuat.TextChanged += new System.EventHandler(this.cboKieuXuat_TextChanged);
            // 
            // txtNgay
            // 
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgay.Location = new System.Drawing.Point(104, 78);
            this.txtNgay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(150, 34);
            this.txtNgay.TabIndex = 45;
            this.txtNgay.Value = new System.DateTime(2021, 5, 19, 23, 23, 54, 0);
            // 
            // cboMaNV
            // 
            this.cboMaNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMaNV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(576, 33);
            this.cboMaNV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(163, 29);
            this.cboMaNV.TabIndex = 43;
            // 
            // txtMa
            // 
            this.txtMa.BackColor = System.Drawing.Color.White;
            this.txtMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMa.Location = new System.Drawing.Point(104, 30);
            this.txtMa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(387, 34);
            this.txtMa.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(267, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 24);
            this.label7.TabIndex = 38;
            this.label7.Text = "Kiểu xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(501, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 24);
            this.label4.TabIndex = 36;
            this.label4.Text = "Tên NV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Ngày xuất";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Mã xuất";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlSoLuong);
            this.groupBox2.Controls.Add(this.txtSoLuong);
            this.groupBox2.Controls.Add(this.txtThanhTien);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboMaSach);
            this.groupBox2.Controls.Add(this.txtGia);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTenSach);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox2.Location = new System.Drawing.Point(21, 152);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.groupBox2.Size = new System.Drawing.Size(757, 142);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết hóa đơn";
            // 
            // pnlSoLuong
            // 
            this.pnlSoLuong.Controls.Add(this.txtSLKho);
            this.pnlSoLuong.Controls.Add(this.txtSLKe);
            this.pnlSoLuong.Controls.Add(this.label6);
            this.pnlSoLuong.Controls.Add(this.label5);
            this.pnlSoLuong.Location = new System.Drawing.Point(473, 32);
            this.pnlSoLuong.Name = "pnlSoLuong";
            this.pnlSoLuong.Size = new System.Drawing.Size(276, 100);
            this.pnlSoLuong.TabIndex = 70;
            // 
            // txtSLKho
            // 
            this.txtSLKho.BackColor = System.Drawing.Color.White;
            this.txtSLKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSLKho.Location = new System.Drawing.Point(139, 55);
            this.txtSLKho.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtSLKho.Name = "txtSLKho";
            this.txtSLKho.Size = new System.Drawing.Size(127, 34);
            this.txtSLKho.TabIndex = 74;
            this.txtSLKho.TextChanged += new System.EventHandler(this.txtSLKho_TextChanged);
            // 
            // txtSLKe
            // 
            this.txtSLKe.BackColor = System.Drawing.Color.White;
            this.txtSLKe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSLKe.Location = new System.Drawing.Point(139, 7);
            this.txtSLKe.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtSLKe.Name = "txtSLKe";
            this.txtSLKe.Size = new System.Drawing.Size(127, 34);
            this.txtSLKe.TabIndex = 73;
            this.txtSLKe.TextChanged += new System.EventHandler(this.txtSLKe_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(48, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 26);
            this.label6.TabIndex = 72;
            this.label6.Text = "SL kho";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(14, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 26);
            this.label5.TabIndex = 71;
            this.label5.Text = "SL trên kệ";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BackColor = System.Drawing.Color.White;
            this.txtSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoLuong.Location = new System.Drawing.Point(376, 41);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(82, 34);
            this.txtSoLuong.TabIndex = 48;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(589, 92);
            this.txtThanhTien.Mask = "0000000";
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(128, 34);
            this.txtThanhTien.TabIndex = 75;
            this.txtThanhTien.ValidatingType = typeof(int);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(482, 100);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 24);
            this.label11.TabIndex = 72;
            this.label11.Text = "Thành tiền";
            // 
            // cboMaSach
            // 
            this.cboMaSach.FormattingEnabled = true;
            this.cboMaSach.Location = new System.Drawing.Point(117, 41);
            this.cboMaSach.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboMaSach.Name = "cboMaSach";
            this.cboMaSach.Size = new System.Drawing.Size(137, 34);
            this.cboMaSach.TabIndex = 43;
            this.cboMaSach.TextChanged += new System.EventHandler(this.cboMaSach_TextChanged);
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(589, 37);
            this.txtGia.Mask = "0000000";
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(128, 34);
            this.txtGia.TabIndex = 74;
            this.txtGia.ValidatingType = typeof(int);
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(499, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 24);
            this.label9.TabIndex = 73;
            this.label9.Text = "Giá nhập";
            // 
            // txtTenSach
            // 
            this.txtTenSach.BackColor = System.Drawing.Color.White;
            this.txtTenSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenSach.Location = new System.Drawing.Point(117, 93);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(341, 34);
            this.txtTenSach.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(286, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 26);
            this.label8.TabIndex = 38;
            this.label8.Text = "SL xuất";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(9, 101);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 26);
            this.label10.TabIndex = 36;
            this.label10.Text = "Tên Sách";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(19, 51);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 26);
            this.label12.TabIndex = 33;
            this.label12.Text = "Mã Sách";
            // 
            // cboTim
            // 
            this.cboTim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTim.FormattingEnabled = true;
            this.cboTim.Location = new System.Drawing.Point(511, 588);
            this.cboTim.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboTim.Name = "cboTim";
            this.cboTim.Size = new System.Drawing.Size(181, 34);
            this.cboTim.TabIndex = 66;
            this.cboTim.DropDown += new System.EventHandler(this.cboTim_DropDown);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.Transparent;
            this.btnTim.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("UTM Cookies", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.Green;
            this.btnTim.Image = global::QuanLyBanSach.Properties.Resources.icons8_search_client_32;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(706, 583);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(82, 38);
            this.btnTim.TabIndex = 69;
            this.btnTim.Text = "tìm ";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(431, 594);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 23);
            this.label13.TabIndex = 68;
            this.label13.Text = "Mã xuất";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Transparent;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("UTM Cookies", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Green;
            this.btnHuy.Image = global::QuanLyBanSach.Properties.Resources.icons8_delete_301;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(252, 588);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(89, 38);
            this.btnHuy.TabIndex = 67;
            this.btnHuy.Text = "xóa";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("UTM Cookies", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Green;
            this.btnLuu.Image = global::QuanLyBanSach.Properties.Resources.icons8_save_close_27;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(153, 588);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(84, 38);
            this.btnLuu.TabIndex = 63;
            this.btnLuu.Text = "lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("UTM Cookies", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Green;
            this.btnThem.Image = global::QuanLyBanSach.Properties.Resources.icons8_plus_30;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(35, 588);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(98, 38);
            this.btnThem.TabIndex = 62;
            this.btnThem.Text = "thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvCTHDX
            // 
            this.dgvCTHDX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTHDX.BackgroundColor = System.Drawing.Color.White;
            this.dgvCTHDX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCTHDX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHDX.Location = new System.Drawing.Point(21, 301);
            this.dgvCTHDX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvCTHDX.Name = "dgvCTHDX";
            this.dgvCTHDX.Size = new System.Drawing.Size(757, 224);
            this.dgvCTHDX.TabIndex = 60;
            this.dgvCTHDX.DoubleClick += new System.EventHandler(this.dgvCTHDX_DoubleClick);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(650, 539);
            this.txtTongTien.Mask = "0000000";
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(128, 34);
            this.txtTongTien.TabIndex = 71;
            this.txtTongTien.ValidatingType = typeof(int);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(549, 546);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 24);
            this.label14.TabIndex = 70;
            this.label14.Text = "Tổng tiền";
            // 
            // pnlTongTien
            // 
            this.pnlTongTien.Location = new System.Drawing.Point(553, 531);
            this.pnlTongTien.Name = "pnlTongTien";
            this.pnlTongTien.Size = new System.Drawing.Size(235, 52);
            this.pnlTongTien.TabIndex = 72;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.Transparent;
            this.btnIn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnIn.FlatAppearance.BorderSize = 0;
            this.btnIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("UTM Cookies", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.Green;
            this.btnIn.Image = global::QuanLyBanSach.Properties.Resources.icons8_page_28;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(345, 588);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(70, 38);
            this.btnIn.TabIndex = 73;
            this.btnIn.Text = "in";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // cboNXB
            // 
            this.cboNXB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNXB.FormattingEnabled = true;
            this.cboNXB.Location = new System.Drawing.Point(64, 10);
            this.cboNXB.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(163, 29);
            this.cboNXB.TabIndex = 49;
            this.cboNXB.TextChanged += new System.EventHandler(this.cboNXB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 26);
            this.label3.TabIndex = 48;
            this.label3.Text = "NXB";
            // 
            // pnlNXB
            // 
            this.pnlNXB.Controls.Add(this.cboNXB);
            this.pnlNXB.Controls.Add(this.label3);
            this.pnlNXB.Location = new System.Drawing.Point(513, 68);
            this.pnlNXB.Name = "pnlNXB";
            this.pnlNXB.Size = new System.Drawing.Size(237, 49);
            this.pnlNXB.TabIndex = 74;
            // 
            // frmXuatSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 630);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.pnlTongTien);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboTim);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvCTHDX);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmXuatSach";
            this.Text = "2";
            this.Load += new System.EventHandler(this.frmXuatSach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlSoLuong.ResumeLayout(false);
            this.pnlSoLuong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDX)).EndInit();
            this.pnlNXB.ResumeLayout(false);
            this.pnlNXB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboKieuXuat;
        private System.Windows.Forms.DateTimePicker txtNgay;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cboMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvCTHDX;
        private System.Windows.Forms.Panel pnlSoLuong;
        private System.Windows.Forms.TextBox txtSLKho;
        private System.Windows.Forms.TextBox txtSLKe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtTongTien;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtThanhTien;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtGia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlTongTien;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlNXB;
    }
}