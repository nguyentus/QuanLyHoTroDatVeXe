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
        private string bienSo;
        private string taiXe;
        private int soDienThoai;
        private string tenXe;

        public Xe(string bienSo, string taiXe, int soDienThoai, string tenXe)
        {
            this.BienSo = bienSo;
            this.TaiXe = taiXe;
            this.SoDienThoai = soDienThoai;
            this.TenXe = tenXe;
        }

        public Xe(DataRow row)
        {
            this.BienSo = row["bienSo"].ToString();
            this.TaiXe = row["taiXe"].ToString();
            this.SoDienThoai = (int)row["sdtTaiXe"];
            this.TenXe = row["tenXe"].ToString();
        }

        public string BienSo { get => bienSo; set => bienSo = value; }
        public string TaiXe { get => taiXe; set => taiXe = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string TenXe { get => tenXe; set => tenXe = value; }
    }
}
