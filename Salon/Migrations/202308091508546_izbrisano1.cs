namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class izbrisano1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Car_dealership_Car_dealershipId", "dbo.Car_dealership");
            DropIndex("dbo.Cars", new[] { "Car_dealership_Car_dealershipId" });
            DropColumn("dbo.Cars", "Car_dealership_Car_dealershipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Car_dealership_Car_dealershipId", c => c.Int());
            CreateIndex("dbo.Cars", "Car_dealership_Car_dealershipId");
            AddForeignKey("dbo.Cars", "Car_dealership_Car_dealershipId", "dbo.Car_dealership", "Car_dealershipId");
        }
    }
}
