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
    public class TestesDeProduto
    {

        [TestMethod]
        public void TestIncluirInsumo()
        {
            Produto produto = new Produto();
            int quantidadeAntes = produto.ObterInsumos().Count;
            Insumo s = new Insumo();
            produto.IncluirInsumo(s, 1);
            int quantidadeDepois = produto.ObterInsumos().Count;

            Assert.AreEqual(0, quantidadeAntes);
            Assert.AreEqual(1, quantidadeDepois);
        }

        [TestMethod]
        public void TestGetInsumos()
        {
            Produto produto = new Produto();
            Insumo s = new Insumo();
            produto.IncluirInsumo(s, 1);
            Assert.IsNotNull(produto.ObterInsumos());
            Assert.AreEqual(1, produto.ObterInsumos().Count);
        }

        [TestMethod]
        public void TestCalcularCustoDoProduto()
        {
            Estoque e = new Estoque("Estoque Principal");
            Insumo insumo1 = new Insumo("Farinha de Trigo");
            Insumo insumo2 = new Insumo("Leite");
            Insumo insumo3 = new Insumo("Ovos");
            Insumo insumo4 = new Insumo("Cenoura");
            
            Aquisicao aq1 = new Aquisicao(insumo1, 10, 1.0);
            Aquisicao aq2 = new Aquisicao(insumo2, 10, 1.0);
            Aquisicao aq3 = new Aquisicao(insumo3, 12, 1.0);
            Aquisicao aq4 = new Aquisicao(insumo4, 5, 1.0);
            Aquisicao aq5 = new Aquisicao(insumo4, 5, 2.0);

            e.IncluirAquisicao(aq1, aq2, aq3, aq4, aq5);

            Produto p1 = new Produto();
            p1.Nome = "Bolo de Cenoura";
            p1.IncluirInsumo(insumo1, 0.3);
            p1.IncluirInsumo(insumo2, 0.5);
            p1.IncluirInsumo(insumo3, 3);
            p1.IncluirInsumo(insumo4, 1);

            double custoEsperadoP1 = 0.3 * 1.0 + 0.5 * 1.0 + 3 * 1.0 + 1.0 * 1.5;
            double custoP1 = p1.CalcularCustoDoProduto(e);
            Assert.AreEqual(custoEsperadoP1, custoP1);
        }

        [TestMethod]
        public void TestObterPrecoDeVenda()
        {
            Estoque e = new Estoque("Estoque Principal");
            Insumo insumo1 = new Insumo("Farinha de Trigo");
            Insumo insumo2 = new Insumo("Leite");
            Insumo insumo3 = new Insumo("Ovos");
            Insumo insumo4 = new Insumo("Cenoura");

            Aquisicao aq1 = new Aquisicao(insumo1, 10, 1.0);
            Aquisicao aq2 = new Aquisicao(insumo2, 10, 1.0);
            Aquisicao aq3 = new Aquisicao(insumo3, 12, 1.0);
            Aquisicao aq4 = new Aquisicao(insumo4, 5, 1.0);

            e.IncluirAquisicao(aq1, aq2, aq3, aq4);

            Produto p1 = new Produto();
            p1.Nome = "Bolo de Cenoura";
            p1.IncluirInsumo(insumo1, 0.3);
            p1.IncluirInsumo(insumo2, 0.5);
            p1.IncluirInsumo(insumo3, 3);
            p1.IncluirInsumo(insumo4, 1);

            double margem = 0.3;
            double precoEsperado = p1.CalcularCustoDoProduto(e) / (1 - margem);
            Assert.AreEqual(precoEsperado, p1.ObterPrecoDeVenda(margem));
        }
        
    }
}
