using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VeXeDAO
    {
        private static VeXeDAO instance;
        public static VeXeDAO Instance 
        {
            get { if (instance == null) instance = new VeXeDAO(); return instance; }
            private set => instance = value; 
        }

        public List<VeXe> layDsVeXe(int maCD)
        {
            List<VeXe> ds = new List<VeXe>();
            string query = "SELECT * FROM dbo.VeXe WHERE maCD = " + maCD;
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in table.Rows)
                ds.Add(new VeXe(item));
            return ds;
        }

        public bool isFull(int maCD)
        {
            if (layDsVeXe(maCD).Count == 15)
                return true;
            return false;
        }

        public bool datVe(int sdt, int maCD, string maGhe)
        {
            int stt = int.Parse(maGhe.Substring(1));
            if (stt <= 15 && stt > 0)
            {
                DateTime tg = DateTime.Now;
                string query = "themVeXe " + sdt + ", " + maCD + ", '" + maGhe + "', '" + tg + "'";
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            return false;
        }

        public List<VeXe> baoCao()
        {
            List<VeXe> ds = new List<VeXe>();
            string query = "SELECT * FROM dbo.VeXe";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in table.Rows)
                ds.Add(new VeXe(item));
            return ds;
        }
        public List<VeXe> timVeKH( int SDT)
        {
            List<VeXe> ds = new List<VeXe>();
            string query = "SELECT * FROM dbo.VeXe WHERE soDienThoai = " + SDT;
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in table.Rows)
                ds.Add( new VeXe(item));
            return ds;
        }
    }
}
