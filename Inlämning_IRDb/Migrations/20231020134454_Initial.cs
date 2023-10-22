using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inlämning_IRDb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Duration", "Genre", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Joaquim Dos Santos", 140, "Action, Animation, Adventure", 8.6999999999999993, "Spider-Man: Across the Spider-Verse", 2023 },
                    { 2, "Christopher Nolan", 148, "Action, Adventure, Sci-Fi", 8.8000000000000007, "Inception", 2010 },
                    { 3, "Andrew Adamson", 90, "Animation, Adventure, Comedy", 7.9000000000000004, "Shrek", 2001 },
                    { 4, "F. Gary Gray", 91, "Comedy, Drama", 7.2000000000000002, "Friday", 1995 },
                    { 5, "Hayao Miyazaki", 122, "Animation, Adventure, Family", 8.5999999999999996, "Spirited Away", 2001 },
                    { 6, "Oliver Nakache", 112, "Biography, Comedy, Drama", 8.5, "The Intouchables", 2011 },
                    { 7, "Martin Scorsese", 180, "Biography, Comedy, Crime", 8.1999999999999993, "The Wolf of Wall Street", 2013 },
                    { 8, "Martin Scorsese", 132, "Mystery, Thriller", 8.1999999999999993, "Shutter Island", 2010 },
                    { 9, "Christopher Nolan", 169, "Adventure, Drama, Sci-Fi", 8.6999999999999993, "Interstellar", 2014 },
                    { 10, "Andrew Stanton", 98, "Animation, Adventure, Family", 8.4000000000000004, "WALL·E", 2008 },
                    { 11, "Tim Burton", 115, "Adventure, Comedy, Family", 6.7000000000000002, "Charlie and the Chocolate Factory", 2005 },
                    { 12, "Bob Persichetti", 117, "Animation, Action, Adventure", 8.4000000000000004, "Spider-Man: Into the Spider-Verse", 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
