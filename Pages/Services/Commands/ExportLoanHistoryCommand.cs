using LibrarySystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LibrarySystem.Services.Commands
{
    public class ExportLoanHistoryCommand : ICommand
    {
        private readonly LibraryContext _context;
        private readonly string _filePath;

        public ExportLoanHistoryCommand(LibraryContext context, string filePath)
        {
            _context = context;
            _filePath = filePath;
        }

        public void Execute()
        {
            // First pull everything into memory
            var loans = _context.Loans
                .Include(l => l.User)
                .Include(l => l.Book)
                .ToList();

            // Now format the data in memory
            var lines = loans.Select(l =>
                $"User: {(l.User != null ? l.User.FullName : "Unknown")}, " +
                $"Book: {(l.Book != null ? l.Book.Title : "Unknown")}, " +
                $"Borrowed: {l.BorrowDate:yyyy-MM-dd}, " +
                $"Returned: {(l.ReturnDate.HasValue ? l.ReturnDate.Value.ToString("yyyy-MM-dd") : "Not Returned")}"
            );

            File.WriteAllLines(_filePath, lines, Encoding.UTF8);
        }
    }
}
