using Microsoft.EntityFrameworkCore;

namespace Inlämning_IRDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<MovieModel> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieModel>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MovieModel>().HasData( //Initial Data to seed the database
                new MovieModel
                {
                    Id = 1,
                    Title = "Spider-Man: Across the Spider-Verse",
                    Director = "Joaquim Dos Santos",
                    Year = 2023,
                    Genre = "Action, Animation, Adventure",
                    Duration = 140,
                    Rating = 8.7,
                    ImageUrl = "images/Spiderverse2.jpg"
                },
                new MovieModel
                {
                    Id = 2,
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Year = 2010,
                    Genre = "Action, Adventure, Sci-Fi",
                    Duration = 148,
                    Rating = 8.8,
                    ImageUrl = "images/Inception.jpg"
                },
                new MovieModel
                {
                    Id = 3,
                    Title = "Shrek",
                    Director = "Andrew Adamson",
                    Year = 2001,
                    Genre = "Animation, Adventure, Comedy",
                    Duration = 90,
                    Rating = 9.9,
                    ImageUrl = "images/Shrek.jpg"
                },
                new MovieModel
                {
                    Id = 4,
                    Title = "Friday",
                    Director = "F. Gary Gray",
                    Year = 1995,
                    Genre = "Comedy, Drama",
                    Duration = 91,
                    Rating = 7.2,
                    ImageUrl = "images/Friday.jpg"
                },
                new MovieModel
                {
                    Id = 5,
                    Title = "Spirited Away",
                    Director = "Hayao Miyazaki",
                    Year = 2001,
                    Genre = "Animation, Adventure, Family",
                    Duration = 122,
                    Rating = 8.6,
                    ImageUrl = "images/SpiritedAway.jpg"
                },
                new MovieModel
                {
                    Id = 6,
                    Title = "The Intouchables",
                    Director = "Oliver Nakache",
                    Year = 2011,
                    Genre = "Biography, Comedy, Drama",
                    Duration = 112,
                    Rating = 8.5,
                    ImageUrl = "images/TheIntouchables.jpg"
                },
                new MovieModel
                {
                    Id = 7,
                    Title = "The Wolf of Wall Street",
                    Director = "Martin Scorsese",
                    Year = 2013,
                    Genre = "Biography, Comedy, Crime",
                    Duration = 180,
                    Rating = 8.2,
                    ImageUrl = "images/TheWolfofWallStreet.jpg"
                },
                new MovieModel
                {
                    Id = 8,
                    Title = "Shutter Island",
                    Director = "Martin Scorsese",
                    Year = 2010,
                    Genre = "Mystery, Thriller",
                    Duration = 132,
                    Rating = 8.2,
                    ImageUrl = "images/ShutterIsland.jpg"
                },
                new MovieModel
                {
                    Id = 9,
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    Year = 2014,
                    Genre = "Adventure, Drama, Sci-Fi",
                    Duration = 169,
                    Rating = 8.7,
                    ImageUrl = "images/Interstellar.jpg"
                },
                new MovieModel
                {
                    Id = 10,
                    Title = "WALL·E",
                    Director = "Andrew Stanton",
                    Year = 2008,
                    Genre = "Animation, Adventure, Family",
                    Duration = 98,
                    Rating = 8.4,
                    ImageUrl = "images/Wall-E.jpg"
                },
                new MovieModel
                {
                    Id = 11,
                    Title = "Charlie and the Chocolate Factory",
                    Director = "Tim Burton",
                    Year = 2005,
                    Genre = "Adventure, Comedy, Family",
                    Duration = 115,
                    Rating = 6.7,
                    ImageUrl = "images/CharlieChocolate.jpg"
                },
                new MovieModel
                {
                    Id = 12,
                    Title = "Spider-Man: Into the Spider-Verse",
                    Director = "Bob Persichetti",
                    Year = 2018,
                    Genre = "Animation, Action, Adventure",
                    Duration = 117,
                    Rating = 8.4,
                    ImageUrl = "images/Spiderverse1.jpg"
                }
            
            );           

            base.OnModelCreating(modelBuilder);
        }
    }
}
