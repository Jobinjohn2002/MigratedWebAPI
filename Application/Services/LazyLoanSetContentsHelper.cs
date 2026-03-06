using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetContentsHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSetContents concreteLoanSetContents, LoanSetContents genericLoanSetContents)
        {
					
			concreteLoanSetContents.LoanSetContentId = genericLoanSetContents.LoanSetContentId;			
			concreteLoanSetContents.LoanSetId = genericLoanSetContents.LoanSetId;			
			concreteLoanSetContents.Description = genericLoanSetContents.Description;			
			concreteLoanSetContents.Quantity = genericLoanSetContents.Quantity;			
			concreteLoanSetContents.Discrepancy = genericLoanSetContents.Discrepancy;			
			concreteLoanSetContents.InstanceId = genericLoanSetContents.InstanceId;
		}
	}
}
		