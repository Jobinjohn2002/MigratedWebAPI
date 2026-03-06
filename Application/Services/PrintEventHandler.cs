//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Text;
//using System.ComponentModel.DataAnnotations;
//using System.Diagnostics;
//using Synergy.Core.Data;
//using Synergy.LabelPrinting.Enums;
//using SynergyApplicationFrameworkApi.Application.Factories;
//using SynergyApplicationFrameworkApi.Application.Models;
//using SynergyApplicationFrameworkApi.Core.Interfaces;
//using SynergyApplicationFrameworkApi.Entities;
//using SynergyApplicationFrameworkApi.Framework.DataCommand;
//using SynergyApplicationFrameworkApi.Framework.Repositories;
//using SynergyApplicationFrameworkApi.Framework.UnitOfWork;
//using SynergyApplicationFrameworkApi.LabelPrinting.Entities;
//using SynergyApplicationFrameworkApi.LabelPrinting.Enums;
//using SynergyApplicationFrameworkApi.LabelPrinting.Factories;
//using SynergyApplicationFrameworkApi.LabelPrinting.Models;
//using SynergyApplicationFrameworkApi.LabelPrinting.Utility;
//using ReportTypeIdentifier = Synergy.LabelPrinting.Enums.ReportTypeIdentifier;

//namespace SynergyApplicationFrameworkApi.Application.Services
//{
//    /// <summary>
//    /// print event handler
//    /// </summary>
//    public sealed class PrintEventHandler : EventHandlerBase, IPrintEventHandler
//    {

//        /// <summary>
//        /// Initializes a new instance of the <see cref="PrintEventHandler"/> class.
//        /// </summary>
//        /// <param name="workUnit">The work unit.</param>
//        internal PrintEventHandler(IUnitOfWork workUnit)
//            : base(workUnit)
//        {

//        }

//        /// <summary>
//        /// Creates an instance label that can be printed
//        /// </summary>
//        /// <param name="printer">The printer.</param>
//        /// <param name="instance">The instance.</param>
//        /// <param name="userId"></param>
//        /// <param name="stationId"></param>
//        /// <param name="facilityId"></param>
//        /// <param name="isNewInstanceCreated"></param>
//        /// <summary>
//        /// PrintInstanceLabel operation
//        /// </summary>
//        public IPrintDetails PrintInstanceLabel(IPrinter printer, IContainerInstance instance, int userId, int? stationId, short facilityId, bool isNewInstanceCreated, string culture)
//        {
//            try
//            {
//                var customerDataAdapter = DataAdapterFactory.GetCustomerDataAdapter(OperativeWorkUnit);
//                var deliveryPointDataAdapter = DataAdapterFactory.GetDeliveryPointDataAdapter(OperativeWorkUnit);
//                var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);
//                var containerMasterDefinitionDataAdapter = DataAdapterFactory.GetContainerMasterDefinitionDataAdapter(OperativeWorkUnit);

//                var containerMaster = containerMasterDataAdapter.GetActiveContainerMasterBydefinitionId(instance.ContainerMasterDefinitionId);
//                var deliveryPoint = (DeliveryPoint)deliveryPointDataAdapter.GetDeliveryPoint(instance.DeliveryPointId);
//                var customer = (Customer)customerDataAdapter.GetActiveOneByDefinitionId(deliveryPoint.CustomerDefinitionId);
//                var containerMasterDefinition = containerMasterDefinitionDataAdapter.GetContainerMasterDefinition(instance.ContainerMasterDefinitionId);
//                var deliveryPointText = deliveryPoint?.Text ?? string.Empty;
//                var pleaseReturnText = TranslatorManager.GetText("pathway", "PTouchLabels", "PleaseReturnAfterUse", false, culture);

//                if (deliveryPoint != null && containerMaster != null && deliveryPoint.CustomerDefinitionId != containerMasterDefinition.CustomerDefinitionId)
//                {
//                    customer = (Customer)customerDataAdapter.GetActiveOneByDefinitionId(containerMasterDefinition.CustomerDefinitionId);
//                    deliveryPointText = "*" + deliveryPointText;
//                }

//                InstanceLabelData instanceLabelData;
//                var concCI = (ContainerInstance)instance;

//                PrintTypeIdentifier labelFormat;

