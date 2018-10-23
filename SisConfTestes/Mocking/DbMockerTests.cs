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

        public void TestInicializarBD()
        {
            TestCriarInsumos();
            TestCriarAquisicoes();
            TestCriarProdutos();
            TestCriarClientes();
            TestCriarEncomendas();
        }

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

        [TestMethod]
        public void TestCriarProdutos()
        {
            mocker.CriarProdutos();
        }

        [TestMethod]
        public void TestCriarEncomendas()
        {
            mocker.CriarEncomendas(140);
        }

        [TestMethod]
        public void TestCriarAquisicoes()
        {
            mocker.CriarAquisicoes();
        }

        [TestMethod]
        public void TestAlterarPrecoEncomendas()
        {
            mocker.AlterarPrecosDeVendaDasEncomendas();
        }

        [TestMethod]
        public void TestIncluirAlertas()
        {
            mocker.IncluirAlertas();
        }
    }
}
