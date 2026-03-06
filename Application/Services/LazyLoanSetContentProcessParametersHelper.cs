using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetContentProcessParametersHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSetContentProcessParameters concreteLoanSetContentProcessParameters, LoanSetContentProcessParameters genericLoanSetContentProcessParameters)
        {
					
			concreteLoanSetContentProcessParameters.LoanSetContentProcessParametersId = genericLoanSetContentProcessParameters.LoanSetContentProcessParametersId;			
			concreteLoanSetContentProcessParameters.LoanSetId = genericLoanSetContentProcessParameters.LoanSetId;			
			concreteLoanSetContentProcessParameters.ProcessParametersId = genericLoanSetContentProcessParameters.ProcessParametersId;			
			concreteLoanSetContentProcessParameters.ParametersValue = genericLoanSetContentProcessParameters.ParametersValue;
		}
	}
}
		