//                if (instance.Linear1dBarcodeId != null && instance.Datamatrix2dBarcodeId != null)
//                {
//                    string? instanceLabelId = null;
//                    string? datamatrix2DBarcode = null;

//                    instanceLabelId = concCI.ContainerInstanceIdentifier.FirstOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == instance.Linear1dBarcodeId)?.Value;
//                    datamatrix2DBarcode = concCI.ContainerInstanceIdentifier.FirstOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == instance.Datamatrix2dBarcodeId)?.Value;

//                    instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                             customer.Text,
//                                                             deliveryPointText,
//                                                             instanceLabelId,
//                                                             PrintTypeIdentifier.CombinedBarcodeInstanceLabel,
//                                                             instance.WeighingRequired,
//                                                             datamatrix2DBarcode,
//                                                             pleaseReturnText);

//                    labelFormat = PrintTypeIdentifier.CombinedBarcodeInstanceLabel;
//                }
//                else if (instance.Linear1dBarcodeId != null)
//                {
//                    string? instanceLabelId = null;

//                    instanceLabelId = concCI.ContainerInstanceIdentifier.FirstOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == instance.Linear1dBarcodeId)?.Value;

//                    instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                                customer.Text,
//                                                                deliveryPointText,
//                                                                instanceLabelId,
//                                                                PrintTypeIdentifier.InstanceLabel,
//                                                                instance.WeighingRequired,
//                                                                pleaseReturnText: pleaseReturnText);

//                    labelFormat = PrintTypeIdentifier.InstanceLabel;
//                }
//                else if (instance.Datamatrix2dBarcodeId != null)
//                {
//                    string? datamatrix2DBarcode = null;

//                    datamatrix2DBarcode = concCI.ContainerInstanceIdentifier.FirstOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == instance.Datamatrix2dBarcodeId)?.Value;

//                    instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                                customer.Text,
//                                                                deliveryPointText,
//                                                                datamatrix2DBarcode,
//                                                                PrintTypeIdentifier.TwoDBarcodeInstanceLabel,
//                                                                instance.WeighingRequired,
//                                                                datamatrix2DBarcode,
//                                                                pleaseReturnText);

//                    labelFormat = PrintTypeIdentifier.TwoDBarcodeInstanceLabel;
//                }
//                else
//                {
//                    instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                                customer.Text,
//                                                                deliveryPointText,
//                                                                concCI.PrimaryId,
//                                                                PrintTypeIdentifier.InstanceLabel,
//                                                                instance.WeighingRequired,
//                                                                pleaseReturnText: pleaseReturnText);

//                    labelFormat = PrintTypeIdentifier.InstanceLabel;
//                }
//                var oneDLabelType = instance?.Linear1dBarcodeId;
//                var twoDLabelType = instance?.Datamatrix2dBarcodeId;
//                AuditInstanceLabelPrint(instance.ContainerInstanceId, userId, stationId, facilityId, oneDLabelType, twoDLabelType, labelFormat, !isNewInstanceCreated);

//                return new PrintDetails(printer.Text, 1, true, instanceLabelData.PrintTypeIdentifierValue, instanceLabelData);
//            }
//            catch (PathwayException)
//            {
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog($"PrintEventHandler: PrintInstanceLabel: {ex.Message} - {DateTime.UtcNow}", EventLogEntryType.Error);
//                throw;
//            }
//        }

//        /// <summary>
//        /// SetupInstanceLabelImage operation
//        /// </summary>
//        public IPrintDetails SetupInstanceLabelImage(IContainerInstance instance, string culture, short? linear1DBarcodeTypeId, short? datamatrix2DBarcodeTypeId)
//        {
//            var customerDataAdapter = DataAdapterFactory.GetCustomerDataAdapter(OperativeWorkUnit);
//            var deliveryPointDataAdapter = DataAdapterFactory.GetDeliveryPointDataAdapter(OperativeWorkUnit);
//            var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);

//            var containerMaster = containerMasterDataAdapter.GetActiveContainerMasterBydefinitionId(instance.ContainerMasterDefinitionId);
//            var deliveryPoint = deliveryPointDataAdapter.GetDeliveryPoint(instance.DeliveryPointId);
//            var customer = customerDataAdapter.GetActiveOneByDefinitionId(deliveryPoint.CustomerDefinitionId);

