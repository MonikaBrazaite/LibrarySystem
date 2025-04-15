namespace LibrarySystem.Adapters
{
    public class ExternalBookService
    {
        public string BookTitle { get; set; }
        public string WriterName { get; set; }
        public string GenreName { get; set; }
        public int Year { get; set; }

        // ✅ Add this if it's missing!
        public ExternalBookService() { }

        public ExternalBookService(string title, string writer, string genre, int year)
        {
            BookTitle = title;
            WriterName = writer;
            GenreName = genre;
            Year = year;
        }
    }
}
