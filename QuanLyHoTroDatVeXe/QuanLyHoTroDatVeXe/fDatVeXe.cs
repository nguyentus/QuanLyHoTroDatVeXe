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
    public partial class fDatVeXe : Form
    {
        public fDatVeXe()
        {
            InitializeComponent();            
        }

        private void Ghe1_Click(object sender, EventArgs e)
        {
            PictureBox p= (PictureBox)sender;
            
            if (p.BackColor == Color.Gray)
            {
                p.BackColor = Color.Gainsboro;
                lbVeChon.Items.Remove(p.Name);
            }
            else
            {
                lbVeChon.Items.Add(p.Name);
                p.BackColor = Color.Gray;
            }
        }

        private void BtDangXuat_Click(object sender, EventArgs e)
        {
            //fDangXuat f = new fQLKH();
            //f.Show();
            //this.Dispose(false);
        }

        private void BtChuyenDi_Click(object sender, EventArgs e)
        {
            fQLCD f = new fQLCD();
            f.Show();
            this.Dispose(false);
        }

        private void BtXe_Click(object sender, EventArgs e)
        {
            //fQLX f = new fQLX();
            //f.Show();
            //this.Dispose(false);
        }

        private void BtKhachHang_Click(object sender, EventArgs e)
        {
            //fQLKH f = new fQLKH();
            //f.Show();
            //this.Dispose(false);
        }

        private void BtBaoCao_Click(object sender, EventArgs e)
        {
            //fBaoCao f = new fBaoCao();
            //f.Show();
            //this.Dispose(false);
        }

        private void BtThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn rời khỏi phần mềm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void BtDatVe_Click(object sender, EventArgs e)
        {

        }
    }
}
