using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSetStatus concreteLoanSetStatus, LoanSetStatus genericLoanSetStatus)
        {
					
			concreteLoanSetStatus.LoanSetStatusId = genericLoanSetStatus.LoanSetStatusId;			
			concreteLoanSetStatus.Text = genericLoanSetStatus.Text;			
			concreteLoanSetStatus.LegacyFacilityOrigin = genericLoanSetStatus.LegacyFacilityOrigin;			
			concreteLoanSetStatus.LegacyImported = genericLoanSetStatus.LegacyImported;
		}
	}
}
		