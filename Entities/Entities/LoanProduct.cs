using System;
using Loan.Entities;

namespace DomainAssemblage.Entities
{
    public enum Tranche
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5
    }

    public class LoanProduct
    {
        public Application Application { get; set; }
        public Loan Loan { get; set; }
        public Tranche SellingTranche { get; set; }
    }
}
