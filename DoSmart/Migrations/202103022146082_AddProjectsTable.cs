namespace DoSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.String(maxLength: 128),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Done = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            AddColumn("dbo.Activities", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "ProjectId");
            AddForeignKey("dbo.Activities", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropIndex("dbo.Activities", new[] { "ProjectId" });
            DropColumn("dbo.Activities", "ProjectId");
            DropTable("dbo.Projects");
        }
    }
}
