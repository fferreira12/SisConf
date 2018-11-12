namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialWithOneToOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlertaDeDisponibilidade",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        QuantidadeMinima = c.Double(nullable: false),
                        Ativado = c.Boolean(nullable: false),
                        Email_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Email", t => t.Email_Id)
                .ForeignKey("dbo.Insumo", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Email_Id);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDeUsuario = c.String(),
                        Provedor = c.String(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Insumo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Marca_Id = c.Int(),
                        Unidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marca", t => t.Marca_Id)
                .ForeignKey("dbo.UnidadeMedida", t => t.Unidade_Id)
                .Index(t => t.Marca_Id)
                .Index(t => t.Unidade_Id);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadeMedida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sigla = c.String(),
                        FatorConversaoSI = c.Double(nullable: false),
                        TipoUnidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Aquisicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        PrecoUnitario = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Estoque_Id = c.Int(),
                        Insumo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estoque", t => t.Estoque_Id)
                .ForeignKey("dbo.Insumo", t => t.Insumo_Id)
                .Index(t => t.Estoque_Id)
                .Index(t => t.Insumo_Id);
            
            CreateTable(
                "dbo.Estoque",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoEstoque = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Descricao = c.String(),
                        CPF = c.String(),
                        DataDeNascimento = c.DateTime(nullable: false),
                        Sexo = c.Int(nullable: false),
                        TipoCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        Cidade = c.String(),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Observacao = c.String(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        Numero = c.String(),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.EncomendaProduto",
                c => new
                    {
                        EncomendaId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.EncomendaId, t.ProdutoId })
                .ForeignKey("dbo.Encomenda", t => t.EncomendaId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.EncomendaId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Encomenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRecebimento = c.DateTime(nullable: false),
                        DataHoraEntrega = c.DateTime(nullable: false),
                        Observacoes = c.String(),
                        Status = c.Int(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                        Cliente_Id = c.Int(),
                        EnderecoEntrega_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoEntrega_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.EnderecoEntrega_Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoInsumo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        Insumo_Id = c.Int(),
                        Unidade_Id = c.Int(),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insumo", t => t.Insumo_Id)
                .ForeignKey("dbo.UnidadeMedida", t => t.Unidade_Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.Insumo_Id)
                .Index(t => t.Unidade_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.SaidaDeEstoque",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Estoque_Id = c.Int(),
                        Insumo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estoque", t => t.Estoque_Id)
                .ForeignKey("dbo.Insumo", t => t.Insumo_Id)
                .Index(t => t.Estoque_Id)
                .Index(t => t.Insumo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaidaDeEstoque", "Insumo_Id", "dbo.Insumo");
            DropForeignKey("dbo.SaidaDeEstoque", "Estoque_Id", "dbo.Estoque");
            DropForeignKey("dbo.ProdutoInsumo", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.ProdutoInsumo", "Unidade_Id", "dbo.UnidadeMedida");
            DropForeignKey("dbo.ProdutoInsumo", "Insumo_Id", "dbo.Insumo");
            DropForeignKey("dbo.EncomendaProduto", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Encomenda", "EnderecoEntrega_Id", "dbo.Endereco");
            DropForeignKey("dbo.EncomendaProduto", "EncomendaId", "dbo.Encomenda");
            DropForeignKey("dbo.Encomenda", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Telefone", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Email", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Aquisicao", "Insumo_Id", "dbo.Insumo");
            DropForeignKey("dbo.Aquisicao", "Estoque_Id", "dbo.Estoque");
            DropForeignKey("dbo.Insumo", "Unidade_Id", "dbo.UnidadeMedida");
            DropForeignKey("dbo.Insumo", "Marca_Id", "dbo.Marca");
            DropForeignKey("dbo.AlertaDeDisponibilidade", "Id", "dbo.Insumo");
            DropForeignKey("dbo.AlertaDeDisponibilidade", "Email_Id", "dbo.Email");
            DropIndex("dbo.SaidaDeEstoque", new[] { "Insumo_Id" });
            DropIndex("dbo.SaidaDeEstoque", new[] { "Estoque_Id" });
            DropIndex("dbo.ProdutoInsumo", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoInsumo", new[] { "Unidade_Id" });
            DropIndex("dbo.ProdutoInsumo", new[] { "Insumo_Id" });
            DropIndex("dbo.Encomenda", new[] { "EnderecoEntrega_Id" });
            DropIndex("dbo.Encomenda", new[] { "Cliente_Id" });
            DropIndex("dbo.EncomendaProduto", new[] { "ProdutoId" });
            DropIndex("dbo.EncomendaProduto", new[] { "EncomendaId" });
            DropIndex("dbo.Telefone", new[] { "Cliente_Id" });
            DropIndex("dbo.Endereco", new[] { "Cliente_Id" });
            DropIndex("dbo.Aquisicao", new[] { "Insumo_Id" });
            DropIndex("dbo.Aquisicao", new[] { "Estoque_Id" });
            DropIndex("dbo.Insumo", new[] { "Unidade_Id" });
            DropIndex("dbo.Insumo", new[] { "Marca_Id" });
            DropIndex("dbo.Email", new[] { "Cliente_Id" });
            DropIndex("dbo.AlertaDeDisponibilidade", new[] { "Email_Id" });
            DropIndex("dbo.AlertaDeDisponibilidade", new[] { "Id" });
            DropTable("dbo.SaidaDeEstoque");
            DropTable("dbo.ProdutoInsumo");
            DropTable("dbo.Produto");
            DropTable("dbo.Encomenda");
            DropTable("dbo.EncomendaProduto");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cliente");
            DropTable("dbo.Estoque");
            DropTable("dbo.Aquisicao");
            DropTable("dbo.UnidadeMedida");
            DropTable("dbo.Marca");
            DropTable("dbo.Insumo");
            DropTable("dbo.Email");
            DropTable("dbo.AlertaDeDisponibilidade");
        }
    }
}
