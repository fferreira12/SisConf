using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConfTestes.Model
{
    [TestClass()]
    public class TestInsumo
    {
        [TestMethod]
        public void TestAdicionarMarcaIncluiInsumoNaMarca()
        {
            Insumo i = new Insumo();
            Marca m = new Marca();
            Assert.AreEqual(0, m.ObterInsumos().Count);
            i.Marca = m;
            Assert.AreEqual(1, m.ObterInsumos().Count);
        }

    }
}