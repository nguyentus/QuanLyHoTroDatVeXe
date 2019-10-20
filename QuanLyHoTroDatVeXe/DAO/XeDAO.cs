using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class XeDAO
    {
        private static XeDAO instance;

        public static XeDAO Instance
        {
            get { if (instance == null) instance = new XeDAO(); return instance; }
            private set => instance = value;
        }

        private XeDAO() { }

        //lấy ds xe
        public List<Xe> LayDsXe()
        {
            List<Xe> danhSach = new List<Xe>();

            string query = "SELECT * FROM dbo.Xe";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new Xe(item));
            }
            return danhSach;
        }

        //thêm xe vào danh sách
        public bool themXe(string bienSo, string taiXe, int sdtTaiXe, string tenXe)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("themXe '" + bienSo 
                                                            + "', '" + taiXe + "' ,'" 
                                                            + sdtTaiXe + "', '" + tenXe +"'");
            return result > 0;
        }

        public string timXeTheoBienSo(string bienSo)
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Xe WHERE bienSo = '" + bienSo +"'");
            foreach( DataRow row in table.Rows)
            {
                Xe xeTim = new Xe(row);
                return xeTim.BienSo;
            }
            return "";
        }

        //xóa xe bằng biển số
        public void xoaXeBangBienSo(string bienSo)
        {
            DataProvider.Instance.ExecuteNonQuery("DELETE dbo.Xe WHERE bienSo = '" + bienSo +"'");
        }

        //sửa thông tin
        public bool suaThongTinXe(string bienSo, string taiXe, int sdt, string tenXe)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.Xe SET taiXe = N'" 
                + taiXe + "', sdtTaiXe = " + sdt + ", tenXe = N'" + tenXe + "' WHERE bienSo = '" + bienSo + "'");
            return result > 0;
        }
    }
}
