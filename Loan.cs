using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
