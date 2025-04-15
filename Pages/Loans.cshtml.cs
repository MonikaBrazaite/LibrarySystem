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

        public List<SelectListItem> UserOptions { get; set; } = new();
        public List<SelectListItem> BookOptions { get; set; } = new();

        [BindProperty]
        public int SelectedUserId { get; set; }

        [BindProperty]
        public int SelectedBookId { get; set; }

        public void OnGet()
        {
            Loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToList();

            UserOptions = _context.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.FullName
                })
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
            if (!ModelState.IsValid)
            {
                OnGet(); // Reload options
                return Page();
            }

            var loan = LoanFactory.CreateLoan(SelectedUserId, SelectedBookId);
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return RedirectToPage("/Loans");
        }
    }
}
