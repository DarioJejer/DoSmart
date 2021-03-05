namespace DoSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForeignKeysBeingNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Activities", new[] { "CreatorId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            AlterColumn("dbo.Activities", "CreatorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Activities", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "CreatorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            CreateIndex("dbo.Activities", "CreatorId");
            CreateIndex("dbo.Projects", "CreatorId");
            AddForeignKey("dbo.Activities", "CreatorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropIndex("dbo.Activities", new[] { "CreatorId" });
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Projects", "CreatorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Activities", "Title", c => c.String());
            AlterColumn("dbo.Activities", "CreatorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "CreatorId");
            CreateIndex("dbo.Activities", "CreatorId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Activities", "CreatorId", "dbo.AspNetUsers", "Id");
        }
    }
}
