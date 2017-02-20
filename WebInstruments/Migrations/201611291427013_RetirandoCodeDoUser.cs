namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetirandoCodeDoUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Code", c => c.String());
        }
    }
}
