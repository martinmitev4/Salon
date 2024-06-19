namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Model_Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Model_Name", c => c.String());
        }
    }
}
