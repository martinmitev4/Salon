namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_in_carmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Fuel_type", c => c.String());
            AddColumn("dbo.Cars", "Gearbox", c => c.String());
            AddColumn("dbo.Cars", "Horse_Power", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Horse_Power");
            DropColumn("dbo.Cars", "Gearbox");
            DropColumn("dbo.Cars", "Fuel_type");
        }
    }
}
