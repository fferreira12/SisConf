using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            var produtos = db.Produtos
                .Include(p => p.ProdutoInsumo.Select(pi => pi.Insumo));
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> insumos = db.Insumos.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            });
            ViewBag.Insumos = insumos;
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {

            if(produtoViewModel.Insumos == null || produtoViewModel.Quantidades == null)
            {
                Response.StatusCode = 404;  //you may want to set this to 200
                return View("BadRequest");
            }

            Produto p = new Produto()
            {
                Descricao = produtoViewModel.Descricao,
                Nome = produtoViewModel.Nome
            };

            p.ProdutoInsumo = new List<ProdutoInsumo>();
            for (int i = 0; i < produtoViewModel.Insumos.Count; i++)
            {
                Insumo insumo = db.Insumos.Find(produtoViewModel.Insumos.ElementAt(i));

                ProdutoInsumo pi = new ProdutoInsumo()
                {
                    Produto = p,
                    Insumo = insumo,
                    Quantidade = produtoViewModel.Quantidades.ElementAt(i)
                };

                p.ProdutoInsumo.Add(pi);
            }

            if (ModelState.IsValid)
            {
                db.Produtos.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtos = db.Produtos.Include(p => p.ProdutoInsumo.Select(pi => pi.Insumo));
            Produto produto = produtos.FirstOrDefault(p => p.Id == id);
            IEnumerable<SelectListItem> insumos = db.Insumos.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            });
            List<string> insumosNomes = produto.ProdutoInsumo.Select(pi => pi.Insumo.Nome).ToList();//db.Insumos.Select(i => i.Nome).ToList();
            ViewBag.Insumos = insumos;
            ViewBag.InsumosNomes = insumosNomes;

            ProdutoViewModel pvm = new ProdutoViewModel(produto);
            pvm.InsumosNomes = insumosNomes;

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(pvm);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.Insumos == null || produtoViewModel.Quantidades == null)
            {
                Response.StatusCode = 404;  //you may want to set this to 200
                return View("BadRequest");
            }
            var produtos = db.Produtos.Include(prod => prod.ProdutoInsumo);
            Produto p = produtos.First(pi => pi.Id == produtoViewModel.Id);

            p.Descricao = produtoViewModel.Descricao;
            p.Nome = produtoViewModel.Nome;

            p.ProdutoInsumo = new List<ProdutoInsumo>();
            for (int i = 0; i < produtoViewModel.Insumos.Count; i++)
            {
                Insumo insumo = db.Insumos.Find(produtoViewModel.Insumos.ElementAt(i));

                if(insumo == null)
                {
                    var insumoName = Request.Form;

                    //insumo = db.Insumos.First(ins => ins.Nome == insumoName);
                }

                ProdutoInsumo pi = new ProdutoInsumo()
                {
                    Produto = p,
                    Insumo = insumo,
                    Quantidade = produtoViewModel.Quantidades.ElementAt(i)
                };

                p.ProdutoInsumo.Add(pi);
            }
            if (ModelState.IsValid)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
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

            db.ProdutoInsumo.RemoveRange(db.ProdutoInsumo.Where(pi => pi.Produto.Id == id));


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
