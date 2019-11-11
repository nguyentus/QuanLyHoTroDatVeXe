using DAO;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class TestDangNhap
    {
        [TestMethod]
        public void TestTenDangNhap()
        {
            string expected = "tu";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.TenDangNhap;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTenDangNhapKhongTonTai()
        {
            string expected = "tu123";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.TenDangNhap;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestTenDangNhapRong()
        {
            string expected = "";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.TenDangNhap;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTenDangNhapKhongHopLe1()
        {
            string expected = "tu       ";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.TenDangNhap;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTenDangNhapKhongHopLe2()
        {
            string expected = "      tu";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.TenDangNhap;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMatKhauRong()
        {
            string expected = "";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.MatKhau;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMatKhauKhongHopLe1()
        {
            string expected = "1     ";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.MatKhau;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMatKhauKhongHopLe2()
        {
            string expected = "     1";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string actual = tk.MatKhau;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDangNhapVoiTaiKhoanVaMatKhau()
        {
            string tk_expected = "tu";
            string mk_expected = "1";
            TaiKhoan tk = TaiKhoanDAO.Instance.layTaiKhoan("tu");
            string tk_actual = tk.TenDangNhap;
            string mk_actual = tk.MatKhau;
            Assert.AreEqual(tk_expected, tk_actual);
            Assert.AreEqual(mk_expected, mk_actual);
        }
    }
}
