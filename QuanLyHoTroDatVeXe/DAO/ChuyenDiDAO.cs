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

        //lấy ds xe
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
    }
}
