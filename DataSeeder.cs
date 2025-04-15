using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public static class DataSeeder
    {
        public static void SeedDatabase(LibraryContext context)
        {
            if (context.Books.Any()) return; // Already seeded

            var authors = new List<Author>
            {
                new Author { Name = "Jonas Biliūnas", Country = "Lithuania", Bio = "Classic author." },
                new Author { Name = "Žemaitė", Country = "Lithuania", Bio = "Feminist writer." },
                new Author { Name = "Maironis", Country = "Lithuania", Bio = "Poet and priest." },
                // Add more authors up to 10+
            };

            var genres = new List<Genre>
            {
                new Genre { Name = "Drama", Description = "Serious stories" },
                new Genre { Name = "Comedy", Description = "Funny and lighthearted" },
                new Genre { Name = "History", Description = "Historical themes" },
                // Add more genres up to 5+
            };

            var users = new List<User>
            {
                new User { FullName = "Monika Brazaite", Email = "monika@example.com", MembershipDate = DateTime.Now.AddYears(-1) },
                new User { FullName = "Lukas Petrauskas", Email = "lukas@example.com", MembershipDate = DateTime.Now.AddMonths(-6) },
                // Add up to 20+ users
            };

            context.Authors.AddRange(authors);
            context.Genres.AddRange(genres);
            context.Users.AddRange(users);
            context.SaveChanges();

            var books = new List<Book>();
            for (int i = 1; i <= 25; i++)
            {
                books.Add(new Book
                {
                    Title = $"Book {i}",
                    ISBN = $"ISBN-{1000 + i}",
                    YearPublished = 2000 + (i % 20),
                    AuthorId = authors[i % authors.Count].Id,
                    GenreId = genres[i % genres.Count].Id
                });
            }

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
