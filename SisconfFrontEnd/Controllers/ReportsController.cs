using SisConf.Model;
using SisconfFrontEnd.Models;
using SisConfPersistence.Persistence;
using System.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisconfFrontEnd.Controllers
{
    public class ReportsController : Controller
    {
        private SisConfDbContext db = new SisConfDbContext();



        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        //GET: Reports/Custos
        public ActionResult Custos()
        {
            //get the products
            var produtos = db.Produtos.Include(prod => prod.ProdutoInsumo.Select(pi => pi.Insumo)).ToList();

            //get que acquisitions
            List<Aquisicao> aquisicoes = db.Aquisicoes.Include(aq => aq.Insumo).ToList();

            Estoque estoque = new Estoque();
            estoque.IncluirAquisicao(aquisicoes.ToArray());

            List<double> custos = new List<double>();

            for(int i = 0; i < produtos.Count; i++)
            {
                double custo = produtos[i].CalcularCustoDoProduto(estoque);
                custos.Add(custo);
            }

            CustosViewModel cvm = new CustosViewModel();
            cvm.produtos = produtos;
            cvm.custos = custos;

            return View(cvm);
        }

        //GET: Reports/PrecoVenda
        public ActionResult PrecoVenda(int? id)
        {//get the products
            var produtos = db.Produtos.Include(prod => prod.ProdutoInsumo.Select(pi => pi.Insumo)).ToList();

            //get que acquisitions
            List<Aquisicao> aquisicoes = db.Aquisicoes.Include(aq => aq.Insumo).ToList();

            Estoque estoque = new Estoque();
            estoque.IncluirAquisicao(aquisicoes.ToArray());

            List<double> custos = new List<double>();

            for (int i = 0; i < produtos.Count; i++)
            {
                double custo = produtos[i].CalcularCustoDoProduto(estoque);
                custos.Add(custo);
            }

            CustosViewModel cvm = new CustosViewModel();
            cvm.produtos = produtos;
            cvm.custos = custos;
            cvm.margemLucro = id == null ? 0 : (double)id;
            return View(cvm);
        }

        //GET: Reports/Lucros
        public ActionResult Lucros()
        {
            List<Encomenda> encomendas = db.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.EncomendaProduto
                .Select(ep => ep.Produto)
                .Select(ep => ep.ProdutoInsumo
                .Select(pi => pi.Insumo)))
                .ToList();

            //get que acquisitions
            List<Aquisicao> aquisicoes = db.Aquisicoes.Include(aq => aq.Insumo).ToList();

            Estoque estoque = new Estoque();
            estoque.IncluirAquisicao(aquisicoes.ToArray());

            List<double> custos = new List<double>();

            double totalCustos = 0;
            double totalPrecoVenda = 0;
            double totalLucroPrejuizo = 0;

            for (int i = 0; i < encomendas.Count; i++)
            {
                double custoEncomenda = 0;
                totalPrecoVenda += encomendas[i].PrecoVenda;
                foreach (EncomendaProduto ep in encomendas[i].EncomendaProduto)
                {
                    custoEncomenda += ep.Produto.CalcularCustoDoProduto(estoque);
                }
                custos.Add(custoEncomenda);
                totalCustos += custoEncomenda;
                totalLucroPrejuizo += encomendas[i].PrecoVenda - custoEncomenda;
            }

            LucrosViewModel lvm = new LucrosViewModel()
            {
                encomendas = encomendas,
                custos = custos,
                totalCustos = totalCustos,
                totalPrecoVenda = totalPrecoVenda,
                totalLucroPrejuizo = totalLucroPrejuizo
            };

            return View(lvm);
        }

        //GET: Reports/Disponibilidade
        public ActionResult Disponibilidade()
        {
            List<Insumo> insumos = db.Insumos.Include(i => i.Unidade).ToList();
            List<Aquisicao> aquisicoes = db.Aquisicoes.Include(aq => aq.Insumo).ToList();
            List<SaidaDeEstoque> saidas = db.SaidaDeEstoque.Include(s => s.Insumo).ToList();
            List<AlertaDeDisponibilidade> alertas = db.Alertas
                .Include(a => a.Email).ToList();

            Estoque e = new Estoque();
            e.IncluirAquisicao(aquisicoes.ToArray());
            e.IncluirSaidas(saidas.ToArray());

            List<double> quantidades = new List<double>();
            foreach(Insumo i in insumos)
            {
                quantidades.Add(e.ObterQuantidade(i));
            }

            DisponibilidadeViewModel dvm = new DisponibilidadeViewModel()
            {
                insumos = insumos,
                quantidades = quantidades
            };

            return View(dvm);
        }
    }
}