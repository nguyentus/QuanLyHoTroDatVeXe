using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public int SoDienThoai { get; set; }
        public int CMND { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public KhachHang(int soDienThoai, int cMND, string hoTen, string gioiTinh, string diaChi, string email)
        {
            this.SoDienThoai = soDienThoai;
            this.CMND = cMND;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.Email = email;
        }

        public KhachHang(DataRow row)
        {
            this.SoDienThoai = (int)row["soDienThoai"];
            this.CMND = (int)row["CMND"];
            this.HoTen = row["hoTen"].ToString();
            this.GioiTinh = row["gioiTinh"].ToString();
            this.DiaChi = row["diaChi"].ToString();
            this.Email = row["email"].ToString();
        }

    }
}
