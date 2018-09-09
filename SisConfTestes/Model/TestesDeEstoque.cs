using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConfTestes.Model
{
    [TestClass]
    public class TestesDeEstoque
    {
        Estoque estoque = null;
        Insumo insumo = null;
        Aquisicao aquisicao = null;

        [TestInitialize]
        public void InicializarTest()
        {
            estoque = new Estoque();
            insumo = new Insumo();
            aquisicao = new Aquisicao();
        }



        [TestMethod]
        public void TestIncluirAquisicao()
        {
            estoque = new Estoque();
            insumo = new Insumo();
            aquisicao.Insumo = insumo;
            aquisicao.PrecoUnitario = 2.99;
            aquisicao.Quantidade = 10;
            estoque.IncluirAquisicao(aquisicao);
        }

        [TestMethod]
        public void TestIncluirAquisicoesMultiplas()
        {
            estoque = new Estoque();
            insumo = new Insumo();
            aquisicao.Insumo = insumo;
            aquisicao.PrecoUnitario = 2.99;
            aquisicao.Quantidade = 10;
            Aquisicao aq2 = new Aquisicao();
            aq2.Insumo = insumo;
            estoque.IncluirAquisicao(aquisicao, aq2);
            Assert.AreEqual(2, estoque.QuantidadeDeAquisicoes(insumo));
        }

        [TestMethod]
        public void TestGetQuantidade()
        {
            estoque.IncluirAquisicao(new Aquisicao(insumo, 20, 20));
            estoque.IncluirAquisicao(new Aquisicao(insumo, 20, 20));
            estoque.IncluirAquisicao(new Aquisicao(insumo, 20, 20));
            Assert.AreEqual(60, estoque.ObterQuantidade(insumo));
        }

        [TestMethod]
        public void TestRetirar()
        {
            Aquisicao a1 = new Aquisicao(insumo, 40, 20);
            Aquisicao a2 = new Aquisicao(insumo, 20, 20);
            estoque.IncluirAquisicao(a1);
            estoque.IncluirAquisicao(a2);
            estoque.RemoverAquisicao(a2);
            Assert.AreEqual(40, estoque.ObterQuantidade(insumo));
        }

        [TestMethod]
        public void TestGetEstoque()
        {
            estoque.IncluirAquisicao(new Aquisicao(insumo, 20, 20));
            estoque.IncluirAquisicao(new Aquisicao(new Insumo(), 20, 20));
            var e = estoque.GetEstoque();
            Assert.IsNotNull(e);
            Assert.AreEqual(2, e.Count);
        }

        [TestMethod]
        public void TestGetEstoqueIsPassedByValue()
        {
            estoque.IncluirAquisicao(new Aquisicao(insumo, 20, 20));
            estoque.IncluirAquisicao(new Aquisicao(insumo, 20, 20));
            var e = estoque.GetEstoque();
            e[insumo] += 20;
            Assert.AreEqual(40, estoque.ObterQuantidade(insumo));
        }

        [TestMethod]
        public void TestValorTotalDoEstoque()
        {
            Estoque e = new Estoque();
            Insumo i1 = new Insumo();
            Insumo i2 = new Insumo();
            e.IncluirAquisicao(new Aquisicao(i1,2,10));
            e.IncluirAquisicao(new Aquisicao(i2,3,10));
            Assert.AreEqual(50, e.ValorTotalDoEstoque());

        }

        [TestMethod]
        public void TestPossuiAquisicoes()
        {
            Assert.IsFalse(estoque.PossuiAquisicoes(insumo));
            estoque.IncluirAquisicao(new Aquisicao(insumo, 1, 1));
            Assert.IsTrue(estoque.PossuiAquisicoes(insumo));
        }

        [TestMethod]
        public void TestQuantidadeDeAquisicoes()
        {
            Assert.AreEqual(0, estoque.QuantidadeDeAquisicoes(insumo));
            estoque.IncluirAquisicao(new Aquisicao(insumo, 1, 1));
            Assert.AreEqual(1, estoque.QuantidadeDeAquisicoes(insumo));
            Assert.AreEqual(0, estoque.QuantidadeDeAquisicoes(null));
        }

    }
}
