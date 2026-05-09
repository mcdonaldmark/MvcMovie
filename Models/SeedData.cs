using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "PG-13",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "PG-13",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "PG",
                    Price = 3.99M
                },
                new Movie
                {
                    Title = "Star Trek: First Contact",
                    ReleaseDate = DateTime.Parse("1996-11-22"),
                    Genre = "Science Fiction",
                    Rating = "PG-13",
                    Price = 13M
                },
                new Movie
                {
                    Title = "Air Force One",
                    ReleaseDate = DateTime.Parse("1997-07-21"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 20M
                },
                new Movie
                {
                    Title = "Star Wars: Rogue One",
                    ReleaseDate = DateTime.Parse("2016-12-16"),
                    Genre = "Science Fiction",
                    Rating = "PG-13",
                    Price = 20M
                }
            );
            context.SaveChanges();
        }
    }
}