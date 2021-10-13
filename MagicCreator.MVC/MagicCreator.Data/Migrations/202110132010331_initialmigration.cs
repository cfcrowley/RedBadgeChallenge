namespace MagicCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        ManaValue = c.Int(nullable: false),
                        Commander_CommanderId = c.Int(),
                        Legacy_LegacyId = c.Int(),
                        Modern_ModernId = c.Int(),
                        Standard_StandardId = c.Int(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Commander", t => t.Commander_CommanderId)
                .ForeignKey("dbo.Legacy", t => t.Legacy_LegacyId)
                .ForeignKey("dbo.Modern", t => t.Modern_ModernId)
                .ForeignKey("dbo.Standard", t => t.Standard_StandardId)
                .Index(t => t.Commander_CommanderId)
                .Index(t => t.Legacy_LegacyId)
                .Index(t => t.Modern_ModernId)
                .Index(t => t.Standard_StandardId);
            
            CreateTable(
                "dbo.Commander",
                c => new
                    {
                        CommanderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CardCount = c.Int(nullable: false),
                        General = c.String(nullable: false),
                        DeckStyle = c.String(),
                        AvgRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CommanderId);
            
            CreateTable(
                "dbo.Legacy",
                c => new
                    {
                        LegacyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CardCount = c.Int(nullable: false),
                        AvgRating = c.Double(nullable: false),
                        DeckStyle = c.String(),
                    })
                .PrimaryKey(t => t.LegacyId);
            
            CreateTable(
                "dbo.Modern",
                c => new
                    {
                        ModernId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CardCount = c.Int(nullable: false),
                        DeckStyle = c.String(),
                        AvgRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ModernId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Standard",
                c => new
                    {
                        StandardId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CardCount = c.Int(nullable: false),
                        AvgRating = c.Double(nullable: false),
                        DeckStyle = c.String(),
                    })
                .PrimaryKey(t => t.StandardId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Card", "Standard_StandardId", "dbo.Standard");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Card", "Modern_ModernId", "dbo.Modern");
            DropForeignKey("dbo.Card", "Legacy_LegacyId", "dbo.Legacy");
            DropForeignKey("dbo.Card", "Commander_CommanderId", "dbo.Commander");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Card", new[] { "Standard_StandardId" });
            DropIndex("dbo.Card", new[] { "Modern_ModernId" });
            DropIndex("dbo.Card", new[] { "Legacy_LegacyId" });
            DropIndex("dbo.Card", new[] { "Commander_CommanderId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Standard");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Modern");
            DropTable("dbo.Legacy");
            DropTable("dbo.Commander");
            DropTable("dbo.Card");
        }
    }
}
