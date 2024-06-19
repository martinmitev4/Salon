namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class price1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        Car_dealershipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriceId)
                .ForeignKey("dbo.Car_dealership", t => t.Car_dealershipId, cascadeDelete: true)
                .Index(t => t.Car_dealershipId);
            
            AddColumn("dbo.Cars", "Price_PriceId", c => c.Int());
            CreateIndex("dbo.Cars", "Price_PriceId");
            AddForeignKey("dbo.Cars", "Price_PriceId", "dbo.Prices", "PriceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Price_PriceId", "dbo.Prices");
            DropForeignKey("dbo.Prices", "Car_dealershipId", "dbo.Car_dealership");
            DropIndex("dbo.Prices", new[] { "Car_dealershipId" });
            DropIndex("dbo.Cars", new[] { "Price_PriceId" });
            DropColumn("dbo.Cars", "Price_PriceId");
            DropTable("dbo.Prices");
        }
    }
}
