using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set => instance = value;
        }

        private TaiKhoanDAO() { }

        //lấy tên tài khoản
        public string LayTenDangNhap(string taiKhoan)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TaiKhoan WHERE tenDangNhap = '" + taiKhoan + "'");
            foreach (DataRow row in table.Rows)
            {
                TaiKhoan tk = new TaiKhoan(row);
                return tk.TenDangNhap;
            }
            return "";
        }
        //lấy mật khẩu
        public string LayMatKhau(string matKhau)
        {
            string query = "SELECT * FROM dbo.TaiKhoan WHERE matKhau = '" + matKhau + "'";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                TaiKhoan tk = new TaiKhoan(row);
                return tk.MatKhau;
            }
            return "";
        }
        //Lấy loại tài khoản
        public int LayLoaiTaiKhoan(string taiKhoan)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TaiKhoan WHERE tenDangNhap = '" + taiKhoan + "'");
            foreach (DataRow row in table.Rows)
            {
                TaiKhoan tk = new TaiKhoan(row);
                return tk.LoaiTaiKhoan;
            }
            return -1;
        }
    }
}
