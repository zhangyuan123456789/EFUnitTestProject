using System;
using BLL;
using EFEntityTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DBFactory.Instance.CreateDBContext();
        }
    }
}
