using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueLoanSetValidationResult
    /// </summary>
    public class CatalogueLoanSetValidationResult
    {
        public CatalogueLoanSetValidationResult(CatalogueLoanSetValidationIdentifier catalogueLoanSetValidationIdentifier)
        {
            switch (catalogueLoanSetValidationIdentifier)
            {
                case CatalogueLoanSetValidationIdentifier.SaveFailed:
                    Message = Constants.General.Errors.SaveFailed;
                    StatusCode = HttpStatusCode.InternalServerError;
                    break;
                case CatalogueLoanSetValidationIdentifier.CustomerMappingSettingNotFound:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.CustomerMappingNotFound;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.ContainerMasterNotFound:
                    Message = Constants.MasterLoaner.Errors.ProductNotFound;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.StartTimeMustPreceedEndTime:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.StartTimeBeforeEndTime;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.DeliveryPointCannotChange:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.DeliveryPointCannotChange;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.NoProceduresOnRequest:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.NoProceduresOnRequest;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.NoDeliveryPointAccess:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.DeliveryPointAccess;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.TenantMappingNotFound:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.TenantMappingNotFound;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.VendorIdNoCustomerFound:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.VendorIdNoCustomerFound;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.CaseStartTimeMustNotBeInThePast:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.CaseStartTimeMustNotBeInThePast;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.CaseStartTimePrecedesALoanerProcessedAndDeliveredToCustomer:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.CaseStartTimePrecedesALoanerProcessedAndDeliveredToCustomer;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.CaseConflictsWithExistingCaseStartTime:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.CaseConflictsWithExistingCaseStartTime;
                    StatusCode = HttpStatusCode.Conflict;
                    break;
                case CatalogueLoanSetValidationIdentifier.DateReceivedDoesNotMeetMinimumRequiredDeliveryAndReProcessingTime:
                    Message = Constants.MasterLoaner.Errors.LoansetErrors.DateReceivedDoesNotMeetMinimumRequiredDeliveryAndReProcessingTime;
                    StatusCode = HttpStatusCode.Conflict;
                    break;

            }
        }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        /// <summary>
        /// Gets or sets ValidationCode
        /// </summary>
        public CatalogueLoanSetValidationIdentifier ValidationCode { get; set; }
    }

    public enum CatalogueLoanSetValidationIdentifier
    {
        Success = 0,
        SaveFailed = 1,
        ContainerMasterNotFound = 2,
        CustomerMappingSettingNotFound = 3,
        StartTimeMustPreceedEndTime = 4,
        DeliveryPointCannotChange = 5,
        LoanSetRecievedDeliveryDateCannotChange = 6,
        NoProceduresOnRequest = 7,
        DeliveryPointCreated = 8,
        NoDeliveryPointAccess = 9,
        TenantMappingNotFound = 10,
        VendorIdNoCustomerFound = 11,
        CaseStartTimeMustNotBeInThePast = 12,
        CaseStartTimePrecedesALoanerProcessedAndDeliveredToCustomer = 13,
        CaseConflictsWithExistingCaseStartTime = 14,
        DateReceivedDoesNotMeetMinimumRequiredDeliveryAndReProcessingTime = 15,
    }
}
