namespace Garage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FordonModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fordontyp = c.Int(nullable: false),
                        Färg = c.String(),
                        Regnr = c.String(),
                        Märke = c.String(),
                        Modell = c.String(),
                        Ägare = c.String(),
                        Parkerad = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FordonModels");
        }
    }
}
