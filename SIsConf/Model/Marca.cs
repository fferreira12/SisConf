using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Marca : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        private ICollection<Insumo> insumos = null;

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

        public ICollection<Insumo> ObterInsumos()
        {
            return insumos;
        }

    }
}
