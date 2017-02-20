namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArrumandoEntidadeCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.State", "City_Id", "dbo.City");
            DropIndex("dbo.State", new[] { "City_Id" });
            DropColumn("dbo.State", "City_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.State", "City_Id", c => c.Int());
            CreateIndex("dbo.State", "City_Id");
            AddForeignKey("dbo.State", "City_Id", "dbo.City", "Id");
        }
    }
}
