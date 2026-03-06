using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetProcessAcceptanceHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSetProcessAcceptance concreteLoanSetProcessAcceptance, LoanSetProcessAcceptance genericLoanSetProcessAcceptance)
        {
					
			concreteLoanSetProcessAcceptance.LoanSetId = genericLoanSetProcessAcceptance.LoanSetId;			
			concreteLoanSetProcessAcceptance.ReceiptDate = genericLoanSetProcessAcceptance.ReceiptDate;			
			concreteLoanSetProcessAcceptance.ReferenceNo = genericLoanSetProcessAcceptance.ReferenceNo;			
			concreteLoanSetProcessAcceptance.DetergentRequired = genericLoanSetProcessAcceptance.DetergentRequired;			
			concreteLoanSetProcessAcceptance.TotalProcessingPrice = genericLoanSetProcessAcceptance.TotalProcessingPrice;			
			concreteLoanSetProcessAcceptance.AdditionalNotes = genericLoanSetProcessAcceptance.AdditionalNotes;			
			concreteLoanSetProcessAcceptance.AuthorisedDate = genericLoanSetProcessAcceptance.AuthorisedDate;			
			concreteLoanSetProcessAcceptance.AuthorisedUserId = genericLoanSetProcessAcceptance.AuthorisedUserId;
		}
	}
}
		