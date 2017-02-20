namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropandoTabelasAspNet : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE AspNetUserRoles;" +
                "DROP TABLE AspNetUserClaims;" +
                "DROP TABLE AspNetUserLogins;" +
                "DROP TABLE AspNetUsers;" +
                "DROP TABLE AspNetRoles;"
                );
        }
        
        public override void Down()
        {
        }
    }
}
