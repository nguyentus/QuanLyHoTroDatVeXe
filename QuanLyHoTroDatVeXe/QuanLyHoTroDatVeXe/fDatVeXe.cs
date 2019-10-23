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
    public partial class fDatVeXe : Form
    {
        public fDatVeXe()
        {
            InitializeComponent();
            phanQuyen();
            hienThiDiemDen();
            hienThiDiemDi();
            hienThiGioDi();
        }

        #region Methods
        void phanQuyen()
        {
            btChuyenDi.Enabled = false;
            btXe.Enabled = false;
            btKhachHang.Enabled = false;
            btBaoCao.Enabled = false;
        }
        void hienThiDiemDi()
        {
            List<ChuyenDi> dsDiemDi = ChuyenDiDAO.Instance.LayDsChuyenDi();
            cbDiemDi.DataSource = dsDiemDi;
            cbDiemDi.DisplayMember = "diemDi";
        }
        void hienThiDiemDen()
        {
            List<ChuyenDi> dsDiemDen = ChuyenDiDAO.Instance.LayDsChuyenDi();
            cbDiemDen.DataSource = dsDiemDen;
            cbDiemDen.DisplayMember = "diemDen";
        }
        void hienThiGioDi()
        {
            List<ChuyenDi> dsChuyenDi = ChuyenDiDAO.Instance.LayDsChuyenDi();
            cbGio.DataSource = dsChuyenDi;
            cbGio.DisplayMember = "gioDi";
        }
        #endregion

        #region Events
        private void ChonGhe_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (p.BackColor == Color.Gray)
            {
                lbVeChon.Items.Remove(p.Name);
                p.BackColor = pGhe.BackColor;
            }
            else
            {
                lbVeChon.Items.Add(p.Name);
                p.BackColor = Color.Gray;
            }
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

        private void btTimChuyen_Click(object sender, EventArgs e)
        {
            string gio = cbGio.SelectedItem.ToString();
            string ngay = dtpNgayDi.Value.Day + "-" + dtpNgayDi.Value.Month + "-" + dtpNgayDi.Value.Year;
            string di = cbDiemDi.SelectedItem.ToString();
            string den = cbDiemDen.SelectedItem.ToString();
       
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
    }
}
