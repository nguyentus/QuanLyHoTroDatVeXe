using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DiemDiDAO
    {
        private static DiemDiDAO instance;

        public static DiemDiDAO Instance
        {
            get { if (instance == null) instance = new DiemDiDAO(); return instance; }
            private set => instance = value;
        }

        private DiemDiDAO() { }

        //lấy ds chuyến đi
        public List<DiemDi> LayDsDiemDi()
        {
            List<DiemDi> danhSach = new List<DiemDi>();

            string query = "SELECT * FROM dbo.DiemDi";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new DiemDi(item));
            }
            return danhSach;
        }

        public string LayMaTinhBangTen(string ten)
        {
            string query = "SELECT * FROM dbo.DiemDi WHERE tenTinh LIKE N'%" + ten + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow items in data.Rows)
            {
                DiemDi diemDi = new DiemDi(items);
                return diemDi.TenTinh;
            }
            return "";
        }
    }
}
