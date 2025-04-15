using LibrarySystem.Data;
using LibrarySystem.Models;
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

        public List<Loan> Loans { get; set; } = new();

        public void OnGet()
        {
            var userName = TempData["User"] as string;

            if (!string.IsNullOrEmpty(userName))
            {
                var user = _context.Users.FirstOrDefault(u => u.FullName == userName);

                if (user != null)
                {
                    Loans = _context.Loans
                        .Include(l => l.Book)
                        .Where(l => l.UserId == user.Id)
                        .ToList();
                }
            }
        }
    }
}
