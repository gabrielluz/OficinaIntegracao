namespace WebInstruments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Complement = c.String(),
                        Number = c.Int(nullable: false),
                        Neighborhood = c.String(),
                        Cep = c.String(),
                        IdState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.IdState, cascadeDelete: true)
                .Index(t => t.IdState);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Acronym = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAddress = c.Int(nullable: false),
                        CNPJ = c.String(nullable: false, maxLength: 14),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.IdAddress, cascadeDelete: true)
                .Index(t => t.IdAddress);
            
            CreateTable(
                "dbo.Instrument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdMeasurementUnit = c.Int(nullable: false),
                        IdSupplier = c.Int(nullable: false),
                        IdInstrumentType = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        MinimumValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegisterDate = c.DateTime(nullable: false),
                        InstrumentType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InstrumentType", t => t.InstrumentType_Id)
                .ForeignKey("dbo.MeasurementUnit", t => t.IdMeasurementUnit, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.IdSupplier, cascadeDelete: true)
                .ForeignKey("dbo.UserS", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.IdMeasurementUnit)
                .Index(t => t.IdSupplier)
                .Index(t => t.InstrumentType_Id);
            
            CreateTable(
                "dbo.InstrumentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeasurementUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Acronym = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRole = c.Int(nullable: false),
                        IdSector = c.Int(nullable: false),
                        IdAddress = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Cpf = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Code = c.String(),
                        HasAccess = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.IdAddress)
                .ForeignKey("dbo.RoleS", t => t.IdRole, cascadeDelete: true)
                .ForeignKey("dbo.Sector", t => t.IdSector, cascadeDelete: true)
                .Index(t => t.IdRole)
                .Index(t => t.IdSector)
                .Index(t => t.IdAddress);
            
            CreateTable(
                "dbo.Loan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        IdInstrument = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        Instrument_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instrument", t => t.Instrument_Id)
                .ForeignKey("dbo.UserS", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.Instrument_Id);
            
            CreateTable(
                "dbo.RoleS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Instrument", "IdUser", "dbo.UserS");
            DropForeignKey("dbo.UserS", "IdSector", "dbo.Sector");
            DropForeignKey("dbo.UserS", "IdRole", "dbo.RoleS");
            DropForeignKey("dbo.Loan", "IdUser", "dbo.UserS");
            DropForeignKey("dbo.Loan", "Instrument_Id", "dbo.Instrument");
            DropForeignKey("dbo.UserS", "IdAddress", "dbo.Address");
            DropForeignKey("dbo.Instrument", "IdSupplier", "dbo.Supplier");
            DropForeignKey("dbo.Instrument", "IdMeasurementUnit", "dbo.MeasurementUnit");
            DropForeignKey("dbo.Instrument", "InstrumentType_Id", "dbo.InstrumentType");
            DropForeignKey("dbo.Supplier", "IdAddress", "dbo.Address");
            DropForeignKey("dbo.Address", "IdState", "dbo.State");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Loan", new[] { "Instrument_Id" });
            DropIndex("dbo.Loan", new[] { "IdUser" });
            DropIndex("dbo.UserS", new[] { "IdAddress" });
            DropIndex("dbo.UserS", new[] { "IdSector" });
            DropIndex("dbo.UserS", new[] { "IdRole" });
            DropIndex("dbo.Instrument", new[] { "InstrumentType_Id" });
            DropIndex("dbo.Instrument", new[] { "IdSupplier" });
            DropIndex("dbo.Instrument", new[] { "IdMeasurementUnit" });
            DropIndex("dbo.Instrument", new[] { "IdUser" });
            DropIndex("dbo.Supplier", new[] { "IdAddress" });
            DropIndex("dbo.Address", new[] { "IdState" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sector");
            DropTable("dbo.RoleS");
            DropTable("dbo.Loan");
            DropTable("dbo.UserS");
            DropTable("dbo.MeasurementUnit");
            DropTable("dbo.InstrumentType");
            DropTable("dbo.Instrument");
            DropTable("dbo.Supplier");
            DropTable("dbo.State");
            DropTable("dbo.Address");
        }
    }
}
