namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEncomendaProduto : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EncomendaProduto", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.EncomendaProduto", "EncomendaId", "dbo.Encomenda");
            DropIndex("dbo.EncomendaProduto", new[] { "ProdutoId" });
            DropIndex("dbo.EncomendaProduto", new[] { "EncomendaId" });
            DropTable("dbo.EncomendaProduto");
        }
    }
}
