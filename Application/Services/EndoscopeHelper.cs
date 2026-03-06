using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class EndoscopeHelper
    {

        private const string sectionGroup = "pathway";
        private const string section = "GenericNotes";

        /// <summary>
        /// GetEndoscopeDataContract operation
        /// </summary>
        public static EndoscopeDataContract GetEndoscopeDataContract(opsapp_GetEndscopeLocationData_Result endoscopeLocationData)
        {
            if (endoscopeLocationData == null) return null;

            return new EndoscopeDataContract()
            {
                ContainerMasterName = endoscopeLocationData.ContainerMasterText,
                ContainerInstancePrimaryId = endoscopeLocationData.ContainerInstancePrimaryId,
                ContainerInstanceId = endoscopeLocationData.ContainerInstanceId,
                ContainerInstanceDeliveryPoint = new DeliveryPointDataContract()
                {
                    Id = endoscopeLocationData.DeliveryPointId,
                    Name = endoscopeLocationData.DeliveryPointText
                },

                FacilityId = endoscopeLocationData.ContainerInstanceFacilityId,
                ContainerInstanceCreated = endoscopeLocationData.ContainerInstanceCreated,
                TurnaroundWarningCount = endoscopeLocationData.TurnaroundWarningCount,
                ContainerMasterDefinitionId = endoscopeLocationData.ContainerMasterDefinitionId,

                ContainerMasterId = endoscopeLocationData.ContainerMasterId,
                ContainerMasterExternalId = endoscopeLocationData.ContainerInstancePrimaryId,
                IsContainerMasterArchived = endoscopeLocationData.ContainerMasterArchived.HasValue,
                IsContainerInstanceArchived = endoscopeLocationData.ContainerInstanceArchived.HasValue,
                ItemTypeId = endoscopeLocationData.ContainerMasterItemTypeId,
                ItemTypeText = endoscopeLocationData.ItemTypeText,
                BaseItemTypeId = endoscopeLocationData.ItemTypeParentItemTypeId ?? endoscopeLocationData.ContainerMasterItemTypeId,
                TrackIndividualInstruments = endoscopeLocationData.TrackIndividualInstruments,
                MachineTypeId = endoscopeLocationData.ContainerMasterMachineTypeId,
                Linear1DBarcodeId = endoscopeLocationData.Linear1dBarcodeId,
                Datamatrix2DBarcodeId = endoscopeLocationData.Datamatrix2dBarcodeId,
                IsIdentifiable = endoscopeLocationData.IsIdentifiable,
                CustomerDefinitionId = endoscopeLocationData.CustomerDefinitionId,
                SterileExpiryDateTime = endoscopeLocationData.CurrentTurnaroundSterileExpiryDate.HasValue ? DateTime.SpecifyKind(endoscopeLocationData.CurrentTurnaroundSterileExpiryDate.Value, DateTimeKind.Utc) : (DateTime?)null
            };
        }

        /// <summary>
        /// GetEndoscopeDataContract operation
        /// </summary>
        public static EndoscopeDataContract GetEndoscopeDataContract(ContainerInstance containerInstance)
        {
            if (containerInstance == null) return null;

            var containerMaster = containerInstance.ContainerMasterDefinition.ContainerMaster;
            return new EndoscopeDataContract()
            {
                ContainerMasterName = containerMaster.Text,
                ContainerInstancePrimaryId = containerInstance.PrimaryId,
                ContainerInstanceId = containerInstance.ContainerInstanceId,
                ContainerInstanceDeliveryPoint = new DeliveryPointDataContract()
                {
                    Id = containerInstance.DeliveryPoint.DeliveryPointId,
                    Name = containerInstance.DeliveryPoint.Text
                },

                FacilityId = containerInstance.FacilityId,
                ContainerInstanceCreated = containerInstance.Created,
                TurnaroundWarningCount = containerInstance.TurnaroundWarningCount,
                ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId,

                ContainerMasterId = containerMaster.ContainerMasterId,
                ContainerMasterExternalId = containerMaster.ExternalId,
                IsContainerMasterArchived = containerMaster.Archived.HasValue,
                IsContainerInstanceArchived = containerInstance.Archived.HasValue,
                ItemTypeId = containerMaster.ItemTypeId,
                ItemTypeText = containerMaster.ItemType.Text,
                BaseItemTypeId = containerMaster.ItemType.ParentItemTypeId ?? containerMaster.ItemTypeId,
                TrackIndividualInstruments = containerMaster.TrackIndividualInstruments,
                MachineTypeId = containerMaster.MachineTypeId,
                Linear1DBarcodeId = containerInstance.Linear1dBarcodeId,
                Datamatrix2DBarcodeId = containerInstance.Datamatrix2dBarcodeId,
                IsIdentifiable = containerInstance.IsIdentifiable,
                CustomerDefinitionId = containerMaster.ContainerMasterDefinition.CustomerDefinitionId,
                SterileExpiryDateTime = containerInstance.CurrentTurnaround?.SterileExpiryDate != null
                                            ? DateTime.SpecifyKind(containerInstance.CurrentTurnaround.SterileExpiryDate.Value, DateTimeKind.Utc)
                                            : (DateTime?)null
            };
        }

        private static EndoscopeDataContract GetEndoscopeDataContract(opsapp_GetEndoscopeOverview_Result getEndoscopeOverview_Result)
        {
            var result = new EndoscopeDataContract
            {
                FacilityId = getEndoscopeOverview_Result.FacilityId,
                ContainerInstanceId = getEndoscopeOverview_Result.ContainerInstanceId,
                ContainerInstancePrimaryId = getEndoscopeOverview_Result.ContainerInstancePrimaryId,
                Linear1DBarcodeId = getEndoscopeOverview_Result.Linear1dBarcodeId,
                Datamatrix2DBarcodeId = getEndoscopeOverview_Result.Datamatrix2dBarcodeId,
                ContainerInstanceDeliveryPoint = new DeliveryPointDataContract
                {
                    Id = getEndoscopeOverview_Result.DeliveryPointId,
                    Name = getEndoscopeOverview_Result.DeliveryPointText
                },
                ContainerMasterName = getEndoscopeOverview_Result.ContainerMasterText,
                LocationId = getEndoscopeOverview_Result.LocationId.HasValue ? getEndoscopeOverview_Result.LocationId.Value : default(int),
                LocationText = getEndoscopeOverview_Result.LocationText
            };

            var warningMinutes = FacilitySettings.EndoscopeAboutToExpireWarningMinutes(getEndoscopeOverview_Result.FacilityId.Value) * -1;

            switch ((TurnAroundEventTypeIdentifier)getEndoscopeOverview_Result?.CurrentProcessEventTypeId)
            {
                case TurnAroundEventTypeIdentifier.IntoDryingCabinet:
                    var intoCabDateTime = getEndoscopeOverview_Result.CurrentProcessEventCreated;
                    var maxDryTimeMinutes = MachineSettings.EndoscopeMaxDryingTimeOrDefault(getEndoscopeOverview_Result.MachineId.Value);
                    var machineRunTimeMinutes = getEndoscopeOverview_Result.MachineRunningTime.Value;

                    SetEndoscopeDryingCabinetData(result, intoCabDateTime, maxDryTimeMinutes, machineRunTimeMinutes, warningMinutes);
                    SetEndoscopeDryingCabinetStatus(result);

                    break;
                case TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetDry:
                case TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetWet:
                case TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetExpired:
                case TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetAutomatic:
                    result.Status = EndoscopeStatus.DryingCabinetRemoved;
                    result.LocationId = getEndoscopeOverview_Result.LastKnownLocationId.Value;
                    result.LocationText = getEndoscopeOverview_Result.LastKnownLocationText;
                    break;
                case TurnAroundEventTypeIdentifier.Inbound:
                    result.Status = EndoscopeStatus.Inbound;
                    break;
                case TurnAroundEventTypeIdentifier.DeconStart:
                case TurnAroundEventTypeIdentifier.PreAerDeconTaskSuccess:
                case TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure:
                case TurnAroundEventTypeIdentifier.DeconCancel:
                case TurnAroundEventTypeIdentifier.DeconEnd:
                case TurnAroundEventTypeIdentifier.RerouteToWash:
                    result.Status = EndoscopeStatus.Decontamination;
                    break;
                case TurnAroundEventTypeIdentifier.AssignedToAer:
                case TurnAroundEventTypeIdentifier.AerStart:
                    result.Status = EndoscopeStatus.AER;
                    break;
                case TurnAroundEventTypeIdentifier.AerPassed:
                    result.Status = EndoscopeStatus.AerPassed;
                    result.LocationId = getEndoscopeOverview_Result.LastKnownLocationId.Value;
                    result.LocationText = getEndoscopeOverview_Result.LastKnownLocationText;
                    break;
                case TurnAroundEventTypeIdentifier.AerFailed:
                    result.Status = EndoscopeStatus.AerFailed;
                    result.LocationId = getEndoscopeOverview_Result.LastKnownLocationId.Value;
                    result.LocationText = getEndoscopeOverview_Result.LastKnownLocationText;
                    break;
                case TurnAroundEventTypeIdentifier.RemovedFromAer:
                    result.Status = EndoscopeStatus.RemovedFromAer;
                    result.LocationId = getEndoscopeOverview_Result.LastKnownLocationId.Value;
                    result.LocationText = getEndoscopeOverview_Result.LastKnownLocationText;
                    break;
                case TurnAroundEventTypeIdentifier.VacuumPackedDry:
                case TurnAroundEventTypeIdentifier.VacuumPackedWet:
                case TurnAroundEventTypeIdentifier.IntoPigeonHoleStock:
                    result.Status = EndoscopeStatus.VacuumPacked;
                    result.SterileExpiryDateTime = getEndoscopeOverview_Result.SterileExpiryDate.Value;
                    result.AboutToExpireAtDateTime = DateTime.SpecifyKind(result.SterileExpiryDateTime.Value.AddMinutes(warningMinutes), DateTimeKind.Utc); ;
                    SetEndoscopeVacuumPackedStatus(result);
                    break;
                case TurnAroundEventTypeIdentifier.OutOfPigeonHoleStock:
                    result.Status = EndoscopeStatus.VacuumPackedRemoved;
                    result.LocationId = getEndoscopeOverview_Result.LastKnownLocationId.Value;
                    result.LocationText = getEndoscopeOverview_Result.LastKnownLocationText;
                    break;
                case TurnAroundEventTypeIdentifier.IntoQuarantine:
                    result.Status = EndoscopeStatus.Quarantined;
                    break;
                case TurnAroundEventTypeIdentifier.Archived:
                    result.Status = EndoscopeStatus.Archived;
                    result.LocationId = getEndoscopeOverview_Result.LastKnownLocationId.Value;
                    result.LocationText = getEndoscopeOverview_Result.LastKnownLocationText;
                    break;
                case TurnAroundEventTypeIdentifier.EndoscopyDispatch:
                    result.Status = EndoscopeStatus.Dispatch;
                    break;
                default:
                    result.Status = EndoscopeStatus.Unknown;
                    break;
            }

            return result;
        }

        private static int EndoscopeMaxDryingTimeOrDefault(Machine dryingCabinet)
        {
            var settingFromCab = dryingCabinet?.MachineSetting.FirstOrDefault(ms => ms.Name == KnownMachineSetting.MaxDryingTime)?.Value;
            if (settingFromCab != null && settingFromCab != "0")
            {
                int castResult;
                int.TryParse(settingFromCab, out castResult);
                return castResult;
            }

            return MachineSettings.EndoscopeMaxDryingTimeOrDefault(dryingCabinet.MachineId);
        }

        private static void SetEndoscopeDryingCabinetData(EndoscopeDataContract endoscopeDataContract, DateTime? intoCabDateTime, int maxDryTimeMinutes, short machineRunTimeMinutes, int warningMinutes)
        {
            endoscopeDataContract.DryAtDateTime = DateTime.SpecifyKind(intoCabDateTime.Value.AddMinutes(machineRunTimeMinutes), DateTimeKind.Utc);
            endoscopeDataContract.AboutToExpireAtDateTime = DateTime.SpecifyKind(intoCabDateTime.Value.AddMinutes(maxDryTimeMinutes).AddMinutes(warningMinutes), DateTimeKind.Utc);
            endoscopeDataContract.SterileExpiryDateTime = DateTime.SpecifyKind(intoCabDateTime.Value.AddMinutes(maxDryTimeMinutes), DateTimeKind.Utc);
        }

        /// <summary>
        /// GetEndoscopeDataContract operation
        /// </summary>
        public static EndoscopeDataContract GetEndoscopeDataContract(opsapp_GetEndscopeLocationData_Result endoscopeLocationData, Machine dryingCabinet)
        {
            var scope = GetEndoscopeDataContract(endoscopeLocationData);

            if (scope == null) return null;
            if (endoscopeLocationData.CurrentTurnaroundEventEventTypeId == (int)TurnAroundEventTypeIdentifier.IntoDryingCabinet)
            {
                var intoCabDateTime = endoscopeLocationData.TunraroundEventCreated;
                var maxDryTimeMinutes = EndoscopeMaxDryingTimeOrDefault(dryingCabinet);
                var machineRunTimeMinutes = dryingCabinet.RunningTime;
                var warningMinutes = FacilitySettings.EndoscopeAboutToExpireWarningMinutes(endoscopeLocationData.ContainerInstanceFacilityId) * -1;

                SetEndoscopeDryingCabinetData(scope, intoCabDateTime, maxDryTimeMinutes, machineRunTimeMinutes, warningMinutes);
                SetEndoscopeDryingCabinetStatus(scope);
            }

            return scope;
        }

        private static void SetEndoscopeDryingCabinetStatus(EndoscopeDataContract scope)
        {
            var now = DateTime.UtcNow;
            if (IsDate(scope.DryAtDateTime) && now < scope.DryAtDateTime)
            {
                scope.Status = EndoscopeStatus.DryingCabinetWet;
                return;
            }

            if (IsDate(scope.DryAtDateTime) && IsDate(scope.AboutToExpireAtDateTime) && now >= scope.DryAtDateTime && now < scope.AboutToExpireAtDateTime)
            {
                scope.Status = EndoscopeStatus.DryingCabinetDry;
                return;
            }

            if (IsDate(scope.AboutToExpireAtDateTime) && IsDate(scope.SterileExpiryDateTime) && now >= scope.AboutToExpireAtDateTime && now < scope.SterileExpiryDateTime)
            {
                scope.Status = EndoscopeStatus.DryingCabinetAboutToExpire;
                return;
            }
            if (IsDate(scope.SterileExpiryDateTime) && now >= scope.SterileExpiryDateTime)
            {
                scope.Status = EndoscopeStatus.DryingCabinetExpired;
                return;
            }
        }

        /// <summary>
        /// SetEndoscopeVacuumPackedStatus operation
        /// </summary>
        public static void SetEndoscopeVacuumPackedStatus(EndoscopeDataContract scope)
        {
            var now = DateTime.UtcNow;

            if (EndoscopeHelper.IsDate(scope.AboutToExpireAtDateTime) && EndoscopeHelper.IsDate(scope.SterileExpiryDateTime) && now >= scope.AboutToExpireAtDateTime && now < scope.SterileExpiryDateTime)
            {
                scope.Status = EndoscopeStatus.VacuumPackedAboutToExpire;
            }
            else if (EndoscopeHelper.IsDate(scope.SterileExpiryDateTime) && now >= scope.SterileExpiryDateTime)
            {
                scope.Status = EndoscopeStatus.VacuumPackedExpired;
            }
            else
            {
                scope.Status = EndoscopeStatus.VacuumPacked;
            }
        }

        internal static bool IsDate(DateTime? dt) => dt.HasValue && dt.Value.Year != 1900;

        /// <summary>
        /// Checks if a scope is currently expired or about to expire
        /// </summary>
        /// <param name="scope">The <see cref="EndoscopeDataContract"/> to check.</param>
        /// <param name="warningMinutes">About to expire warning period. NOTE: NEGATIVE VALUE here!!!</param>
        /// <returns></returns>
        public static (bool expired, bool almostExpired) GetIsExpired(EndoscopeDataContract scope, int warningMinutes)
        {
            if (scope.SterileExpiryDateTime.HasValue)
            {
                if (scope.SterileExpiryDateTime.Value < DateTime.UtcNow)
                {
                    return (true, false);
                }
                if (DateTime.UtcNow >= scope.SterileExpiryDateTime.Value.AddMinutes(warningMinutes))
                {
                    return (false, true);
                }
            }

            return (false, false);
        }

        /// <summary>
        /// GetEndoscopeOverviewData operation
        /// </summary>
        public static List<EndoscopeDataContract> GetEndoscopeOverviewData(BaseRequestDataContract request)
        {
            var results = new List<EndoscopeDataContract>();

            using (var context = new OperativeModelContainer())
            {
                var data = context.opsapp_GetEndoscopeOverview(
                    request.FacilityId,
                    KnownMachineSetting.MaxDryingTime,
                    MachineSettings.DEFAULT_MAX_DRYING_TIME_MINS);

                foreach (var d in data)
                {
                    results.Add(GetEndoscopeDataContract(d));
                }
            }

            return results;
        }

        /// <summary>
        /// Inbound operation
        /// </summary>
        public static ScanAssetDataContract Inbound(ScanDetails scanDetails) => EndoscopeStartEvent(scanDetails, TurnAroundEventTypeIdentifier.Inbound);

        /// <summary>
        /// DeconStart operation
        /// </summary>
        public static ScanAssetDataContract DeconStart(ScanDetails scanDetails) => EndoscopeStartEvent(scanDetails, TurnAroundEventTypeIdentifier.DeconStart);

        private static ScanAssetDataContract EndoscopeStartEvent(ScanDetails scanDetails, TurnAroundEventTypeIdentifier startEventType)
        {
            var dataContract = new ScanAssetDataContract();

            if (scanDetails == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.InvalidRequest;
                return dataContract;
            }

            try
            {
                scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)startEventType });
                var startEventDataContract = new ScanAssetDataContract();
                var mk3 = new SynergyTrakHelperMk3(new Models.SynergyTrakData(), true);
                mk3.Scan(scanDetails, startEventDataContract);

                return startEventDataContract;
            }
            catch
            {
                dataContract.ErrorCode = (int)ErrorCodes.Unknown;
            }

            return dataContract;
        }

        /// <summary>
        /// CheckRetroAddOutOfDryingCabAutoEvent operation
        /// </summary>
        public static bool CheckRetroAddOutOfDryingCabAutoEvent(ScanDetails scanDetails, ScanAssetDataContract dataContract)
        {
            if (dataContract.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.IntoDryingCabinet)
            {
                if (!dataContract.ApprovedByUserId.HasValue)
                {
                    var scopeNameAndId = $"{dataContract?.Asset?.ContainerMasterName ?? string.Empty}  {scanDetails.ExternalId ?? string.Empty}";

                    using (IUnitOfWork operativeWorkUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                    {
                        var locationRepository = LocationRepository.New(operativeWorkUnit);

                        var intoCabinetTurnaroundEvent = dataContract.TurnaroundEvents.FirstOrDefault(e => e.TurnaroundEventId == dataContract.LastProcessEventId);
                        var intoCabinetLocation = locationRepository.Get(intoCabinetTurnaroundEvent.LocationId.Value);

                        var locationName = string.Empty;
                        var dryingCabinetName = string.Empty;

                        if (intoCabinetLocation != null && intoCabinetLocation.Leaf != null)
                        {
                            var shelfLeft = intoCabinetLocation.Leaf.Lft;
                            var shelfRight = intoCabinetLocation.Leaf.Rgt;
                            var parentTree = intoCabinetLocation.Leaf.Tree.Leaf.Where(l => l.Lft <= shelfLeft && l.Rgt > shelfRight).OrderBy(l => l.Lft);
                            dryingCabinetName = parentTree?.FirstOrDefault()?.Location.FirstOrDefault()?.Text;
                            locationName = intoCabinetLocation.Leaf.Tree.Machine.FirstOrDefault()?.Location.FirstOrDefault()?.Text;
                        }

                        var warningText = TranslatorManager.GetText(sectionGroup, section, "EndoscopyCreateRemoveFromCabAutoEventWarning", false, scanDetails.Culture);

                        dataContract.Message = string.Format(warningText, scopeNameAndId, locationName, dryingCabinetName).Replace("\\n", "\n");
                        dataContract.ErrorCode = (int)ErrorCodes.ApprovedByUserIdRequired;

                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// PrintLabel operation
        /// </summary>
        public static EndoscopyScanDataContract PrintLabel(ScanDetails scanDetails)
        {
            var dataContract = new EndoscopyScanDataContract();

            if (scanDetails == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.InvalidRequest;
                return dataContract;
            }

            try
            {
                scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.PrintLabel });
                var printEventDataContract = new EndoscopyScanDataContract();
                var mk3 = new SynergyTrakHelperMk3(new Models.SynergyTrakData(), true);
                mk3.Scan(scanDetails, printEventDataContract);
                if (printEventDataContract.ErrorCode.HasValue || printEventDataContract.Asset == null)
                    return printEventDataContract;

                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                    var containerInstance = containerInstanceRepository.Get(printEventDataContract.Asset.ContainerInstanceId.Value);

                    printEventDataContract.Endoscope = EndoscopeHelper.GetEndoscopeDataContract(containerInstance);
                }

                return printEventDataContract;
            }
            catch
            {
                dataContract.ErrorCode = (int)ErrorCodes.Unknown;
            }

            return dataContract;
        }

        /// <summary>
        /// Dispatch operation
        /// </summary>
        public static EndoscopyScanDataContract Dispatch(ScanDetails scanDetails)
        {
            var dataContract = new EndoscopyScanDataContract();

            if (scanDetails == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.InvalidRequest;
            }
            else
            { 
                try
                {
                    scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.EndoscopyDispatch });
                    var mk3 = new SynergyTrakHelperMk3(new Models.SynergyTrakData(), true);
                    mk3.Scan(scanDetails, dataContract);

                    if (dataContract.ErrorCode.HasValue || dataContract.Asset == null)
                        return dataContract;

                    {
                        var containerInstanceRepository = new ContainerInstanceRepository(workUnit);
                        var containerInstance = containerInstanceRepository.Get(dataContract.Asset.ContainerInstanceId.Value);

                        dataContract.Endoscope = EndoscopeHelper.GetEndoscopeDataContract(containerInstance);
                    }
                }
                catch
                {
                    dataContract.ErrorCode = (int)ErrorCodes.Unknown;
                }
            }

            return dataContract;
        }
    }
}