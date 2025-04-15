using LibrarySystem.Models;

namespace LibrarySystem.Adapters
{
    public class ExternalBookAdapter
    {
        private readonly ExternalBookService _external;

        // ✅ THIS is the only constructor you need
        public ExternalBookAdapter(ExternalBookService external)
        {
            _external = external;
        }

        public Book ConvertToBook()
        {
            return new Book
            {
                Title = _external.BookTitle,
                Author = new Author { Name = _external.WriterName },
                Genre = new Genre { Name = _external.GenreName },
                YearPublished = _external.Year
            };
        }
    }
}
