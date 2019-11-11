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
    public partial class fQuanLyXe : Form
    {
        BindingSource dsXe = new BindingSource();
        public fQuanLyXe()
        {
            InitializeComponent();
            phanQuyen();
            dgvXe.DataSource = dsXe;
            hienThiDanhSachXe();
            taoRangBuoc();
        }

        #region Methods
        void phanQuyen()
        {
            btDatVe.Enabled = false;
        }
        void hienThiDanhSachXe()
        { 
            dsXe.DataSource = XeDAO.Instance.LayDsXe();

            dgvXe.Columns[0].HeaderText = "Biển số";
            dgvXe.Columns[0].Width = 200;

            dgvXe.Columns[1].HeaderText = "Tên tài xế";
            dgvXe.Columns[1].Width = 235;

            dgvXe.Columns[2].HeaderText = "Số điện thoại tài xế";
            dgvXe.Columns[2].Width = 150;

            dgvXe.Columns[3].HeaderText = "Loại xe";
            dgvXe.Columns[3].Width = 200;
        }

        //tạo ràng buộc giữa datagridview với các ô text
        void taoRangBuoc()
        {
            txtBienSo.DataBindings.Add("Text", dgvXe.DataSource, "bienSo", true, DataSourceUpdateMode.Never);
            txtTenXe.DataBindings.Add("text", dgvXe.DataSource, "tenXe", true, DataSourceUpdateMode.Never);
            txtTaiXe.DataBindings.Add("text", dgvXe.DataSource, "taiXe", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add("text", dgvXe.DataSource, "sdtTaiXe", true, DataSourceUpdateMode.Never);
        }
        void themDuLieu()
        {
            try
            {
                string bienSo = txtBienSo.Text;
                string taiXe = txtTaiXe.Text;
                int sdt = int.Parse(txtSDT.Text);
                string tenXe = txtTenXe.Text;

                if (bienSo == "" || taiXe == "" || tenXe == "")
                    MessageBox.Show("Bạn phải nhập đủ!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string bienSoTim = XeDAO.Instance.timXeTheoBienSo(bienSo).ToLower();
                    if (bienSoTim == bienSo.ToLower())
                        MessageBox.Show("Lỗi!! Trùng biển số xe!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool ketQua = XeDAO.Instance.themXe(bienSo, taiXe, sdt, tenXe);
                        if (ketQua)
                        {
                            MessageBox.Show("Thêm thành công!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            hienThiDanhSachXe();
                        }
                        else
                            MessageBox.Show("Thêm không thành công!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi nhập!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Events

        private void btThem_Click(object sender, EventArgs e)
        {
            themDuLieu();
        }
        
        private void btXoa_Click(object sender, EventArgs e)
        {
            string bienSo = txtBienSo.Text;
            if (bienSo == "")
                MessageBox.Show("Bạn chưa chọn xe", "Xóa xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                XeDAO.Instance.xoaXeBangBienSo(bienSo);
                hienThiDanhSachXe();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                string bienSo = txtBienSo.Text;
                string taiXe = txtTaiXe.Text;
                int sdt = int.Parse(txtSDT.Text);
                string tenXe = txtTenXe.Text;
                bool ketQua = XeDAO.Instance.suaThongTinXe(bienSo, taiXe, sdt, tenXe);
                if (ketQua)
                {
                    MessageBox.Show("Sửa thành công!", "Sửa thông tin xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiDanhSachXe();
                }
                else
                    MessageBox.Show("Sửa không thành công!", "Sửa thông tin xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi định dạng nhập! Vui lòng kiểm tra lại", "Sửa thông tin xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtDatVeXe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn không phải khách hàng", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtChuyenDi_Click(object sender, EventArgs e)
        {
            fQuanLyChuyenDi f = new fQuanLyChuyenDi();
            f.Show();
            this.Dispose(false);
        }

        private void BtKhachHang_Click(object sender, EventArgs e)
        {
            fQuanLyKhachHang f = new fQuanLyKhachHang();
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
            {
                fDangNhap f = new fDangNhap();
                f.Show();
                this.Dispose(false);
            }
        }
        #endregion
    }
}
