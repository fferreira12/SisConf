namespace SisConfPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrecoVendaEncomenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encomenda", "PrecoVenda", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encomenda", "PrecoVenda");
        }
    }
}
