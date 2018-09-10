using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        private List<Insumo> insumos = null;

        public Marca() {
            insumos = new List<Insumo>();
        }

        public Marca(string nomeDaMarca = null)
        {
            Nome = nomeDaMarca;
            insumos = new List<Insumo>();
        }

        public void IncluirInsumo(Insumo insumo)
        {
            insumos.Add(insumo);
        }

        public void RemoverInsumo(Insumo insumo)
        {
            insumos.Remove(insumo);
        }

        public List<Insumo> ObterInsumos()
        {
            return insumos;
        }

    }
}
