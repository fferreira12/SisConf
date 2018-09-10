using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Estoque
    {
        public int Id { get; set; }
        public string NomeDoEstoque { get; set; }
        private Dictionary<Insumo, double> estoque = null;
        private List<Aquisicao> aquisicoes = null;


        public Estoque(string nomeDoEstoque = null)
        {
            NomeDoEstoque = nomeDoEstoque == null ? "" : nomeDoEstoque;
            estoque = new Dictionary<Insumo, double>();
            aquisicoes = new List<Aquisicao>();
        }

        public Dictionary<Insumo, double> GetEstoque()
        {
            AtualizarEstoque();

            return new Dictionary<Insumo, double>(estoque);
        }

        private void AtualizarEstoque()
        {
            estoque = new Dictionary<Insumo, double>();

            foreach (Aquisicao aquisicao in aquisicoes)
            {
                if (estoque.ContainsKey(aquisicao.Insumo))
                {
                    estoque[aquisicao.Insumo] += aquisicao.Quantidade;
                }
                else
                {
                    estoque[aquisicao.Insumo] = aquisicao.Quantidade;
                }
            }
        }

        public void IncluirAquisicao(params Aquisicao[] aquisicoes)
        {
            foreach (Aquisicao aquisicao in aquisicoes)
            {
                this.aquisicoes.Add(aquisicao);
            }
        }

        public void RemoverAquisicao(Aquisicao aquisicao)
        {
            aquisicoes.Remove(aquisicao);
        }

        public double ObterQuantidade(Insumo insumo)
        {
            AtualizarEstoque();
            return estoque[insumo];
        }

        public double ValorTotalDoEstoque()
        {
            double valorTotal = 0;
            foreach (Aquisicao aquisicao in aquisicoes)
            {
                valorTotal += aquisicao.Quantidade * aquisicao.PrecoUnitario;
            }
            return valorTotal;
        }

        public double CalcularPrecoMedio(Insumo insumo = null)
        {
            if(insumo == null)
            {
                return 0;
            }

            double ponderacao = 0;

            aquisicoes.ForEach((aquisicao) =>
            {
                if(insumo != null && aquisicao.Insumo == insumo)
                {
                    ponderacao += aquisicao.Quantidade * aquisicao.PrecoUnitario;
                }
            });

            return ponderacao / ObterQuantidade(insumo);

        }

        public bool PossuiAquisicoes(Insumo insumo)
        {
            return aquisicoes != null && aquisicoes.FirstOrDefault((aquisicao) => aquisicao.Insumo == insumo) != null;
        }

        public int QuantidadeDeAquisicoes(Insumo insumo)
        {
            if(insumo == null)
            {
                return 0;
            }
            int quantidade = 0;
            foreach (Aquisicao aquisicao in aquisicoes)
            {
                if(aquisicao.Insumo == insumo)
                {
                    quantidade++;
                }
            }
            return quantidade;
        }

    }
}
