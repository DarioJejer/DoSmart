namespace DoSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.String(maxLength: 128),
                        Title = c.String(),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Activities", new[] { "CreatorId" });
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Activities");
        }
    }
}
