namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO States (Name, Acronym) VALUES('Acre', 'AC')" +
                "INSERT INTO States (Name, Acronym) VALUES('Alagoas', 'AL'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Amazonas', 'AM'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Amapá', 'AP'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Bahia', 'BA'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Ceará', 'CE'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Distrito Federal', 'DF'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Espírito Santo', 'ES'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Goiás', 'GO'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Maranhão', 'MA'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Minas Gerais', 'MG'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Mato Grosso do Sul', 'MS'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Mato Grosso', 'MT'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Pará', 'PA'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Paraíba', 'PB'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Pernambuco', 'PE'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Piauí', 'PI'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Paraná', 'PR'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Rio de Janeiro', 'RJ'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Rio Grande do Norte', 'RN'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Rondônia', 'RO'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Roraima', 'RR'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Rio Grande do Sul', 'RS'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Santa Catarina', 'SC'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Sergipe', 'SE'); " +
                "INSERT INTO States (Name, Acronym) VALUES('São Paulo', 'SP'); " +
                "INSERT INTO States (Name, Acronym) VALUES('Tocantins', 'TO');");
        }
        
        public override void Down()
        {
        }
    }
}
