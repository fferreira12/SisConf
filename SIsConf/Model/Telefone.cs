using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Telefone
    {

        public int Id { get; set; }

        public int DDD { get; set; }

        //string para aceitar caracteres como #, * e +
        public string Numero { get; set; }

        public Telefone(int ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }

    }
}
