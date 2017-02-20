namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instrument", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instrument", "Code", c => c.String());
        }
    }
}
