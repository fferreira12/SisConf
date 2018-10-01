using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisconfFrontEnd.Models
{
    public class EncomendaViewModel
    {
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public DateTime HoraEntrega { get; set; }
        public Endereco EnderecoEntrega { get; set; }
        public int EnderecoId { get; set; }
        public ICollection<EncomendaProduto> Produtos { get; set; }
        public string Observacoes { get; set; }
    }
}