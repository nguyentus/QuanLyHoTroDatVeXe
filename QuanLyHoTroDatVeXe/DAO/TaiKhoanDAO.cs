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

        //lấy ds tài khoản
        public List<TaiKhoan> LayDsTaiKhoan()
        {
            List<TaiKhoan> danhSach = new List<TaiKhoan>();
            string query = "SELECT * FROM dbo.DiemDi";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new TaiKhoan(item));
            }
            return danhSach;
        }

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
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TaiKhoan WHERE matKhau = '" + matKhau + "'");
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
