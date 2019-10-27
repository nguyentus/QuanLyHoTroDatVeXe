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
        private KhachHang taiKhoanKH;
        public KhachHang TaiKhoanKH { get => taiKhoanKH; set => taiKhoanKH = value; }

        ChuyenDi chuyenDangChon = new ChuyenDi();
        VeXe veXeHienTai = new VeXe();


        public fDatVeXe(KhachHang kh)
        {
            InitializeComponent();
            this.taiKhoanKH = kh;

            phanQuyen();
            
            fromMacDinh();
        }

        #region Methods
        void fromMacDinh()
        {
            hienThiDiemDen();
            hienThiDiemDi();
            hienThiGioDi();
            grbGhe.Enabled = false;
            btChon.Enabled = false;
            btXacNhan.Enabled = false;

            txtHoTen.Text = taiKhoanKH.HoTen;
            txtSDT.Text = "0" + taiKhoanKH.SoDienThoai;
        }
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
            string gio = cbGio.GetItemText(cbGio.SelectedItem);
            string ngay = dtpNgayDi.Value.Month + "-" + dtpNgayDi.Value.Day + "-" + dtpNgayDi.Value.Year;
            string di = cbDiemDi.GetItemText(cbDiemDi.SelectedItem);
            string den = cbDiemDen.GetItemText(cbDiemDen.SelectedItem);

            chuyenDangChon = ChuyenDiDAO.Instance.timChuyenDi(gio, ngay, di, den);
            if (chuyenDangChon != null)
            {
                grbGhe.Enabled = true;
                btChon.Enabled = true;

                List<VeXe> dsVeDaDat = VeXeDAO.Instance.layDsVeXe(chuyenDangChon.MaCD);
                foreach (VeXe ve in dsVeDaDat)
                {
                    ((PictureBox)grbGhe.Controls[ve.MaGhe]).BackColor = Color.Red;
                    ((PictureBox)grbGhe.Controls[ve.MaGhe]).Enabled = false;
                }
            }
            else
                MessageBox.Show("Nhà xe chưa có chuyến này rồi!! Bạn vui lòng tìm chuyến khác nhé", "Tìm chuyến", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void BtChon_Click(object sender, EventArgs e)
        {
            int soLuongGhe = lbVeChon.Items.Count;
            if (soLuongGhe > 0)
            {
                btXacNhan.Enabled = true;
                lbChuyen.Text = chuyenDangChon.DiemDi + " - " + chuyenDangChon.DiemDen;
                lbGio.Text = chuyenDangChon.GioDi + " " + chuyenDangChon.NgayDi.Day + "/"
                        + chuyenDangChon.NgayDi.Month + "/" + chuyenDangChon.NgayDi.Year;
                string ghe = "";
                foreach (var item in lbVeChon.Items)
                {
                    ghe += item.ToString() + " - ";
                }
                lbGhe.Text = ghe;
                lbSoLuong.Text = soLuongGhe.ToString();
                lbGia.Text = chuyenDangChon.GiaVe.ToString();
                double tong = chuyenDangChon.GiaVe * soLuongGhe;
                lbTongTien.Text = string.Format( "%f VNĐ", tong);
            }
            else
                MessageBox.Show("Bạn chưa chọn ghế!! Mau chọn ghế đi nè", "Chọn ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
    }
}
