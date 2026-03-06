using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ISterilisationService
    /// </summary>
    public interface ISterilisationService
    {
        /// <summary>
        /// To retrieve all Sterilisation Test Report
        /// </summary>
        /// <returns></returns>
        IList<SterilisationTestReportData> ReadAllSterilisationTestReports();

        /// <summary>
        /// To retrieve all Sterilisation Temperature
        /// </summary>
        /// <returns></returns>
        IList<SterilisationTemperatureData> ReadAllSterilisationTemperatures();

         //// <summary>
        /// To retrieve all Sterilisation Temperature By Report Id
        /// </summary>
        /// <returns></returns>
        IList<TestReportTemperatureData> ReadSterilisationTemperaturesByReportId(int sterilisationTestReportId);

        /// <summary>
        /// To retrieve all Sterilisation Batch By Report Id
        /// </summary>
        /// <returns></returns>
        IList<BatchSterilisationTestReportData> ReadBatchSterilisationTestReportsByReportId(int sterilisationTestReportId);

        /// <summary>
        /// To retrieve all Sterilisation Test Report Status
        /// </summary>
        /// <returns></returns>
        IList<SterilisationTestReportStatusData> ReadAllSterilisationTestReportStatus();

        /// <summary>
        /// To retrieve  Sterilisation Test Report by id
        /// </summary>
        /// <returns></returns>
        SterilisationTestReportData GetSterilisationTestReport(int sterilisationTestReportId);

        /// <summary>
        ///  Get Sterilisation Report Audit History by Sterilisation Test Report Id
        /// </summary>
        /// <returns></returns>
        IList<SterilisationTestReportAuditHistoryData> GetSterilisationTestReportAuditHistoryByReportId(int sterilisationTestReportId);

        /// <summary>
        /// Creates the Sterilisation Test Report
        /// </summary>
        /// <returns></returns>
        int CreateSterilisationTestReport(SterilisationTestReportData sterilisationTestReportData, List<BatchSterilisationTestReportData> batches, List<TestReportTemperatureData> temperatures);

        /// <summary>
        /// Updates the Sterilisation Test Report.
        /// </summary>
        /// <returns></returns>
        OperationResponseContract UpdateSterilisationTestReport(SterilisationTestReportData sterilisationTestReportData, List<BatchSterilisationTestReportData> batches, List<TestReportTemperatureData> temperatures);

        /// <summary>
        /// To retrieve View Sterilisation Test Reports
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="machineId"></param>
        /// <param name="reportStatusId"></param>
        /// <param name="filter"></param>
        /// <param name="userId"></param>
        /// <param name="userTimeZone"></param>
        /// <returns></returns>
        IList<SterilisationTestReportData> ReadSterilisationTestReports(short facilityId, int machineId, int reportStatusId, Synergy.Core.Data.DataFilter filter, int userId, string userTimeZone);

        /// <summary>
        /// To retrieve Sterilisation Open Test Reports
        /// </summary>             
        /// <param name="machineId"></param>
        /// <param name="createdDateTime"></param>        
        /// <returns></returns>
        IList<SterilisationTestReportData> ReadSterilisationOpenTestReports(int machineId, DateTime createdDateTime);

        /// <summary>
        /// Print Sterilisation Test Report
        /// </summary>
        /// <returns></returns>
        OperationResponseContract PrintSterilisationTestReport(int sterilisationTestReportId, int userId, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// To retrieve Batchs By Machine
        /// </summary>              
        /// <param name="machineId"></param>
        /// <param name="dateTo"></param>
        /// <param name="filter"></param>
        /// <param name="dateFrom"></param>
        /// <param name="existingBatchs"></param>
        /// <param name="sterilisationTestReportId"></param>
        /// <param name="userId"></param>
        /// <param name="userTimeZone"></param>
        /// <returns></returns>
        IList<BatchData> ReadBatchsByMachine(int machineId, DateTime dateFrom, DateTime dateTo, Synergy.Core.Data.DataFilter filter, string existingBatchs, int sterilisationTestReportId, int userId, string userTimeZone);

         /// <summary>
        /// To retrieve Open Reports By Machine
        /// </summary>              
        /// <param name="machineId"></param>
        /// <param name="dateTo"></param>
        /// <param name="filter"></param>
        /// <param name="dateFrom"></param>
        /// <returns></returns>
        SterilisationTestReportData ReadOpenReportsByMachine(int machineId, DateTime dateFrom, SterilisationTestReportType reportType);

    }
}
