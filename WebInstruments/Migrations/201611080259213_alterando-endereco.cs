namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterandoendereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "IdCity", c => c.Int(nullable: false));
            CreateIndex("dbo.Address", "IdCity");
            AddForeignKey("dbo.Address", "IdCity", "dbo.City", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "IdCity", "dbo.City");
            DropIndex("dbo.Address", new[] { "IdCity" });
            DropColumn("dbo.Address", "IdCity");
        }
    }
}
