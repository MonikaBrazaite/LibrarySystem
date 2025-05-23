using LibrarySystem.Models;
using System;

namespace LibrarySystem.Services.Factories
{
    public static class LoanFactory
    {
        public static Loan CreateLoan(int userId, int bookId)
        {
            return new Loan
            {
                UserId = userId,
                BookId = bookId,
                BorrowDate = DateTime.Today,
                ReturnDate = null
            };
        }
    }
}
