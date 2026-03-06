using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetRequiredOnHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSetRequiredOn concreteLoanSetRequiredOn, LoanSetRequiredOn genericLoanSetRequiredOn)
        {
					
			concreteLoanSetRequiredOn.LoanSetRequiredOnId = genericLoanSetRequiredOn.LoanSetRequiredOnId;			
			concreteLoanSetRequiredOn.LoanSetId = genericLoanSetRequiredOn.LoanSetId;			
			concreteLoanSetRequiredOn.DateRequired = genericLoanSetRequiredOn.DateRequired;
		}
	}
}
		