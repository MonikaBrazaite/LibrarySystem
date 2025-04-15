using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Pages.Auth
{
    public class SignUpModel : PageModel
    {
        private readonly LibraryContext _context;

        public SignUpModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserInputModel NewUser { get; set; } = new();

        public class UserInputModel
        {
            [Required]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(6)]
            public string Password { get; set; }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                FullName = NewUser.FullName,
                Email = NewUser.Email,
                Password = NewUser.Password, // ✅ Store the password
                MembershipDate = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToPage("/Auth/Login"); // Redirect to login page after sign up
        }
    }
}
