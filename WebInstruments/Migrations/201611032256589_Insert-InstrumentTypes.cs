using System.IO;

namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertInstrumentTypes : DbMigration
    {
        public override void Up()
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\ProjectOI\SqlBoys\WebInstruments\App_Data\Instrument_types.sql");
            Sql(File.ReadAllText(sqlFile));
        }
        
        public override void Down()
        {
        }
    }
}
