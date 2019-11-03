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
        //lấy khách hàng bằng số điện thoại
        public KhachHang layKH(int? sdt)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KhachHang WHERE soDienThoai = " + sdt);
            foreach (DataRow row in table.Rows)
            {
                return new KhachHang(row);
            }
            return null;
        }
        //tìm khách hàng bằng số điện thoại
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
        //thêm 1 khách hàng vô danh sách khách hàng
        public bool themKH(int sdt, int cnmd, string ht, string gt, string dc, string email)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("themKH " + sdt +", " + cnmd + ", N'" + ht + "', N'" + gt + "', N'" + dc + "', '" + email + "'");
            return result > 0;
        }
        //sửa thông tin khách hàng bằng số điện thoại
        public bool suaKHBangSDT(int sdt, int cmnd, string ht, string gt, string dc, string email)
        {
            string query = "UPDATE dbo.KhachHang SET CMND =" + cmnd + ", hoTen = N'" + ht 
                    + "', gioiTinh = N'" + gt + "', diaChi = N'" + dc + "', email ='" + email 
                    + "' WHERE soDienThoai = " + sdt;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //xóa khách hàng bằng số điện thoại
        public bool xoaKHBangSDT(int sdt)
        {
            string query = "DELETE dbo.KhachHang WHERE soDienThoai = " + sdt;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
