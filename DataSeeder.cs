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
                new Author { Name = "George Orwell", Country = "UK", Bio = "Known for dystopian novels." },
                new Author { Name = "Jane Austen", Country = "UK", Bio = "Romantic fiction writer." },
                new Author { Name = "Mark Twain", Country = "USA", Bio = "Humorist and social critic." },
                new Author { Name = "J.K. Rowling", Country = "UK", Bio = "Fantasy author." },
                new Author { Name = "Haruki Murakami", Country = "Japan", Bio = "Surrealist fiction writer." },
                new Author { Name = "Jojo Moyes", Country = "UK", Bio = "Romantic fiction and drama." },
                new Author { Name = "Erin Morgenstern", Country = "USA", Bio = "Fantasy and magical realism." },
                new Author { Name = "Agatha Christie", Country = "UK", Bio = "Queen of mystery." },
                new Author { Name = "J.R.R. Tolkien", Country = "UK", Bio = "Fantasy and mythology." },
                new Author { Name = "Gillian Flynn", Country = "USA", Bio = "Thriller and mystery writer." },
                new Author { Name = "Alex Michaelides", Country = "Cyprus", Bio = "Psychological thriller author." },
                new Author { Name = "Madeline Miller", Country = "USA", Bio = "Mythological fiction." },
                new Author { Name = "Matt Haig", Country = "UK", Bio = "Fiction and mental health advocate." },
                new Author { Name = "Colleen Hoover", Country = "USA", Bio = "Contemporary romance writer." },
                new Author { Name = "Delia Owens", Country = "USA", Bio = "Nature writer and novelist." },
                new Author { Name = "Taylor Jenkins Reid", Country = "USA", Bio = "Women’s fiction author." },
                new Author { Name = "Andy Weir", Country = "USA", Bio = "Science fiction and space." },
                new Author { Name = "Arthur Conan Doyle", Country = "UK", Bio = "Created Sherlock Holmes." },
                new Author { Name = "Suzanne Collins", Country = "USA", Bio = "Author of The Hunger Games." },
                new Author { Name = "Stephen King", Country = "USA", Bio = "Master of horror and suspense." }
            };

            var genres = new List<Genre>
            {
                new Genre { Name = "Fiction", Description = "Narrative literary works." },
                new Genre { Name = "Mystery", Description = "Suspenseful and puzzling plots." },
                new Genre { Name = "Fantasy", Description = "Magical and imaginary worlds." },
                new Genre { Name = "Romance", Description = "Love and relationships." },
                new Genre { Name = "Sci-Fi", Description = "Science and futuristic fiction." }
            };

         var users = new List<User>
{
    new User { FullName = "Alice Johnson", Email = "alice@example.com", MembershipDate = DateTime.Now.AddYears(-2) },
    new User { FullName = "Tom Rivers", Email = "tom@example.com", MembershipDate = DateTime.Now.AddMonths(-10) },
    new User { FullName = "Lina Adams", Email = "lina@example.com", MembershipDate = DateTime.Now.AddMonths(-3) },
    new User { FullName = "Mike D.", Email = "mike@example.com", MembershipDate = DateTime.Now.AddYears(-1) },
    new User { FullName = "Sara Evans", Email = "sara@example.com", MembershipDate = DateTime.Now.AddMonths(-7) },
    new User { FullName = "David Carter", Email = "david@example.com", MembershipDate = DateTime.Now.AddMonths(-5) },
    new User { FullName = "Emma Brooks", Email = "emma@example.com", MembershipDate = DateTime.Now.AddMonths(-9) },
    new User { FullName = "Noah Mitchell", Email = "noah@example.com", MembershipDate = DateTime.Now.AddYears(-3) },
    new User { FullName = "Olivia Thompson", Email = "olivia@example.com", MembershipDate = DateTime.Now.AddMonths(-2) },
    new User { FullName = "James Wright", Email = "james@example.com", MembershipDate = DateTime.Now.AddYears(-1).AddMonths(-6) },
    new User { FullName = "Ava Brown", Email = "ava@example.com", MembershipDate = DateTime.Now.AddMonths(-8) },
    new User { FullName = "Ethan Davis", Email = "ethan@example.com", MembershipDate = DateTime.Now.AddMonths(-4) },
    new User { FullName = "Sophia Miller", Email = "sophia@example.com", MembershipDate = DateTime.Now.AddMonths(-11) },
    new User { FullName = "Liam Wilson", Email = "liam@example.com", MembershipDate = DateTime.Now.AddYears(-2).AddMonths(-1) },
    new User { FullName = "Isabella Moore", Email = "isabella@example.com", MembershipDate = DateTime.Now.AddMonths(-6) },
    new User { FullName = "Benjamin Taylor", Email = "benjamin@example.com", MembershipDate = DateTime.Now.AddYears(-1).AddDays(-30) },
    new User { FullName = "Mia Anderson", Email = "mia@example.com", MembershipDate = DateTime.Now.AddMonths(-12) },
    new User { FullName = "William Harris", Email = "william@example.com", MembershipDate = DateTime.Now.AddYears(-3).AddDays(-15) },
    new User { FullName = "Charlotte Clark", Email = "charlotte@example.com", MembershipDate = DateTime.Now.AddMonths(-1) },
    new User { FullName = "Lucas Lewis", Email = "lucas@example.com", MembershipDate = DateTime.Now.AddYears(-2).AddMonths(-4) }
};


            context.Authors.AddRange(authors);
            context.Genres.AddRange(genres);
            context.Users.AddRange(users);
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book { Title = "1984", ISBN = "ISBN-1001", YearPublished = 1949, AuthorId = authors[0].Id, GenreId = genres[0].Id },
                new Book { Title = "Pride and Prejudice", ISBN = "ISBN-1002", YearPublished = 1813, AuthorId = authors[1].Id, GenreId = genres[3].Id },
                new Book { Title = "Adventures of Huckleberry Finn", ISBN = "ISBN-1003", YearPublished = 1884, AuthorId = authors[2].Id, GenreId = genres[0].Id },
                new Book { Title = "Harry Potter and the Sorcerer's Stone", ISBN = "ISBN-1004", YearPublished = 1997, AuthorId = authors[3].Id, GenreId = genres[2].Id },
                new Book { Title = "Norwegian Wood", ISBN = "ISBN-1005", YearPublished = 1987, AuthorId = authors[4].Id, GenreId = genres[0].Id },
                new Book { Title = "Me Before You", ISBN = "ISBN-1006", YearPublished = 2012, AuthorId = authors[5].Id, GenreId = genres[3].Id },
                new Book { Title = "The Night Circus", ISBN = "ISBN-1007", YearPublished = 2011, AuthorId = authors[6].Id, GenreId = genres[2].Id },
                new Book { Title = "Murder on the Orient Express", ISBN = "ISBN-1008", YearPublished = 1934, AuthorId = authors[7].Id, GenreId = genres[1].Id },
                new Book { Title = "The Hobbit", ISBN = "ISBN-1009", YearPublished = 1937, AuthorId = authors[8].Id, GenreId = genres[2].Id },
                new Book { Title = "Gone Girl", ISBN = "ISBN-1010", YearPublished = 2012, AuthorId = authors[9].Id, GenreId = genres[1].Id },
                new Book { Title = "The Silent Patient", ISBN = "ISBN-1011", YearPublished = 2019, AuthorId = authors[10].Id, GenreId = genres[1].Id },
                new Book { Title = "Circe", ISBN = "ISBN-1012", YearPublished = 2018, AuthorId = authors[11].Id, GenreId = genres[2].Id },
                new Book { Title = "The Midnight Library", ISBN = "ISBN-1013", YearPublished = 2020, AuthorId = authors[12].Id, GenreId = genres[0].Id },
                new Book { Title = "It Ends With Us", ISBN = "ISBN-1014", YearPublished = 2016, AuthorId = authors[13].Id, GenreId = genres[3].Id },
                new Book { Title = "Where the Crawdads Sing", ISBN = "ISBN-1015", YearPublished = 2018, AuthorId = authors[14].Id, GenreId = genres[0].Id },
                new Book { Title = "The Seven Husbands of Evelyn Hugo", ISBN = "ISBN-1016", YearPublished = 2017, AuthorId = authors[15].Id, GenreId = genres[3].Id },
                new Book { Title = "Project Hail Mary", ISBN = "ISBN-1017", YearPublished = 2021, AuthorId = authors[16].Id, GenreId = genres[4].Id },
                new Book { Title = "The Adventures of Sherlock Holmes", ISBN = "ISBN-1018", YearPublished = 1892, AuthorId = authors[17].Id, GenreId = genres[1].Id },
                new Book { Title = "The Hunger Games", ISBN = "ISBN-1019", YearPublished = 2008, AuthorId = authors[18].Id, GenreId = genres[2].Id },
                new Book { Title = "The Shining", ISBN = "ISBN-1020", YearPublished = 1977, AuthorId = authors[19].Id, GenreId = genres[1].Id }
            };

            context.Books.AddRange(books);
            context.SaveChanges();


