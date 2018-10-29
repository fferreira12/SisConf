namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationEstoqueAquisicaoSaida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aquisicao", "Estoque_Id", c => c.Int());
            AddColumn("dbo.SaidaDeEstoque", "Estoque_Id", c => c.Int());
            CreateIndex("dbo.Aquisicao", "Estoque_Id");
            CreateIndex("dbo.SaidaDeEstoque", "Estoque_Id");
            AddForeignKey("dbo.Aquisicao", "Estoque_Id", "dbo.Estoque", "Id");
            AddForeignKey("dbo.SaidaDeEstoque", "Estoque_Id", "dbo.Estoque", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaidaDeEstoque", "Estoque_Id", "dbo.Estoque");
            DropForeignKey("dbo.Aquisicao", "Estoque_Id", "dbo.Estoque");
            DropIndex("dbo.SaidaDeEstoque", new[] { "Estoque_Id" });
            DropIndex("dbo.Aquisicao", new[] { "Estoque_Id" });
            DropColumn("dbo.SaidaDeEstoque", "Estoque_Id");
            DropColumn("dbo.Aquisicao", "Estoque_Id");
        }
    }
}
