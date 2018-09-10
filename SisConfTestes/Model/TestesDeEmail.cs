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
    public class TestesDeEmail
    {
        [TestMethod()]
        public void TestValidarEmail()
        {
            Assert.IsFalse(Email.ValidarEmail("fferreira"));
            Assert.IsTrue(Email.ValidarEmail("fernando@gmail.com"));
        }

        [TestMethod]
        public void TestCriacaoEmailCompleto()
        {
            Email e = new Email("fferreira@gmail.com");
            Assert.AreEqual("fferreira", e.NomeDeUsuario);
            Assert.AreEqual("gmail.com", e.Provedor);

        }

        [TestMethod]
        public void TestCriacaoEmailPorPartes()
        {
            Email e = new Email("fferreira","gmail.com");
            Assert.AreEqual("fferreira@gmail.com", e.EmailCompleto());
            

        }
    }
}