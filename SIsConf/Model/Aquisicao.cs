using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Aquisicao
    {
        public int Id { get; set; }
        public Insumo Insumo { get; set; }
        public double Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public DateTime Data { get; set; }

        public Aquisicao(){}

        public Aquisicao(Insumo insumo, double quantidade, double precoUnitario)
        {
            Insumo = insumo;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

    }
}
