namespace VegiEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GrowableItems", name: "GrowableItemID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GrowableItems", name: "Name", newName: "GrowableItemID");
            RenameColumn(table: "dbo.GrowableItems", name: "__mig_tmp__0", newName: "GrowableItemID1");
            AlterColumn("dbo.GrowableItems", "GrowableItemID", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.GrowableItems", "GrowableItemID", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.GrowableItems", "Description");
            DropColumn("dbo.GrowableItems", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GrowableItems", "ImagePath", c => c.String());
            AddColumn("dbo.GrowableItems", "Description", c => c.String());
            AlterColumn("dbo.GrowableItems", "GrowableItemID", c => c.String());
            AlterColumn("dbo.GrowableItems", "GrowableItemID", c => c.Int(nullable: false, identity: true));
            RenameColumn(table: "dbo.GrowableItems", name: "GrowableItemID1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GrowableItems", name: "GrowableItemID", newName: "Name");
            RenameColumn(table: "dbo.GrowableItems", name: "__mig_tmp__0", newName: "GrowableItemID");
        }
    }
}
