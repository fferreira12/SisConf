using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class EncomendaProduto
    {
        public virtual Encomenda Encomenda { get; set; }
        public int EncomendaId { get; set; }
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        public double Quantidade { get; set; }

        public EncomendaProduto() { }
        public EncomendaProduto(Encomenda encomenda, Produto produto, double quantidade)
        {
            Encomenda = encomenda;
            EncomendaId = encomenda.Id;
            Produto = produto;
            ProdutoId = produto.Id;
            Quantidade = quantidade;
        }
    }
}
