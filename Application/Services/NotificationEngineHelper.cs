using SynergyApplicationFrameworkApi.Application.DTOs.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using PrintUtility = Pathway.ServicesWCF.Printing.PrintUtility;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// NotificationEngineHelper
    /// </summary>
    public class NotificationEngineHelper
    {
        private readonly List<byte[]> _pdfPrintData = new List<byte[]>();

        private ILog Log;

        public NotificationEngineHelper()
        {
            Log = InstanceFactory.GetInstance<ILog>();
        }

        /// <summary>
        /// ProcessNotifications operation
        /// </summary>
        public List<CommunicationTypeIdentifier> ProcessNotifications(ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId)
        {
            _pdfPrintData.Clear();
            var notificationTypesFired = new List<CommunicationTypeIdentifier>();

            using (var repository = new PathwayRepository())
            {
                foreach (var item in repository.Container.GetNotificationRuleOutcome(turnaroundEventId).ToList())
                {
                    if (item.CanProcess)
                    {
                        notificationTypesFired.Add((CommunicationTypeIdentifier)item.CommunicationTypeId);
                    }
                    
                    if (item.CanProcess || item.Reprintable)
                    {
                        switch ((CommunicationTypeIdentifier)item.CommunicationTypeId)
                        {
                            case CommunicationTypeIdentifier.Print:
                            case CommunicationTypeIdentifier.PrintLabel:
                                DoPrintNotification(scanDC, scanDetails, turnaroundEventId, item);
                                break;
                            case CommunicationTypeIdentifier.Email:
                                DoEmailNotification(scanDC, scanDetails, turnaroundEventId, item);
                                break;
                            case CommunicationTypeIdentifier.SMS:
                                DoSMSNotification(scanDC, scanDetails, turnaroundEventId, item);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            return notificationTypesFired;
        }

        /// <summary>
        /// ProcessNotifications operation
        /// </summary>
        public List<CommunicationTypeIdentifier> ProcessNotifications(ScanAssetDataContract scanDC, ScanDetails scanDetails, ITurnaroundEvent turnaroundEvent)
        {
            return ProcessNotifications(scanDC, scanDetails, turnaroundEvent.TurnaroundEventId);
        }

        /// <summary>
        /// GetReportsAndNotification operation
        /// </summary>
        public void GetReportsAndNotification(List<ScanAssetDataContract> listOfDataContracts, BaseReplyDataContract replyContract)
        {
            replyContract.Reports = new List<ReportDataContract>();

            foreach (var dc in listOfDataContracts)
            {
                if (dc.Reports != null && dc.Reports.Count > 0)
                {
                    foreach (var report in dc.Reports)
                    {
                        replyContract.Reports.Add(report);
                    }

                }

                if (replyContract.NotificationTypesFired == null)
                {
                    replyContract.NotificationTypesFired = dc.NotificationTypesFired;
                }
            }
        }

        private void DoPrintNotification(ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId, GetNotificationRuleOutcome_Result notificationOutcome)
        {
            switch ((OutputTypeIdentifier)notificationOutcome.OutputTypeId)
            {
                case OutputTypeIdentifier.Generic:
                    DoGenericPrintForNotification(scanDC, scanDetails, turnaroundEventId, notificationOutcome);
                    break;
                case OutputTypeIdentifier.GenericLabel:
                case OutputTypeIdentifier.QALabel:
                    DoLabelPrintForNotification(scanDC, scanDetails, turnaroundEventId, notificationOutcome);
                    break;
                case OutputTypeIdentifier.Traylist:
                    DoTrayListPrintForNotification(scanDC, scanDetails, turnaroundEventId, notificationOutcome);
                    break;
                case OutputTypeIdentifier.DeliveryNote:
                    DoDeliveryNotePrintForNotifications(scanDC, scanDetails, turnaroundEventId, notificationOutcome);
                    break;
                default:
                    break;
            }
        }
        
        private void DoGenericPrintForNotification(
            ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId, GetNotificationRuleOutcome_Result ruleOutcome)
        {
            var printContentTypeId = ruleOutcome.PrintContentTypeId;
            var notificationRuleId = ruleOutcome.NotificationRuleId;
            var createPrintHistory = ruleOutcome.Reprintable;
            var sendToPrinter = ruleOutcome.CanProcess;
            var reportPath = ruleOutcome.ReportPath;
            var numberOfCopies = ruleOutcome.NumberOfCopies;

            if (scanDC != null && !string.IsNullOrWhiteSpace(reportPath))
            {
                if (scanDC.Reports == null) scanDC.Reports = new List<ReportDataContract>();

                if (PrintUtility.IsLaserPrinterAvailable(scanDetails.LaserPrinter, scanDetails.IsNetworkPrinting))
                {
                    using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                    {
                        var userRepository = UserRepository.New(workUnit);
                        var user = userRepository.Get(scanDetails.UserId);
                        
                        var list = new List<Tuple<string, string>>
                        {
                            new Tuple<string, string>("S", user.SystemId.ToString()),
                            new Tuple<string, string>("TurnaroundEventId", turnaroundEventId.ToString())
                        };

                        if (sendToPrinter || createPrintHistory)
                        {
                            var result = PrintUtility.CreatePDFReport(reportPath, list.ToArray());
                            result.NumberOfCopies = numberOfCopies;

                            if (sendToPrinter)
                            {
                                if (!scanDetails.IsNetworkPrinting)
                                {
                                    PrintUtility.PrintLocalPDFReport(result, scanDC);
                                    Log.Info($"Notification Engine Generic Report Print. Report count = {scanDC.Reports.Count}. TeId={turnaroundEventId}, CI={scanDC.Asset.ContainerInstanceId}");
                                }
                                else
                                {
                                    System.Threading.Tasks.Task.Run(() =>
                                    {
                                        PrintUtility.PrintPDFReport(result, scanDetails.LaserPrinter);
                                        Log.Info($"Notification Engine Generic Report Print (Newtwork). Report count = {scanDC.Reports.Count}. TeId={turnaroundEventId}, CI={scanDC.Asset.ContainerInstanceId}");
                                    });
                                }
                            }
                            if (createPrintHistory)
                            {
                                CreatePrintHistoryForPdfContent(user.UserId, printContentTypeId, scanDC.TurnaroundId, turnaroundEventId, scanDC.BatchId, notificationRuleId, result.ReportData);
                            }
                        }
                    }
                }
            }
        }

        private void DoLabelPrintForNotification(
            ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId, GetNotificationRuleOutcome_Result ruleOutcome)
        {
            var sendToPrinter = ruleOutcome.CanProcess;
            var createPrintHistory = ruleOutcome.Reprintable;
            var printContentTypeId = ruleOutcome.PrintContentTypeId;
            var lblTemplateId = ruleOutcome.LblTemplateId;
            var lblDataId = ruleOutcome.LblDataId;
            var secondLblTemplateId = ruleOutcome.SecondLblTemplateId;
            var secondLblDataId = ruleOutcome.SecondLblDataId;
            var numberOfCopies = ruleOutcome.NumberOfCopies;
            var notificationRuleId = ruleOutcome.NotificationRuleId;

            if ((sendToPrinter || createPrintHistory) && (lblTemplateId.HasValue && lblDataId.HasValue))
            {
                {
                    DeliveryPoint deliveryPt = null;
                    Customer customer = null;
                    ItemType itemType = null;
                    string location = null;
                    DateTime? processedDate = null;
                    DateTime? deconEndDate = null;

                    var exceptions = new List<ItemExceptionLabelInfo>();
                    var serialNumber = string.Empty;
                    var processingMachine = string.Empty;
                    var batchCycle = string.Empty;
                    var additionalInfo = string.Empty;
                    var isPrintSecondaryLabelEnabled = false;

                    var userRepository = UserRepository.New(workUnit);
                    var user = userRepository.Get(scanDetails.UserId);

                    var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);
                    var turnaroundEvent = turnaroundEventRepository.Get(turnaroundEventId);

                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var turnaround = turnaroundRepository.Get(turnaroundEvent.Turnaround.TurnaroundId);

                    var facilityRepository = FacilityRepository.New(workUnit);
                    var primaryFacilityId = scanDetails.PrimaryFacilityId ?? scanDetails.FacilityId;
                    var facility = facilityRepository.Get(primaryFacilityId);
                    if (facility == null)
                    {
                        facility = facilityRepository.Get(turnaround.FacilityId);
                    }
                    var doesFacilityRequireSecondaryLabel = facility.PrintSecondaryLabel;

                    var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                    var containerMaster = containerMasterRepository.Get(scanDC.Asset.ContainerMasterId);

                    var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                    var itemMasterRepository = ItemMasterRepository.New(workUnit);

                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    var customerRepository = CustomerRepository.New(workUnit);

                    var labelTypeRepository = LabelTypeRepository.New(workUnit);
                    var itemTypeRepository = ItemTypeRepository.New(workUnit);

                    deliveryPt = deliveryPointRepository.Get(turnaround.DeliveryPointId);

                    if (deliveryPt != null)
                    {
                        location = deliveryPt.Text;
                        customer = customerRepository.GetActiveOneByDefinitionId(turnaround.DeliveryPoint.CustomerDefinitionId);
                    }

                    var containerContentRepository = ContainerContentRepository.New(workUnit);
                    var containerContent = containerContentRepository.ReadContainerContent(turnaround.ContainerMasterId).Where(x => x.ContainerContentNoteId == null).OrderBy(x => x.Position).FirstOrDefault();
                    if (containerContent != null)
                    {
                        var itemInstance = turnaround.ContainerInstance.ItemInstance.Where(x => x.ItemMasterDefinitionId == containerContent.ItemMasterDefinitionId).FirstOrDefault();
                        if (itemInstance != null)
                        {
                            var id = itemInstance.ItemInstanceIdentifier.Where(x => x.ItemInstanceIdentifierTypeId == 4).FirstOrDefault(); // Serial Number
                            if (id != null && !string.IsNullOrWhiteSpace(id.Value))
                            {
                                serialNumber = id.Value;
                            }
                        }
                    }
                    var customerTimezone = customer.CustomerDefinition.Owner.TimeZone.Text;
                    var nowInCustomerZone = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                    var sterileExpiryDate = TimeZoneInfo.ConvertTimeFromUtc(turnaround.SterileExpiryDate.GetValueOrDefault(), TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                    processedDate = TimeZoneInfo.ConvertTimeFromUtc(turnaroundEvent.Created, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                    var batchId = scanDC.BatchId;

                    if (turnaround.ContainerInstance?.ActiveContainerMaster.BaseItemTypeId == (int)ItemTypeIdentifier.Endoscopy ||
                        turnaround.ContainerMaster.ItemType.ParentItemTypeId == (int)ItemTypeIdentifier.Endoscopy)
                    {
                        var aerPassed = turnaround.TurnaroundEvent.Where(x => x.EventTypeId == (int)TurnAroundEventTypeIdentifier.AerPassed)
                            .OrderByDescending(x => x.TurnaroundEventId)
                            .ThenByDescending(x => x.Created)
                            .FirstOrDefault();

                        if (aerPassed != null)
                        {
                            processedDate = TimeZoneInfo.ConvertTimeFromUtc(aerPassed.Created, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                            batchId = aerPassed.BatchId;
                        }
                    }
                    if (batchId.HasValue)
                    {
                        var batchRepository = BatchRepository.New(workUnit);
                        var batch = batchRepository.Get(batchId.Value);
                        if (batch != null)
                        {
                            batchCycle = batch.ExternalId;
                            processingMachine = batch.Machine?.Text;
                        }
                    }
                    var deconEnd = turnaround.TurnaroundEvent.Where(x => x.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeconEnd)
                        .OrderByDescending(x => x.TurnaroundEventId)
                        .ThenByDescending(x => x.Created)
                        .FirstOrDefault();
                    if (deconEnd != null)
                    {
                        deconEndDate = TimeZoneInfo.ConvertTimeFromUtc(deconEnd.Created, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                    }
                    var turnaroundEventWeighing = turnaround.TurnaroundEvent.OrderByDescending(te => te.TurnaroundEventId);

                    TurnaroundEventWeight turnaroundEventWeight = null;
                    foreach (var te in turnaroundEventWeighing)
                    {
                        if (te.TurnaroundEventWeight.Count() > 0)
                        {
                            turnaroundEventWeight = te.TurnaroundEventWeight.OrderByDescending(tew => tew.TurnaroundEventWeightId).First();
                            break;
                        }
                    }

                    ContainerInstanceWeight containerInstanceWeight = null;
                    if (turnaround.ContainerInstance.ContainerInstanceWeight.Count() > 0)
                    {
                        containerInstanceWeight = turnaround.ContainerInstance.ContainerInstanceWeight.OrderByDescending(ciw => ciw.ContainerInstanceWeightId).First();
                    }

                    decimal weight = 0;
                    decimal refWeight = 0;

                    if (turnaroundEventWeight != null)
                    {
                        weight = Math.Ceiling(turnaroundEventWeight.WeightKg * 10) / 10;
                    }

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
                    var dateFormat = customer.CustomerDefinition.Owner.DateTimeFormat.ShortDateFormat.Text;
                    var dateTimeFormat = dateFormat + " " + customer.CustomerDefinition.Owner.DateTimeFormat.ShortTimeFormat.Text;

                    var externalId = string.Empty;
                    var facilityText = string.Empty;
                    var facilityAddress = string.Empty;
                    var facilityCity = string.Empty;
                    var facilityPostcode = string.Empty;
                    var facilityTelephone = string.Empty;
                    var customerText = string.Empty;
                    var customerGS1 = string.Empty;

                    if (turnaround.ContainerInstance?.ActiveContainerMaster.BaseItemTypeId == (int)ItemTypeIdentifier.Extra ||
                        turnaround.ContainerMaster.ItemType.ParentItemTypeId == (int)ItemTypeIdentifier.Extra)
                    {
                        externalId = containerMaster == null ? string.Empty : containerMaster.ExternalId;
                        facilityText = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Text;
                        facilityAddress = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Address1;
                        facilityCity = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.City;
                        facilityPostcode = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Postcode;
                        facilityTelephone = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Facility.Address.Telephone;
                        customerText = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Text;
                        customerGS1 = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.GS1Code;
                    }
                    else
                    {
                        externalId = turnaround.ContainerInstance == null ? string.Empty : turnaround.ContainerInstance.PrimaryId;
                        facilityText = facility.Text;
                        facilityAddress = facility.Address.Address1;
                        facilityCity = facility.Address.City;
                        facilityPostcode = facility.Address.Postcode;
                        facilityTelephone = facility.Address.Telephone;
                        customerText = customer.Text;
                        customerGS1 = customer.GS1Code;
                    }

                    var labels = new List<TurnaroundLabelDataContract> ();

                    TurnaroundLabelDataMk2 mk2 = null;
                    TurnaroundLabelDataContract label = null;

                    switch ((OutputTypeIdentifier)ruleOutcome.OutputTypeId)
                    {
                        case OutputTypeIdentifier.GenericLabel:
                            mk2 = new TurnaroundLabelDataMk2(
                                turnaround.ExternalId.ToString(),
                                externalId,
                                containerMaster.Text,
                                containerMaster.NumberOfLabels,
                                exceptions,
                                facilityText,
                                customerText,
                                customerGS1,
                                location,
                                facilityAddress,
                                facilityCity,
                                facilityPostcode,
                                facilityTelephone,
                                containerMaster.Gtin,
                                null,
                                nowInCustomerZone,
                                sterileExpiryDate,
                                isPrintSecondaryLabelEnabled,
                                weight,
                                refWeight,
                                additionalInfo,
                                serialNumber,
                                processedDate,
                                deconEndDate,
                                processingMachine,
                                batchCycle);
                            label = GenerateGenericLabel(turnaround, mk2, user, dateFormat, dateTimeFormat, lblTemplateId.Value, lblDataId.Value);
                            break;

                        case OutputTypeIdentifier.QALabel:
                            if (scanDC.Asset.ContainerInstanceId.HasValue)
                            {
                                var containerInstance = containerInstanceRepository.Get(scanDC.Asset.ContainerInstanceId.Value);
                                additionalInfo = containerInstance.AdditionalInfo;

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

                                if (itemExceptions.Any())
                                {
                                    var result = itemExceptions.GroupBy(ie => new { ie.ItemExceptionReason.Text, ie.ContainerContent.ItemMasterDefinitionId })
                                        .Select(o => new { ItemExceptionReasonText = o.Key.Text, o.Key.ItemMasterDefinitionId, Quantity = o.Count() });

                                    foreach (var ie in result)
                                    {
                                        var itemMaster = itemMasterRepository.GetActiveOneByItemMasterDefinitionId(ie.ItemMasterDefinitionId.Value);
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
                            itemType = itemTypeRepository.Get(containerMaster.ItemTypeId);
                            isPrintSecondaryLabelEnabled = (facility.PrintSecondaryLabel != null) && (facility.PrintSecondaryLabel == true);

                            mk2 = new TurnaroundLabelDataMk2(
                                turnaround.ExternalId.ToString(),
                                externalId,
                                containerMaster.Text,
                                containerMaster.NumberOfLabels,
                                exceptions,
                                facilityText,
                                customerText,
                                customerGS1,
                                location,
                                facilityAddress,
                                facilityCity,
                                facilityPostcode,
                                facilityTelephone,
                                containerMaster.Gtin,
                                null,
                                nowInCustomerZone,
                                sterileExpiryDate,
                                isPrintSecondaryLabelEnabled,
                                weight,
                                refWeight,
                                additionalInfo,
                                serialNumber,
                                processedDate,
                                deconEndDate,
                                processingMachine,
                                batchCycle);

                            label = GenerateQALabel(turnaround, mk2, user, dateFormat, dateTimeFormat, lblTemplateId.Value, lblDataId.Value, false, scanDC.Asset.BaseItemTypeId);
                            break;
                    }

                    if (label != null)
                    {
                        label.Count = numberOfCopies;
                        labels.Add(label);
                        TurnaroundLabelDataContract label2 = null;
                        if (ruleOutcome.OutputTypeId == (int) OutputTypeIdentifier.QALabel && isPrintSecondaryLabelEnabled 
                            && exceptions != null && exceptions.Count > 0 && secondLblTemplateId.HasValue && secondLblDataId.HasValue
                            && doesFacilityRequireSecondaryLabel == true)
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

                            label2 = GenerateQALabel(turnaround, t2, user, dateFormat, dateTimeFormat, secondLblTemplateId.Value, secondLblDataId.Value, true, scanDC.Asset.BaseItemTypeId);
                            label2.IsPrintSecondaryLabel = true;
                            label2.Count = 1;
                            labels.Add(label2);
                           
                        }
                       
                        if (sendToPrinter)
                        {
                            if (!scanDetails.IsNetworkPrinting)
                            {
                                if (scanDC.NotificationLabels == null)
                                {
                                    scanDC.NotificationLabels = new List<TurnaroundLabelDataContract>();
                                }
                                scanDC.NotificationLabels.AddRange(labels);
                            }
                            else
                            {
                                for (var j = 0; j < label.Count; j++)
                                {
                                    Printing.PrintUtility.SendStringToPrinter(scanDetails.LabelPrinter, label.Template);
                                    Printing.PrintUtility.SendStringToPrinter(scanDetails.LabelPrinter, label.Content);

                                    if (label2 != null && label2.Count > j)
                                    {
                                        Printing.PrintUtility.SendStringToPrinter(scanDetails.LabelPrinter, label2.Template);
                                        Printing.PrintUtility.SendStringToPrinter(scanDetails.LabelPrinter, label2.Content);
                                    }
                                }
                            }
                        }
                        if (createPrintHistory)
                        {
                            CreatePrintHistoryForLabelContent(user.UserId, printContentTypeId, turnaround.TurnaroundId, turnaroundEventId, scanDC.BatchId, notificationRuleId, labels);
                        }
                    }
                }
            }
        }

        private void CreatePrintHistoryForLabelContent(int userId, int printContentTypeId, int? turnaroundId, int? turnaroundEventId, int? batchId, int? notificationRuleId, List<TurnaroundLabelDataContract> labels)
        {
            try
            {
                var printHistoryHelper = new PrintHistoryHelper();
                var printHistory = printHistoryHelper.CreatePrintHistory(userId, (PrintContentTypeIdentifier)printContentTypeId, turnaroundId, turnaroundEventId, batchId, notificationRuleId);
                if (printHistory != null)
                {
                    foreach (var label in labels)
                    {
                        printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, Enums.Printing.PrintHistoryPrinterType.QALabelPrinter, new LabelContent
                        {
                            Template = label.Template,
                            Content = label.Content
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Info($"Notification Engine Print History Create Failure (Label), exception: {ex.Message}");
            }
        }

        private void CreatePrintHistoryForPdfContent(
            int userId, int printContentTypeId, int? turnaroundId, int? turnaroundEventId, int? batchId, int? notificationRuleId, byte[] reportData)
        {
            try
            {
                var printHistoryHelper = new PrintHistoryHelper();

                var printHistory = printHistoryHelper.CreatePrintHistory(userId, (PrintContentTypeIdentifier) printContentTypeId, turnaroundId, turnaroundEventId, batchId, notificationRuleId);
                if (printHistory != null)
                {
                    printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, PrintHistoryPrinterType.LaserPrinter, new PDFContent { Bytes = reportData });
                }
            }
            catch (Exception ex)
            {
                Log.Info($"Notification Engine Print History Create Failure (Pdf), exception: {ex.Message}");
            }
        }
        
        private TurnaroundLabelDataContract GenerateGenericLabel(Turnaround turnaround, TurnaroundLabelDataMk2 turnaroundLabelData, User user, 
            string dateFormat, string dateTimeFormat, byte templateLabelId, byte dataLabelId)
        {
            {
                var dataContract = new TurnaroundLabelDataContract
                {
                    Count = turnaround.ContainerMaster.NumberOfLabels,
                    TurnaroundId = turnaround.TurnaroundId,
                };

                var labelDefinitionRepository = LabelDefinitionRepository.New(workUnit);
                var customStationeryRepository = CustomStationeryRepository.New(workUnit);

                var templateLabelDefinition = LabelDefinitionFactory.CreateEntity(workUnit);
                var dataLabelDefinition = LabelDefinitionFactory.CreateEntity(workUnit);

                var cs = customStationeryRepository.All().Where
                (
                    x => x.CustomStationeryTypeId == (byte)Pathway.Enums.OutputTypeIdentifier.GenericLabel &&
                    x.LblTemplateId == templateLabelId && 
                    x.LblDataId == dataLabelId
                ).FirstOrDefault();

                if (cs != null)
                {
                    templateLabelDefinition = labelDefinitionRepository.Get(templateLabelId);
                    dataLabelDefinition = labelDefinitionRepository.Get(dataLabelId);
                }

                if (templateLabelDefinition != null && dataLabelDefinition != null)
                {

                    dataContract.Template = templateLabelDefinition.Definition;
                    dataContract.Content = Printing.PrintUtility.PopulateLabelContent(turnaround, turnaroundLabelData, user, dateFormat, dateTimeFormat, dataLabelDefinition.Definition);

                    return dataContract;
                }
                return null;
            }
        }

        private TurnaroundLabelDataContract GenerateQALabel(Turnaround turnaround, TurnaroundLabelDataMk2 turnaroundLabelData, User user,
            string dateFormat, string dateTimeFormat, byte templateLabelId, byte dataLabelId, bool isSecondaryLabel, int baseItemType)
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

                var templateLabelDefinition = LabelDefinitionFactory.CreateEntity(workUnit);
                var dataLabelDefinition = LabelDefinitionFactory.CreateEntity(workUnit);

                templateLabelDefinition = labelDefinitionRepository.Get(templateLabelId);
                dataLabelDefinition = labelDefinitionRepository.Get(dataLabelId);

                if (templateLabelDefinition != null && dataLabelDefinition != null)
                {
                    dataContract.Template = templateLabelDefinition.Definition;
                    dataContract.Content = Printing.PrintUtility.PopulateLabelContent(turnaround, turnaroundLabelData, user, dateFormat, dateTimeFormat, dataLabelDefinition.Definition, customerDefinitionId);

                    return dataContract;
                }
                return null;
            }
        }

        private string Encode(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string tmp = null;
            foreach (var b in System.Text.Encoding.GetEncoding(20936).GetBytes(input))
            {
                tmp += Convert.ToChar(b);
            }

            return tmp;
        }

        private void DoTrayListPrintForNotification(ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId, GetNotificationRuleOutcome_Result ruleOutcome)
        {
        }

        private void DoDeliveryNotePrintForNotifications(ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId, GetNotificationRuleOutcome_Result ruleOutcome)
        {
            var sendToPrinter = ruleOutcome.CanProcess;
            var reportPath = ruleOutcome.ReportPath;
            var numberOfCopies = ruleOutcome.NumberOfCopies;
        }

        private void DoEmailNotification(ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId, GetNotificationRuleOutcome_Result notificationOutcome)
        {
        }

        private void DoSMSNotification(ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId, GetNotificationRuleOutcome_Result notificationOutcome)
        {
        }
    }
}

