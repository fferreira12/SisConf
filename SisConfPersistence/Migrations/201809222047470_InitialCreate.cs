namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aquisicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        PrecoUnitario = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Insumo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insumo", t => t.Insumo_Id)
                .Index(t => t.Insumo_Id);
            
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
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDeUsuario = c.String(),
                        Provedor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Encomenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRecebimento = c.DateTime(nullable: false),
                        DataHoraEntrega = c.DateTime(nullable: false),
                        Observacoes = c.String(),
                        Cliente_Id = c.Int(),
                        EnderecoEntrega_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoEntrega_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.EnderecoEntrega_Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estoque",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoEstoque = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Encomenda", "EnderecoEntrega_Id", "dbo.Endereco");
            DropForeignKey("dbo.Encomenda", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Aquisicao", "Insumo_Id", "dbo.Insumo");
            DropForeignKey("dbo.Insumo", "Unidade_Id", "dbo.UnidadeMedida");
            DropForeignKey("dbo.Insumo", "Marca_Id", "dbo.Marca");
            DropIndex("dbo.Encomenda", new[] { "EnderecoEntrega_Id" });
            DropIndex("dbo.Encomenda", new[] { "Cliente_Id" });
            DropIndex("dbo.Insumo", new[] { "Unidade_Id" });
            DropIndex("dbo.Insumo", new[] { "Marca_Id" });
            DropIndex("dbo.Aquisicao", new[] { "Insumo_Id" });
            DropTable("dbo.Telefone");
            DropTable("dbo.Produto");
            DropTable("dbo.Estoque");
            DropTable("dbo.Endereco");
            DropTable("dbo.Encomenda");
            DropTable("dbo.Email");
            DropTable("dbo.Cliente");
            DropTable("dbo.UnidadeMedida");
            DropTable("dbo.Marca");
            DropTable("dbo.Insumo");
            DropTable("dbo.Aquisicao");
        }
    }
}
