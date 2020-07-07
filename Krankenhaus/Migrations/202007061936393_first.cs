namespace Krankenhaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Personnnmmer = c.String(),
                        Age = c.Int(nullable: false),
                        Symptomnivå = c.Int(nullable: false),
                        Afterlife_ID = c.Int(),
                        Iva_ID = c.Int(),
                        queue_ID = c.Int(),
                        Sanatorium_ID = c.Int(),
                        Tillfrisknade_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Afterlives", t => t.Afterlife_ID)
                .ForeignKey("dbo.IVAs", t => t.Iva_ID)
                .ForeignKey("dbo.Queues", t => t.queue_ID)
                .ForeignKey("dbo.Sanatoriums", t => t.Sanatorium_ID)
                .ForeignKey("dbo.Tillfrisknades", t => t.Tillfrisknade_ID)
                .Index(t => t.Afterlife_ID)
                .Index(t => t.Iva_ID)
                .Index(t => t.queue_ID)
                .Index(t => t.Sanatorium_ID)
                .Index(t => t.Tillfrisknade_ID);
            
            CreateTable(
                "dbo.IVAs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sanatoriums",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Tillfrisknade_ID", "dbo.Tillfrisknades");
            DropForeignKey("dbo.Patients", "Sanatorium_ID", "dbo.Sanatoriums");
            DropForeignKey("dbo.Patients", "queue_ID", "dbo.Queues");
            DropForeignKey("dbo.Patients", "Iva_ID", "dbo.IVAs");
            DropForeignKey("dbo.Patients", "Afterlife_ID", "dbo.Afterlives");
            DropIndex("dbo.Patients", new[] { "Tillfrisknade_ID" });
            DropIndex("dbo.Patients", new[] { "Sanatorium_ID" });
            DropIndex("dbo.Patients", new[] { "queue_ID" });
            DropIndex("dbo.Patients", new[] { "Iva_ID" });
            DropIndex("dbo.Patients", new[] { "Afterlife_ID" });
            DropTable("dbo.Tillfrisknades");
            DropTable("dbo.Sanatoriums");
            DropTable("dbo.Queues");
            DropTable("dbo.IVAs");
            DropTable("dbo.Patients");
            DropTable("dbo.Afterlives");
        }
    }
}
