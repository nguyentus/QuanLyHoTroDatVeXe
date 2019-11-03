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
    public class TestQuanLyKhachHang
    {
        [TestMethod]
        public void TestLayDSKhachHang()
        {
            List<KhachHang> kh = KhachHangDAO.Instance.layDsKhachHang();
            int expected = 3;
            int actual = kh.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemKhachHang()
        {
            bool expected = true;
            bool actual = KhachHangDAO.Instance.themKH(986413978, 473946125, "Nguyễn Tèo", "Nam", "Sóc trăng", "teonguyen@gmail.com");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemKhachHangVoiSDTDaTonTai()
        {
            bool expected = true;
            bool actual = KhachHangDAO.Instance.themKH(986413978, 473946125, "Nguyễn Tí", "Nam", "Sóc trăng", "tinguyen@gmail.com");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaKhachHang()
        {
            bool expected = true;
            bool actual = KhachHangDAO.Instance.xoaKHBangSDT(986413978);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaKhachHangVoiSDTKhongHopLe()
        {
            bool expected = true;
            bool actual = KhachHangDAO.Instance.xoaKHBangSDT(886413978);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatKhachHang()
        {
            bool expected = true;
            bool actual = KhachHangDAO.Instance.suaKHBangSDT(918236031, 345543678, "Nguyễn Tẹo", "Nam", "Cần Giuộc", "nguyenteo123@gmail.com");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatKhachHangVoiSoDienThoaiKhongTonTai()
        {
            bool expected = true;
            bool actual = KhachHangDAO.Instance.suaKHBangSDT(886413978, 345543678, "Nguyễn Tẹo", "Nam", "Cần Giuộc", "nguyenteo123@gmail.com");
            Assert.AreEqual(expected, actual);
        }
    }
}
