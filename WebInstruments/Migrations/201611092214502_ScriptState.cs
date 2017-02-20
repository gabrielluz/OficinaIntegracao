namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class ScriptState : DbMigration
    {
        public override void Up()
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\ProjectOI\SqlBoys\WebInstruments\App_Data\Estados.sql");
            Sql(File.ReadAllText(sqlFile));
        }
        
        public override void Down()
        {
        }
    }
}
