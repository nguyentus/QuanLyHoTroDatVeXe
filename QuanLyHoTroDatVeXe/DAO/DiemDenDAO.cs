using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DiemDenDAO
    {
        private static DiemDenDAO instance;

        public static DiemDenDAO Instance
        {
            get { if (instance == null) instance = new DiemDenDAO(); return instance; }
            private set => instance = value;
        }

        private DiemDenDAO() { }

        //lấy ds điểm đến
        public List<DiemDen> LayDsDiemDen()
        {
            List<DiemDen> danhSach = new List<DiemDen>();

            string query = "SELECT * FROM dbo.DiemDen";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new DiemDen(item));
            }
            return danhSach;
        }
        public string LayMaTinhBangTen(string ten)
        {
            string query = "SELECT * FROM dbo.DiemDen WHERE tenTinh LIKE N'%" + ten + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow items in data.Rows)
            {
                DiemDi diemDen = new DiemDi(items);
                return diemDen.TenTinh;
            }
            return "";
        }
    }
}
