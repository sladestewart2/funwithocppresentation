using System;
namespace Loan.Entities
{
    public enum LoanWritingState
    {
        NewYork = 1,
        Louisiana = 2,
        Mississippi = 3,
        Illinois = 4,
        Maine = 5
    }

    public class Application
    {
        public LoanWritingState WritingState { get; set; }
        public Applicant Applicant { get; set; }
        public Property Property { get; set; }
    }
}
