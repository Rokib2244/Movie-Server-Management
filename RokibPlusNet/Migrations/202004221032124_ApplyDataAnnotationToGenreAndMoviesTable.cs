namespace RokibPlusNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotationToGenreAndMoviesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "GenreName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieName", c => c.String());
            AlterColumn("dbo.Genres", "GenreName", c => c.String());
        }
    }
}
