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
    public partial class fBaoCaoThongKe : Form
    {
        public fBaoCaoThongKe()
        {
            InitializeComponent();
            phanQuyen();
            load();
        }
        #region Methods
        void load()
        {
            dgvBaoCao.DataSource = VeXeDAO.Instance.baoCao();

            dgvBaoCao.Columns[0].HeaderText = "Số điện thoại";
            dgvBaoCao.Columns[0].Width = 100;
            dgvBaoCao.Columns[1].HeaderText = "Mã chuyến đi";
            dgvBaoCao.Columns[1].Width = 150;
            dgvBaoCao.Columns[2].HeaderText = "Số ghế";
            dgvBaoCao.Columns[2].Width = 100;
            dgvBaoCao.Columns[3].HeaderText = "Ngày đặt";
            dgvBaoCao.Columns[3].Width = 100;
        }
        void phanQuyen()
        {
            btDatVe.Enabled = false;
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

        private void BtTim_Click(object sender, EventArgs e)
        {
            try
            {
                int sdt = int.Parse(txtSDT.Text);
                List<VeXe> ds = VeXeDAO.Instance.timVeKH(sdt);
                dgvBaoCao.DataSource = ds;
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi định dạng nhập! Vui lòng kiểm tra lại", "Tìm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
