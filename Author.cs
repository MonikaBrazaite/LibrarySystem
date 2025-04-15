using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public string Country { get; set; } = "";

        public string Bio { get; set; } = "";

        public List<Book> Books { get; set; } = new();
    }
}
