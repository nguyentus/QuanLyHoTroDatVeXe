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
            dgvKhachHang.DataSource = dsKhachHang;
            hienThiDanhSach();
        }

        #region Methods
        void hienThiDanhSach()
        {
            dsKhachHang.DataSource = KhachHangDAO.Instance.layDsKhachHang();

            dgvKhachHang.Columns[0].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[0].Width = 100;

            dgvKhachHang.Columns[1].HeaderText = "CMND";
            dgvKhachHang.Columns[1].Width = 70;

            dgvKhachHang.Columns[2].HeaderText = "Họ tên";
            dgvKhachHang.Columns[2].Width = 150;

            dgvKhachHang.Columns[3].HeaderText = "Giới tính";
            dgvKhachHang.Columns[3].Width = 70;

            dgvKhachHang.Columns[4].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[4].Width = 140;

            dgvKhachHang.Columns[5].HeaderText = "Email";
            dgvKhachHang.Columns[5].Width = 140;

            dgvKhachHang.Columns[6].HeaderText = "Tên đăng nhập";
            dgvKhachHang.Columns[6].Width = 120;
        }
        #endregion

        #region Events
        private void BtDatVeXe_Click(object sender, EventArgs e)
        {
            fDatVeXe f = new fDatVeXe();
            f.Show();
            this.Dispose(false);
        }

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
        #endregion
    }
}
