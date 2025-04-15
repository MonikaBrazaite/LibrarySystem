using LibrarySystem.Models;

namespace LibrarySystem.Factory
{
    public interface ILoanFactory
    {
        Loan CreateLoan(int userId, int bookId);
    }
}
