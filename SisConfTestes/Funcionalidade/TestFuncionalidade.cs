using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;

namespace SisConfTestes.Funcionalidade
{
    [TestClass()]
    public class TestFuncionalidade
    {
        [TestMethod]
        public void TestCriacaoDeEstoqueInicial()
        {
            Estoque e = new Estoque("Estoque Principal");

            Insumo insumo1 = new Insumo("Farinha de Trigo");
            Insumo insumo2 = new Insumo("Leite");
            Insumo insumo3 = new Insumo("Ovos");
            Insumo insumo4 = new Insumo("Cenoura");

            Marca marca1 = new Marca("Dona Benta");
            insumo1.Marca = marca1;
            insumo2.Marca = marca1;
            insumo3.Marca = marca1;

            List<Insumo> insumosMarca1 = marca1.ObterInsumos();

            Aquisicao aq1 = new Aquisicao(insumo1, 10, 3.5);
            Aquisicao aq2 = new Aquisicao(insumo2, 10, 3.5);
            Aquisicao aq3 = new Aquisicao(insumo3, 12, 0.5);
            Aquisicao aq4 = new Aquisicao(insumo4, 5, 3.0);

            e.IncluirAquisicao(aq1, aq2, aq3, aq4);

            Assert.AreEqual(10*3.5+10*3.5+12*0.5+5*3, e.ValorTotalDoEstoque());

            Produto p1 = new Produto();
            p1.Nome = "Bolo de Cenoura";
            p1.IncluirInsumo(insumo1, 0.3);
            p1.IncluirInsumo(insumo2, 0.5);
            p1.IncluirInsumo(insumo3, 3);
            p1.IncluirInsumo(insumo4, 1);

            double custoP1 = p1.CalcularCustoDoProduto(e);
            
        }
    }
}
