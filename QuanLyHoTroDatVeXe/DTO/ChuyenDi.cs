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
        private int maCD;
        private DateTime ngayDi;
        private string gioDi, diemDi, diemDen, bienSo;
        private double giaVe;
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

        public int MaCD { get => maCD; set => maCD = value; }
        public DateTime NgayDi { get => ngayDi; set => ngayDi = value; }
        public string GioDi { get => gioDi; set => gioDi = value; }
        public string DiemDi { get => diemDi; set => diemDi = value; }
        public string DiemDen { get => diemDen; set => diemDen = value; }
        public string BienSo { get => bienSo; set => bienSo = value; }
        public double GiaVe { get => giaVe; set => giaVe = value; }
    }
}
