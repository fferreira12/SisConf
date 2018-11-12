using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class AlertaDeDisponibilidade : IIdentificadoNumericamente
    {

        public int Id { get; set; }
        
        public virtual Insumo Insumo { get; set; }
        public double QuantidadeMinima { get; set; }
        public Email Email { get; set; }
        public bool Ativado { get; set; }

    }
}
