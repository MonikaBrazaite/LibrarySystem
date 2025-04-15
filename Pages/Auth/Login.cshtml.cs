using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibrarySystem.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly LibraryContext _context;

        public LoginModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);

            if (user == null || user.Password != Password)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            // Optional: store the name temporarily for display
            HttpContext.Session.SetString("User", user.FullName);

            return RedirectToPage("/Index");
        }
    }
}
