using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ILoanSetRecordService
    /// </summary>
    public interface ILoanSetRecordService
    {
        IList<LoanSetRequiredOnData> ReadLoanSetRequiredOnById(int loanSetId);
        IList<LoanSetContentsData> ReadLoanSetContentsById(int loanSetId);
        LoanSetContentsData ReadLoanSetContentsByContentsId(int loanSetContentsId);

        /// <summary>
        /// To retrieve Loan Set Record by id
        /// </summary>
        /// <returns></returns>
        LoanSetRecordData ReadLoanSetRecordById(int loanSetId);

        /// <summary>
        /// To retrieve Loan Set Contents Data by loanSetId
        /// </summary>
        /// <returns></returns>
        IList<LoanSetContentsData> ReadTraysByLoanSetRecordId(int loanSetId);

        /// <summary>
        /// To retrieve paged and filtered Loan Set Records
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="viewArchivedAndCancelled"></param>
        /// <param name="filter"></param>
        /// <param name="userId"></param>
        /// <param name="userTimeZone"></param>
        IList<LoanSetRecordData> ReadPagedLoanSetRecords(short facilityId, bool? viewArchivedAndCancelled, Synergy.Core.Data.DataFilter filter, int userId, string userTimeZone);

        /// <summary>
        /// Method to get all loan set statuses
        /// </summary>
        /// <returns></returns>
        IList<GenericKeyValueData> ReadAllLoanSetStatus();

        /// <summary>
        /// Updates the Loan set record, required on and also the contents of it
        /// </summary>
        /// <param name="loanSetRecord"> loan set record</param>
        /// <param name="requiredOnList">list of Loan Set RequiredOn Data</param>
        /// <param name="trays"> list of Loan Set Contents Data </param>
        /// <returns></returns>
        OperationResponseContract UpdateLoanSetRecord(LoanSetRecordData loanSetRecord, List<LoanSetRequiredOnData> requiredOnList, List<LoanSetContentsData> trays);

        /// <summary>
        /// To retrieve Loan Set Contents Data by loanSetId
        /// </summary>
        /// <returns></returns>
        IList<LoanSetRequiredOnData> GetAllLoanSetRequiredOn(int loanSetId);
        
        /// <summary>
        /// Get Loan Set Record Audit History by Loan Set Record Id
        /// </summary>
        /// <returns></returns>
        IList<LoanSetAuditHistoryData> GetLoanSetRecordAuditHistoryByLoanSetRecordId(int loanSetId);
        bool DeleteTrayByRecordId(int loanSetContentsId);
        SimplifiedLoanSetContract GetLoanSetForContainerInstance(int? loanSetId, int containerInstanceId);
        int GetActiveTurnaroundCount(int loanSetId);
        bool CanUnarchiveLoanSetRecord(int loanSetId);
        bool IsLoanSetExpired(int containerInstanceId);
        IList<LoanSetContentsData> AreAllLoanSetDespatched(int deliveryNoteId);
        IEnumerable<Comment> GetLoanSetComments(int loanSetId);
        bool CreateLoanSetRecordComment(int loanSetId, int createdBy, string text);
        LoanSetProcessAcceptanceData ReadLoanSetProcessAcceptanceData(int loanSetId);
        OperationResponseContract PrintLoanSetRecord(int reportId, int userId, UserCultureData userCultureData, bool localPrintingEnabled = false);
    }
}
