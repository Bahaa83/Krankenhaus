namespace Krankenhaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afterlives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tillfrisknades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Patients", "Afterlife_ID", c => c.Int());
            AddColumn("dbo.Patients", "Tillfrisknade_ID", c => c.Int());
            CreateIndex("dbo.Patients", "Afterlife_ID");
            CreateIndex("dbo.Patients", "Tillfrisknade_ID");
            AddForeignKey("dbo.Patients", "Afterlife_ID", "dbo.Afterlives", "ID");
            AddForeignKey("dbo.Patients", "Tillfrisknade_ID", "dbo.Tillfrisknades", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Tillfrisknade_ID", "dbo.Tillfrisknades");
            DropForeignKey("dbo.Patients", "Afterlife_ID", "dbo.Afterlives");
            DropIndex("dbo.Patients", new[] { "Tillfrisknade_ID" });
            DropIndex("dbo.Patients", new[] { "Afterlife_ID" });
            DropColumn("dbo.Patients", "Tillfrisknade_ID");
            DropColumn("dbo.Patients", "Afterlife_ID");
            DropTable("dbo.Tillfrisknades");
            DropTable("dbo.Afterlives");
        }
    }
}
