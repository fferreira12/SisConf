using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisconfFrontEnd.Models
{
    public class DisponibilidadePostViewModel
    {
        public Dictionary<int,AlertaDeDisponibilidade> alertas { get; set; }
    }
}