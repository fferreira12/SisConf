using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisconfFrontEnd.Models
{
    public class ProdutoViewModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<int> Insumos { get; set; }
        public List<string> InsumosNomes { get; set; }
        public ICollection<double> Quantidades { get; set; }

        public ProdutoViewModel() { }

        public ProdutoViewModel(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Insumos = new List<int>();
            Quantidades = new List<double>();
            foreach (var produtoInsumo in produto.ProdutoInsumo)
            {
                Insumos.Add(produtoInsumo.Insumo.Id);
                Quantidades.Add(produtoInsumo.Quantidade);
            }

        }


    }
}