//            var pleaseReturnText = TranslatorManager.GetText("pathway", "PTouchLabels", "PleaseReturnAfterUse", false, culture);

//            InstanceLabelData instanceLabelData;
//            var concCI = (ContainerInstance)instance;

//            if (linear1DBarcodeTypeId != null && datamatrix2DBarcodeTypeId != null)
//            {
//                string? linear1DBarcode = null;
//                string? datamatrix2DBarcode = null;
//                linear1DBarcode = concCI.ContainerInstanceIdentifier.Where(cii => cii.ContainerInstanceIdentifierTypeId == linear1DBarcodeTypeId || cii.IsPrimary).OrderBy(cii => cii.IsPrimary).FirstOrDefault()?.Value;
//                datamatrix2DBarcode = concCI.ContainerInstanceIdentifier.Where(cii => cii.ContainerInstanceIdentifierTypeId == datamatrix2DBarcodeTypeId || cii.IsPrimary).OrderBy(cii => cii.IsPrimary).FirstOrDefault()?.Value;

//                instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                         customer.Text,
//                                                         deliveryPoint.Text,
//                                                         linear1DBarcode,
//                                                         PrintTypeIdentifier.CombinedBarcodeInstanceLabel,
//                                                         instance.WeighingRequired,
//                                                         datamatrix2DBarcode,
//                                                         pleaseReturnText);
//            }
//            else if (linear1DBarcodeTypeId != null)
//            {
//                string? linear1DBarcode = null;
//                linear1DBarcode = concCI.ContainerInstanceIdentifier.Where(cii => cii.ContainerInstanceIdentifierTypeId == linear1DBarcodeTypeId || cii.IsPrimary).OrderBy(cii => cii.IsPrimary).FirstOrDefault()?.Value;

//                instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                            customer.Text,
//                                                            deliveryPoint.Text,
//                                                            linear1DBarcode,
//                                                            PrintTypeIdentifier.InstanceLabel,
//                                                            instance.WeighingRequired,
//                                                            pleaseReturnText: pleaseReturnText);
//            }
//            else if (datamatrix2DBarcodeTypeId != null)
//            {
//                string? datamatrix2DBarcode = null;
//                datamatrix2DBarcode = concCI.ContainerInstanceIdentifier.Where(cii => cii.ContainerInstanceIdentifierTypeId == datamatrix2DBarcodeTypeId || cii.IsPrimary).OrderBy(cii => cii.IsPrimary).FirstOrDefault()?.Value;

//                instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                            customer.Text,
//                                                            deliveryPoint.Text,
//                                                            datamatrix2DBarcode,
//                                                            PrintTypeIdentifier.TwoDBarcodeInstanceLabel,
//                                                            instance.WeighingRequired,
//                                                            datamatrix2DBarcode,
//                                                            pleaseReturnText);
//            }
//            else
//            {
//                instanceLabelData = new InstanceLabelData(containerMaster.Text,
//                                                            customer.Text,
//                                                            deliveryPoint.Text,
//                                                            concCI.PrimaryId,
//                                                            PrintTypeIdentifier.InstanceLabel,
//                                                            instance.WeighingRequired,
//                                                            pleaseReturnText: pleaseReturnText);
//            }

//            return new PrintDetails("Image Printer", 1, true, instanceLabelData.PrintTypeIdentifierValue, instanceLabelData);
//        }

//        /// <summary>
//        /// SetupInstanceLabelImage operation
//        /// </summary>
//        public IPrintDetails SetupInstanceLabelImage(
//            string containerMasterText,
//            string customerText,
//            string deliveryPointText,
//            bool weighingRequired,
//            string culture,
//            string linear1DBarcode,
//            string datamatrix2DBarcode)
//        {
//            InstanceLabelData instanceLabelData;

//            var pleaseReturnText = TranslatorManager.GetText("pathway", "PTouchLabels", "PleaseReturnAfterUse", false, culture);

