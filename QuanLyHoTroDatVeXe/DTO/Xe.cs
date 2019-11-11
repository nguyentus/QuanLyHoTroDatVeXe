using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Xe
    {
        public string BienSo { get; set; }
        public string TaiXe { get; set; }
        public int SDTTaiXe { get; set; }
        public string TenXe { get; set; }

        public Xe(string bienSo, string taiXe, int sdtTaiXe, string tenXe)
        {
            this.BienSo = bienSo;
            this.TaiXe = taiXe;
            this.SDTTaiXe = sdtTaiXe;
            this.TenXe = tenXe;
        }

        public Xe(DataRow row)
        {
            this.BienSo = row["bienSo"].ToString();
            this.TaiXe = row["taiXe"].ToString();
            this.SDTTaiXe = (int)row["sdtTaiXe"];
            this.TenXe = row["tenXe"].ToString();
        }
    }
}
