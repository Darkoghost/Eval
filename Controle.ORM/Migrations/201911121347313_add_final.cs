namespace Controle.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Administrations", "Admin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Administrations", "Admin");
        }
    }
}
