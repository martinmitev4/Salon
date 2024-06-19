namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorite : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favorites", "FavCars_PriceId", "dbo.Prices");
            DropIndex("dbo.Favorites", new[] { "FavCars_PriceId" });
            RenameColumn(table: "dbo.Favorites", name: "FavCars_PriceId", newName: "PriceId");
            AlterColumn("dbo.Favorites", "PriceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Favorites", "PriceId");
            AddForeignKey("dbo.Favorites", "PriceId", "dbo.Prices", "PriceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "PriceId", "dbo.Prices");
            DropIndex("dbo.Favorites", new[] { "PriceId" });
            AlterColumn("dbo.Favorites", "PriceId", c => c.Int());
            RenameColumn(table: "dbo.Favorites", name: "PriceId", newName: "FavCars_PriceId");
            CreateIndex("dbo.Favorites", "FavCars_PriceId");
            AddForeignKey("dbo.Favorites", "FavCars_PriceId", "dbo.Prices", "PriceId");
        }
    }
}
