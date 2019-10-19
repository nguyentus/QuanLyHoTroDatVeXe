using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quan_Ly_Mua_Ve_Xe_Truc_Tuyen
{
    public partial class fQLCD : Form
    {
        public fQLCD()
        {
            InitializeComponent();
        }

        private void BtDatVe_Click(object sender, EventArgs e)
        {
            fDatVeXe f = new fDatVeXe();
            f.Show();
            this.Dispose(false);
        }

        private void BtQLKH_Click(object sender, EventArgs e)
        {
            //fDatVeXe f = new fDatVeXe();
            //f.Show();
            //this.Dispose(false);
        }

        private void BtDangXuat_Click(object sender, EventArgs e)
        {
            //fDatVeXe f = new fDatVeXe();
            //f.Show();
            //this.Dispose(false);
        }
    }
}