//            if (!string.IsNullOrEmpty(linear1DBarcode) && !string.IsNullOrEmpty(datamatrix2DBarcode))
//            {
//                instanceLabelData = new InstanceLabelData(containerMasterText,
//                                                         customerText,
//                                                         deliveryPointText,
//                                                         linear1DBarcode,
//                                                         PrintTypeIdentifier.CombinedBarcodeInstanceLabel,
//                                                         weighingRequired,
//                                                         datamatrix2DBarcode,
//                                                         pleaseReturnText);
//            }
//            else if (!string.IsNullOrEmpty(linear1DBarcode))
//            {
//                instanceLabelData = new InstanceLabelData(containerMasterText,
//                                                            customerText,
//                                                            deliveryPointText,
//                                                            linear1DBarcode,
//                                                            PrintTypeIdentifier.InstanceLabel,
//                                                            weighingRequired,
//                                                            pleaseReturnText: pleaseReturnText);
//            }
//            else if (!string.IsNullOrEmpty(datamatrix2DBarcode))
//            {
//                instanceLabelData = new InstanceLabelData(containerMasterText,
//                                                            customerText,
//                                                            deliveryPointText,
//                                                            datamatrix2DBarcode,
//                                                            PrintTypeIdentifier.TwoDBarcodeInstanceLabel,
//                                                            weighingRequired,
//                                                            datamatrix2DBarcode,
//                                                            pleaseReturnText);
//            }
//            else
//            {
//                instanceLabelData = new InstanceLabelData(containerMasterText,
//                                                            customerText,
//                                                            deliveryPointText,
//                                                            "NO BARCODE DATA",
//                                                            PrintTypeIdentifier.InstanceLabel,
//                                                            weighingRequired,
//                                                            pleaseReturnText: pleaseReturnText);
//            }

//            return new PrintDetails("Image Printer", 1, true, instanceLabelData.PrintTypeIdentifierValue, instanceLabelData);
//        }

//        /// <summary>
//        /// print an station label
//        /// </summary>
//        /// <param name="printer">The printer.</param>
//        /// <param name="station">The station.</param>
//        /// <summary>
//        /// PrintStationLabel operation
//        /// </summary>
//        public IPrintDetails PrintStationLabel(IPrinter printer, IStation station, bool localPrintingEnabled = false)
//        {
//            try
//            {
//                var stationLabelData = new StationLabelData(station.Text,
//                                                            station.NTLogon);

//                var printUtility = PrintFactory.Create();
//                var printDetails = new PrintDetails(printer.Text,
//                                                    1,
//                                                    true,
//                                                    PrintTypeIdentifier.StationLabel,
//                                                    stationLabelData);

//                if (localPrintingEnabled)
//                {
//                    printDetails.ReturnPdfData = true;
//                    return printDetails;
//                }

//                printUtility.Print(printDetails);
//                ErrorLog($"PrintEventHandler: Printed to:{printDetails.PrinterName} - {DateTime.UtcNow}", EventLogEntryType.Information);

//                return printDetails;
//            }
//            catch (PathwayException)
//            {
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog($"PrintEventHandler: PrintStationLabel:{ex} - {DateTime.UtcNow}", EventLogEntryType.Error);
//                throw;
//            }
//        }

//        /// <summary>
//        /// print a user tag
//        /// </summary>
//        /// <summary>
//        /// PrintUserTag operation
//        /// </summary>
//        public IPrintDetails PrintUserTag(IPrinter printer, IUser user, bool localPrintingEnabled = false)
//        {
//            try
//            {
//                var userTagData = new UserTagData(user.FirstName, user.Surname, user.ExternalId);

//                var printUtility = PrintFactory.Create();
//                var printDetails = new PrintDetails(printer.Text,
//                                                    1,
//                                                    true,
//                                                    PrintTypeIdentifier.UserTag,
//                                                    userTagData);

//                if (localPrintingEnabled)
//                {
//                    return printDetails;
//                }

//                printUtility.Print(printDetails);

//                ErrorLog($"PrintEventHandler: Printed to:{printDetails.PrinterName} - {DateTime.UtcNow}", EventLogEntryType.Information);
//                return printDetails;
//            }
//            catch (PathwayException)
//            {
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog($"PrintEventHandler: PrintUserTag:{ex} - {DateTime.UtcNow}", EventLogEntryType.Error);

//                throw;
//            }
//        }

//        /// <summary>
//        /// PrintLocation operation
//        /// </summary>
//        public IPrintDetails PrintLocation(IPrinter printer, ILocation location, bool localPrintingEnabled = false)
//        {
//            try
//            {
//                var locationBarcodeData = new LocationBarcodeData(location.Text, location.ExternalId);
//                var printDetails = new PrintDetails(printer.Text, 1, true, PrintTypeIdentifier.Location, locationBarcodeData);

