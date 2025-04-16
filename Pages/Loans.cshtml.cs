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
        private readonly IWebHostEnvironment _env;

        public LoansModel(LibraryContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public List<Loan>? Loans { get; set; }

        public List<SelectListItem> BookOptions { get; set; } = new();

        [BindProperty]
        public int SelectedBookId { get; set; }

        public void OnGet()
        {
            LoadData();
        }

        private void LoadData()
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
                LoadData();
                return Page();
            }

            var loan = LoanFactory.CreateLoan(user.Id, SelectedBookId);
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return RedirectToPage("/Loans");
        }

        public IActionResult OnPostExport()
        {
            var loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .ToList();

            var csvBuilder = new System.Text.StringBuilder();
            csvBuilder.AppendLine("User,Book,Loan Date,Return Date");

            foreach (var loan in loans)
            {
                csvBuilder.AppendLine($"{loan.User.FullName},{loan.Book.Title},{loan.BorrowDate:yyyy-MM-dd},{loan.ReturnDate?.ToString("yyyy-MM-dd") ?? "Not returned"}");
            }

            var folderPath = Path.Combine(_env.WebRootPath, "exports");
            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, $"loans_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
            System.IO.File.WriteAllText(filePath, csvBuilder.ToString());

            TempData["ExportMessage"] = "Loan history exported!";
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostReturn(int id)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == id);

            if (loan != null && loan.ReturnDate == null)
            {
                loan.ReturnDate = DateTime.Now;
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
