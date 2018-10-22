namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAlertaDisponibilidade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlertaDeDisponibilidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeMinima = c.Double(nullable: false),
                        Email_Id = c.Int(),
                        Insumo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Email", t => t.Email_Id)
                .ForeignKey("dbo.Insumo", t => t.Insumo_Id)
                .Index(t => t.Email_Id)
                .Index(t => t.Insumo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlertaDeDisponibilidade", "Insumo_Id", "dbo.Insumo");
            DropForeignKey("dbo.AlertaDeDisponibilidade", "Email_Id", "dbo.Email");
            DropIndex("dbo.AlertaDeDisponibilidade", new[] { "Insumo_Id" });
            DropIndex("dbo.AlertaDeDisponibilidade", new[] { "Email_Id" });
            DropTable("dbo.AlertaDeDisponibilidade");
        }
    }
}
