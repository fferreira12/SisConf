using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class SaidaDeEstoque : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public Insumo Insumo { get; set; }
        public double Quantidade { get; set; }
        public Estoque Estoque { get; set; }
        public DateTime Data { get; set; }

    }
}
