using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisconfFrontEnd.Models
{
    public class LucrosViewModel
    {

        public List<Encomenda> encomendas { get; set; }
        public List<double> custos { get; set; }

        public double totalCustos { get; set; }
        public double totalPrecoVenda { get; set; }
        public double totalLucroPrejuizo { get; set; }
    }
}