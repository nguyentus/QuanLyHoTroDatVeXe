using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoTroDatVeXe
{
    public partial class fQuanLyKhachHang : Form
    {
        BindingSource dsKhachHang = new BindingSource();
        public fQuanLyKhachHang()
        {
            InitializeComponent();
            phanQuyen();
            dgvKhachHang.DataSource = dsKhachHang;
            hienThiDanhSach();
            taoRangBuoc();
        }

        #region Methods
        void phanQuyen()
        {
            btDatVe.Enabled = false;
        }
        void hienThiDanhSach()
        {
            dsKhachHang.DataSource = KhachHangDAO.Instance.layDsKhachHang();

            dgvKhachHang.Columns[0].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[0].Width = 90;

            dgvKhachHang.Columns[1].HeaderText = "CMND";
            dgvKhachHang.Columns[1].Width = 70;

            dgvKhachHang.Columns[2].HeaderText = "Họ tên";
            dgvKhachHang.Columns[2].Width = 150;

            dgvKhachHang.Columns[3].HeaderText = "Giới tính";
            dgvKhachHang.Columns[3].Width = 70;

            dgvKhachHang.Columns[4].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[4].Width = 120;

            dgvKhachHang.Columns[5].HeaderText = "Email";
            dgvKhachHang.Columns[5].Width = 140;
        }
        //tạo ràng buộc giữa datagridview với các ô text
        void taoRangBuoc()
        {
            txtSDT.DataBindings.Add("text", dgvKhachHang.DataSource, "soDienThoai", true, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Add("text", dgvKhachHang.DataSource, "hoTen", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("text", dgvKhachHang.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtGioiTinh.DataBindings.Add("text", dgvKhachHang.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("text", dgvKhachHang.DataSource, "diaChi", true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Add("text", dgvKhachHang.DataSource, "email", true, DataSourceUpdateMode.Never);
        }

        void themDuLieu()
        {
            try
            {
                int sdt = int.Parse(txtSDT.Text);
                int cmnd = int.Parse(txtCMND.Text);
                string ht = txtHoTen.Text;
                string gt = txtGioiTinh.Text;
                string dc = txtDiaChi.Text;
                string email = txtEmail.Text;
                if( ht == "" || gt == "" || dc == "" || email == "")
                    MessageBox.Show("Bạn phải nhập đủ thông tin!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    int sdtTim = KhachHangDAO.Instance.timKH(sdt);
                    if (sdtTim == sdt)
                        MessageBox.Show("Lỗi!! Số điện thoại đã tồn tại", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool ketQua = KhachHangDAO.Instance.themKH(sdt, cmnd, ht, gt, dc, email);
                        if (ketQua)
                        {
                            MessageBox.Show("Thêm thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            hienThiDanhSach();
                        }
                        else
                            MessageBox.Show("Thêm không thành công!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi nhập!", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Events
        private void BtChuyenDi_Click(object sender, EventArgs e)
        {
            fQuanLyChuyenDi f = new fQuanLyChuyenDi();
            f.Show();
            this.Dispose(false);
        }
        private void BtXe_Click(object sender, EventArgs e)
        {
            fQuanLyXe f = new fQuanLyXe();
            f.Show();
            this.Dispose(false);
        }
        private void BtBaoCao_Click(object sender, EventArgs e)
        {
            fBaoCaoThongKe f = new fBaoCaoThongKe();
            f.Show();
            this.Dispose(false);
        }
        private void BtThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn rời khỏi phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
        private void BtThem_Click(object sender, EventArgs e)
        {
            themDuLieu();
        }

        private void BtSua_Click(object sender, EventArgs e)
        {
            try
            {
                int sdt = int.Parse(txtSDT.Text);
                int cmnd = int.Parse(txtCMND.Text);
                string ht = txtHoTen.Text;
                string gt = txtGioiTinh.Text;
                string dc = txtDiaChi.Text;
                string email = txtEmail.Text;
                bool ketQua = KhachHangDAO.Instance.suaKHBangSDT(sdt, cmnd, ht, gt, dc, email);
                if (ketQua)
                {
                    MessageBox.Show("Sửa thành công!", "Sửa thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiDanhSach();
                }
                else
                    MessageBox.Show("Sửa không thành công!", "Sửa thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi định dạng nhập! Vui lòng kiểm tra lại", "Sửa thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtXoa_Click(object sender, EventArgs e)
        {
            int sdt = int.Parse(txtSDT.Text);
            if (sdt == 0)
                MessageBox.Show("Bạn chưa chọn khách hàng", "Xóa khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                KhachHangDAO.Instance.xoaKHBangSDT(sdt);
                hienThiDanhSach();
            }
        }
        #endregion
    }
}
