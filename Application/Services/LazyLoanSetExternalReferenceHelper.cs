using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetExternalReferenceHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSetExternalReference concreteLoanSetExternalReference, LoanSetExternalReference genericLoanSetExternalReference)
        {
					
			concreteLoanSetExternalReference.LoanSetExternalReferenceId = genericLoanSetExternalReference.LoanSetExternalReferenceId;			
			concreteLoanSetExternalReference.LoanSetId = genericLoanSetExternalReference.LoanSetId;			
			concreteLoanSetExternalReference.ExternalReference = genericLoanSetExternalReference.ExternalReference;			
			concreteLoanSetExternalReference.ExternalReferenceTypeId = genericLoanSetExternalReference.ExternalReferenceTypeId;			
			concreteLoanSetExternalReference.VendorId = genericLoanSetExternalReference.VendorId;
		}
	}
}
		