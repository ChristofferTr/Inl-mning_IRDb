﻿// <auto-generated />
using Inlämning_IRDb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inlämning_IRDb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231021102225_update-database")]
    partial class updatedatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inlämning_IRDb.MovieModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Joaquim Dos Santos",
                            Duration = 140,
                            Genre = "Action, Animation, Adventure",
                            ImageUrl = "Spiderverse.jpg",
                            Rating = 8.6999999999999993,
                            Title = "Spider-Man: Across the Spider-Verse",
                            Year = 2023
                        },
                        new
                        {
                            Id = 2,
                            Director = "Christopher Nolan",
                            Duration = 148,
                            Genre = "Action, Adventure, Sci-Fi",
                            ImageUrl = "Inception.jpg",
                            Rating = 8.8000000000000007,
                            Title = "Inception",
                            Year = 2010
                        },
                        new
                        {
                            Id = 3,
                            Director = "Andrew Adamson",
                            Duration = 90,
                            Genre = "Animation, Adventure, Comedy",
                            ImageUrl = "Shrek.jpg",
                            Rating = 9.9000000000000004,
                            Title = "Shrek",
                            Year = 2001
                        },
                        new
                        {
                            Id = 4,
                            Director = "F. Gary Gray",
                            Duration = 91,
                            Genre = "Comedy, Drama",
                            ImageUrl = "Friday.jpg",
                            Rating = 7.2000000000000002,
                            Title = "Friday",
                            Year = 1995
                        },
                        new
                        {
                            Id = 5,
                            Director = "Hayao Miyazaki",
                            Duration = 122,
                            Genre = "Animation, Adventure, Family",
                            ImageUrl = "SpiritedAway.jpg",
                            Rating = 8.5999999999999996,
                            Title = "Spirited Away",
                            Year = 2001
                        },
                        new
                        {
                            Id = 6,
                            Director = "Oliver Nakache",
                            Duration = 112,
                            Genre = "Biography, Comedy, Drama",
                            ImageUrl = "TheIntouchables.jpg",
                            Rating = 8.5,
                            Title = "The Intouchables",
                            Year = 2011
                        },
                        new
                        {
                            Id = 7,
                            Director = "Martin Scorsese",
                            Duration = 180,
                            Genre = "Biography, Comedy, Crime",
                            ImageUrl = "TheWolfofWallStreet.jpg",
                            Rating = 8.1999999999999993,
                            Title = "The Wolf of Wall Street",
                            Year = 2013
                        },
                        new
                        {
                            Id = 8,
                            Director = "Martin Scorsese",
                            Duration = 132,
                            Genre = "Mystery, Thriller",
                            ImageUrl = "ShutterIsland.jpg",
                            Rating = 8.1999999999999993,
                            Title = "Shutter Island",
                            Year = 2010
                        },
                        new
                        {
                            Id = 9,
                            Director = "Christopher Nolan",
                            Duration = 169,
                            Genre = "Adventure, Drama, Sci-Fi",
                            ImageUrl = "Interstellar.jpg",
                            Rating = 8.6999999999999993,
                            Title = "Interstellar",
                            Year = 2014
                        },
                        new
                        {
                            Id = 10,
                            Director = "Andrew Stanton",
                            Duration = 98,
                            Genre = "Animation, Adventure, Family",
                            ImageUrl = "Wall-E.jpg",
                            Rating = 8.4000000000000004,
                            Title = "WALL·E",
                            Year = 2008
                        },
                        new
                        {
                            Id = 11,
                            Director = "Tim Burton",
                            Duration = 115,
                            Genre = "Adventure, Comedy, Family",
                            ImageUrl = "CharlieChocolate.jpg",
                            Rating = 6.7000000000000002,
                            Title = "Charlie and the Chocolate Factory",
                            Year = 2005
                        },
                        new
                        {
                            Id = 12,
                            Director = "Bob Persichetti",
                            Duration = 117,
                            Genre = "Animation, Action, Adventure",
                            ImageUrl = "Spiderverse1.jpg",
                            Rating = 8.4000000000000004,
                            Title = "Spider-Man: Into the Spider-Verse",
                            Year = 2018
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
