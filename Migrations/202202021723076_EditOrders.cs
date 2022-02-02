namespace FlyBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrders : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerName", c => c.String(nullable: false));
        }
    }
}
