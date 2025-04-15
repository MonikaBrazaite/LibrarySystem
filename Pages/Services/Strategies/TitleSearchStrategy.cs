using LibrarySystem.Models;
using LibrarySystem.Strategies;


namespace LibrarySystem.Strategies
{
    public class TitleSearchStrategy : ISearchStrategy
    {
        public IQueryable<Book> Search(IQueryable<Book> books, string searchTerm)
        {
            return books.Where(b => b.Title.Contains(searchTerm));
        }
    }
}
