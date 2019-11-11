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
    public class TestQuanLyXe
    {
        [TestMethod]
        public void TestLayDSXe()
        {
            List<Xe> xe = XeDAO.Instance.LayDsXe();
            int expected = 7;
            int actual = xe.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemXe()
        {
            bool expected = true;
            bool actual = XeDAO.Instance.themXe("51G-52030", "Nguyễn Tèo", 0935678234, "THACO");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXeVoiBienSoDaTonTai()
        {
            bool expected = true;
            bool actual = XeDAO.Instance.themXe("62L-10054", "Nguyễn Tí", 0935678234, "Hyundai");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaXe()
        {
            bool expected = true;
            bool actual = XeDAO.Instance.xoaXeBangBienSo("51G-52030");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaXeVoiBienSoKhongTonTai()
        {
            bool expected = true;
            bool actual = XeDAO.Instance.xoaXeBangBienSo("51G-64030");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatXe()
        {
            bool expected = true;
            bool actual = XeDAO.Instance.suaThongTinXe("74L-98754", "Nguyễn Tẹo", 092528030, "Mazda");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatXeVoiBienSoKhongTonTai()
        {
            bool expected = true;
            bool actual = XeDAO.Instance.suaThongTinXe("77H-89754", "Nguyễn Tẹo", 092528030, "Mazda"); 
            Assert.AreEqual(expected, actual);
        }
    }
}
