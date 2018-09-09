using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Encomenda
    {
        public DateTime DataRecebimento { get; set; }
        public DateTime DataHoraEntrega { get; set; }
        public Endereco EnderecoEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public string Observacoes { get; set; }

        private Dictionary<Produto, double> produtosDaEncomenda;

        public Encomenda()
        {
            produtosDaEncomenda = new Dictionary<Produto, double>();
        }

        public void IncluirProduto(Produto produto, double quantidade)
        {
            produtosDaEncomenda.Add(produto, quantidade);
        }

        public void AlterarQuantidade(Produto produto, double novaQuantidade)
        {
            produtosDaEncomenda[produto] = novaQuantidade;
        }

        public void RemoverProduto(Produto produto)
        {
            produtosDaEncomenda.Remove(produto);
        }
    }
}
