using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChuyenDiDAO
    {
        private static ChuyenDiDAO instance;

        public static ChuyenDiDAO Instance
        {
            get { if (instance == null) instance = new ChuyenDiDAO(); return instance; }
            private set => instance = value;
        }

        private ChuyenDiDAO() { }

        //lấy ds chuyến đi
        public List<ChuyenDi> LayDsChuyenDi()
        {
            List<ChuyenDi> danhSach = new List<ChuyenDi>();

            string query = "SELECT * FROM dbo.ChuyenDi";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new ChuyenDi(item));
            }
            return danhSach;
        }
        //thêm chuyến đi vào danh sách
        public bool themChuyenDi(string gioDi, string ngayDi, string diemDi, string diemDen, double giaVe, string bienSo)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("themChuyenDi '" + gioDi + "', '" + ngayDi + "', '" + diemDi + "', '" + diemDen + "', " + giaVe + ", '" + bienSo + "'");
            return result > 0;
        }
        //lấy khoa bằng tên

        //xóa xe chuyến đi
        public void xoaChuyenDiBymaCD(int maCD)
        {
            DataProvider.Instance.ExecuteNonQuery("DELETE dbo.ChuyenDi WHERE maCD = '" + maCD + "'");
        }

        //sửa thông tin
        public bool suaThongTinChuyenDi(int maCD, string gioDi, string ngayDi, string diemDi, string diemDen, double giaVe, string bienSo)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.ChuyenDi SET gioDi = N'"
                + gioDi + "', ngayDi = '" + ngayDi + "', diemDi = N'" + diemDi + "', diemDen = N'" + diemDen + "', giaVe = " + giaVe
                + ", bienSo = N'" + bienSo + "' WHERE maCD = " + maCD);
            return result > 0;
        }
    }
}
