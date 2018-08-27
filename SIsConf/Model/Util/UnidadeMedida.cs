using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class UnidadeMedida
    {

        public string Nome { get; set; }
        public string Sigla { get; set; }
        public double FatorConversãoSI { get; set; }
        public TipoUnidadeMedida TipoUnidade { get; set; }


    }
}
