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
    public partial class fBaoCaoThongKe : Form
    {
        public fBaoCaoThongKe()
        {
            InitializeComponent();
            phanQuyen();
        }
        #region Methods
        void phanQuyen()
        {
            btDatVe.Enabled = false;
        }
        #endregion

        #region Events
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

        private void BtThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn rời khỏi phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
        #endregion

    }
}
