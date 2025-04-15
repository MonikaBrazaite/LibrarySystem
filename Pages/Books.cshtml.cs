using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;

public class BooksModel : PageModel
{
    private readonly LibraryContext _context;

    public BooksModel(LibraryContext context)
    {
        _context = context;
    }

    public List<Book> Books { get; set; } = new();
    public string? SearchTerm { get; set; }

    public void OnGet(string? search)
    {
        SearchTerm = search;

        var query = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(b =>
                b.Title.Contains(search) ||
                b.Author.Name.Contains(search) ||
                b.Genre.Name.Contains(search));
        }

        Books = query.ToList();
    }
}
