using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Strategies;
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

    public void OnGet(string? search, string? type)
    {
        SearchTerm = search;
        SearchType = type;

        var booksQuery = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(type))
        {
            var searcher = new BookSearcher();

            switch (type.ToLower())
            {
                case "author":
                    searcher.SetStrategy(new AuthorSearchStrategy());
                    break;
                case "genre":
                    searcher.SetStrategy(new GenreSearchStrategy());
                    break;
                default:
                    searcher.SetStrategy(new TitleSearchStrategy());
                    break;
            }

            booksQuery = searcher.Search(booksQuery, search);
        }

        Books = booksQuery.ToList();
    }
}
