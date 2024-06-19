namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car_dealership",
                c => new
                    {
                        Car_dealershipId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Car_dealershipId);
            
            AddColumn("dbo.Cars", "Car_dealership_Car_dealershipId", c => c.Int());
            CreateIndex("dbo.Cars", "Car_dealership_Car_dealershipId");
            AddForeignKey("dbo.Cars", "Car_dealership_Car_dealershipId", "dbo.Car_dealership", "Car_dealershipId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Car_dealership_Car_dealershipId", "dbo.Car_dealership");
            DropIndex("dbo.Cars", new[] { "Car_dealership_Car_dealershipId" });
            DropColumn("dbo.Cars", "Car_dealership_Car_dealershipId");
            DropTable("dbo.Car_dealership");
        }
    }
}
