using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoanSetHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoanSet concreteLoanSet, ILoanSet genericLoanSet)
        {
					
			concreteLoanSet.LoanSetId = genericLoanSet.LoanSetId;			
			concreteLoanSet.RequestOriginator = genericLoanSet.RequestOriginator;			
			concreteLoanSet.RequestDate = genericLoanSet.RequestDate;			
			concreteLoanSet.ContactTelNo = genericLoanSet.ContactTelNo;					
			concreteLoanSet.LoanSupplier = genericLoanSet.LoanSupplier;			
			concreteLoanSet.Consultant = genericLoanSet.Consultant;			
			concreteLoanSet.LongTermLoan = genericLoanSet.LongTermLoan;			
			concreteLoanSet.LoanSetDesc = genericLoanSet.LoanSetDesc;			
			concreteLoanSet.PreviouslyUsed = genericLoanSet.PreviouslyUsed;				
			concreteLoanSet.PONumber = genericLoanSet.PONumber;					
			concreteLoanSet.DeliveryDate = genericLoanSet.DeliveryDate;			
			concreteLoanSet.ReturnDate = genericLoanSet.ReturnDate;			
			concreteLoanSet.CEMark = genericLoanSet.CEMark;			
			concreteLoanSet.DeconCert = genericLoanSet.DeconCert;			
			concreteLoanSet.Instructions = genericLoanSet.Instructions;			
			concreteLoanSet.Traylist = genericLoanSet.Traylist;			
			concreteLoanSet.Photographs = genericLoanSet.Photographs;			
			concreteLoanSet.Checker = genericLoanSet.Checker;			
			concreteLoanSet.Note = genericLoanSet.Note;			
			concreteLoanSet.LoanStatusId = genericLoanSet.LoanStatusId;			
			concreteLoanSet.FacilityId = genericLoanSet.FacilityId;
		    concreteLoanSet.ManufacturersTrayReference = genericLoanSet.ManufacturersTrayReference;
		    concreteLoanSet.DeliveryPointId = genericLoanSet.DeliveryPointId;
		    concreteLoanSet.CustomerDefinitionId = genericLoanSet.CustomerDefinitionId;
        }
	}
}
		