using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Estoque : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public string NomeDoEstoque { get; set; }
        private Dictionary<Insumo, double> estoque = null;
        private List<Aquisicao> aquisicoes = null;
        private List<SaidaDeEstoque> saidas = null;


        public Estoque(string nomeDoEstoque = null)
        {
            NomeDoEstoque = nomeDoEstoque == null ? "" : nomeDoEstoque;
            estoque = new Dictionary<Insumo, double>();
            aquisicoes = new List<Aquisicao>();
            saidas = new List<SaidaDeEstoque>();
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
            foreach (SaidaDeEstoque saida in saidas)
            {
                if (estoque.ContainsKey(saida.Insumo))
                {
                    estoque[saida.Insumo] -= saida.Quantidade;
                }
                else
                {
                    estoque[saida.Insumo] = saida.Quantidade;
                }

                //TODO: melhorar validação para os casos de saídas maiores que entradas
                if(estoque[saida.Insumo] < 0)
                {
                    estoque[saida.Insumo] = 0;
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

        public void IncluirSaidas(params SaidaDeEstoque[] saidas)
        {
            foreach (SaidaDeEstoque saida in saidas)
            {
                this.saidas.Add(saida);
            }
        }

        public void RemoverAquisicao(Aquisicao aquisicao)
        {
            aquisicoes.Remove(aquisicao);
        }

        public void RemoverSaida(SaidaDeEstoque saida)
        {
            saidas.Remove(saida);
        }

        public double ObterQuantidade(Insumo insumo)
        {
            AtualizarEstoque();
            try
            {
                return estoque[insumo];
            } catch(Exception e)
            {
                return 0;
            }
        }

        public double ValorTotalDoEstoque()
        {
            double valorTotal = 0;
            foreach (Aquisicao aquisicao in aquisicoes)
            {
                valorTotal += aquisicao.Quantidade * aquisicao.PrecoUnitario;
            }
            foreach (SaidaDeEstoque saida in saidas)
            {
                valorTotal -= saida.Quantidade * CalcularPrecoMedio(saida.Insumo);
            }
            return valorTotal > 0 ? valorTotal : 0;
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
                    ponderacao += aquisicao.PrecoTotal;
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
