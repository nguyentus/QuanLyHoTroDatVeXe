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
    }
}
