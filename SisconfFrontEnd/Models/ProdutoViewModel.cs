using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisconfFrontEnd.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<Insumo> insumosDisponiveis = null;

        public List<int> insumosIds { get; set; }
        public List<string> insumosNomes { get; set; }
        public List<double> insumosQuantidades { get; set; }

        public ProdutoViewModel() { }

        public ProdutoViewModel(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;

            insumosIds = new List<int>();
            insumosNomes = new List<string>();
            insumosQuantidades = new List<double>();
            foreach(ProdutoInsumo pi in produto.ProdutoInsumo)
            {
                insumosIds.Add(pi.Insumo.Id);
                insumosNomes.Add(pi.Insumo.Nome);
                insumosQuantidades.Add(pi.Quantidade);
            }

        }
    }
}