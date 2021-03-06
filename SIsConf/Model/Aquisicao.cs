﻿using SisConf.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConf.Model
{
    public class Aquisicao : IIdentificadoNumericamente
    {
        public int Id { get; set; }
        public Insumo Insumo { get; set; }
        public double Quantidade { get; set; }
        public Estoque Estoque { get; set; }
        public double PrecoUnitario { get; set; }
        public DateTime Data { get; set; }
        public double PrecoTotal
        {
            get
            {
                return Quantidade * PrecoUnitario;
            }
        }

        public Aquisicao(){}

        public Aquisicao(Insumo insumo, double quantidade, double precoUnitario)
        {
            Insumo = insumo;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Data = DateTime.Now;
        }

        public Aquisicao(Insumo insumo, double quantidade, double precoUnitario, DateTime data)
        {
            Insumo = insumo;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Data = data;
        }

    }
}
