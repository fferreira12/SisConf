using SisConf.Model;
using SisConf.Model.Util;
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
        private List<Insumo> insumos = null;
        private List<Produto> produtos = null;
        private List<Cliente> clientes = null;


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
            insumos = _db.Insumos.ToList();
            produtos = _db.Produtos.ToList();
            clientes = _db.Clientes.Include(c => c.Enderecos).ToList();
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

        public void CriarProdutos()
        {
            //List<Insumo> insumos = _db.Insumos.ToList();

            for (int i = 0; i < nomesProdutos.Count(); i++)
            {
                Produto prod = new Produto(nomesProdutos[i])
                {
                    Descricao = nomesProdutos[i],
                };

                int quantidadeDeInsumos = random.Next(5) + 1;


                prod.ProdutoInsumo = new List<ProdutoInsumo>();
                for(int j = 0; j < quantidadeDeInsumos; j++)
                {
                    ProdutoInsumo pi = new ProdutoInsumo()
                    {
                        Insumo = GetRandomFromArray(insumos.ToArray()),
                        Produto = prod,
                        Quantidade = random.NextDouble() * 10 + 1
                    };
                    prod.ProdutoInsumo.Add(pi);
                }

                _db.Produtos.Add(prod);
            }

            _db.SaveChanges();
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

        public void CriarEncomendas(int quantidade) 
        {
            //ICollection<Cliente> clientes = _db.Clientes.Include(c => c.Enderecos).ToList();
            //ICollection<Produto> produtos = _db.Produtos.ToList();
            for (int i = 0; i < quantidade; i++)
            {
                bool passada = random.NextDouble() < 0.85;

                Encomenda enc = new Encomenda()
                {
                    Cliente = GetRandomFromArray(clientes.ToArray()),
                    DataHoraEntrega = passada ? DateTime.Now.AddDays(-random.NextDouble() * 150) : DateTime.Now.AddDays(random.NextDouble() * 30),
                    DataRecebimento = passada ? DateTime.Now.AddDays(-random.NextDouble() * 180) : DateTime.Now,
                    Status = passada ? StatusEncomenda.FINALIZADA : StatusEncomenda.ATIVA   
                };

                enc.EncomendaProduto = new List<EncomendaProduto>()
                {
                    new EncomendaProduto(
                        enc,
                        GetRandomFromArray(produtos.ToArray()),
                        random.NextDouble()*10
                    )
                };

                enc.EnderecoEntrega = enc.Cliente.Enderecos.ToArray()[0];

                _db.Encomendas.Add(enc);

            }

            _db.SaveChanges();
        }

        public void CriarAquisicoes()
        {
            for(int i = 0; i < nomesInsumos.Length; i++)
            {
                int quantidadeDeAquisicoes = random.Next(5, 11);

                for(int j = 0; j < quantidadeDeAquisicoes; j++)
                {
                    Aquisicao aquis = new Aquisicao(GetRandomFromArray(insumos.ToArray()), random.NextDouble() * 150 + 50, random.NextDouble() * 90 + 10);
                    _db.Aquisicoes.Add(aquis);
                }
            }
            _db.SaveChanges();
        }
    }
}

