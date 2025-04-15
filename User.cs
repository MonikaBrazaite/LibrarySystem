using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = "";

        public string Email { get; set; } = "";

        public string? Password { get; set; }


        public DateTime MembershipDate { get; set; }
    }
}
