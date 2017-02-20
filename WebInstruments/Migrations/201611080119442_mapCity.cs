namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IdState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.IdState)
                .Index(t => t.IdState);
            
            AddColumn("dbo.State", "City_Id", c => c.Int());
            CreateIndex("dbo.State", "City_Id");
            AddForeignKey("dbo.State", "City_Id", "dbo.City", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.State", "City_Id", "dbo.City");
            DropForeignKey("dbo.City", "IdState", "dbo.State");
            DropIndex("dbo.City", new[] { "IdState" });
            DropIndex("dbo.State", new[] { "City_Id" });
            DropColumn("dbo.State", "City_Id");
            DropTable("dbo.City");
        }
    }
}
