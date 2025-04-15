using LibrarySystem.Models;

namespace LibrarySystem.Strategies
{
    public interface ISearchStrategy
    {
        IQueryable<Book> Search(IQueryable<Book> books, string searchTerm);
    }
}
