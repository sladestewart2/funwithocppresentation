using System;
using DomainAssemblage.Entities;
using DomainAssemblage.Interfaces;

namespace Services
{
    //NOTE: This is a demo; the real thing is much more complicated
    public class LoanProductPreparer
    {
        private readonly LoanTrancheEvaluator _loanTrancheEvaluator;

        public LoanProductPreparer(LoanTrancheEvaluator loanTrancheEvaluator)
        {
            if (loanTrancheEvaluator == null) throw new ArgumentException("LoanProductPreparer: loanTrancheEvaluator must be provided.");
            _loanTrancheEvaluator = loanTrancheEvaluator;

        }

        public void PrepareLoanProduct(LoanProduct loanProduct)
        {
            DoABunchOfStuffThatWeAreNotGoingIntoForThisDemo(loanProduct);
            loanProduct.SellingTranche = _loanTrancheEvaluator.EvaluateLoanTranche(loanProduct);
        }

        private void DoABunchOfStuffThatWeAreNotGoingIntoForThisDemo(LoanProduct loanProduct)
        {
            
        }
    }
}
