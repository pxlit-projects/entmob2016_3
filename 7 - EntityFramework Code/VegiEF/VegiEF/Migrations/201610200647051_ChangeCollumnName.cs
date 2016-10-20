namespace VegiEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCollumnName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GrowableItems", name: "GrowableItemID", newName: "GrowableItemName");
            RenameColumn(table: "dbo.GrowableItems", name: "GrowableItemID1", newName: "GrowableItemID");
            DropPrimaryKey("dbo.GrowableItems");
            AlterColumn("dbo.GrowableItems", "GrowableItemID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GrowableItems", "GrowableItemID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GrowableItems");
            AlterColumn("dbo.GrowableItems", "GrowableItemID", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.GrowableItems", "GrowableItemID1");
            RenameColumn(table: "dbo.GrowableItems", name: "GrowableItemName", newName: "GrowableItemID");
            RenameColumn(table: "dbo.GrowableItems", name: "GrowableItemID", newName: "GrowableItemID1");
        }
    }
}
