using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set => instance = value;
        }

        public List<KhachHang> layDsKhachHang()
        {
            List<KhachHang> ds = new List<KhachHang>();
            string query = "SELECT * FROM dbo.KhachHang";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
                ds.Add(new KhachHang(row));

            return ds;
        }

        public int timKH(int sdt)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KhachHang WHERE soDienThoai = " + sdt );
            foreach (DataRow row in table.Rows)
            {
                KhachHang KHTim = new KhachHang(row);
                return KHTim.SoDienThoai;
            }
            return -1;
        }

        public bool themKH(int sdt, int cnmd, string ht, string gt, string dc, string email, string tdn)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("themKH " + sdt +", " + cnmd + ", N'" + ht + "', N'" + gt + "', N'" + dc + "', '" + email + "', '" + tdn +"'");
            return result > 0;
        }

        public bool suaKHBangSDT(int sdt, int cmnd, string ht, string gt, string dc, string email, string tenDN)
        {
            string query = "UPDATE dbo.KhachHang SET CMND =" + cmnd + ", hoTen =N'" + ht 
                    + "', gioiTinh = N'" + gt + "', diaChi = N'" + dc + "'s, email ='" + email 
                    + "', tenDangNhap = '" + tenDN + "' WHERE soDienThoai = " + sdt;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public void xoaKHBangMa(string sdt)
        {
            string query = "DELETE dbo.KhachHang WHERE soDienThoai = " + sdt;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
