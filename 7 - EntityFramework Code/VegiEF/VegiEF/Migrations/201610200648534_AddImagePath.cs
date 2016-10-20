namespace VegiEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GrowableItems", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GrowableItems", "ImagePath");
        }
    }
}
