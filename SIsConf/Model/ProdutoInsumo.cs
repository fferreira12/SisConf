using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisConf.Model.Interfaces;

namespace SisConf.Model
{
    public class ProdutoInsumo : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Insumo Insumo { get; set; }
        public double Quantidade { get; set; }
        public UnidadeMedida Unidade { get; set; }
    }
}
