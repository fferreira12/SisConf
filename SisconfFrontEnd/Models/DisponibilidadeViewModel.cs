using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisconfFrontEnd.Models
{
    public class DisponibilidadeViewModel
    {
        public List<Insumo> insumos;
        public List<double> quantidades;
        public List<bool> possuiAlerta;

    }
}