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
    public class TestesDeProduto
    {

        [TestMethod]
        public void TestIncluirInsumo()
        {
            Produto produto = new Produto();
            int quantidadeAntes = produto.GetInsumos().Count;
            Insumo s = new Insumo();
            produto.IncluirInsumo(s, 1);
            int quantidadeDepois = produto.GetInsumos().Count;

            Assert.AreEqual(0, quantidadeAntes);
            Assert.AreEqual(1, quantidadeDepois);
        }

        [TestMethod]
        public void TestGetInsumos()
        {
            Produto produto = new Produto();
            Insumo s = new Insumo();
            produto.IncluirInsumo(s, 1);
            Assert.IsNotNull(produto.GetInsumos());
            Assert.AreEqual(1, produto.GetInsumos().Count);
        }

    }
}
