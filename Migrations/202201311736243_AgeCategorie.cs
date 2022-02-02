namespace FlyBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeCategorie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AgeCategories");
        }
    }
}
