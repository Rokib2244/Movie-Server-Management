namespace RokibPlusNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValueIntoMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(MovieName,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES('Hangover','1/1/2012','1/5/2015',5,2)");
            Sql("INSERT INTO Movies(MovieName,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES('MI 2','3/4/2010','2/6/2014',10,1)");
            Sql("INSERT INTO Movies(MovieName,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES('Crank','1/1/1999','1/5/2003',16,2)");
            Sql("INSERT INTO Movies(MovieName,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES('Lion King','1/12/2019','2/3/2020',5,1)");
            Sql("INSERT INTO Movies(MovieName,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES('Titanic','1/1/2003','1/5/2009',5,4)");
        }
        
        public override void Down()
        {
        }
    }
}