//                ErrorLog($"PrintEventHandler: Printed to:{printDetails.PrinterName} - {DateTime.UtcNow}", EventLogEntryType.Information);
//                return printDetails;
//            }
//            catch (PathwayException)
//            {
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog($"PrintEventHandler: PrintUserTag:{ex} - {DateTime.UtcNow}", EventLogEntryType.Error);

//                throw;
//            }
//        }

//        #region Report prints

//        /// <summary>
//        /// Prints a pick list for the Order.
//        /// </summary>
//        /// <param name="orderNumber">The Order Number of the order to print the pick list for</param>
//        /// <param name="printer">The printer to print on.</param>
//        /// <param name="ownerId">The Id of the owner/facility</param>
//        /// <summary>
//        /// PrintOrderPickListReport operation
//        /// </summary>
//        public IPrintDetails PrintOrderPickListReport(IPrinter printer, string orderNumber, int ownerId, string? systemId = null)
//        {
//            var parameters = new List<ReportParameter>();
//            if (!string.IsNullOrEmpty(systemId))
//            {
//                parameters.Add(new ReportParameter("S", systemId));
//            }

//            parameters.Add(new ReportParameter("OrderNumber", orderNumber));
//            parameters.Add(new ReportParameter("OwnerId", ownerId.ToString()));
//            var orderPickListReport = new ServerReportData(ReportTypeIdentifier.OrderPickList, parameters);

//            var printDetails = new PrintDetails(printer.Text, 1, true, PrintTypeIdentifier.Report, orderPickListReport);

//            return printDetails;
//        }

//        /// <summary>
//        /// PrintLocationLabels operation
//        /// </summary>
//        public List<IPrintDetails> PrintLocationLabels(IPrinter printer, List<LocationBarcodeData> locationLabels, string pdfTitle)
//        {
//            var results = new List<IPrintDetails>();

//            try
//            {
//                var printerName = printer == null
//                    ? string.Empty
//                    : printer.Text;

//                var printDetails = new PrintDetails(printerName,
//                    1,
//                    true,
//                    PrintTypeIdentifier.AveryLocationLabel,
//                    new AveryLocationLabelsData(locationLabels, pdfTitle))
//                { ReturnPdfData = true };

//                results.Add(printDetails);
//            }
//            catch (PathwayException ex)
//            {
//                ErrorLog("PrintLocationLabels: PathwayException: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog("PrintLocationLabels: Exception: " + ex, EventLogEntryType.Error);

//                throw;
//            }

//            return results;
//        }

//        /// <summary>
//        /// PrintLocationLabels operation
//        /// </summary>
//        public List<IPrintDetails> PrintLocationLabels(IPrinter printer, List<LocationBarcodeData> locationLabels)
//        {
//            var results = new List<IPrintDetails>();

//            try
//            {
//                var printerName = printer == null
//                    ? string.Empty
//                    : printer.Text;

//                var printDetails = new PrintDetails(printerName,
//                    1,
//                    true,
//                    PrintTypeIdentifier.AveryLocationLabel,
//                    new AveryLocationLabelsData(locationLabels))
//                { ReturnPdfData = true };

//                results.Add(printDetails);
//            }
//            catch (PathwayException ex)
//            {
//                ErrorLog("PrintLocationLabels: PathwayException: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog("PrintLocationLabels: Exception: " + ex, EventLogEntryType.Error);
//                throw;
//            }

//            return results;
//        }

//        /// <summary>
//        /// print a tray list by turnaround
//        /// </summary>
//        /// <param name="printer">The printer.</param>
//        /// <param name="turnaround">The turnaround.</param>
//        /// <param name="containerInstance">The container instance.</param>
//        /// <param name="reprint">if set to <c>true</c> [reprint].</param>
//        /// <summary>
//        /// PrintTrayListByTurnaround operation
//        /// </summary>
//        public List<IPrintDetails> PrintTrayListByTurnaround(IPrinter printer, ITurnaround turnaround, ContainerInstance containerInstance, bool reprint, bool autoTickFirstCheck, bool isSupervisorNotAvailabe, string? systemId = null)
//        {
//            var results = new List<IPrintDetails>();

