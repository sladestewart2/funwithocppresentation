using System;
using DomainAssemblage.Entities;

namespace AcquiredCompanyLoanProcessor
{
    public class HudLoanTrancheEvaluator
    {
        public Tuple<bool, Tranche> GetTranche(LoanProduct loanProduct)
        {
            //This isn't real
            return new Tuple<bool, Tranche>(true, Tranche.A);
        }
    }
}
