using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {
        private string tenDangNhap, matKhau;
        private int loaiTaiKhoan;
        private int soDienThoai;
        public TaiKhoan(DataRow row)
        {
            this.TenDangNhap = row["tenDangNhap"].ToString();
            this.MatKhau = row["matKhau"].ToString();
            this.LoaiTaiKhoan = (int)row["loaiTaiKhoan"];
            this.SoDienThoai = (int)row["soDienThoai"];
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
    }
}
