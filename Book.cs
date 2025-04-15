using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public string ISBN { get; set; } = "";

        public int YearPublished { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
