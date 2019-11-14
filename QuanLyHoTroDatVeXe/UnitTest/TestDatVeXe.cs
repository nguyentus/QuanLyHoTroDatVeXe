using DAO;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class TestDatVeXe
    {
        [TestMethod]
        public void TestLayDsVeXe()
        {
            List<VeXe> dsVe = VeXeDAO.Instance.layDsVeXe(102);
            int expected = 2;
            int actual = dsVe.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLayDsVeXeVoiChuyenDiKhongTonTai()
        {
            List<VeXe> dsVe = VeXeDAO.Instance.layDsVeXe(101);
            int expected = 0;
            int actual = dsVe.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChuyenDiConVe()
        {
            bool actual = VeXeDAO.Instance.isFull(101);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDatVeThanhCong()
        {
            bool actual = VeXeDAO.Instance.datVe(912839740, 107, "A12");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDatVeKhongThanhCong()
        {
            bool actual = VeXeDAO.Instance.datVe(912839740, 107, "A16");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTimVeVoiSDTDung()
        {
            List<VeXe> dsVeTim = VeXeDAO.Instance.timVeKH(912839740);
            int expected = 1;
            int actual = dsVeTim.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestTimVeVoiSDTSai()
        {
            List<VeXe> dsVeTim = VeXeDAO.Instance.timVeKH(123457890);
            int expected = 0;
            int actual = dsVeTim.Count;
            Assert.AreEqual(expected, actual);
        }
  
    }
}
