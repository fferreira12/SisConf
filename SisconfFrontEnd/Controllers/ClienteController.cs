using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SisConfPersistence.Persistence;

namespace SisconfFrontEnd.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Clientes()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Fernando";

            Cliente c2 = new Cliente()
            {
                Nome = "Jane"
            };
            return View(new Cliente[] { cliente, c2 });
        }

        public ActionResult Adicionar() => View();

        public ActionResult SalvarCliente(Cliente c)
        {

            using (SisConfDbContext db = new SisConfDbContext("name=Home"))
            {
                db.Clientes.Add(c);
                db.SaveChanges();
            }


            return View();
        }
    }
}