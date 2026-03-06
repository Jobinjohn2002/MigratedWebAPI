using SynergyApplicationFrameworkApi.Application.DTOs.Data;
using SynergyApplicationFrameworkApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PrintTypeIdentifier = Synergy.LabelPrinting.Enums.PrintTypeIdentifier;
using ReportTypeIdentifier = Synergy.LabelPrinting.Enums.ReportTypeIdentifier;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// PrintUtility
    /// </summary>
    public class PrintUtility
    {
        private static string _ghostScriptPath = System.Configuration.ConfigurationManager.AppSettings["GhostScriptPath"];
        private const int EXTERNAL_ID_TYPE_ID = 1;
        private const int ALTERNATE_ID_TYPE_ID = 2;

        public static string GhostScriptPath
        {
            get
            {
                return _ghostScriptPath;
            }
        }

        /// <summary>
        /// Sends the string to printer.
        /// </summary>
        /// <param name="szPrinterName">Name of the sz printer.</param>
        /// <param name="szString">The sz string.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// SendStringToPrinter operation
        /// </summary>
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;

            dwCount = szString.Length;
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);

            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);

            return true;
        }

        /// <summary>
        /// SendBytesToPrinter operation
        /// </summary>
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwWritten = 0;
            var hPrinter = new IntPtr(0);
            var di = new DOCINFOA();
            bool bSuccess = false;

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            if (Externals.OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (Externals.StartDocPrinter(hPrinter, 1, di))
                {
                    if (Externals.StartPagePrinter(hPrinter))
                    {
                        bSuccess = Externals.WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        Externals.EndPagePrinter(hPrinter);
                    }

                    Externals.EndDocPrinter(hPrinter);
                }

                Externals.ClosePrinter(hPrinter);
            }

            return bSuccess;
        }

        /// <summary>
        /// ProcessPrint operation
        /// </summary>
        public static void ProcessPrint(byte[] bytes, string printerName, string reportName)
        {
            string filename = @"C:\Windows\Temp\" + Guid.NewGuid() + ".pdf";

            using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                fs.Dispose();
            }

            Process process = null;

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.Arguments = " -dPrinted -dBATCH -dNOPAUSE -dNOSAFER -q -dNumCopies=1 -sDEVICE=ljet4 -sOutputFile=\"\\\\spool\\" + printerName + "\" \"" + filename + "\" ";
                startInfo.FileName = GhostScriptPath;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;

                process = Process.Start(startInfo);

                if (process != null)
                {
                    process.WaitForExit(30000);
                }
            }
            catch (Exception ex)
            {
                InstanceFactory.GetInstance<ILog>().Exception(ex, $"CreatePDFReport-Error GhostScript Name: {reportName}");
            }
            finally
            {
                if (process != null && !process.HasExited)
                {
                    process.Kill();
                }
            }

            File.Delete(filename);
        }

        /// <summary>
        /// PrintPDFReport operation
        /// </summary>
        public static void PrintPDFReport(PDFReport pdfReport, string printerName)
        {
            for (int i = 0; i < pdfReport.NumberOfCopies; i++)
            {
                ProcessPrint(pdfReport.ReportData, printerName, pdfReport.ReportName);
            }
        }

        /// <summary>
        /// PrintLocalPDFReport operation
        /// </summary>
        public static void PrintLocalPDFReport(PDFReport pdfReport, ScanAssetDataContract scanDC = null)
        {
            if (scanDC != null)
            {
                if (scanDC.Reports == null)
                {
                    scanDC.Reports = new List<ReportDataContract>();
                }

                scanDC.Reports.Add(new ReportDataContract { Data = pdfReport.ReportData, TurnaroundId = scanDC.TurnaroundId.Value, NumberOfCopies = pdfReport.NumberOfCopies });
            }
        }

        /// <summary>
        /// CreatePDFReport operation
        /// </summary>
        public static PDFReport CreatePDFReport(string reportName, Tuple<string, string>[] parameters)
        {
            try
            {
                InstanceFactory.GetInstance<ILog>().Info(string.Format("CreatePDFReport Name: {0}", reportName));
                var report = new Microsoft.Reporting.WebForms.ServerReport();

                var reportParameters = new List<Microsoft.Reporting.WebForms.ReportParameter>();

                foreach (Tuple<string, string> param in parameters)
                {
                    reportParameters.Add(new Microsoft.Reporting.WebForms.ReportParameter(param.Item1, param.Item2));
                }

                report.ReportServerUrl = new Uri(SystemSettings.ReportApplicationBaseUrl, UriKind.Absolute);
                report.ReportPath = SystemSettings.SystemReportPath + reportName;
                report.ReportServerCredentials = new ReportServerCredentials(SystemSettings.ReportServiceLogonUser, SystemSettings.ReportServerPassword, SystemSettings.ReportServiceLogonDomain);
                report.SetParameters(reportParameters);
                report.Refresh();

                Microsoft.Reporting.WebForms.Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                var bytes = report.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                return new PDFReport
                {
                    ReportData = bytes,
                    ReportName = reportName,
                    NumberOfCopies = 1
                };
            }
            catch (Exception ex)
            {
                InstanceFactory.GetInstance<ILog>().Exception(ex, $"CreatePDFReport-Error Name: {reportName}.");

                return new PDFReport
                {
                    ReportData = new byte[0],
                    ReportName = string.Empty,
                    NumberOfCopies = 1
                };
            }
        }

        /// <summary>
        /// CreatePDFReport operation
        /// </summary>
        public static PDFReport CreatePDFReport(int tenancyId, int facilityId, int customerDefinitionId, ReportTypeIdentifier reportTypeIdentifier, Tuple<string, string>[] parameters)
        {
            var stationary = GetStationeryVersion(reportTypeIdentifier, customerDefinitionId, facilityId, tenancyId);
            var result = CreatePDFReport(stationary.ReportPath, parameters);
            result.NumberOfCopies = stationary.NumberOfCopies ?? result.NumberOfCopies;
            return result;
        }

        /// <summary>
        /// GetStationeryVersion operation
        /// </summary>
        public static GetStationeryVersion_Result GetStationeryVersion(ReportTypeIdentifier reportType, int? customerDefinitionId, int? facilityId, int? tenancyId)
        {
            using (var repository = new PathwayRepository())
            {
                var context = repository.Container;

                var parameters = new Dictionary<string, object>
                {
                    {"ReportType", reportType.ToString()},
                    {"CustomerDefinitionId", customerDefinitionId},
                    {"FacilityId", facilityId},
                    {"TenancyId", tenancyId}
                };

                var dataCommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, "GetStationeryVersion", parameters);

                var results = dataCommand.GetEntityList<GetStationeryVersion_Result>().FirstOrDefault();

                if (results.ReportPath != null)
                {
                    if (results.NumberOfCopies == null)
                    {
                        results.NumberOfCopies = 1;
                    }

                    return results;
                }

                var noCustomReportResult = new GetStationeryVersion_Result
                {
                    ReportPath = reportType.ToString(),
                    NumberOfCopies = 1
                };

                return noCustomReportResult;
            }
        }

        /// <summary>
        /// IsLaserPrinterAvailable operation
        /// </summary>
        public static bool IsLaserPrinterAvailable(string laserPrinter, bool isNetworkPrinting)
        {
            if (isNetworkPrinting)
            {
                if (!string.IsNullOrEmpty(laserPrinter))
                {
                    try
                    {
                        var printerServerUri = new Uri(laserPrinter);

                        var hostName = string.Format("\\\\{0}", printerServerUri.Host);

                        var ps = new PrintServer(hostName);

                        if (ps != null)
                        {
                            var tsPrintQueues = ps.GetPrintQueues();

                            foreach (var pdc in tsPrintQueues)
                            {
                                if (string.Compare(pdc.FullName, laserPrinter, true) == 0)
                                {
                                    if (!string.IsNullOrEmpty(printerServerUri.AbsolutePath))
                                    {
                                        return true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// PrintTraylist operation
        /// </summary>
        public static void PrintTraylist(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool reprint = false, bool autoTickFirstCheck = false, bool supervisorNotAvailable = false)
        {
            if ((scanDC != null) && (scanDC.Asset != null) && (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BatchTag))
            {
                scanDC.Reports = new List<ReportDataContract>();

                if (IsLaserPrinterAvailable(scanDetails.LaserPrinter, scanDetails.IsNetworkPrinting))
                {
                    using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                    {
                        var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                        var deliveryPointCustomer = deliveryPointRepository.GetCustomerByDeliveryPoint(scanDC.DeliveryPtId);

                        var tenancyId = deliveryPointCustomer.Facility.Owner.TenancyId;
                        var facilityId = deliveryPointCustomer.FacilityId;
                        var customerDefinitionId = deliveryPointCustomer.CustomerDefinitionId;

                        var userRepository = UserRepository.New(workUnit);
                        var user = userRepository.Get(scanDC.UserId);

                        if (deliveryPointCustomer != null && deliveryPointCustomer.PrintTrayListFrontSheet == true)
                        {
                            var list = new List<Tuple<string, string>>
                            {
                                new Tuple<string, string>("S", user.SystemId.ToString()),
                                new Tuple<string, string>("TurnaroundUid", scanDC.TurnaroundId.Value.ToString()),
                                new Tuple<string, string>("ContainerInstanceUid", scanDC.Asset.ContainerInstanceId.ToString()),
                                new Tuple<string, string>("Reprint", reprint.ToString())
                            };

                            var result = CreatePDFReport(tenancyId, facilityId, customerDefinitionId, ReportTypeIdentifier.TrayListFrontSheet, list.ToArray());
                            if (scanDetails.IsNetworkPrinting)
                            {
                                PrintPDFReport(result, scanDetails.LaserPrinter);
                            }
                            else
                            {
                                PrintLocalPDFReport(result, scanDC);
                            }
                            if (!reprint)
                            {
                                var printHistoryHelper = new PrintHistoryHelper();
                                var printHistory = printHistoryHelper.CreatePrintHistory(user.UserId, PrintContentTypeIdentifier.TrayListFrontSheet, scanDC.TurnaroundId, null, scanDC.BatchId, null);
                                if (printHistory != null)
                                {
                                    printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, PrintHistoryPrinterType.LaserPrinter, new PDFContent { Bytes = result.ReportData });
                                }
                            }

                            InstanceFactory.GetInstance<ILog>().Info($"TrayPrioritisation - Create front sheet Report count = {scanDC.Reports.Count}. T={scanDC.TurnaroundId.Value}, CI={scanDC.Asset.ContainerInstanceId}");
                        }

                        var list2 = new List<Tuple<string, string>>
                        {
                            new Tuple<string, string>("S", user.SystemId.ToString()),
                            new Tuple<string, string>("TurnaroundUid", scanDC.TurnaroundId.Value.ToString()),
                            new Tuple<string, string>("ContainerInstanceUid",
                                scanDC.Asset.ContainerInstanceId.ToString()),
                            new Tuple<string, string>("Reprint", reprint.ToString()),
                            new Tuple<string, string>("AutoTickFirstCheck", autoTickFirstCheck.ToString()),
                            new Tuple<string, string>("SupervisorNotAvailable", supervisorNotAvailable.ToString())
                        };

                        var result2 = CreatePDFReport(tenancyId, facilityId, customerDefinitionId, ReportTypeIdentifier.TrayList, list2.ToArray());
                        if (scanDetails.IsNetworkPrinting)
                        {
                            PrintPDFReport(result2, scanDetails.LaserPrinter);
                        }
                        else
                        {
                            PrintLocalPDFReport(result2, scanDC);
                        }
                        if (!reprint)
                        {
                            var printHistoryHelper = new PrintHistoryHelper();
                            var printHistory = printHistoryHelper.CreatePrintHistory(user.UserId, PrintContentTypeIdentifier.TrayList, scanDC.TurnaroundId, null, scanDC.BatchId, null);
                            if (printHistory != null)
                            {
                                printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, PrintHistoryPrinterType.LaserPrinter, new PDFContent { Bytes = result2.ReportData });
                            }
                        }
                        InstanceFactory.GetInstance<ILog>().Info($"TrayPrioritisation - Create report Report count = {scanDC.Reports.Count}. T={scanDC.TurnaroundId.Value}, CI={scanDC.Asset.ContainerInstanceId}");
                    }
                }
            }
        }

        /// <summary>
        /// CreateTurnaroundLabelUpdateSterileExpiry operation
        /// </summary>
        public static void CreateTurnaroundLabelUpdateSterileExpiry(ScanAssetDataContract scanDC, ScanDetails scanDetails, short facilityId, TurnAroundEventTypeIdentifier eventType)
        {
            var isPrintRequired = false;

            scanDC.Labels = new List<TurnaroundLabelDataContract>();

            {
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var containerMaster = containerMasterRepository.Get(scanDC.Asset.ContainerMasterId);

                var facilityRepository = FacilityRepository.New(workUnit);

                var primaryFacilityId = scanDetails.PrimaryFacilityId ?? facilityId;
                var facility = facilityRepository.Get(primaryFacilityId);

                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.Value);

                var customerRepository = CustomerRepository.New(workUnit);
                var customer = customerRepository.GetActiveOneByDefinitionId(turnaround.DeliveryPoint.CustomerDefinitionId);

                var userRepository = UserRepository.New(workUnit);
                var user = userRepository.Get(scanDC.UserId);

                var exceptions = new List<ItemExceptionLabelInfo>();
                var externalId = containerMaster.ExternalId;
                var customerTimezone = customer.CustomerDefinition.Owner.TimeZone.Text;
                var nowInCustomerZone = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                var dateFormat = customer.CustomerDefinition.Owner.DateTimeFormat.ShortDateFormat.Text;
                var dateTimeFormat = dateFormat + " " + customer.CustomerDefinition.Owner.DateTimeFormat.ShortTimeFormat.Text;

                var location = turnaround.DeliveryPoint.Text;

                var additionalInfo = string.Empty;

                decimal refWeight = 0;

                if (scanDC.Asset.ContainerInstanceId.HasValue)
                {
                    var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                    var containerInstance = containerInstanceRepository.Get(scanDC.Asset.ContainerInstanceId.Value);
                    var customerFacilityId = containerInstance.ContainerMasterDefinition.CustomerDefinition.Customer.OrderByDescending(o => o.Revision).FirstOrDefault().FacilityId;

                    facility = facilityRepository.Get(customerFacilityId);
                    additionalInfo = containerInstance.AdditionalInfo;

                    var containerInstanceWeight = containerInstance.ContainerInstanceWeight?.OrderByDescending(ciw => ciw.ContainerInstanceWeightId).FirstOrDefault();

                    if (containerInstanceWeight != null)
                    {
                        if (containerInstanceWeight.PostWashRefWeightKg != 0)
                        {
                            refWeight = Math.Ceiling(containerInstanceWeight.PostWashRefWeightKg * 10) / 10;
                        }
                        else
                        {
                            refWeight = Math.Ceiling(containerInstanceWeight.PreWashRefWeightKg * 10) / 10;
                        }
                    }

                    ContainerInstanceIdentifier containerInstancePreference = null;
                    ContainerInstanceIdentifier customerInstancePreference = null;

                    if (containerInstance.QALabelProductCodeId != null)
                    {
                        containerInstancePreference = containerInstance.ContainerInstanceIdentifier.SingleOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == containerInstance.QALabelProductCodeId);
                    }
                    if (customer.QALabelProductCodeId != null)
                    {
                        customerInstancePreference = containerInstance.ContainerInstanceIdentifier.SingleOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == customer.QALabelProductCodeId);
                    }

                    externalId = containerInstancePreference?.Value ?? customerInstancePreference?.Value ?? containerInstance.PrimaryId;

                    var itemExceptionRepository = ItemExceptionRepository.New(workUnit);
                    var itemExceptions = itemExceptionRepository.GetItemExceptionsByInstance(containerInstance.ContainerInstanceId);
                    var repository = ItemMasterRepository.New(workUnit);

                    if (itemExceptions.Any())
                    {
                        var result = itemExceptions.GroupBy(ie => new { ie.ItemExceptionReason.Text, ie.ContainerContent.ItemMasterDefinitionId })
                                        .Select(o => new { ItemExceptionReasonText = o.Key.Text, o.Key.ItemMasterDefinitionId, Quantity = o.Count() });

                        foreach (var ie in result)
                        {
                            var itemMaster = repository.GetActiveOneByItemMasterDefinitionId(ie.ItemMasterDefinitionId.Value);
                            var culture = scanDetails.Culture;

                            if (ie.Quantity > 1)
                            {
                                var itemExceptionLabel = new ItemExceptionLabelInfo(
                                    itemMaster.ManufacturersReference
                                    , itemMaster.ExternalId
                                    , itemMaster.Text
                                    , ie.Quantity
                                    , ie.ItemExceptionReasonText
                                    , $" ({TranslatorManager.GetText("entities", "dbo.ItemExceptionReason", ie.ItemExceptionReasonText, false, culture)} x {ie.Quantity} x {itemMaster.Text})"
                                );

                                exceptions.Add(itemExceptionLabel);
                            }
                            else
                            {
                                var itemExceptionLabel = new ItemExceptionLabelInfo(
                                    itemMaster.ManufacturersReference
                                    , itemMaster.ExternalId
                                    , itemMaster.Text
                                    , ie.Quantity
                                    , ie.ItemExceptionReasonText
                                    , $" ({TranslatorManager.GetText("entities", "dbo.ItemExceptionReason", ie.ItemExceptionReasonText, false, culture)} x {itemMaster.Text}) "
                                );

                                exceptions.Add(itemExceptionLabel);
                            }
                        }
                    }
                }

                var itemTypeRepository = ItemTypeRepository.New(workUnit);
                var itemType = itemTypeRepository.Get(containerMaster.ItemTypeId);

                if ((eventType == TurnAroundEventTypeIdentifier.QualityAssurance) && (turnaround.ContainerInstanceId.HasValue))
                {
                    int days = SterileExpiryHelper.GetSterileExpiryDays(turnaround.TurnaroundId);

                    bool isDateEqual = false;
                    if (turnaround.SterileExpiryDate != null)
                    {
                        var expiryInCustomerZone = TimeZoneInfo.ConvertTimeFromUtc(turnaround.SterileExpiryDate.Value, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                        isDateEqual = nowInCustomerZone.AddDays(days).Date.Equals(expiryInCustomerZone.Date);
                    }

                    bool wasSterileExpiryNull = false;
                    if ((turnaround.SterileExpiryDate == null) || (customer.PrintTrayListFrontSheet == false) || (!isDateEqual))
                    {
                        if (turnaround.SterileExpiryDate == null)
                        {
                            wasSterileExpiryNull = true;
                        }
                    }

                    turnaround.SterileExpiryDate = DateTime.UtcNow.AddDays(days);
                    turnaroundRepository.Save();

                    var turnaroundWhRepository = TurnaroundWHRepository.New(workUnit);
                    var turnaroundWh = turnaroundWhRepository.GetByTurnaround(turnaround.TurnaroundId);

                    if (turnaroundWh != null)
                    {
                        turnaroundWh.SterileExpiryDate = turnaround.SterileExpiryDate;
                        turnaroundWhRepository.Save();
                    }

                    if ((customer.PrintTrayListFrontSheet.HasValue) && (customer.PrintTrayListFrontSheet.Value))
                    {
                        isPrintRequired = !wasSterileExpiryNull && !isDateEqual;
                    }
                }

                var isPrintSecondaryLabelEnabled = (facility.PrintSecondaryLabel != null) && (facility.PrintSecondaryLabel == true);
                var sterileExpiryDate = TimeZoneInfo.ConvertTimeFromUtc(turnaround.SterileExpiryDate.GetValueOrDefault(), TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));

                var labelTypeRepository = LabelTypeRepository.New(workUnit);
                var labelType = labelTypeRepository.Get(itemType.LabelTypeId);

                var turnaroundEvent = turnaround.TurnaroundEvent.OrderByDescending(te => te.TurnaroundEventId);

                TurnaroundEventWeight turnaroundEventWeight = null;
                foreach (var te in turnaroundEvent)
                {
                    if (te.TurnaroundEventWeight.Count() > 0)
                    {
                        turnaroundEventWeight = te.TurnaroundEventWeight.OrderByDescending(tew => tew.TurnaroundEventWeightId).First();
                        break;
                    }
                }

                decimal weight = 0;

                if (turnaroundEventWeight != null)
                {
                    weight = Math.Ceiling(turnaroundEventWeight.WeightKg * 10) / 10;
                }

                var t1 = new TurnaroundLabelDataMk2(
                    turnaround.ExternalId.ToString(),
                    externalId,
                    containerMaster.Text,
                    containerMaster.NumberOfLabels,
                    exceptions,
                    turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Text,
                    turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Text,
                    turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.GS1Code, location,
                    turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Address1,
                    turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.City,
                    turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Postcode,
                    turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Telephone,
                    containerMaster.Gtin,
                    null,
                    nowInCustomerZone,
                    sterileExpiryDate,
                    isPrintSecondaryLabelEnabled,
                    weight,
                    refWeight,
                    additionalInfo,
                    string.Empty,
                    null,
                    null,
                    string.Empty,
                    string.Empty);

                var label = GeneratePrintLabelStrings(turnaround, t1, user, labelType, false, scanDC.Asset.BaseItemTypeId, dateFormat, dateTimeFormat);
                TurnaroundLabelDataContract label2 = null;
                if (isPrintSecondaryLabelEnabled && exceptions != null && exceptions.Count > 0 && labelType.SecondaryLabelTypeId != null)
                {
                    var t2 = new TurnaroundLabelDataMk2(
                        turnaround.ExternalId.ToString(),
                        externalId,
                        containerMaster.Text,
                        containerMaster.NumberOfLabels,
                        exceptions,
                        turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Text,
                        turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Text,
                        turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.GS1Code, location,
                        turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Address1,
                        turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.City,
                        turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Postcode,
                        turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Telephone,
                        containerMaster.Gtin,
                        null,
                        nowInCustomerZone,
                        sterileExpiryDate,
                        false,
                        weight,
                        refWeight,
                        additionalInfo,
                        string.Empty,
                        null,
                        null,
                        string.Empty,
                        string.Empty);

                    label2 = GeneratePrintLabelStrings(turnaround, t2, user, labelType, true, scanDC.Asset.BaseItemTypeId, dateFormat, dateTimeFormat);
                    label2.IsPrintSecondaryLabel = true;
                    if (facility.PrintSingleSecondaryLabel)
                    {
                        label2.Count = 1;
                    }
                }

                if (scanDetails.IsNetworkPrinting)
                {
                    for (var j = 0; j < label.Count; j++)
                    {
                        SendStringToPrinter(scanDetails.LabelPrinter, label.Template);
                        SendStringToPrinter(scanDetails.LabelPrinter, label.Content);

                        if (label2 != null && label2.Count > j)
                        {
                            SendStringToPrinter(scanDetails.LabelPrinter, label2.Template);
                            SendStringToPrinter(scanDetails.LabelPrinter, label2.Content);
                        }
                    }

                }
                else
                {
                    scanDC.Labels.Add(label);  // Add labels for printing locally.

                    if (label2 != null)
                    {
                        scanDC.Labels.Add(label2);  // Add labels for printing locally.
                    }
                }
                if (label != null)
                {
                    var printHistoryHelper = new PrintHistoryHelper();
                    var printHistory = printHistoryHelper.CreatePrintHistory(scanDetails.UserId, PrintContentTypeIdentifier.QALabel, scanDC.TurnaroundId.Value, null, null, null);
                    if (printHistory != null)
                    {
                        printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, PrintHistoryPrinterType.QALabelPrinter, new LabelContent
                        {
                            Template = label.Template,
                            Content = label.Content
                        });
                        if (label2 != null)
                        {
                            printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, PrintHistoryPrinterType.QALabelPrinter, new LabelContent
                            {
                                Template = label2.Template,
                                Content = label2.Content
                            });
                        }
                    }
                }
            }
            if (isPrintRequired && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Supplementary)
            {
                var list = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("TurnaroundUid", scanDC.TurnaroundId.Value.ToString()),
                    new Tuple<string, string>("ContainerInstanceUid", scanDC.Asset.ContainerInstanceId.ToString()),
                    new Tuple<string, string>("Reprint", "False")
                };
                var result = CreatePDFReport(ReportTypeIdentifier.TrayListFrontSheet.ToString(), list.ToArray());
                PrintLocalPDFReport(result, scanDC);

                var printHistoryHelper = new PrintHistoryHelper();
                var printHistory = printHistoryHelper.CreatePrintHistory(scanDetails.UserId, PrintContentTypeIdentifier.TrayListFrontSheet, scanDC.TurnaroundId.Value, null, null, null);
                if (printHistory != null)
                {
                    printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, PrintHistoryPrinterType.LaserPrinter, new PDFContent { Bytes = result.ReportData });
                }
            }
        }

        /// <summary>
        /// GeneratePrintLabelStrings operation
        /// </summary>
        public static TurnaroundLabelDataContract GeneratePrintLabelStrings(Turnaround turnaround, TurnaroundLabelDataMk2 turnaroundLabelData, User user, LabelType labelType, bool isSecondaryLabel, int baseItemType, string dateFormat, string dateTimeFormat)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                turnaround = turnaroundRepository.Get(turnaround.TurnaroundId);

                var dataContract = new TurnaroundLabelDataContract
                {
                    Count = turnaround.ContainerMaster.NumberOfLabels,
                    TurnaroundId = turnaround.TurnaroundId,
                    BaseItemTypeId = baseItemType
                };

                var labelDefinitionRepository = LabelDefinitionRepository.New(workUnit);
                var customStationeryLogicRepository = CustomStationeryLogicRepository.New(workUnit);

                var tenancyId = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Owner.TenancyId;
                var facilityId = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.FacilityId;
                var customerDefinitionId = turnaround.DeliveryPoint.CustomerDefinitionId;

                var labelTypeId = labelType.LabelTypeId;

                if (isSecondaryLabel && labelType.SecondaryLabelTypeId != null)
                {
                    labelTypeId = labelType.SecondaryLabelTypeId.Value;
                }

                var customStationeryLogic = customStationeryLogicRepository.All().Where(csl =>
                            csl.CustomStationery.CustomStationeryTypeId == (int)OutputTypeIdentifier.QALabel &&
                            csl.CustomStationery.DataLabelDefinition.LabelTypeId == labelTypeId &&
                            csl.CustomStationery.TemplateLabelDefinition.LabelTypeId == labelTypeId &&
                            (
                                (
                                    (csl.TenancyId == tenancyId &&
                                     (csl.FacilityId == facilityId || csl.FacilityId == null) &&
                                     (csl.CustomerDefinitionId == customerDefinitionId ||
                                      csl.CustomerDefinitionId == null))

                                    ||
                                    (csl.FacilityId == facilityId &&
                                     (csl.TenancyId == tenancyId || csl.TenancyId == null) &&
                                     (csl.CustomerDefinitionId == customerDefinitionId ||
                                      csl.CustomerDefinitionId == null))
                                    ||
                                    (csl.CustomerDefinitionId == customerDefinitionId &&
                                     (csl.TenancyId == tenancyId || csl.TenancyId == null) &&
                                     (csl.FacilityId == facilityId || csl.FacilityId == null))
                                )

                                || (csl.TenancyId == null && csl.FacilityId == null && csl.CustomerDefinitionId == null)
                            )
                    )
                    .OrderByDescending(a => a.CustomerDefinitionId)
                    .ThenByDescending(a => a.FacilityId)
                    .ThenByDescending(a => a.TenancyId)
                    .FirstOrDefault();
                var templateLabelDefinition = LabelDefinitionFactory.CreateEntity(workUnit);
                var dataLabelDefinition = LabelDefinitionFactory.CreateEntity(workUnit);

                if (customStationeryLogic != null)
                {
                    templateLabelDefinition = labelDefinitionRepository.Get(customStationeryLogic.CustomStationery.LblTemplateId.Value);
                    dataLabelDefinition = labelDefinitionRepository.Get(customStationeryLogic.CustomStationery.LblDataId.Value);
                }
                else
                {
                    if (labelType.LabelDefinition.Count > 1)
                    {
                        templateLabelDefinition = labelDefinitionRepository.Get(labelType.LabelDefinition.First().LabelDefinitionId);
                        dataLabelDefinition = labelDefinitionRepository.Get(labelType.LabelDefinition.Skip(1).First().LabelDefinitionId);
                    }
                }

                dataContract.Template = templateLabelDefinition.Definition;

                dataContract.Content = PopulateLabelContent(
                    turnaround,
                    turnaroundLabelData,
                    user,
                    dateFormat,
                    dateTimeFormat,
                    dataLabelDefinition.Definition,
                    customerDefinitionId
                );

                return dataContract;
            }
        }

        /// <summary>
        /// Encode operation
        /// </summary>
        public static string Encode(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string tmp = null;
            foreach (var b in System.Text.Encoding.GetEncoding(20936).GetBytes(input))
            {
                tmp += Convert.ToChar(b);
            }

            return tmp;
        }

        /// <summary>
        /// PrintPackList operation
        /// </summary>
        public static PDFReport PrintPackList(int turnaroundId, string laserPrinterName, bool isNetworkPrinting, string systemId = null)
        {
            var list = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("id", turnaroundId.ToString())
            };

            if (!string.IsNullOrEmpty(systemId))
            {
                list.Add(new Tuple<string, string>("S", systemId));
            }
            return CreatePDFReport(ReportTypeIdentifier.PackList.ToString(), list.ToArray());
        }

        /// <summary>
        /// PrintItemDetails operation
        /// </summary>
        public static void PrintItemDetails(ScanDetails scanDetails, ScanAssetDataContract scanDC, ReportTypeIdentifier reportIdentifier = ReportTypeIdentifier.TurnaroundDetails)
        {
            if (scanDetails.TurnaroundId.HasValue)
            {
                {
                    var userRepository = UserRepository.New(workUnit);
                    var user = userRepository.Get(scanDC.UserId);

                    var list = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("S", user.SystemId.ToString()),
                        new Tuple<string, string>("TurnaroundId", scanDetails.TurnaroundId.ToString())
                    };

                    InstanceFactory.GetInstance<ILog>().Info("PrintItemDetails CreateReport start");

                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    var deliveryPointCustomer = deliveryPointRepository.GetCustomerByDeliveryPoint(scanDC.DeliveryPtId);

                    var tenancyId = deliveryPointCustomer.Facility.Owner.TenancyId;
                    var facilityId = deliveryPointCustomer.FacilityId;
                    var customerDefinitionId = deliveryPointCustomer.CustomerDefinitionId;

                    var result = CreatePDFReport(tenancyId, facilityId, customerDefinitionId, reportIdentifier, list.ToArray());
                    if (scanDetails.IsNetworkPrinting)
                    {
                        PrintPDFReport(result, scanDetails.LaserPrinter);
                    }
                    else
                    {
                        PrintLocalPDFReport(result, scanDC);
                    }
                }

                InstanceFactory.GetInstance<ILog>().Info("PrintItemDetails CreateReport finish");
            }
        }

        /// <summary>
        /// PrintReferenceTraylist operation
        /// </summary>
        public static void PrintReferenceTraylist(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool reprint = false, bool autoTickFirstCheck = false, bool supervisorNotAvailable = false)
        {
            if (scanDC?.Asset != null && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BatchTag)
            {
                scanDC.Reports = new List<ReportDataContract>();
                var list2 = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("TurnaroundUid", scanDC.TurnaroundId.Value.ToString()),
                    new Tuple<string, string>("ContainerInstanceUid", scanDC.Asset.ContainerInstanceId.ToString()),
                    new Tuple<string, string>("Reprint", reprint.ToString()),
                    new Tuple<string, string>("AutoTickFirstCheck", autoTickFirstCheck.ToString()),
                    new Tuple<string, string>("SupervisorNotAvailable", supervisorNotAvailable.ToString())
                };

                {
                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    var deliveryPointCustomer = deliveryPointRepository.GetCustomerByDeliveryPoint(scanDC.DeliveryPtId);

                    var tenancyId = deliveryPointCustomer.Facility.Owner.TenancyId;
                    var facilityId = deliveryPointCustomer.FacilityId;
                    var customerDefinitionId = deliveryPointCustomer.CustomerDefinitionId;

                    var result = CreatePDFReport(tenancyId, facilityId, customerDefinitionId, ReportTypeIdentifier.TrayList, list2.ToArray());
                    if (scanDetails.IsNetworkPrinting)
                    {
                        PrintPDFReport(result, scanDetails.LaserPrinter);
                    }
                    else
                    {
                        PrintLocalPDFReport(result, scanDC);
                    }
                }

                InstanceFactory.GetInstance<ILog>().Info($"TrayPrioritisation - Create report Report count = {scanDC.Reports.Count}. T={scanDC.TurnaroundId.Value}, CI={scanDC.Asset.ContainerInstanceId}");
            }
        }

        /// <summary>
        /// ReprintInstanceBarcode operation
        /// </summary>
        public static void ReprintInstanceBarcode(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            InstanceFactory.GetInstance<ILog>().Info($"ReprintInstanceBarcode {scanDC.ScannedString} printer {scanDetails.BarcodePrinter}");

            PrintInstanceBarcode(scanDC, scanDetails, true);
            Charges.RecordCharges(scanDetails);
        }

        /// <summary>
        /// PrintInstanceBarcode operation
        /// </summary>
        public static bool PrintInstanceBarcode(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool isReprint)
        {
            var result = false;

            try
            {
                InstanceFactory.GetInstance<ILog>().Info($"PrintInstanceBarcode {scanDC.ScannedString} printer {scanDetails.BarcodePrinter}");

                var oneDContainerInstanceIdentiferValue = scanDC.Asset.ContainerInstancePrimaryId;
                var twoDContainerInstanceIdentiferValue = scanDC.Asset.ContainerInstancePrimaryId;

                short? oneDLabelTypeId = null;
                short? twoDLabelTypeId = null;
                string culture;

                {
                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    var dp = deliveryPointRepository.Get(scanDC.DeliveryPtId);
                    culture = CustomerSettings.GetEvaluatedCultureForCustomer(dp.CustomerDefinitionId);

                    var containerInstanceIdentifierRepository = new ContainerInstanceIdentifierRepository(workUnit);
                    var containerInstanceIdentifiers = containerInstanceIdentifierRepository.All().Where(cii => cii.ContainerInstanceId == scanDC.Asset.ContainerInstanceId);

                    if (scanDC.Asset.Linear1DBarcodeId.HasValue)
                    {
                        oneDLabelTypeId = (short)scanDC.Asset.Linear1DBarcodeId;

                        var containerInstanceIdentifier = containerInstanceIdentifiers.SingleOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == oneDLabelTypeId);

                        if (containerInstanceIdentifier != null)
                        {
                            oneDContainerInstanceIdentiferValue = containerInstanceIdentifier.Value;
                        }
                    }

                    if (scanDC.Asset.Datamatrix2DBarcodeId.HasValue)
                    {
                        twoDLabelTypeId = (short)scanDC.Asset.Datamatrix2DBarcodeId;

                        var containerInstanceIdentifier = containerInstanceIdentifiers.SingleOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == twoDLabelTypeId);

                        if (containerInstanceIdentifier != null)
                        {
                            twoDContainerInstanceIdentiferValue = containerInstanceIdentifier.Value;
                        }
                    }
                }

                InstanceLabelPrint labelForm;
                PrintTypeIdentifier labelFormat;

                if (scanDC.Asset.Linear1DBarcodeId.HasValue && scanDC.Asset.Datamatrix2DBarcodeId.HasValue)
                {
                    labelForm = new InstanceLabelPrint(PrintTypeIdentifier.CombinedBarcodeInstanceLabel, scanDetails.BarcodePrinter, scanDC.Asset.CustomerName, scanDC.Asset.ContainerMasterName, scanDC.Asset.ContainerInstanceDeliveryPoint.Name, twoDContainerInstanceIdentiferValue, scanDC.Asset.WeighingRequired, TranslatorManager.GetText("pathway", "PTouchLabels", "PleaseReturnAfterUse", false, culture));
                    labelFormat = PrintTypeIdentifier.CombinedBarcodeInstanceLabel;
                }
                else if (scanDC.Asset.Datamatrix2DBarcodeId.HasValue)
                {
                    labelForm = new InstanceLabelPrint(PrintTypeIdentifier.TwoDBarcodeInstanceLabel, scanDetails.BarcodePrinter, scanDC.Asset.CustomerName, scanDC.Asset.ContainerMasterName, scanDC.Asset.ContainerInstanceDeliveryPoint.Name, twoDContainerInstanceIdentiferValue, scanDC.Asset.WeighingRequired, TranslatorManager.GetText("pathway", "PTouchLabels", "PleaseReturnAfterUse", false, culture));
                    labelFormat = PrintTypeIdentifier.TwoDBarcodeInstanceLabel;
                }
                else
                {
                    labelForm = new InstanceLabelPrint(PrintTypeIdentifier.InstanceLabel, scanDetails.BarcodePrinter, scanDC.Asset.CustomerName, scanDC.Asset.ContainerMasterName, scanDC.Asset.ContainerInstanceDeliveryPoint.Name, oneDContainerInstanceIdentiferValue, scanDC.Asset.WeighingRequired, TranslatorManager.GetText("pathway", "PTouchLabels", "PleaseReturnAfterUse", false, culture));
                    labelFormat = PrintTypeIdentifier.InstanceLabel;
                }
                {
                    var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                    var containerInstance = containerInstanceRepository.Get(scanDC.Asset.ContainerInstanceId.GetValueOrDefault());

                    if (containerInstance != null)
                    {
                        var audit = ContainerInstanceLabelAuditFactory.CreateEntity(workUnit,
                            containerInstanceId: containerInstance.ContainerInstanceId,
                            created: DateTime.UtcNow,
                            createdUserId: scanDetails.UserId,
                            stationId: scanDetails.StationId ?? 0,
                            facilityId: scanDetails.FacilityId,
                            oneDLabelType: oneDLabelTypeId,
                            twoDLabelType: twoDLabelTypeId,
                            labelFormat: (byte)labelFormat,
                            reprint: isReprint
                        );

                        containerInstance.ContainerInstanceLabelAudit.Add(audit);
                        containerInstanceRepository.Save();
                    }
                }
                if (scanDetails.IsNetworkPrinting)
                {
                    labelForm.Print();
                    result = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                InstanceFactory.GetInstance<ILog>().Exception(ex, "Print Instance Barcode");
            }

            return result;
        }

        /// <summary>
        /// AuditInstanceLabelPrint operation
        /// </summary>
        public static void AuditInstanceLabelPrint(InstanceLabelPrintAuditRequestDataContract dataContract)
        {
            {
                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                var containerInstance = containerInstanceRepository.Get(dataContract.ContainerInstanceId);

                if (containerInstance != null)
                {
                    var audit = ContainerInstanceLabelAuditFactory.CreateEntity(workUnit,
                        containerInstanceId: containerInstance.ContainerInstanceId,
                        created: DateTime.UtcNow,
                        createdUserId: dataContract.UserId,
                        stationId: dataContract.StationId ?? 0,
                        facilityId: dataContract.FacilityId,
                        oneDLabelType: (byte?)dataContract.OneDLabelType,
                        twoDLabelType: (byte?)dataContract.TwoDLabelType,
                        labelFormat: (byte)dataContract.LabelFormat,
                        reprint: dataContract.IsReprint
                    );

                    containerInstance.ContainerInstanceLabelAudit.Add(audit);
                    containerInstanceRepository.Save();
                }
            }
        }

        /// <summary>
        /// PopulateLabelContent operation
        /// </summary>
        public static string PopulateLabelContent(Turnaround turnaround, TurnaroundLabelDataMk2 turnaroundLabelData, User user, string dateFormat, string dateTimeFormat, string dataLabelDefinition, int? customerDefinitionId = null)
        {
            var label = new StringBuilder(dataLabelDefinition);
            string culture = turnaround.User.Culture != null ? turnaround.User.Culture.Code : null;

            string name = turnaroundLabelData.ItemName;

            string[] words = name.Split(' ');

            int n = 0;

            var sb1 = new StringBuilder(name.Length);
            while (n < words.Length && sb1.Length < 25)
            {
                sb1.Append(words[n]);
                sb1.Append(" ");
                n++;
            }
            var trayName = sb1.ToString().TrimEnd();

            var sb2 = new StringBuilder(name.Length);
            while (n < words.Length && sb2.Length < 25)
            {
                sb2.Append(words[n]);
                sb2.Append(" ");
                n++;
            }

            var trayName1 = sb2.ToString().TrimEnd();

            label.Replace("[BARCODE]", Encode(turnaroundLabelData.SerialNumber));
            label.Replace("[TRAY ID]", Encode(turnaroundLabelData.ItemExternalId));

            string pti = "01" + turnaroundLabelData.Gtin + "17" + turnaroundLabelData.ExpiryDate.ToString("yyMMdd") + "21" + turnaroundLabelData.SerialNumber;
            var gs1DateFormat = "yyMMdd";
            label.Replace("[AI01]", Encode(turnaroundLabelData.Gtin)); // GTIN
            label.Replace("[AI10]", Encode(turnaroundLabelData.SerialNumber)); // Batch/Log
            label.Replace("[AI11]", Encode(turnaroundLabelData.PrintDate.ToString(gs1DateFormat))); // Production Date
            label.Replace("[AI17]", Encode(turnaroundLabelData.ExpiryDate.ToString(gs1DateFormat))); // Expiry Date

            label.Replace("[TURNAROUND]", Encode(turnaroundLabelData.SerialNumber));

            if (turnaround.ContainerInstance != null)
            {
                {
                    var customerSettingRepository = CustomerSettingRepository.New(workUnit);
                    var ciiTypeRepository = ContainerInstanceIdentifierTypeRepository.New(workUnit);

                    var alternateIdUsed = customerDefinitionId != null ? customerSettingRepository.ReadCustomerSetting<bool>((short)customerDefinitionId.Value, "ExternalAndAlternateIdPassed") : false;

                    foreach (var cii in turnaround.ContainerInstance.ContainerInstanceIdentifier)
                    {
                        label.Replace(string.Format("[CONTAINERINSTANCEID-{0}]", cii.ContainerInstanceIdentifierType.Text), Encode(cii.Value));
                    }
                    label = new StringBuilder(Regex.Replace(label.ToString(), "\\[CONTAINERINSTANCEID\\-.*?\\]", Encode(turnaround.ContainerInstance.PrimaryId)));
                    foreach (var cii in ciiTypeRepository.All())
                    {
                        label.Replace(string.Format("[CONTAINERINSTANCEIDTYPETEXT-{0}]", cii.Text), Encode(TranslatorManager.GetText("entities", "dbo.ContainerInstanceIdentifierType", cii.Text, false, culture)));
                    }

                    var barcodeIdentifier = turnaround.ContainerInstance.ContainerInstanceIdentifier.FirstOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == turnaround.ContainerInstance.QALabelProductCodeId)?.Value;
                    string textIdentifier = string.Empty;

                    if (alternateIdUsed)
                    {
                        if (turnaround.ContainerInstance.QALabelProductCodeId == EXTERNAL_ID_TYPE_ID)
                        {
                            textIdentifier = turnaround.ContainerInstance.ContainerInstanceIdentifier.FirstOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == ALTERNATE_ID_TYPE_ID)?.Value;
                        }
                        else if (turnaround.ContainerInstance.QALabelProductCodeId == ALTERNATE_ID_TYPE_ID)
                        {
                            textIdentifier = turnaround.ContainerInstance.ContainerInstanceIdentifier.FirstOrDefault(cii => cii.ContainerInstanceIdentifierTypeId == EXTERNAL_ID_TYPE_ID)?.Value;
                        }
                    }
                    if (string.IsNullOrEmpty(textIdentifier))
                    {
                        textIdentifier = barcodeIdentifier;
                    }

                    label.Replace("[INSTANCE BARCODE]", Encode(barcodeIdentifier ?? turnaround.ContainerInstance.PrimaryId));
                    label.Replace("[INSTANCE TEXT]", Encode(textIdentifier ?? turnaround.ContainerInstance.PrimaryId));
                }
            }
            else
            {
                label.Replace("[INSTANCE BARCODE]", Encode(turnaround.ContainerMaster.ExternalId));
                label.Replace("[INSTANCE TEXT]", Encode(turnaround.ContainerMaster.ExternalId));
            }

            label.Replace("[ADDITIONAL INFO]", Encode(turnaroundLabelData.AdditionalInfo));
            label.Replace("[TRAY NAME]", Encode(trayName));
            label.Replace("[TRAY NAME1]", Encode(trayName1));
            label.Replace("[ADDRESS1]", Encode(turnaroundLabelData.FacilityName));
            label.Replace("[ADDRESS2]", Encode(turnaroundLabelData.Town + ", " + turnaroundLabelData.Postcode));
            label.Replace("[MANUFACTURED DATE]", Encode(turnaroundLabelData.PrintDate.ToString(dateFormat)));
            label.Replace("[MANUFACTURED DATETIME]", Encode(turnaroundLabelData.PrintDate.ToString(dateTimeFormat)));
            label.Replace("[EXPIRY DATE]", Encode(turnaroundLabelData.ExpiryDate.ToString(dateFormat)));
            label.Replace("[EXPIRY DATETIME]", Encode(turnaroundLabelData.ExpiryDate.ToString(dateTimeFormat)));
            label.Replace("[TELEPHONE]", Encode(turnaroundLabelData.Telephone));
            label.Replace("[THEATRE]", Encode(turnaroundLabelData.DeliveryPointName));
            label.Replace("[CUSTOMER NAME]", Encode(turnaroundLabelData.CustomerName));
            label.Replace("[GS1]", Encode(turnaroundLabelData.CustomerGs1));
            label.Replace("[PTI]", Encode(pti));
            label.Replace("[QUANTITY]", Encode(turnaroundLabelData.Quantity.ToString()));
            label.Replace("[COMPONENT SERIAL NUMBER]", Encode(turnaroundLabelData.ComponentSerialNumber));
            label.Replace("[DECON END DATE]", Encode(turnaroundLabelData.DeconEndDate.HasValue ? turnaroundLabelData.DeconEndDate.Value.ToString(dateFormat) : string.Empty));
            label.Replace("[DECON END DATETIME]", Encode(turnaroundLabelData.DeconEndDate.HasValue ? turnaroundLabelData.DeconEndDate.Value.ToString(dateTimeFormat) : string.Empty));
            label.Replace("[PROCESSED DATE]", Encode(turnaroundLabelData.ProcessedDate.HasValue ? turnaroundLabelData.ProcessedDate.Value.ToString(dateFormat) : string.Empty));
            label.Replace("[PROCESSED DATETIME]", Encode(turnaroundLabelData.ProcessedDate.HasValue ? turnaroundLabelData.ProcessedDate.Value.ToString(dateTimeFormat) : string.Empty));
            label.Replace("[BATCH CYCLE]", Encode(turnaroundLabelData.BatchCycle));
            label.Replace("[PROCESSING MACHINE]", Encode(turnaroundLabelData.ProcessingMachine));
            label.Replace("[ITEM TYPE]", Encode(turnaround.ContainerMaster.ItemType.Text));
            label.Replace("[PARENT ITEM TYPE]", Encode(turnaround.ContainerMaster.BaseItemType.Text));

            if (turnaroundLabelData.Exceptions.Count == 0)
            {
                label.Replace("[EXCEPTION Code]", Encode(TranslatorManager.GetText("pathway", "QALabels", "QAExceptionsNo", false, culture)));
            }
            else
            {
                label.Replace("[EXCEPTION Code]", Encode(TranslatorManager.GetText("pathway", "QALabels", "QAExceptionsYes", false, culture)) +
                    " (" + turnaroundLabelData.Exceptions.Count + ")");
            }

            label.Replace("[CONTAINERMASTER REVISION]", Encode(turnaround.ContainerMaster.Revision.ToString()));

            if (turnaround.ContainerMaster.BiologicalIndicatorEnabled.HasValue && turnaround.ContainerMaster.BiologicalIndicatorEnabled.Value)
            {
                label.Replace("[BIOLOGICAL INDICATOR ENABLED]", Encode(Synergy.Resources.QALabelResources.BiologicalIndicatorEnabledTag));
            }
            else
            {
                label.Replace("[BIOLOGICAL INDICATOR ENABLED]", "");
            }

            label.Replace("[FIRSTNAME]", Encode(user.FirstName));
            label.Replace("[SURNAME]", Encode(user.Surname));
            label.Replace("[INITIAL FIRSTNAME]", Encode(user.FirstName.ToUpperInvariant().FirstOrDefault().ToString()));
            label.Replace("[INITIAL SURNAME]", Encode(user.Surname.ToUpperInvariant().FirstOrDefault().ToString()));

            label.Replace("[CHARGEABLEBATCHCYCLETEXT]", Encode(TranslatorManager.GetText("entities", "dbo.BatchCycle", turnaround.ContainerMaster.ChargableBatchCycle.Text, culture: culture)));

            if (turnaroundLabelData.LastKnownWeight > 0)
            {
                label.Replace("[TRAYWEIGHT]", turnaroundLabelData.LastKnownWeight.ToString("0.0 ") + Encode(TranslatorManager.GetText("pathway", "QALabels", "Kg", culture: culture)));
            }
            else
            {
                label.Replace("[TRAYWEIGHT]", Encode(TranslatorManager.GetText("pathway", "QALabels", "NoWeight", culture: culture)));
            }

            if (turnaroundLabelData.ReferenceWeight > 0)
            {
                label.Replace("[REFERENCEWEIGHT]", turnaroundLabelData.ReferenceWeight.ToString("0.0 ") + Encode(TranslatorManager.GetText("pathway", "QALabels", "Kg", culture: culture)));
            }
            else
            {
                label.Replace("[REFERENCEWEIGHT]", Encode(TranslatorManager.GetText("pathway", "QALabels", "NoWeight", culture: culture)));
            }

            int j = 0;

            if (turnaroundLabelData.AdditionalDetails != null)
            {
                foreach (string ad in turnaroundLabelData.AdditionalDetails)
                {
                    if (dataLabelDefinition.Contains("[EXCEPTIONS" + j.ToString(CultureInfo.InvariantCulture) + "]"))
                    {
                        label.Replace("[EXCEPTIONS" + j.ToString(CultureInfo.InvariantCulture) + "]", Encode(ad));
                        j++;
                    }
                }
            }
            if (turnaroundLabelData.ShowQuantity && dataLabelDefinition.Contains("[EXCEPTIONS" + j.ToString(CultureInfo.InvariantCulture) + "]"))
            {
                if (turnaroundLabelData.Exceptions.Count == 0)
                {
                    label.Replace("[EXCEPTIONS" + j.ToString(CultureInfo.InvariantCulture) + "]",
                        Encode(TranslatorManager.GetText("pathway", "QALabels", "QAExceptionsNo", false, culture)));
                }
                else
                {
                    label.Replace("[EXCEPTIONS" + j.ToString(CultureInfo.InvariantCulture) + "]",
                        Encode(TranslatorManager.GetText("pathway", "QALabels", "QAExceptionsYes", false, culture)) +
                        " (" + turnaroundLabelData.Exceptions.Count + ")");
                }

                j++;
            }

            for (int i = 0; i < 12 - j; i++)
            {
                if (i <= turnaroundLabelData.Exceptions.Count - 1)
                {
                    var exception = turnaroundLabelData.Exceptions[i];

                    label.Replace("[EXCEPTIONS" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", Encode(exception.ExceptionDescription));
                    label.Replace("[EXCEPTION REF" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]",
                        Encode(exception.ManufacturersReference.Length > 0
                            ? exception.ManufacturersReference
                            : exception.ItemMasterExternalId));
                    label.Replace("[EXCEPTION REASON" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", Encode(exception.ItemExceptionReason));
                    label.Replace("[EXCEPTION QTY" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", exception.ItemExceptionQuantity.ToString(CultureInfo.InvariantCulture));
                    label.Replace("[EXCEPTION MASTER" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", Encode(exception.ItemMasterName));
                }
                else
                {
                    label.Replace("[EXCEPTIONS" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", string.Empty);
                    label.Replace("[EXCEPTION REF" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", string.Empty);
                    label.Replace("[EXCEPTION REASON" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", string.Empty);
                    label.Replace("[EXCEPTION QTY" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", string.Empty);
                    label.Replace("[EXCEPTION MASTER" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", string.Empty);
                }
            }

            return label.ToString();
        }

    }
}