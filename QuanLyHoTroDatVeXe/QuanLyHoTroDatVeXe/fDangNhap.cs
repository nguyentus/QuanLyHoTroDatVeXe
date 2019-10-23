using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoTroDatVeXe
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void BtDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap = this.txtTaiKhoan.Text;
                string matKhau = this.txtMatKhau.Text;

                if (tenDangNhap == "" || matKhau == "")
                    MessageBox.Show("Bạn phải nhập đủ!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string tenTaiKhoan_real = TaiKhoanDAO.Instance.LayTenDangNhap(tenDangNhap);
                    string matkhau_real = TaiKhoanDAO.Instance.LayMatKhau(matKhau);
                    if (tenDangNhap == tenTaiKhoan_real && matKhau == matkhau_real)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Đăng nhập không thành công!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi nhập!", "Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
