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

        //lấy tài khoản
        public TaiKhoan layTaiKhoan(string tenDangNhap)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TaiKhoan WHERE tenDangNhap = '" + tenDangNhap + "'");
            foreach (DataRow row in table.Rows)
            {
                return new TaiKhoan(row);
            }
            return null;
        }
    }
}
