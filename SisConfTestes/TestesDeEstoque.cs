using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConfTestes
{
    [TestClass]
    public class TestesDeEstoque
    {
        Estoque estoque = null;
        Insumo insumo = null;

        [TestInitialize]
        public void Inicializar()
        {
            estoque = new Estoque();
            insumo = new Insumo();
        }



        [TestMethod]
        public void TestIncluir()
        {
            estoque = new Estoque();
            insumo = new Insumo();
            estoque.Incluir(insumo, 20);
        }

        [TestMethod]
        public void TestGetQuantidade()
        {
            estoque.Incluir(insumo, 20);
            estoque.Incluir(insumo, 20);
            estoque.Incluir(insumo, 20);
            Assert.AreEqual(60, estoque.GetQuantidade(insumo));
        }

        [TestMethod]
        public void TestRetirar()
        {
            estoque.Incluir(insumo, 20);
            estoque.Incluir(insumo, 20);
            estoque.Incluir(insumo, 20);
            estoque.Retirar(insumo, 30);
            Assert.AreEqual(30, estoque.GetQuantidade(insumo));
        }

        [TestMethod]
        public void TestGetEstoque()
        {
            estoque.Incluir(insumo, 20);
            estoque.Incluir(new Insumo(), 30);
            var e = estoque.GetEstoque();
            Assert.IsNotNull(e);
            Assert.AreEqual(2, e.Count);
        }

        [TestMethod]
        public void TestGetEstoqueIsPassedByValue()
        {
            estoque.Incluir(insumo, 20);
            estoque.Incluir(new Insumo(), 30);
            var e = estoque.GetEstoque();
            e[insumo] += 20;
            Assert.AreEqual(20, estoque.GetQuantidade(insumo));
        }

    }
}
