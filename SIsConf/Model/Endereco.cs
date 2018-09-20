using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Endereco : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        //string para aceitar valores como "15A"
        public string Numero { get; set; }
        public string Observacao { get; set; }
    }
}
