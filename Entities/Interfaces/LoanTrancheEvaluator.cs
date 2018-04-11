using System;
using DomainAssemblage.Entities;
using Loan.Entities;

namespace DomainAssemblage.Interfaces
{
    public interface LoanTrancheEvaluator
    {
        Tranche EvaluateLoanTranche(LoanProduct loanProduct);
    }
}
