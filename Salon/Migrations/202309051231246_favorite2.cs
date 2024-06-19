namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorite2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "FavoriteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prices", "FavoriteId");
        }
    }
}
