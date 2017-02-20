namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudandoNomeTabelas : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserS", newName: "User");
            RenameTable(name: "dbo.RoleS", newName: "Role");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Role", newName: "RoleS");
            RenameTable(name: "dbo.User", newName: "UserS");
        }
    }
}
