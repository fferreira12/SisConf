namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSaidaEstoque : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaidaDeEstoque",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Insumo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insumo", t => t.Insumo_Id)
                .Index(t => t.Insumo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaidaDeEstoque", "Insumo_Id", "dbo.Insumo");
            DropIndex("dbo.SaidaDeEstoque", new[] { "Insumo_Id" });
            DropTable("dbo.SaidaDeEstoque");
        }
    }
}
