namespace MagicCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Card", "Commander_CommanderId", "dbo.Commander");
            DropForeignKey("dbo.Card", "Legacy_LegacyId", "dbo.Legacy");
            DropForeignKey("dbo.Card", "Modern_ModernId", "dbo.Modern");
            DropForeignKey("dbo.Card", "Standard_StandardId", "dbo.Standard");
            DropIndex("dbo.Card", new[] { "Commander_CommanderId" });
            DropIndex("dbo.Card", new[] { "Legacy_LegacyId" });
            DropIndex("dbo.Card", new[] { "Modern_ModernId" });
            DropIndex("dbo.Card", new[] { "Standard_StandardId" });
            RenameColumn(table: "dbo.Card", name: "Commander_CommanderId", newName: "CommanderId");
            RenameColumn(table: "dbo.Card", name: "Legacy_LegacyId", newName: "LegacyId");
            RenameColumn(table: "dbo.Card", name: "Modern_ModernId", newName: "ModernId");
            RenameColumn(table: "dbo.Card", name: "Standard_StandardId", newName: "StandardId");
            AlterColumn("dbo.Card", "CommanderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Card", "LegacyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Card", "ModernId", c => c.Int(nullable: false));
            AlterColumn("dbo.Card", "StandardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Card", "ModernId");
            CreateIndex("dbo.Card", "LegacyId");
            CreateIndex("dbo.Card", "CommanderId");
            CreateIndex("dbo.Card", "StandardId");
            AddForeignKey("dbo.Card", "CommanderId", "dbo.Commander", "CommanderId", cascadeDelete: true);
            AddForeignKey("dbo.Card", "LegacyId", "dbo.Legacy", "LegacyId", cascadeDelete: true);
            AddForeignKey("dbo.Card", "ModernId", "dbo.Modern", "ModernId", cascadeDelete: true);
            AddForeignKey("dbo.Card", "StandardId", "dbo.Standard", "StandardId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Card", "StandardId", "dbo.Standard");
            DropForeignKey("dbo.Card", "ModernId", "dbo.Modern");
            DropForeignKey("dbo.Card", "LegacyId", "dbo.Legacy");
            DropForeignKey("dbo.Card", "CommanderId", "dbo.Commander");
            DropIndex("dbo.Card", new[] { "StandardId" });
            DropIndex("dbo.Card", new[] { "CommanderId" });
            DropIndex("dbo.Card", new[] { "LegacyId" });
            DropIndex("dbo.Card", new[] { "ModernId" });
            AlterColumn("dbo.Card", "StandardId", c => c.Int());
            AlterColumn("dbo.Card", "ModernId", c => c.Int());
            AlterColumn("dbo.Card", "LegacyId", c => c.Int());
            AlterColumn("dbo.Card", "CommanderId", c => c.Int());
            RenameColumn(table: "dbo.Card", name: "StandardId", newName: "Standard_StandardId");
            RenameColumn(table: "dbo.Card", name: "ModernId", newName: "Modern_ModernId");
            RenameColumn(table: "dbo.Card", name: "LegacyId", newName: "Legacy_LegacyId");
            RenameColumn(table: "dbo.Card", name: "CommanderId", newName: "Commander_CommanderId");
            CreateIndex("dbo.Card", "Standard_StandardId");
            CreateIndex("dbo.Card", "Modern_ModernId");
            CreateIndex("dbo.Card", "Legacy_LegacyId");
            CreateIndex("dbo.Card", "Commander_CommanderId");
            AddForeignKey("dbo.Card", "Standard_StandardId", "dbo.Standard", "StandardId");
            AddForeignKey("dbo.Card", "Modern_ModernId", "dbo.Modern", "ModernId");
            AddForeignKey("dbo.Card", "Legacy_LegacyId", "dbo.Legacy", "LegacyId");
            AddForeignKey("dbo.Card", "Commander_CommanderId", "dbo.Commander", "CommanderId");
        }
    }
}
