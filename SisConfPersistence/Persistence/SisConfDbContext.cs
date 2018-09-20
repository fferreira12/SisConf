﻿using SisConf.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConfPersistence.Persistence
{
    public class SisConfDbContext:DbContext
    {
        public DbSet<Aquisicao> Aquisicoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<UnidadeMedida> UnidadesMedida { get; set; }
        //public DbSet<TipoUnidadeMedida> TipoUnidadeMedida { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.ComplexType<Marca>();
            //modelBuilder.ComplexType<UnidadeMedida>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}