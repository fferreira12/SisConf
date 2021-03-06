﻿using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Produto : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        private Dictionary<Insumo, double> insumos = null;
        private Estoque Estoque = null;

        public ICollection<EncomendaProduto> EncomendaProduto { get; set; }
        public ICollection<ProdutoInsumo> ProdutoInsumo { get; set; }

        public Produto()
        {
            Nome = null;
            insumos = new Dictionary<Insumo, double>();

        }

        public Produto(string nome = null)
        {
            Nome = nome;
            insumos = new Dictionary<Insumo, double>();
        }

        public void IncluirInsumo(Insumo insumo, double quantidade)
        {
            insumos.Add(insumo, quantidade);
        }

        public Dictionary<Insumo, double> ObterInsumos()
        {
            return new Dictionary<Insumo, double>(insumos);
        }

        public double CalcularCustoDoProduto(Estoque estoque = null)
        {
            if(estoque == null && Estoque == null)
            {
                return 0.0;
            }
            else if (Estoque == null || (estoque != null && Estoque != estoque))
            {
                Estoque = estoque;
            }

            double valorTotal = 0.0;
            //foreach (var insumo in insumos)
            //{
            //    valorTotal += insumo.Value * Estoque.CalcularPrecoMedio(insumo.Key);
            //}
            foreach (ProdutoInsumo produtoInsumo in ProdutoInsumo)
            {
                valorTotal += produtoInsumo.Quantidade * Estoque.CalcularPrecoMedio(produtoInsumo.Insumo);
            }
            return valorTotal;
        }

        public double ObterPrecoDeVendaPelaMargemDeLucro(double margemDeLucro)
        {
            return CalcularCustoDoProduto() / (1.0 - margemDeLucro);
        }

        public double ObterPrecoDeVendaPeloLucroAbsoluto(double lucroDesejado)
        {
            return CalcularCustoDoProduto() + lucroDesejado;
        }

    }
}
