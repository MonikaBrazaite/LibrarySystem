using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages
{
    public class MyLoansModel : PageModel
    {
        private readonly LibraryContext _context;

        public MyLoansModel(LibraryContext context)
        {
            _context = context;
        }

        public List<LoanDisplay> LoanSummaries { get; set; } = new();

        public IActionResult OnGet()
        {
            var userName = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/Auth/Login");
            }

            var user = _context.Users.FirstOrDefault(u => u.FullName == userName);

            if (user != null)
            {
                var userLoans = _context.Loans
                    .Include(l => l.Book)
                    .Where(l => l.UserId == user.Id)
                    .ToList();

                LoanSummaries = userLoans.Select(loan => new LoanDisplay(loan)).ToList();
            }

            return Page();
        }

        // 🎨 Decorator: Enhances Loan with formatted info
        public class LoanDisplay
        {
            private readonly Loan _loan;

            public LoanDisplay(Loan loan)
            {
                _loan = loan;
            }

            public string BookTitle => _loan.Book?.Title ?? "Unknown";

            public string BorrowDateFormatted => _loan.BorrowDate.ToString("yyyy-MM-dd");

            public string ReturnDateFormatted => _loan.ReturnDate?.ToString("yyyy-MM-dd") ?? "Not returned";

            public string Status => _loan.ReturnDate == null ? "📘 Still borrowed" : "✅ Returned";
        }
    }
}
