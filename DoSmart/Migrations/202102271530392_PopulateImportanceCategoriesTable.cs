namespace DoSmart.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateImportanceCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ImportanceCategories (Id, Name) VALUES (1, 'None')");
            Sql("INSERT INTO ImportanceCategories (Id, Name) VALUES (2, 'Low')");
            Sql("INSERT INTO ImportanceCategories (Id, Name) VALUES (3, 'Medium')");
            Sql("INSERT INTO ImportanceCategories (Id, Name) VALUES (4, 'High')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
