using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;
using SisConfPersistence.Persistence;
using System.Linq;
using System.Collections.Generic;

namespace SisConfTestes.Persistence
{
    [TestClass]
    public class TestesDePersistencia
    {
        string connString = "name=Home";

        [TestMethod]
        public void TestObterContexto()
        {
            using (var context = new SisConfDbContext(connString))
            {
                var query = from i in context.Insumos
                            select i;

                foreach (var item in query)
                {
                    Console.WriteLine("Insumo na base de dados: " + item.Nome);
                }

            }
        }

        [TestMethod]
        public void TestSalvarDados()
        {
            using (var context = new SisConfDbContext(connString))
            {
                Insumo insumo = new Insumo(1, "Farinha de Trigo");

                Marca m = new Marca("Dona Benta");

                insumo.Marca = m;

                context.Insumos.Add(insumo);

                context.SaveChanges();



            }
        }

        [TestMethod]
        public void TestObterDados()
        {
            using (var context = new SisConfDbContext(connString))
            {
                List<Insumo> insumosRecuperados = new List<Insumo>();

                var query = from i in context.Insumos
                            select i;

                foreach (var insumo in query)
                {
                    insumosRecuperados.Add(insumo);
                }
                double quantidade = insumosRecuperados.Count;
            }
                
        }

        [TestMethod]
        public void TestExcluirDados()
        {
            using (var context = new SisConfDbContext(connString))
            {

                Insumo i = context.Insumos.Add(new Insumo());
                context.SaveChanges();

                var query = from insumo in context.Insumos
                            where insumo.Id == i.Id
                            select insumo;

                context.Insumos.Remove(query.FirstOrDefault());

                context.SaveChanges();
            }
        }
    }
}
