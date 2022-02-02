namespace FlyBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Description", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
