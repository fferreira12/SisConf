using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class UnidadeMedida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public double FatorConversaoSI { get; set; }
        public virtual TipoUnidadeMedida TipoUnidade { get; set; }


    }
}
