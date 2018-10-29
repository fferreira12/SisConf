namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnidadeMedidaProdutoInsumo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProdutoInsumo", "Unidade_Id", c => c.Int());
            CreateIndex("dbo.ProdutoInsumo", "Unidade_Id");
            AddForeignKey("dbo.ProdutoInsumo", "Unidade_Id", "dbo.UnidadeMedida", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoInsumo", "Unidade_Id", "dbo.UnidadeMedida");
            DropIndex("dbo.ProdutoInsumo", new[] { "Unidade_Id" });
            DropColumn("dbo.ProdutoInsumo", "Unidade_Id");
        }
    }
}
