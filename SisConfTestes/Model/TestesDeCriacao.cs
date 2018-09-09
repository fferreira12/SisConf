using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisConf.Model;

namespace SisConfTestes.Model
{
    [TestClass]
    public class TestesDeCriacao
    {

        [TestMethod]
        public void CriacaoDeUnidade()
        {
            UnidadeMedida unidade = new UnidadeMedida()
            {
                Nome = "quilograma",
                FatorConversãoSI = 1000,
                TipoUnidade = TipoUnidadeMedida.MASSA
            };
        }

        [TestMethod]
        public void CriacaoDeInsumo()
        {

            Insumo insumo = new Insumo()
            {
                Nome = "Farinha de Trigo",
                Descricao = "Farinha de trigo, pacote de 1 kg.",
                Unidade = new UnidadeMedida()
                {
                    Nome = "quilograma",
                    FatorConversãoSI = 1000,
                    TipoUnidade = TipoUnidadeMedida.MASSA
                }
                
            };

        }

        [TestMethod]
        public void CriacaoProduto()
        {
            Produto produto = new Produto()
            {
                Nome = "Bolo de cenoura",
                Descricao = "Bolo de cenoura, vendido por kg"

            };
        }

        [TestMethod]
        public void CriacaoDeEstoque()
        {
            Estoque estoque = new Estoque();
            
        }

        [TestMethod]
        public void CriacaoDeMarca()
        {
            Marca marca = new Marca()
            {
                Nome = "Dr. Oetker"
            };

        }
    }
}
