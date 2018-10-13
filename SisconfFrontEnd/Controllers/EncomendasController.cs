using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisConf.Model;
using SisconfFrontEnd.Models;
using SisConfPersistence.Persistence;
using SisConf.Model.Util;

namespace SisconfFrontEnd.Controllers
{
    public class EncomendasController : Controller
    {
        private SisConfDbContext db = new SisConfDbContext();

        // GET: Encomendas
        public ActionResult Index()
        {
            var encomendas = db.Encomendas.Include(e => e.Cliente);
            return View(encomendas.ToList());
        }

        // GET: Encomendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // GET: Encomendas/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> clientes = db.Clientes.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            });
            ViewBag.Clientes = clientes;

            IEnumerable<SelectListItem> produtos = db.Produtos.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nome
            });
            ViewBag.Produtos = produtos;

            return View();
        }

        // POST: Encomendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,HoraEntrega,Observacoes")] EncomendaViewModel encomenda)
        {
            if (ModelState.IsValid)
            {
                Encomenda enc = new Encomenda();
                enc.DataRecebimento = DateTime.Now;
                enc.DataHoraEntrega = encomenda.HoraEntrega;
                enc.Observacoes = encomenda.Observacoes;
                enc.Status = StatusEncomenda.ATIVA;
                enc.Cliente = db.Clientes.FirstOrDefault(c => c.Id == encomenda.ClienteId);

                db.Encomendas.Add(enc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encomenda);
        }

        // GET: Encomendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // POST: Encomendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataRecebimento,DataHoraEntrega,Observacoes")] Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encomenda);
        }

        // GET: Encomendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        // POST: Encomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
