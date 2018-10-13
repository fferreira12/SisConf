namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelacaoProdutoInsumo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoInsumo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        Insumo_Id = c.Int(),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insumo", t => t.Insumo_Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.Insumo_Id)
                .Index(t => t.Produto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoInsumo", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.ProdutoInsumo", "Insumo_Id", "dbo.Insumo");
            DropIndex("dbo.ProdutoInsumo", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoInsumo", new[] { "Insumo_Id" });
            DropTable("dbo.ProdutoInsumo");
        }
    }
}
