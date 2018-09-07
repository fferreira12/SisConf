using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConfTestes
{
    [TestClass()]
    public class TestInsumo
    {
        [TestMethod()]
        public void TestIncluirAquisicao()
        {
            Insumo i = new Insumo();
            i.IncluirAquisicao(2, 10);
        }

        [TestMethod()]
        public void TestCalcularPrecoMedio()
        {
            Insumo i = new Insumo();
            i.IncluirAquisicao(2, 10);
            i.IncluirAquisicao(2, 20);
            Assert.AreEqual(15, i.CalcularPrecoMedio());
        }

        [TestMethod()]
        public void TestQuantidadeTotalAdquirida()
        {
            Insumo i = new Insumo();
            i.IncluirAquisicao(2, 10);
            i.IncluirAquisicao(2, 20);
            Assert.AreEqual(4, i.QuantidadeTotalAdquirida());
        }

        [TestMethod()]
        public void TestPossuiAquisicoes()
        {
            Insumo i = new Insumo();
            Assert.IsFalse(i.PossuiAquisicoes());
            i.IncluirAquisicao(2, 10);
            Assert.IsTrue(i.PossuiAquisicoes());
        }

        [TestMethod()]
        public void TestQuantidadeDeAquisicoes()
        {
            Insumo i = new Insumo();
            Assert.AreEqual(0,i.QuantidadeDeAquisicoes());
            i.IncluirAquisicao(2, 10);
            Assert.AreEqual(1,i.QuantidadeDeAquisicoes());
        }

    }
}