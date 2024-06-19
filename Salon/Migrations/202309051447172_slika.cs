namespace Salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slika : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Favorites", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Favorites", "Image");
        }
    }
}
