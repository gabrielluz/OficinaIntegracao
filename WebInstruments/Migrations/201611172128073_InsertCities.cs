namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Text;

    public partial class InsertCities : DbMigration
    {
        public override void Up()
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\ProjectOI\SqlBoys\WebInstruments\App_Data\cidades.sql");
            Sql(File.ReadAllText(sqlFile, Encoding.GetEncoding("iso-8859-1")));
        }
        
        public override void Down()
        {
        }
    }
}