//            try
//            {
//                var deliveryPointDataAdapter = DataAdapterFactory.GetDeliveryPointDataAdapter(OperativeWorkUnit);
//                var customer = (Customer)deliveryPointDataAdapter.GetCustomerByDeliveryPoint(turnaround.DeliveryPointId);

//                ErrorLog("PrintTrayListByTurnaround:  step1:" + containerInstance.PrimaryId + " " + turnaround.TurnaroundId + " " + DateTime.UtcNow, EventLogEntryType.Information);

//                var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("TurnaroundUid", turnaround.TurnaroundId.ToString()),
//                    new ReportParameter("ContainerInstanceUid", containerInstance.ContainerInstanceId.ToString()),
//                    new ReportParameter("Reprint", reprint.ToString())
//                };

//                if (!string.IsNullOrEmpty(systemId))
//                {
//                    parameters.Add(new ReportParameter("S", systemId));
//                }

//                GetStationeryVersion_Result stationeryVersion;
//                if (customer != null && customer.PrintTrayListFrontSheet == true)
//                {
//                    stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.TrayListFrontSheet, turnaround.CustomerDefinitionId, turnaround.FacilityId, ((Turnaround)turnaround).Facility.Owner.TenancyId);
//                    for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//                    {
//                        results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.TrayListFrontSheet, parameters, stationeryVersion.ReportPath));
//                    }
//                }
//                var tlparameters = new List<ReportParameter>
//                {
//                    new ReportParameter("TurnaroundUid", turnaround.TurnaroundId.ToString()),
//                    new ReportParameter("ContainerInstanceUid", containerInstance.ContainerInstanceId.ToString()),
//                    new ReportParameter("Reprint", reprint.ToString()),
//                    new ReportParameter("AutoTickFirstCheck", autoTickFirstCheck.ToString()),
//                    new ReportParameter("SupervisorNotAvailable", isSupervisorNotAvailabe.ToString())
//                };

//                if (!string.IsNullOrEmpty(systemId))
//                {
//                    tlparameters.Add(new ReportParameter("S", systemId));
//                }
//                ErrorLog("PrintTrayListByTurnaround:  step2:" + parameters + " " + DateTime.UtcNow, EventLogEntryType.Information);

//                stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.TrayList, turnaround.CustomerDefinitionId, turnaround.FacilityId, ((Turnaround)turnaround).Facility.Owner.TenancyId);

//                for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//                {
//                    results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.TrayList, tlparameters, stationeryVersion.ReportPath));
//                }

//                return results;
//            }
//            catch (PathwayException ex)
//            {
//                ErrorLog("PrintTrayListByTurnaround: PathwayException: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog("PrintTrayListByTurnaround: Exception: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//        }

//        /// <summary>
//        /// GetStationeryVersion operation
//        /// </summary>
//        public GetStationeryVersion_Result GetStationeryVersion(Synergy.LabelPrinting.Enums.ReportTypeIdentifier reportType, int? customerDefinitionId, int? facilityId, int? tenancyId)
//        {
//            using (var repository = new PathwayRepository())
//            {
//                var context = repository.Container;

//                var parameters = new Dictionary<string, object?>
//                {
//                    {"ReportType", reportType.ToString()},
//                    {"CustomerDefinitionId", customerDefinitionId},
//                    {"FacilityId", facilityId},
//                    {"TenancyId", tenancyId}
//                };

//                var dataCommand = DataCommandFactory.CreateCommand(context, System.Data.CommandType.StoredProcedure, "GetStationeryVersion", parameters);

//                var results = dataCommand.GetEntityList<GetStationeryVersion_Result>().FirstOrDefault();

//                if (results?.ReportPath != null)
//                {
//                    if (results.NumberOfCopies == null)
//                    {
//                        results.NumberOfCopies = 1;
//                    }

//                    return results;
//                }

//                var noCustomReportResult = new GetStationeryVersion_Result
//                {
//                    ReportPath = reportType.ToString(),
//                    NumberOfCopies = 1
//                };

//                return noCustomReportResult;
//            }
//        }

//        /// <summary>
//        /// print a tray list by container instance
//        /// </summary>
//        /// <param name="containerMasterId"></param>
//        /// <summary>
//        /// PrintTrayListByDefinitionMaster operation
//        /// </summary>
//        public List<IPrintDetails> PrintTrayListByDefinitionMaster(IPrinter printer, IContainerMaster containerMasterId, string? systemId = null)
//        {
//            try
//            {
//                ErrorLog($"PrintTrayListByDefinitionMaster:  step1:{containerMasterId.ContainerMasterId} {DateTime.UtcNow}", EventLogEntryType.Information);
//                var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("ContainerMasterid", containerMasterId.ContainerMasterId.ToString())
//                };

