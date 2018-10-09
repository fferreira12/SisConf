using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConfPersistence.Persistence;

namespace SisConfTestes.Mocking
{
    [TestClass]
    public class DbMockerTests
    {
        private static SisConfDbContext _db = new SisConfDbContext();
        private static DbMocker mocker = new DbMocker(_db);


        [TestMethod]
        public void TestCriarInsumos()
        {
            mocker.CriarInsumos();
        }

        [TestMethod]
        public void TestCriarClientes()
        {
            mocker.CriarClientes();
        }
    }
}
