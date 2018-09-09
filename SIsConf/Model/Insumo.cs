using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Insumo
    {
        private Marca marca = null;
        public int IdInsumo { get; set; }
        public Marca Marca
        {
            get {
                return marca;
            }
            set {
                if(marca != null)
                {
                    value.IncluirInsumo(this);
                }
                marca = value;
            }
        }
        public UnidadeMedida Unidade { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Insumo(string nomeDoInsumo = null, Marca marca = null)
        {
            Nome = nomeDoInsumo;
            Marca = marca == null ? new Marca() : marca;
        }

    }
}
