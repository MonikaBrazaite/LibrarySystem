using LibrarySystem.Models;
using LibrarySystem.Strategies;


namespace LibrarySystem.Strategies
{
    public class BookSearcher
    {
        private ISearchStrategy _strategy = new TitleSearchStrategy(); // Default strategy

        public void SetStrategy(ISearchStrategy strategy)
        {
            _strategy = strategy;
        }

        public IQueryable<Book> Search(IQueryable<Book> books, string searchTerm)
        {
            return _strategy.Search(books, searchTerm);
        }
    }
}
