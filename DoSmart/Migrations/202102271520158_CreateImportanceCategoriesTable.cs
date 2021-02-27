namespace DoSmart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateImportanceCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportanceCategories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Activities", "ImportanceCategoryId", c => c.Byte(nullable: true));
            CreateIndex("dbo.Activities", "ImportanceCategoryId");
            AddForeignKey("dbo.Activities", "ImportanceCategoryId", "dbo.ImportanceCategories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ImportanceCategoryId", "dbo.ImportanceCategories");
            DropIndex("dbo.Activities", new[] { "ImportanceCategoryId" });
            DropColumn("dbo.Activities", "ImportanceCategoryId");
            DropTable("dbo.ImportanceCategories");
        }
    }
}
