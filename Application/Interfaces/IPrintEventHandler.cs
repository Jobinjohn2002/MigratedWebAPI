using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IPrintEventHandler
    /// </summary>
    public interface IPrintEventHandler
    {
        List<IPrintDetails> PrintDetailsList { get; set; }

        /// <summary>
        /// print an instance label
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="userId">The user id requesting the activity.</param>
        /// <param name="stationId">The id of the station requesting the activity.</param>
        /// <param name="facilityId">The facility id requesting the activity.</param>
        /// <param name="isNewInstanceCreated"></param>
        IPrintDetails PrintInstanceLabel(IPrinter printer, IContainerInstance instance, int userId, int? stationId, short facilityId, bool isNewInstanceCreated, string culture);

        IPrintDetails SetupInstanceLabelImage(IContainerInstance instance, string culture, short? linear1DBarcodeTypeId, short? datamatrix2DBarcodeTypeId);

        IPrintDetails SetupInstanceLabelImage(
            string containerMasterText,
            string customerText,
            string deliveryPointText,
            bool weighingRequired,
            string culture,
            string linear1DBarcode,
            string datamatrix2DBarcode);

        /// <summary>
        /// print an station label
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="station">The station.</param>
        IPrintDetails PrintStationLabel(IPrinter printer, IStation station, bool localPrintingEnabled = false);

        /// <summary>
        /// print a user tag
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="user">The user.</param>
        IPrintDetails PrintUserTag(IPrinter printer, IUser user, bool localPrintingEnabled = false);

        /// <summary>
        /// Print Location
        /// </summary>
        /// <param name="printer"></param>
        /// <param name="location"></param>
        IPrintDetails PrintLocation(IPrinter printer, ILocation location, bool localPrintingEnabled = false);

        /// <summary>
        /// print a tray list by turnaround
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="turnaround">The turnaround.</param>
        /// <param name="containerInstance">The container instance.</param>
        /// <param name="reprint">if set to <c>true</c> [reprint].</param>
        List<IPrintDetails> PrintTrayListByTurnaround(IPrinter printer, ITurnaround turnaround, ContainerInstance containerInstance, bool reprint, bool autoTickFirstCheck = false, bool isSupervisorNotAvailabe = false, string systemId = null);

        List<IPrintDetails> PrintLocationLabels(IPrinter printer, List<LocationBarcodeData> locationLabels);

        List<IPrintDetails> PrintLocationLabels(IPrinter printer, List<LocationBarcodeData> locationLabels, string pdfTitle);

        /// <summary>
        /// print a tray list by container instance
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="systemId">System Id.</param>
        List<IPrintDetails> PrintTrayListByContainerInstance(IPrinter printer, IContainerInstance instance, string systemId = null);

        /// <summary>
        /// print a tray list by container instance
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="systemId">System Id.</param>
        List<IPrintDetails> PrintTrayListByDefinitionMaster(IPrinter printer, IContainerMaster instance, string systemId = null);

        /// <summary>
        /// print a trolley list
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="trolley">The trolley.</param>
        List<IPrintDetails> PrintTrolleyList(IPrinter printer, IContainerInstance trolley, string systemId = null);

        /// <summary>
        /// print a pack list
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="turnaround">The turnaround.</param>
        List<IPrintDetails> PrintPackList(IPrinter printer, ITurnaround turnaround, string systemId = null);

        /// <summary>
        /// print a deliverynote
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="deliveryNote">The deliverynote.</param>
        List<IPrintDetails> PrintDeliveryNote(IPrinter printer, IDeliveryNote deliveryNote, string systemId = null);

        /// <summary>
        /// Prints the turnaround.
        /// </summary>
        /// <param name="turnaround">The turnaround.</param>
        /// <param name="printer">The printer.</param>
        List<IPrintDetails> PrintTurnaroundDetails(ITurnaround turnaround, IPrinter printer, string systemId = null);

        /// <summary>
        ///  Prints the decontamination certificate.
        /// </summary>
        /// <param name="turnaround">The turnaround.</param>
        /// <param name="printer">The printer.</param>
        List<IPrintDetails> PrintDeContaminationCertificate(ITurnaround turnaround, IPrinter printer, string systemId = null);

        /// <summary>
        ///  Reprints the decontamination certificate.
        /// </summary>
        /// <param name="turnaround">The turnaround.</param>
        /// <param name="printer">The printer.</param>
        List<IPrintDetails> ReprintDecontaminationCertificate(ITurnaround turnaround, IPrinter printer, string systemId = null);
        
        /// <summary>
        ///  Prints the customer service report for the turnaround.
        /// </summary>
        /// <param name="customerDefect">The customerdefect.</param>
        /// <param name="printer">The printer.</param>
        List<IPrintDetails> PrintCustomerServiceReport(ICustomerDefect customerDefect, Guid systemId, IPrinter printer);

        /// <summary>
        ///  Prints the service report for the turnaround.
        /// </summary>
        /// <param name="defect">The defect.</param>
        /// <param name="printer">The printer.</param>
        List<IPrintDetails> PrintServiceReport(IDefect defect, Guid systemId, IPrinter printer);

        /// <summary>
        ///  PrintServiceReportDetails
        /// </summary>
        /// <param name="defect">The defect.</param>
        /// <param name="printer">The printer.</param>
        List<IPrintDetails> PrintServiceReportDetails(IDefect defect, Guid systemId, IPrinter printer);

        /// <summary>
        /// Prints batch Turnaround details
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="systemId"></param>
        /// <param name="printer"></param>
        List<IPrintDetails> PrintBatchTurnaroundsReport(int batchId, int facilityId, Guid systemId, IPrinter printer);

        /// <summary>
        /// Prints Loan Set record id
        /// </summary>
        /// <param name="printer"></param>
        /// <param name="systemId"></param>
        /// <param name="reportId"></param>
        List<IPrintDetails> PrintLoanSetReport(IPrinter printer, Guid systemId, int reportId);

        /// <summary>
        ///  Prints the containernote for the turnaround.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="report"></param>
        List<IPrintDetails> PrintMaintenanceReport(IPrinter printer, Guid systemId, IMaintenanceReport report);

        /// <summary>
        ///  Prints the containernote for the turnaround.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="report"></param>
        List<IPrintDetails> PrintSterlisationReport(IPrinter printer, Guid systemId, ISterilisationTestReport report);

        List<IPrintDetails> PrintTrayListFrontSheetTurnaround(IPrinter printer, ITurnaround turnaround, IContainerInstance containerInstance, bool reprint, string systemId = null);

        /// <summary>
        /// Prints the Instrument Stock Report.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="facilityId"></param>
        /// <param name="isLocation"></param>
        List<IPrintDetails> PrintInstrumentStockReport(IPrinter printer, short facilityId, bool isLocation, Guid systemId, Synergy.Core.Data.DataFilter filter);

        /// <summary>
        /// Prints the Order Pick List.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="orderNumber"></param>
        /// <param name="ownerId"></param>
        IPrintDetails PrintOrderPickListReport(IPrinter printer, string orderNumber, int ownerId, string systemId = null);

        /// <summary>
        ///  PrintServiceReportDetails
        /// </summary>
        /// <param name="defect">The defect.</param>
        /// <param name="printer">The printer.</param>
        List<IPrintDetails> PrintProductionSummary(short facilityId, int? baseItemTypeId, int? lastProcessEventTypeId, Synergy.Core.Data.DataFilter filter, IPrinter printer, Guid systemId, string userTimeZone);

        List<IPrintDetails> PrintSingleUseItems(int customerDefinitionId, Guid systemId, Synergy.Core.Data.DataFilter filter, IPrinter printer);

        List<IPrintDetails> PrintDeliverableItems(int customerDefinitionId, string searchText, Guid systemId, Synergy.Core.Data.DataFilter filter, IPrinter printer);

        List<IPrintDetails> PrintItemInstanceList(short facilityId, int itemMasterDefId, Synergy.Core.Data.DataFilter filter, IPrinter printer, string systemId = null);

        List<IPrintDetails> PrintMaintainenceReports(IPrinter printer, short facilityId, bool? isClose, bool? isCancelled, int? turnaroundId, int? containerInstanceId, Synergy.Core.Data.DataFilter filter, string systemId = null);

        GetStationeryVersion_Result GetStationeryVersion(ReportTypeIdentifier reportType, int? customerDefinitionId, int? facilityId, int? tenancyId);

        IPrintDetails PrintServiceReportImage(IPrinter printer, string imagePath, bool localPrintingEnabled = false, string systemId = null);

    }
}
