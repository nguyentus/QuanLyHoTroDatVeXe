using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DiemDen
    {
        private string tenTinh;
        public DiemDen(DataRow row)
        {
            this.TenTinh = row["tenTinh"].ToString();
        }

        public string TenTinh { get => tenTinh; set => tenTinh = value; }
    }
}
