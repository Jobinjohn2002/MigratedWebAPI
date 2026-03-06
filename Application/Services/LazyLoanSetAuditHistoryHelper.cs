using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetAuditHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSetAuditHistory concreteLoanSetAuditHistory, LoanSetAuditHistory genericLoanSetAuditHistory)
        {
					
			concreteLoanSetAuditHistory.LoanSetAuditHistoryId = genericLoanSetAuditHistory.LoanSetAuditHistoryId;			
			concreteLoanSetAuditHistory.LoanSetId = genericLoanSetAuditHistory.LoanSetId;			
			concreteLoanSetAuditHistory.LoanSetStatusId = genericLoanSetAuditHistory.LoanSetStatusId;			
			concreteLoanSetAuditHistory.Created = genericLoanSetAuditHistory.Created;			
			concreteLoanSetAuditHistory.CreatedUserId = genericLoanSetAuditHistory.CreatedUserId;
		}
	}
}
		