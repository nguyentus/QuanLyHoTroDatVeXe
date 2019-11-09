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
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int LoaiTaiKhoan { get; set; }
        public int SoDienThoai { get; set; }
        public TaiKhoan(DataRow row)
        {
            this.TenDangNhap = row["tenDangNhap"].ToString();
            this.MatKhau = row["matKhau"].ToString();
            this.LoaiTaiKhoan = (int)row["loaiTaiKhoan"];
            this.SoDienThoai = (int)row["soDienThoai"];
        }

    }
}
