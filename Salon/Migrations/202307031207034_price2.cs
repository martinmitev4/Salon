namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class price2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prices", "price");
        }
    }
}
