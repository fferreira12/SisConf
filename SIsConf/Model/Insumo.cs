using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Insumo
    {
        public int IdInsumo { get; set; }
        public Marca Marca { get; set; }
        public UnidadeMedida Unidade { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        List<Aquisicao> Aquisicoes { get; }

        public Insumo()
        {
            Aquisicoes = new List<Aquisicao>();
        }


        private class Aquisicao
        {
            public double Quantidade { get; set; }
            public double PrecoUnitario { get; set; }
        }

        public void IncluirAquisicao(double quantidade, double precoUnitario)
        {
            Aquisicoes.Add(new Aquisicao()
            {
                Quantidade = quantidade,
                PrecoUnitario = precoUnitario
            });
        }

        public double CalcularPrecoMedio()
        {
            if (!PossuiAquisicoes())
            {
                return 0;
            }
            double ponderacao = Aquisicoes.Aggregate(0.0, (acc, x) => acc + x.Quantidade * x.PrecoUnitario);
            return ponderacao / QuantidadeTotalAdquirida();
        }

        public double QuantidadeTotalAdquirida()
        {
            if (!PossuiAquisicoes())
            {
                return 0;
            }
            return Aquisicoes.Aggregate(0.0, (acc, x) => acc + x.Quantidade);
        }

        public bool PossuiAquisicoes()
        {
            return !(Aquisicoes == null || Aquisicoes.Count == 0);
        }

        public int QuantidadeDeAquisicoes()
        {
            return Aquisicoes.Count;
        }
    }
}
