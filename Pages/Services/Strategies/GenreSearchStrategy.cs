using LibrarySystem.Models;
using LibrarySystem.Strategies;


namespace LibrarySystem.Strategies
{
    public class GenreSearchStrategy : ISearchStrategy
    {
        public IQueryable<Book> Search(IQueryable<Book> books, string searchTerm)
        {
            return books.Where(b => b.Genre != null && b.Genre.Name.Contains(searchTerm));
        }
    }
}
