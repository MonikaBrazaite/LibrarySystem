using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void OnGet()
        {
            Loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToList();
        }
    }
}
