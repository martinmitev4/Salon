namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class izbrisano2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarCar_dealership",
                c => new
                    {
                        Car_CarId = c.Int(nullable: false),
                        Car_dealership_Car_dealershipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Car_CarId, t.Car_dealership_Car_dealershipId })
                .ForeignKey("dbo.Cars", t => t.Car_CarId, cascadeDelete: true)
                .ForeignKey("dbo.Car_dealership", t => t.Car_dealership_Car_dealershipId, cascadeDelete: true)
                .Index(t => t.Car_CarId)
                .Index(t => t.Car_dealership_Car_dealershipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarCar_dealership", "Car_dealership_Car_dealershipId", "dbo.Car_dealership");
            DropForeignKey("dbo.CarCar_dealership", "Car_CarId", "dbo.Cars");
            DropIndex("dbo.CarCar_dealership", new[] { "Car_dealership_Car_dealershipId" });
            DropIndex("dbo.CarCar_dealership", new[] { "Car_CarId" });
            DropTable("dbo.CarCar_dealership");
        }
    }
}