var loans = new List<Loan>
{
    new Loan { UserId = users[0].Id, BookId = books[0].Id, BorrowDate = DateTime.Now.AddDays(-14), ReturnDate = DateTime.Now.AddDays(-5) },
    new Loan { UserId = users[1].Id, BookId = books[1].Id, BorrowDate = DateTime.Now.AddDays(-10), ReturnDate = DateTime.Now.AddDays(-2) },
    new Loan { UserId = users[2].Id, BookId = books[2].Id, BorrowDate = DateTime.Now.AddDays(-8), ReturnDate = null },
    new Loan { UserId = users[3].Id, BookId = books[3].Id, BorrowDate = DateTime.Now.AddDays(-20), ReturnDate = DateTime.Now.AddDays(-1) },
    new Loan { UserId = users[0].Id, BookId = books[4].Id, BorrowDate = DateTime.Now.AddDays(-12), ReturnDate = null },
    new Loan { UserId = users[1].Id, BookId = books[5].Id, BorrowDate = DateTime.Now.AddDays(-7), ReturnDate = null },
    new Loan { UserId = users[2].Id, BookId = books[6].Id, BorrowDate = DateTime.Now.AddDays(-6), ReturnDate = null },
    new Loan { UserId = users[3].Id, BookId = books[7].Id, BorrowDate = DateTime.Now.AddDays(-3), ReturnDate = null },
    new Loan { UserId = users[0].Id, BookId = books[8].Id, BorrowDate = DateTime.Now.AddDays(-9), ReturnDate = DateTime.Now },
    new Loan { UserId = users[1].Id, BookId = books[9].Id, BorrowDate = DateTime.Now.AddDays(-2), ReturnDate = null },
    new Loan { UserId = users[2].Id, BookId = books[10].Id, BorrowDate = DateTime.Now.AddDays(-13), ReturnDate = DateTime.Now.AddDays(-4) },
    new Loan { UserId = users[3].Id, BookId = books[11].Id, BorrowDate = DateTime.Now.AddDays(-11), ReturnDate = null },
    new Loan { UserId = users[0].Id, BookId = books[12].Id, BorrowDate = DateTime.Now.AddDays(-15), ReturnDate = DateTime.Now.AddDays(-6) },
    new Loan { UserId = users[1].Id, BookId = books[13].Id, BorrowDate = DateTime.Now.AddDays(-4), ReturnDate = null },
    new Loan { UserId = users[2].Id, BookId = books[14].Id, BorrowDate = DateTime.Now.AddDays(-1), ReturnDate = null }
};

context.Loans.AddRange(loans);
context.SaveChanges();



    }
}
}