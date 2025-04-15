using LibrarySystem.Models;
using LibrarySystem.Strategies;


namespace LibrarySystem.Strategies
{
    public class AuthorSearchStrategy : ISearchStrategy
    {
        public IQueryable<Book> Search(IQueryable<Book> books, string searchTerm)
        {
            return books.Where(b => b.Author != null && b.Author.Name.Contains(searchTerm));
        }
    }
}
