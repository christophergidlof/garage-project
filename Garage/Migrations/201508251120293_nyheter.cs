namespace Garage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nyheter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NyhetModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ämne = c.String(nullable: false),
                        Innehåll = c.String(nullable: false),
                        Skapad = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NyhetModels");
        }
    }
}
