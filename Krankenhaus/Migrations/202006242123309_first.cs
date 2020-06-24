namespace Krankenhaus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Personnnmmer = c.String(),
                        Symptomnivå = c.Int(nullable: false),
                        queue_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Queues", t => t.queue_ID)
                .Index(t => t.queue_ID);
            
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "queue_ID", "dbo.Queues");
            DropIndex("dbo.Patients", new[] { "queue_ID" });
            DropTable("dbo.Queues");
            DropTable("dbo.Patients");
        }
    }
}
