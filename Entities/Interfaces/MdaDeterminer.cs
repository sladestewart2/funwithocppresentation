using System;
using Loan.Entities;

namespace DomainAssemblage.Interfaces
{
    public interface MdaDeterminer
    {
        bool IsInMda(BoundaryPoints boundaryPoints);
    }
}
