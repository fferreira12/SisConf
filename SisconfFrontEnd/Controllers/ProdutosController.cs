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

namespace SisconfFrontEnd.Controllers
{
    public class ProdutosController : Controller
    {
        private SisConfDbContext db = new SisConfDbContext();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtos = db.Produtos.Include(p => p.ProdutoInsumo.Select(pi => pi.Insumo)).ToList();
            Produto produto = produtos.Find(p => p.Id == id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(new ProdutoViewModel(produto));
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtos = db.Produtos.Include(p => p.ProdutoInsumo.Select(pi => pi.Insumo)).ToList();
            Produto produto = produtos.Find(p => p.Id == id);

            var insumosDisponiveis = db.Insumos.Select(i => i);
            if (produto == null)
            {
                return HttpNotFound();
            }

            ProdutoViewModel pvm = new ProdutoViewModel(produto);
            pvm.insumosDisponiveis = insumosDisponiveis.ToList();

            return View(pvm);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {

            var form = Request.Form.GetValues(4);
            var form2 = Request.Form.GetValues(5);


            for(int i = 0; i < Request.Form.Keys.Count; i++)
            {

            }



            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
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
