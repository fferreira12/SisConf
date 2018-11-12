using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Insumo : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        private Marca marca = null;
        public virtual Marca Marca
        {
            get {
                return marca;
            }
            set {
                if(value != null)
                {
                    value.IncluirInsumo(this);
                }
                marca = value;
            }
        }
        public UnidadeMedida Unidade { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public AlertaDeDisponibilidade Alerta { get; set; }

        public Insumo() { }

        public Insumo(string nomeDoInsumo = null, Marca marca = null)
        {
            Nome = nomeDoInsumo;
            Marca = marca == null ? new Marca() : marca;
            Unidade = new UnidadeMedida();
        }

        public Insumo(int id, string nomeDoInsumo = null, Marca marca = null)
        {
            Id = id;
            Nome = nomeDoInsumo;
            Marca = marca == null ? new Marca() : marca;
            Unidade = new UnidadeMedida();
        }

    }
}
