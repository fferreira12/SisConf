namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClienteRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Email", "Cliente_Id", c => c.Int());
            AddColumn("dbo.Endereco", "Cliente_Id", c => c.Int());
            AddColumn("dbo.Telefone", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.Email", "Cliente_Id");
            CreateIndex("dbo.Endereco", "Cliente_Id");
            CreateIndex("dbo.Telefone", "Cliente_Id");
            AddForeignKey("dbo.Email", "Cliente_Id", "dbo.Cliente", "Id");
            AddForeignKey("dbo.Endereco", "Cliente_Id", "dbo.Cliente", "Id");
            AddForeignKey("dbo.Telefone", "Cliente_Id", "dbo.Cliente", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Email", "Cliente_Id", "dbo.Cliente");
            DropIndex("dbo.Telefone", new[] { "Cliente_Id" });
            DropIndex("dbo.Endereco", new[] { "Cliente_Id" });
            DropIndex("dbo.Email", new[] { "Cliente_Id" });
            DropColumn("dbo.Telefone", "Cliente_Id");
            DropColumn("dbo.Endereco", "Cliente_Id");
            DropColumn("dbo.Email", "Cliente_Id");
        }
    }
}
