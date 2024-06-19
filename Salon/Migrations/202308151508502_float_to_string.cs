namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class float_to_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prices", "price", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prices", "price", c => c.Single(nullable: false));
        }
    }
}
