using System.Linq;
using LibrarySystem.Models;

namespace LibrarySystem.SearchStrategies
{
    public interface IBookSearchStrategy
    {
        IQueryable<Book> Search(IQueryable<Book> books, string searchTerm);
    }
}
