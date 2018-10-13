using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisconfFrontEnd.Models
{
    public class CustosViewModel
    {
        public List<Produto> produtos { get; set; }
        public List<double> custos { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public double margemLucro { get; set; }
    }
}