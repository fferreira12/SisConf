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
    public class TestEmail
    {
        [TestMethod()]
        public void TestValidarEmail()
        {
            Assert.IsFalse(Email.ValidarEmail("fferreira"));
            Assert.IsTrue(Email.ValidarEmail("fernando@gmail.com"));
        }
    }
}