using LibrarySystem.Models;

namespace LibrarySystem.Factory
{
    public class RegularLoanFactory : ILoanFactory
    {
        public Loan CreateLoan(int userId, int bookId)
        {
            return new Loan
            {
                UserId = userId,
                BookId = bookId,
                BorrowDate = DateTime.Now,
                ReturnDate = null
            };
        }
    }
}
