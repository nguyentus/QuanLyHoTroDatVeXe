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
        private int soDienThoai;
        private int cmnd;
        private string hoTen;
        private string gioiTinh;
        private string diaChi;
        private string email;

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

        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int CMND { get => cmnd; set => cmnd = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
    }
}
