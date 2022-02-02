namespace FlyBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AgeCategory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AgeCategory");
        }
    }
}
