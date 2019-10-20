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

        public bool suaKHBangSDT(int sdt, string ht, int gt, string dc, string email, string tenDN)
        {
            string query = "UPDATE dbo.KhachHang SET hoTen = N'" + ht + "', gioiTinh = " + gt + ", diaChi = N'" + dc
                        + ", email ='" + email + "', tenDN = '" + tenDN + "'";
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