//                if (!string.IsNullOrEmpty(systemId))
//                {
//                    parameters.Add(new ReportParameter("S", systemId));
//                }

//                ErrorLog("PrintTrayListByDefinitionMaster:  step2:" + parameters + " " + DateTime.UtcNow, EventLogEntryType.Information);

//                var containerMasterDefinitionDataAdapter = DataAdapterFactory.GetContainerMasterDefinitionDataAdapter(OperativeWorkUnit);
//                var containerMasterDefinition = containerMasterDefinitionDataAdapter.GetContainerMasterDefinition(containerMasterId.ContainerMasterDefinitionId);
//                var customerDefinitionDataAdapter = DataAdapterFactory.GetCustomerDefinitionDataAdapter(OperativeWorkUnit);
//                var customerDefinition = customerDefinitionDataAdapter.GetCustomerDefinition(containerMasterDefinition.CustomerDefinitionId);
//                var customerDataAdapter = DataAdapterFactory.GetCustomerDataAdapter(OperativeWorkUnit);
//                var customer = customerDataAdapter.GetActiveOneByDefinitionId(customerDefinition.CustomerDefinitionId);
//                var ownerDataAdapter = DataAdapterFactory.GetOwnerDataAdapter(OperativeWorkUnit);
//                var owner = ownerDataAdapter.GetOwner(customerDefinition.OwnerId);

//                var results = new List<IPrintDetails>();
//                var stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.ComponentList, customerDefinition.CustomerDefinitionId, customer.FacilityId, owner.TenancyId);
//                for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//                {
//                    results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.ComponentList, parameters, stationeryVersion.ReportPath));
//                }

//                return results;
//            }
//            catch (PathwayException ex)
//            {
//                ErrorLog("PrintTrayListByDefinitionMaster: PathwayException: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog("PrintTrayListByDefinitionMaster: Exception: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//        }

//        /// <summary>
//        /// print a tray list by container instance
//        /// </summary>
//        /// <summary>
//        /// PrintTrayListByContainerInstance operation
//        /// </summary>
//        public List<IPrintDetails> PrintTrayListByContainerInstance(IPrinter printer, IContainerInstance containerInstanceId, string? systemId = null)
//        {
//            try
//            {
//                ErrorLog($"PrintTrayListByContainerInstance:  step1:{containerInstanceId.ContainerInstanceId} {DateTime.UtcNow}", EventLogEntryType.Information);
//                var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("ContainerInstanceUid", containerInstanceId.ContainerInstanceId.ToString())
//                };

//                if (!string.IsNullOrEmpty(systemId))
//                {
//                    parameters.Add(new ReportParameter("S", systemId));
//                }

//                ErrorLog($"PrintTrayListByContainerInstance:  step2:{parameters} {DateTime.UtcNow}", EventLogEntryType.Information);

//                var containerInstance = (ContainerInstance)containerInstanceId;
//                var results = new List<IPrintDetails>();

//                var stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.ContainerInstanceTrayList,
//                    containerInstance.DeliveryPoint.CustomerDefinitionId,
//                    containerInstance.FacilityId,
//                    containerInstance.Facility.Owner.TenancyId);

//                for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//                {
//                    results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.ContainerInstanceTrayList, parameters, stationeryVersion.ReportPath));
//                }

//                return results;
//            }
//            catch (PathwayException ex)
//            {
//                ErrorLog("PrintTrayListByContainerInstance: PathwayException: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//            catch (Exception ex)
//            {
//                ErrorLog("PrintTrayListByContainerInstance: Exception: " + ex, EventLogEntryType.Error);
//                throw;
//            }
//        }

//        /// <summary>
//        /// print a trolley list
//        /// </summary>
//        /// <param name="printer">The printer.</param>
//        /// <param name="trolley">The trolley.</param>
//        /// <summary>
//        /// PrintTrolleyList operation
//        /// </summary>
//        public List<IPrintDetails> PrintTrolleyList(IPrinter printer, IContainerInstance trolley, string? systemId = null)
//        {
//            var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("TrolleyId", trolley.ContainerInstanceId.ToString())
//                };

