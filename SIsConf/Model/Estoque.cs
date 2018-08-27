using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Estoque
    {

        private Dictionary<Insumo, double> estoque = null;


        public Estoque()
        {
            estoque = new Dictionary<Insumo, double>();
        }

        public Dictionary<Insumo, double> GetEstoque()
        {
            return new Dictionary<Insumo, double>(estoque);
        }

        public void Incluir(Insumo insumo, double quantidade)
        {
            if (estoque.ContainsKey(insumo))
            {
                estoque[insumo] += quantidade;
            } else
            {
                estoque[insumo] = quantidade;
            }
        }

        public void Retirar(Insumo insumo, double quantidade)
        {
            if (estoque.ContainsKey(insumo))
            {
                estoque[insumo] -= quantidade;
            }
            else
            {
                estoque[insumo] = 0;
            }
        }

        public double GetQuantidade(Insumo insumo)
        {
            return estoque[insumo];
        }



    }
}
