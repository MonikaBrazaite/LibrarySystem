using LibrarySystem.Models;

namespace LibrarySystem.Decorators
{
    public class BasicLoanDisplay : ILoanDisplay
    {
        private readonly Loan _loan;

        public BasicLoanDisplay(Loan loan)
        {
            _loan = loan;
        }

        public string GetDisplayText()
        {
            return $"{_loan.User?.FullName} borrowed '{_loan.Book?.Title}' on {_loan.BorrowDate.ToShortDateString()}";
        }
    }
}
