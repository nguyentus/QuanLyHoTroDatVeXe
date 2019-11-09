using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuyenDi
    {
        public int MaCD { get; set; }
        public DateTime NgayDi { get; set; }
        public string GioDi { get; set; }
        public string DiemDi { get; set; }
        public string DiemDen { get; set; }
        public string BienSo { get; set; }
        public double GiaVe { get; set; }

        public ChuyenDi() { }
        public ChuyenDi(DataRow row)
        {
            this.MaCD = (int)row["maCD"];
            this.GioDi = row["gioDi"].ToString();
            this.NgayDi = (DateTime)row["ngayDi"];
            this.DiemDi = row["diemDi"].ToString();
            this.DiemDen = row["diemDen"].ToString();
            this.GiaVe = (double)row["giaVe"];
            this.BienSo = row["bienSo"].ToString();
        }

    }
}
