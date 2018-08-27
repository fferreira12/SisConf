using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Produto
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        private Dictionary<Insumo, double> insumos = null;

        public Produto()
        {
            insumos = new Dictionary<Insumo, double>();
        }

        public void IncluirInsumo(Insumo insumo, double quantidade)
        {
            insumos.Add(insumo, quantidade);
        }

        public Dictionary<Insumo, double> GetInsumos()
        {
            return insumos;
        }

    }
}
