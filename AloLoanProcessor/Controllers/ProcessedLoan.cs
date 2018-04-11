using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloLoanTrancheEvaluation.LoanTrancheEvaluators;
using DomainAssemblage.Entities;
using DomainAssemblage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AloLoanProcessor.Controllers
{
    [Route("api/[controller]")]
    public class ProcessedLoanController : Controller
    {
        private readonly LoanTrancheEvaluator _loanTrancheEvaluator;

        public ProcessedLoanController(LoanTrancheEvaluator loanTrancheEvaluator)
        {
            if (loanTrancheEvaluator == null) throw new ArgumentException("ProcessedLoanController: loanTrancheEvaluator must be provided.");
            _loanTrancheEvaluator = loanTrancheEvaluator;
        }

        [HttpPost]
        public LoanProduct ProcessLoan(LoanProduct loanProduct)
        {
            new LoanProductPreparer(_loanTrancheEvaluator).PrepareLoanProduct(loanProduct);
            DoOtherProcessingStuffThatDoesNotApplyToDemo(loanProduct);
            return loanProduct;
        }

        private void DoOtherProcessingStuffThatDoesNotApplyToDemo(LoanProduct loanProduct)
        {
            //This isn't real
        }
    }
}
