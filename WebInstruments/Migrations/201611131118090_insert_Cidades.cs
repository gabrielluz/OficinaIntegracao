namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class insert_Cidades : DbMigration
    {
        public override void Up()
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\Users\Gabriel\Source\Workspaces\ProjectOI\SqlBoys\WebInstruments\App_Data\cidades.sql");
            Sql(File.ReadAllText(sqlFile));
        }
        
        public override void Down()
        {
        }
    }
}
