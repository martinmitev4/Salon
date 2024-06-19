namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        ManufacturerId = c.Int(nullable: false),
                        Model_Name = c.String(),
                        God = c.String(),
                        Image = c.String(),
                        Power = c.String(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Cars");
        }
    }
}
