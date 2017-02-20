namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChanginHasAccessToRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "HasAccess", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "HasAccess");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "HasAccess", c => c.Boolean(nullable: false));
            DropColumn("dbo.Role", "HasAccess");
        }
    }
}
