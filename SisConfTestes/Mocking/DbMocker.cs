﻿using SisConf.Model;
using SisConfPersistence.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisConfTestes.Mocking
{
    public class DbMocker
    {
        private SisConfDbContext _db = null;
        static Random random = new Random();

        private static Marca[] marcas = new[] {
            new Marca("Marca 1"),
            new Marca("Marca 2"),
            new Marca("Marca 3"),
            new Marca("Marca 4")
        };

        private static UnidadeMedida[] unidades = new[]
        {
            new UnidadeMedida()
            {
                FatorConversaoSI = 1,
                Nome = "grama",
                Sigla = "g",
                TipoUnidade = TipoUnidadeMedida.MASSA
            },
            new UnidadeMedida()
            {
                FatorConversaoSI = 1000,
                Nome = "mililitro",
                Sigla = "ml",
                TipoUnidade = TipoUnidadeMedida.VOLUME
            },
            new UnidadeMedida()
            {
                FatorConversaoSI = 1,
                Nome = "unidade",
                Sigla = "un",
                TipoUnidade = TipoUnidadeMedida.UNIDADE
            }

        };

        private static readonly string[] nomesInsumos = new[] { "Açúcar",
                                                                "Açúcar Mascavo",
                                                                "Farinha de Trigo",
                                                                "Margarina",
                                                                "Manteiga",
                                                                "Ovo",
                                                                "Leite",
                                                                "Fermento em pó",
                                                                "Chocolate",
                                                                "Chocolate em pó",
                                                                "Achocolatado",
                                                                "Essência",
                                                                };

        private static readonly UnidadeMedida[] unidadesOrdem = new[] {
                                                                unidades[0],
                                                                unidades[0],
                                                                unidades[0],
                                                                unidades[0],
                                                                unidades[0],
                                                                unidades[2],
                                                                unidades[1],
                                                                unidades[0],
                                                                unidades[0],
                                                                unidades[0],
                                                                unidades[0],
                                                                unidades[1],
                                                                };


        private static readonly TipoUnidadeMedida[] unidadesTipos = new[] {
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.UNIDADE,
                                                                TipoUnidadeMedida.VOLUME,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.MASSA,
                                                                TipoUnidadeMedida.VOLUME,
                                                                };

        private static readonly string[] nomesProdutos = new[] {
                                                                "Bolo",
                                                                "Cookie",
                                                                "Cupcake",
                                                                "Brownie",
                                                                "Brigadeiro",
                                                                "Doce",
                                                                };

        private static readonly string[] nomesClientes = new[] {
                                                              "Fernando",
                                                              "Maria",
                                                              "João",
                                                              "José",
                                                              "Milena",
                                                              "Gabriel",
                                                              "Kamila",
                                                              "Marina",
                                                              "Sebastião",
                                                              "Juvenal",
                                                              "Arnaldo",
                                                              "Alessandro",
                                                              "Lucas"
                                                              };

        private static readonly string[] nomesCidades = new[]
        {
                "Brazlândia",
                "Ceilândia",
                "Taguatinga"
        };

        public DbMocker(SisConfDbContext db)
        {
            _db = db;
        }

        public void CriarInsumos()
        {
            foreach (Marca m in marcas)
            {
                foreach (string nome in nomesInsumos)
                {
                    int index = Array.IndexOf(nomesInsumos, nome);
                    Insumo insumo = CriarInsumo(nome, m, index);
                    _db.Insumos.Add(insumo);
                }

            }
            _db.SaveChanges();

        }

        private Insumo CriarInsumo(string nomeInsumo, Marca marca, int index)
        {
            //int r = random.Next(nomesInsumos.Count());
            Insumo insumo = new Insumo();
            insumo.Nome = nomeInsumo;
            insumo.Descricao = insumo.Nome;
            insumo.Marca = marca;
            insumo.Unidade = unidadesOrdem[index];
            return insumo;
        }

        public void CriarClientes()
        {
            foreach (string nome in nomesClientes)
            {
                Cliente cliente = new Cliente()
                {
                    CPF = random.Next(int.MaxValue).ToString(),
                    DataDeNascimento = new DateTime(random.Next(1900, 2018), random.Next(1, 13), random.Next(1, 29)),
                    Nome = nome,
                    Sexo = (Sexo)random.Next(0, 2),
                    Sobrenome = GetRandomFromArray<string>(nomesClientes)
                };
                cliente.Adicionar(new Email(cliente.Nome + cliente.Sobrenome + "@gmail.com"));
                cliente.Adicionar(new Email(cliente.Nome + cliente.Sobrenome + "@hotmail.com"));
                cliente.Adicionar(new Email(cliente.Nome + cliente.Sobrenome + "@yahoo.com"));

                cliente.Adicionar(new Endereco()
                {
                    Cidade = GetRandomFromArray<string>(nomesCidades),
                    Estado = "DF",
                    Logradouro = "Quadra",
                    Numero = random.Next(100).ToString()
                });
                cliente.Adicionar(new Endereco()
                {
                    Cidade = GetRandomFromArray<string>(nomesCidades),
                    Estado = "DF",
                    Logradouro = "Quadra",
                    Numero = random.Next(100).ToString()
                });

                cliente.Adicionar(new Telefone(61, random.Next(999999999).ToString()));
                cliente.Adicionar(new Telefone(61, random.Next(999999999).ToString()));
                cliente.Adicionar(new Telefone(61, random.Next(999999999).ToString()));

                _db.Clientes.Add(cliente);

            }

            _db.SaveChanges();

        }

        private static T GetRandomFromArray<T>(T[] itemsArray)
        {
            return itemsArray[random.Next(itemsArray.Count())];
        }
    }
}
