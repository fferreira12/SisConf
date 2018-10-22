namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteraAlertaDisponibilidade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlertaDeDisponibilidade", "Insumo_Id", "dbo.Insumo");
            DropIndex("dbo.AlertaDeDisponibilidade", new[] { "Insumo_Id" });
            AddColumn("dbo.Insumo", "Alerta_Id", c => c.Int());
            CreateIndex("dbo.Insumo", "Alerta_Id");
            AddForeignKey("dbo.Insumo", "Alerta_Id", "dbo.AlertaDeDisponibilidade", "Id");
            DropColumn("dbo.AlertaDeDisponibilidade", "Insumo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlertaDeDisponibilidade", "Insumo_Id", c => c.Int());
            DropForeignKey("dbo.Insumo", "Alerta_Id", "dbo.AlertaDeDisponibilidade");
            DropIndex("dbo.Insumo", new[] { "Alerta_Id" });
            DropColumn("dbo.Insumo", "Alerta_Id");
            CreateIndex("dbo.AlertaDeDisponibilidade", "Insumo_Id");
            AddForeignKey("dbo.AlertaDeDisponibilidade", "Insumo_Id", "dbo.Insumo", "Id");
        }
    }
}
