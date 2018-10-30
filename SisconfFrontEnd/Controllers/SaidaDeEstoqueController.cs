using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisConf.Model;
using SisConfPersistence.Persistence;

namespace SisconfFrontEnd.Controllers
{
    public class SaidaDeEstoqueController : Controller
    {
        private SisConfDbContext db = new SisConfDbContext();

        // GET: SaidaDeEstoque
        public ActionResult Index()
        {
            return View(db.SaidaDeEstoque.ToList());
        }

        // GET: SaidaDeEstoque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaidaDeEstoque saidaDeEstoque = db.SaidaDeEstoque.Find(id);
            if (saidaDeEstoque == null)
            {
                return HttpNotFound();
            }
            return View(saidaDeEstoque);
        }

        // GET: SaidaDeEstoque/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaidaDeEstoque/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantidade,Data")] SaidaDeEstoque saidaDeEstoque)
        {
            if (ModelState.IsValid)
            {
                db.SaidaDeEstoque.Add(saidaDeEstoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saidaDeEstoque);
        }

        // GET: SaidaDeEstoque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaidaDeEstoque saidaDeEstoque = db.SaidaDeEstoque.Find(id);
            if (saidaDeEstoque == null)
            {
                return HttpNotFound();
            }
            return View(saidaDeEstoque);
        }

        // POST: SaidaDeEstoque/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantidade,Data")] SaidaDeEstoque saidaDeEstoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saidaDeEstoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saidaDeEstoque);
        }

        // GET: SaidaDeEstoque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaidaDeEstoque saidaDeEstoque = db.SaidaDeEstoque.Find(id);
            if (saidaDeEstoque == null)
            {
                return HttpNotFound();
            }
            return View(saidaDeEstoque);
        }

        // POST: SaidaDeEstoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaidaDeEstoque saidaDeEstoque = db.SaidaDeEstoque.Find(id);
            db.SaidaDeEstoque.Remove(saidaDeEstoque);
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
