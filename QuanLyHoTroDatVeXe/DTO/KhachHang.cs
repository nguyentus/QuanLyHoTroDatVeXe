﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        private int soDienThoai;
        private int cmnd;
        private string hoTen;
        private int gioiTinh;
        private string diaChi;
        private string email;
        private string tenDangNhap;

        public KhachHang(int soDienThoai, int cMND, string hoTen, int gioiTinh, string diaChi, string email, string tenDangNhap)
        {
            this.SoDienThoai = soDienThoai;
            this.CMND = cMND;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.Email = email;
            this.TenDangNhap = tenDangNhap;
        }

        public KhachHang(DataRow row)
        {
            this.SoDienThoai = (int)row["soDienThoai"];
            this.CMND = (int)row["CMND"];
            this.HoTen = row["hoTen"].ToString();
            this.GioiTinh = (int)row["gioiTinh"];
            this.DiaChi = row["diaChi"].ToString();
            this.Email = row["email"].ToString();
            this.TenDangNhap = row["tenDangNhap"].ToString();
        }

        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int CMND { get => cmnd; set => cmnd = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
    }
}
