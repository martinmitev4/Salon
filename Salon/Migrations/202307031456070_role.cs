namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prices", "CarId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prices", "CarId");
        }
    }
}
