using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        private int maNV;
        private string hoTen;
        private string gioiTinh;
        private int soDienThoai;
        private double luong;
        private string diaChi;
        private string email;
        private string tenDangNhap;

        public NhanVien(int maNV, string hoTen, string gioiTinh, int soDienThoai, double luong, string diaChi, string email, string tenDangNhap)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.SoDienThoai = soDienThoai;
            this.Luong = luong;
            this.DiaChi = diaChi;
            this.Email = email;
            this.TenDangNhap = tenDangNhap;
        }

        public NhanVien(DataRow row)
        {
            this.MaNV = (int)row["maNV"];
            this.HoTen = row["hoTen"].ToString();
            this.GioiTinh = row["gioiTinh"].ToString();
            this.SoDienThoai = (int)row["soDienThoai"];
            this.Luong = (double)row["luong"];
            this.DiaChi = row["diaChi"].ToString();
            this.Email = row["email"].ToString();
            this.TenDangNhap = row["tenDangNhap"].ToString();
        }

        public int MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public double Luong { get => luong; set => luong = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
    }
}
