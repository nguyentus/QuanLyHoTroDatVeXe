using DAO;
using DTO;
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
    public partial class fQuanLyChuyenDi : Form
    {
        BindingSource dsChuyenDi = new BindingSource();
        public fQuanLyChuyenDi()
        {
            InitializeComponent();
            phanQuyen();
            dgvChuyenDi.DataSource = dsChuyenDi;
            hienThiDanhSachChuyenDi();
            hienThiBienSo();
            taoRangBuoc();
        }

        #region Methods
        void phanQuyen()
        {
            btDatVe.Enabled = false;
        }
        void hienThiDanhSachChuyenDi()
        {
            dsChuyenDi.DataSource = ChuyenDiDAO.Instance.LayDsChuyenDi();
            dgvChuyenDi.Columns[0].HeaderText = "Mã Chuyến đi";
            dgvChuyenDi.Columns[0].Width = 108;
            dgvChuyenDi.Columns[2].HeaderText = "Giờ đi";
            dgvChuyenDi.Columns[2].Width = 108;
            dgvChuyenDi.Columns[1].HeaderText = "Ngày đi";
            dgvChuyenDi.Columns[1].Width = 108;
            dgvChuyenDi.Columns[3].HeaderText = "Nơi xuất phát";
            dgvChuyenDi.Columns[3].Width = 108;
            dgvChuyenDi.Columns[4].HeaderText = "Điểm đến";
            dgvChuyenDi.Columns[4].Width = 108;
            dgvChuyenDi.Columns[5].HeaderText = "Biển số";
            dgvChuyenDi.Columns[5].Width = 108;
            dgvChuyenDi.Columns[6].HeaderText = "Giá vé";
            dgvChuyenDi.Columns[6].Width = 108;
        }
        void hienThiBienSo()
        {
            List<Xe> dsBienSo = XeDAO.Instance.LayDsXe();
            cbBienSo.DataSource = dsBienSo;
            cbBienSo.DisplayMember = "bienSo";
        }
        void taoRangBuoc()
        {
            txtMa.DataBindings.Add("Text", dgvChuyenDi.DataSource, "maCD", true, DataSourceUpdateMode.Never);
            txtGio.DataBindings.Add("Text", dgvChuyenDi.DataSource, "gioDi", true, DataSourceUpdateMode.Never);
            dtpNgay.DataBindings.Add("Value", dgvChuyenDi.DataSource, "ngayDi");
            cbBienSo.DataBindings.Add("Text", dgvChuyenDi.DataSource, "bienSo", true, DataSourceUpdateMode.Never);
            txtDiemDi.DataBindings.Add("Text", dgvChuyenDi.DataSource, "diemDi", true, DataSourceUpdateMode.Never);
            txtDiemDen.DataBindings.Add("Text", dgvChuyenDi.DataSource, "diemDen", true, DataSourceUpdateMode.Never);
            txtGiaVe.DataBindings.Add("Text", dgvChuyenDi.DataSource, "giaVe", true, DataSourceUpdateMode.Never);
        }
            #endregion

            #region Events
            private void BtThem_Click(object sender, EventArgs e)
        {
            try
            {
                string gioDi = txtGio.Text;
                string ngayDi = dtpNgay.Value.Month + "-" + dtpNgay.Value.Day + "-" + dtpNgay.Value.Year;
                string diemDi = txtDiemDi.Text;
                string bienSo = this.cbBienSo.GetItemText(this.cbBienSo.SelectedItem);
                string diemDen = txtDiemDen.Text;
                double giaVe = double.Parse(txtGiaVe.Text);

                if (gioDi == "" || ngayDi == "" || diemDi == "" || diemDen == "" || giaVe == 0 || bienSo == "")
                    MessageBox.Show("Bạn phải nhập đủ!", "Thêm chuyến đi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    bool ketQua = ChuyenDiDAO.Instance.themChuyenDi(gioDi, ngayDi, diemDi, diemDen, giaVe, bienSo);
                    if (ketQua)
                    {
                        MessageBox.Show("Thêm thành công!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienThiDanhSachChuyenDi();
                    }
                    else
                        MessageBox.Show("Thêm không thành công!", "Thêm chuyến đi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi nhập!", "Thêm chuyến đi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtCapNhat_Click(object sender, EventArgs e)
        {
            string gioDi = txtGio.Text;
            string ngayDi = dtpNgay.Value.Month + "-" + dtpNgay.Value.Day + "-" + dtpNgay.Value.Year;
            string diemDi = txtDiemDi.Text;
            string bienSo = this.cbBienSo.GetItemText(this.cbBienSo.SelectedItem);
            string diemDen = txtDiemDen.Text;
            double giaVe = double.Parse(txtGiaVe.Text);
            bool ketQua = ChuyenDiDAO.Instance.suaThongTinChuyenDi(int.Parse(txtMa.Text), gioDi, ngayDi, diemDi, diemDen, giaVe, bienSo);
            if (ketQua)
            {
                MessageBox.Show("Sửa thành công!", "Sửa thông tin chuyến đi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienThiDanhSachChuyenDi();
            }
            else
                MessageBox.Show("Sửa không thành công!", "Sửa thông tin chuyến đi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BtXoa_Click(object sender, EventArgs e)
        {
            int maCD = int.Parse(txtMa.Text);
            if (maCD == 0)
                MessageBox.Show("Bạn chưa chọn chuyến đi", "Xóa chuyến đi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ChuyenDiDAO.Instance.xoaChuyenDiBangmaCD(maCD);
                hienThiDanhSachChuyenDi();
            }
        }
        private void BtDatVeXe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn không phải khách hàng", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtXe_Click(object sender, EventArgs e)
        {
            fQuanLyXe f = new fQuanLyXe();
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
                this.Close();
        }
        #endregion
    }
}
