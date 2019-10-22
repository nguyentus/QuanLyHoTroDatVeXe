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
            Load();
        }

        #region Methods
        void Load()
        {
            dgvChuyenDi.DataSource = dsChuyenDi;
            hienThiDanhSachChuyenDi();
            hienThiBienSo();
            hienThiMaCD();
            hienThiDiemDi();
            hienThiDiemDen();
            hienThiGioDi();
        }
        void hienThiDanhSachChuyenDi()
        {
            dsChuyenDi.DataSource = ChuyenDiDAO.Instance.LayDsChuyenDi();
            dgvChuyenDi.Columns[0].HeaderText = "Mã Chuyến đi";
            dgvChuyenDi.Columns[0].Width = 108;
            dgvChuyenDi.Columns[1].HeaderText = "Ngày đi";
            dgvChuyenDi.Columns[1].Width = 108;
            dgvChuyenDi.Columns[2].HeaderText = "Giờ đi";
            dgvChuyenDi.Columns[2].Width = 108;
            dgvChuyenDi.Columns[3].HeaderText = "Điểm đi";
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
        void hienThiMaCD()
        {
            txtMaChuyenDi.DataBindings.Add("Text", dgvChuyenDi.DataSource, "maCD", true, DataSourceUpdateMode.Never);
        }
        void hienThiGioDi()
        {
            List<ChuyenDi> dsChuyenDi = ChuyenDiDAO.Instance.LayDsChuyenDi();
            cbGioKhoiHanh.DataSource = dsChuyenDi;
            cbGioKhoiHanh.DisplayMember = "gioDi";
        }
        void hienThiDiemDi()
        {
            List<DiemDi> dsDiemDi = DiemDiDAO.Instance.LayDsDiemDi();
            cbDiemDi.DataSource = dsDiemDi;
            cbDiemDi.DisplayMember = "tenTinh";
        }
        void hienThiDiemDen()
        {
            List<DiemDen> dsDiemDen = DiemDenDAO.Instance.LayDsDiemDen();
            cbDiemDen.DataSource = dsDiemDen;
            cbDiemDen.DisplayMember = "tenTinh";
        }
        #endregion

        #region Events
        private void BtThem_Click(object sender, EventArgs e)
        {
            try
            {
                string gioDi = this.cbGioKhoiHanh.GetItemText(this.cbGioKhoiHanh.SelectedItem);
                string ngayDi = dtpNgayKhoiHanh.Value.Month + "-" + dtpNgayKhoiHanh.Value.Day + "-" + dtpNgayKhoiHanh.Value.Year;
                string diemDi = this.cbDiemDi.GetItemText(this.cbDiemDi.SelectedItem);
                string bienSo = this.cbBienSo.GetItemText(this.cbBienSo.SelectedItem);
                string diemDen = this.cbDiemDen.GetItemText(this.cbDiemDen.SelectedItem);
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
            string gioDi = this.cbGioKhoiHanh.GetItemText(this.cbGioKhoiHanh.SelectedItem);
            string ngayDi = dtpNgayKhoiHanh.Value.Month + "-" + dtpNgayKhoiHanh.Value.Day + "-" + dtpNgayKhoiHanh.Value.Year;
            string diemDi = this.cbDiemDi.GetItemText(this.cbDiemDi.SelectedItem);
            string bienSo = this.cbBienSo.GetItemText(this.cbBienSo.SelectedItem);
            string diemDen = this.cbDiemDen.GetItemText(this.cbDiemDen.SelectedItem);
            double giaVe = double.Parse(txtGiaVe.Text);
            bool ketQua = ChuyenDiDAO.Instance.suaThongTinChuyenDi(int.Parse(txtMaChuyenDi.Text), gioDi, ngayDi, diemDi, diemDen, giaVe, bienSo);
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
            int maCD = int.Parse(txtMaChuyenDi.Text);
            if (maCD == 0)
                MessageBox.Show("Bạn chưa chọn chuyến đi", "Xóa chuyến đi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                ChuyenDiDAO.Instance.xoaChuyenDiBymaCD(maCD);
                hienThiDanhSachChuyenDi();
            }
        }
        private void BtDatVeXe_Click(object sender, EventArgs e)
        {
            fDatVeXe f = new fDatVeXe();
            f.Show();
            this.Dispose(false);
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
