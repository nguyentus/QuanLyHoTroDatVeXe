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
            LoadDanhSachXe();
            XeBinding();
        }

        #region Methods
        void LoadDanhSachXe()
        {
            dsXe.DataSource = XeDAO.Instance.LayDsXe();
            dgvXe.DataSource = dsXe;

            dgvXe.Columns[0].HeaderText = "Biển số";
            dgvXe.Columns[0].Width = 200;

            dgvXe.Columns[1].HeaderText = "Tên tài xế";
            dgvXe.Columns[1].Width = 237;

            dgvXe.Columns[2].HeaderText = "Số điện thoại tài xế";
            dgvXe.Columns[2].Width = 150;

            dgvXe.Columns[3].HeaderText = "Loại xe";
            dgvXe.Columns[3].Width = 200;
        }
        void XeBinding()
        {
            txtBienSo.DataBindings.Add("Text", dgvXe.DataSource, "bienSo", true, DataSourceUpdateMode.Never);
            txtTenXe.DataBindings.Add("text", dgvXe.DataSource, "tenXe", true, DataSourceUpdateMode.Never);
            txtTaiXe.DataBindings.Add("text", dgvXe.DataSource, "taiXe", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add("text", dgvXe.DataSource, "sdtTaiXe", true, DataSourceUpdateMode.Never);
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
