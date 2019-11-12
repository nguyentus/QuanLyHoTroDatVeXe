using System;
using System.Collections.Generic;
using DAO;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestQuanLyChuyenDi
    {
        [TestMethod]
        public void TestLayDSChuyenDi()
        {
            List<ChuyenDi> cd = ChuyenDiDAO.Instance.LayDsChuyenDi();
            int expected = 6;
            int actual = cd.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemChuyenDi()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.themChuyenDi("5h45", "11-12-2019", "cantho", "haugiang", 60000, "66t-10054");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThemChuyenDiVoiBienSoKhongTonTai()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.themChuyenDi("5h45", "11-12-2019", "cantho", "haugiang", 60000, "65B-30124");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaChuyenDi()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.xoaChuyenDiBangmaCD(115);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestXoaChuyenDiVoiMaChuyenDiNgauNhien()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.xoaChuyenDiBangmaCD(999);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatChuyenDi()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.suaThongTinChuyenDi(118, "7h30", "11-11-2013", "HauGiang", "CanTho", 70000, "66t-10054");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatChuyenDiVoiBienSoKhongTonTai()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.suaThongTinChuyenDi(118, "7h30", "11-11-2013", "HauGiang", "CanTho", 70000, "66T-22134");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatChuyenDiTrungMaChuyenDi()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.suaThongTinChuyenDi(118, "7h30", "11-11-2013", "DongThap", "CanTho", 70000, "66t-10054");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCapNhatChuyenDiVoiMaChuyenDiNgauNhien()
        {
            bool expected = true;
            bool actual = ChuyenDiDAO.Instance.suaThongTinChuyenDi(999, "7h30", "11-11-2013", "HauGiang", "CanTho", 70000, "66T-22134");
            Assert.AreEqual(expected, actual);
        }
    }
}
