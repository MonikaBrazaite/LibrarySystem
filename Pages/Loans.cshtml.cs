using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Services.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages
{
    public class LoansModel : PageModel
    {
        private readonly LibraryContext _context;

        public LoansModel(LibraryContext context)
        {
            _context = context;
        }

        public List<Loan>? Loans { get; set; }

        public List<SelectListItem> BookOptions { get; set; } = new();

        [BindProperty]
        public int SelectedBookId { get; set; }

        public void OnGet()
        {
            Loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToList();

            BookOptions = _context.Books
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Title
                })
                .ToList();
        }

        public IActionResult OnPost()
        {
            var userName = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/Auth/Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.FullName == userName);

            if (user == null || SelectedBookId == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid user or book selection.");
                OnGet();
                return Page();
            }

            var loan = LoanFactory.CreateLoan(user.Id, SelectedBookId);
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return RedirectToPage("/Loans");
        }
    }
}
