using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Strategies;
using LibrarySystem.Adapters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class BooksModel : PageModel
{
    private readonly LibraryContext _context;

    public BooksModel(LibraryContext context)
    {
        _context = context;
    }

    public List<Book> Books { get; set; } = new();
    public string? SearchTerm { get; set; }
    public string? SearchType { get; set; }
    public string? SortBy { get; set; }

    public void OnGet(string? search, string? type, string? sort)
    {
        SearchTerm = search;
        SearchType = type;
        SortBy = sort;

        var query = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .AsQueryable();

        // 🔍 Searching
        if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(type))
        {
            var searcher = new BookSearcher();

            switch (type.ToLower())
            {
                case "title":
                    searcher.SetStrategy(new TitleSearchStrategy());
                    break;
                case "author":
                    searcher.SetStrategy(new AuthorSearchStrategy());
                    break;
                case "genre":
                    searcher.SetStrategy(new GenreSearchStrategy());
                    break;
            }

            query = searcher.Search(query, search);
        }

        // 🔃 Sorting
        query = sort switch
        {
            "title" => query.OrderBy(b => b.Title),
            "year" => query.OrderByDescending(b => b.YearPublished),
            "author" => query.OrderBy(b => b.Author.Name),
            _ => query
        };

        Books = query.ToList();

        // 📦 External Book Injection (Adapter pattern)
        var externalBooks = new List<ExternalBookService>
        {
            new("The Outsider", "Stephen King", "Thriller", 2018),
            new("Educated", "Tara Westover", "Memoir", 2018),
            new("Becoming", "Michelle Obama", "Biography", 2018),
            new("Atomic Habits", "James Clear", "Self-help", 2018),
            new("Where the Crawdads Sing", "Delia Owens", "Fiction", 2018),
            new("The Silent Patient", "Alex Michaelides", "Thriller", 2019),
            new("The Night Circus", "Erin Morgenstern", "Fantasy", 2011),
            new("It Ends With Us", "Colleen Hoover", "Romance", 2016),
            new("Circe", "Madeline Miller", "Fantasy", 2018),
            new("Daisy Jones & The Six", "Taylor Jenkins Reid", "Fiction", 2019),
            new("The Midnight Library", "Matt Haig", "Fiction", 2020),
            new("Project Hail Mary", "Andy Weir", "Sci-Fi", 2021)
        };

        Books.AddRange(externalBooks.Select(b => new ExternalBookAdapter(b).ConvertToBook()));
    }
}
