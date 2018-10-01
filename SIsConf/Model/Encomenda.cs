using SisConf.Model.Interfaces;
using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisConf.Model.Util;

namespace SisConf.Model
{
    public class Encomenda : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataHoraEntrega { get; set; }
        public Endereco EnderecoEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public string Observacoes { get; set; }
        public StatusEncomenda Status { get; set; }

        //private Dictionary<Produto, double> produtosDaEncomenda;
        public ICollection<EncomendaProduto> EncomendaProduto { get; set; }

        public Encomenda()
        {
            //produtosDaEncomenda = new Dictionary<Produto, double>();
            EncomendaProduto = new List<EncomendaProduto>();
        }

        public void IncluirProduto(Produto produto, double quantidade)
        {
            //produtosDaEncomenda.Add(produto, quantidade);
            EncomendaProduto.Add(new EncomendaProduto(this, produto, quantidade));
        }

        public void AlterarQuantidade(Produto produto, double novaQuantidade)
        {
            //[produto] = novaQuantidade;
            EncomendaProduto.First(e => e.Encomenda == this && e.Produto == produto).Quantidade = novaQuantidade;
        }

        public void RemoverProduto(Produto produto)
        {
            //produtosDaEncomenda.Remove(produto);
            EncomendaProduto ep = EncomendaProduto.First(e => e.Encomenda == this && e.Produto == produto);
            EncomendaProduto.Remove(ep);
        }
    }
}
