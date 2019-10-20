﻿using DAO;
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
        public fQuanLyChuyenDi()
        {
            InitializeComponent();
            hienThiDanhSachChuyenDi();
        }

        #region Methods
        void hienThiDanhSachChuyenDi()
        {
            dgvChuyenDi.DataSource = ChuyenDiDAO.Instance.LayDsChuyenDi();

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

        //tạo ràng buộc giữa datagridview với các ô text
        void taoRangBuoc()
        {
                                  
        }
        #endregion

        //private void BtXem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string gioKhoiHanh = cbGioKhoiHanh.SelectedItem.ToString();
        //        string taiXe = txtTaiXe.Text;
        //        int sdt = int.Parse(txtSDT.Text);
        //        string tenXe = txtTenXe.Text;

        //        if (bienSo == "" || taiXe == "" || tenXe == "")
        //            MessageBox.Show("Bạn phải nhập đủ!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        else
        //        {
        //            string bienSoTim = XeDAO.Instance.timXeTheoBienSo(bienSo).ToLower();
        //            if (bienSoTim == bienSo.ToLower())
        //                MessageBox.Show("Lỗi!! Trùng biển số xe!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            else
        //            {
        //                bool ketQua = XeDAO.Instance.themXe(bienSo, taiXe, sdt, tenXe);
        //                if (ketQua)
        //                {
        //                    MessageBox.Show("Thêm thành công!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    hienThiDanhSachXe();
        //                }
        //                else
        //                    MessageBox.Show("Thêm không thành công!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Lỗi nhập!", "Thêm xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        #region Events
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