//            if (!string.IsNullOrEmpty(systemId))
//            {
//                parameters.Add(new ReportParameter("S", systemId));
//            }

//            var results = new List<IPrintDetails>();
//            var stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.TrayList, ((Turnaround)trolley).CustomerDefinitionId, trolley.FacilityId, ((Turnaround)trolley).Facility.Owner.TenancyId);

//            for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//            {
//                results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.TrolleyList, parameters, stationeryVersion.ReportPath));
//            }

//            return results;
//        }

//        /// <summary>
//        /// print a pack list
//        /// </summary>
//        /// <param name="printer">The printer.</param>
//        /// <param name="turnaround">The turnaround.</param>
//        /// <summary>
//        /// PrintPackList operation
//        /// </summary>
//        public List<IPrintDetails> PrintPackList(IPrinter printer, ITurnaround turnaround, string? systemId = null)
//        {
//            var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("id", turnaround.TurnaroundId.ToString())
//                };

//            if (!string.IsNullOrEmpty(systemId))
//            {
//                parameters.Add(new ReportParameter("S", systemId));
//            }

//            var results = new List<IPrintDetails>();
//            var stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.PackList, turnaround.CustomerDefinitionId,
//                    turnaround.FacilityId, ((Turnaround)turnaround).Facility.Owner.TenancyId);
//            for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//            {
//                results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.PackList, parameters, stationeryVersion.ReportPath));
//            }

//            return results;
//        }

//        /// <summary>
//        /// print a delivery note
//        /// </summary>
//        /// <summary>
//        /// PrintDeliveryNote operation
//        /// </summary>
//        public List<IPrintDetails> PrintDeliveryNote(IPrinter printer, IDeliveryNote deliveryNote, string? systemId = null)
//        {
//            var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("DeliveryNoteId", deliveryNote.DeliveryNoteId.ToString())
//                };

//            if (!string.IsNullOrEmpty(systemId))
//            {
//                parameters.Add(new ReportParameter("S", systemId));
//            }

//            var fullDeliveryNote = (DeliveryNote)deliveryNote;
//            var results = new List<IPrintDetails>();

//            var stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.DeliveryNote, fullDeliveryNote.DeliveryPoint.CustomerDefinitionId,
//                fullDeliveryNote.FacilityId, fullDeliveryNote.Facility.Owner.TenancyId);

//            for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//            {
//                results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.DeliveryNote, parameters, stationeryVersion.ReportPath));
//            }

//            return results;
//        }

//        /// <summary>
//        /// Prints the details of the turnaround.
//        /// </summary>
//        /// <summary>
//        /// PrintTurnaroundDetails operation
//        /// </summary>
//        public List<IPrintDetails> PrintTurnaroundDetails(ITurnaround turnaround, IPrinter printer, string? systemId = null)
//        {
//            var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("TurnaroundId", turnaround.TurnaroundId.ToString())
//                };

//            if (!string.IsNullOrEmpty(systemId))
//            {
//                parameters.Add(new ReportParameter("S", systemId));
//            }

//            var results = new List<IPrintDetails>();
//            var stationeryVersion = GetStationeryVersion(ReportTypeIdentifier.TurnaroundDetails, turnaround.CustomerDefinitionId,
//                turnaround.FacilityId, ((Turnaround)turnaround).Facility.Owner.TenancyId);
//            for (var i = 0; i < stationeryVersion.NumberOfCopies; i++)
//            {
//                results.Add(ProcessReportPrintJob(printer, ReportTypeIdentifier.TurnaroundDetails, parameters, stationeryVersion.ReportPath));
//            }

//            return results;
//        }

//        /// <summary>
//        /// Prints the decontamination certificate.
//        /// </summary>
//        /// <summary>
//        /// PrintDeContaminationCertificate operation
//        /// </summary>
//        public List<IPrintDetails> PrintDeContaminationCertificate(ITurnaround turnaround, IPrinter printer, string? systemId = null)
//        {
//            var parameters = new List<ReportParameter>
//                {
//                    new ReportParameter("item", turnaround.ContainerInstanceId.ToString())
//                };

//            if (!string.IsNullOrEmpty(systemId))
//            {
//                parameters.Add(new ReportParameter("S", systemId));
//            } 
//        }

//            // TODO