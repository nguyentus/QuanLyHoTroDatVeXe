using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VeXe
    {
        private int sdt;
        private int maCD;
        private string maGhe;
        private DateTime thoiGianDat;

        public VeXe(int sdt, int maCD, string maGhe, DateTime thoiGianDat)
        {
            this.Sdt = sdt;
            this.MaCD = maCD;
            this.MaGhe = maGhe;
            this.ThoiGianDat = thoiGianDat;
        }

        public VeXe(DataRow row)
        {
            this.Sdt = (int)row["soDienThoai"];
            this.MaCD = (int)row["maCD"];
            this.MaGhe = row["maGhe"].ToString();
            this.ThoiGianDat = (DateTime)row["thoiGianDat"];
        }

        public int Sdt { get => sdt; set => sdt = value; }
        public int MaCD { get => maCD; set => maCD = value; }
        public string MaGhe { get => maGhe; set => maGhe = value; }
        public DateTime ThoiGianDat { get => thoiGianDat; set => thoiGianDat = value; }
    }
}
