using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.Services;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// PlannedMaintenance
    /// </summary>
    public class PlannedMaintenance : TurnaroundEvents
    {
        public PlannedMaintenance(SynergyTrakData data) : base(data)
        {
        }

        /// <summary>
        /// IsScheduled operation
        /// </summary>
        public static bool IsScheduled(ScanAssetDataContract scanDC)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    {"InstanceId", scanDC.Asset.ContainerInstanceId},
                    {"TurnaroundId", scanDC.TurnaroundId.GetValueOrDefault() }
                };

                var commandContext = new OperativeModelContainer();
                var datacommand = DataCommandFactory.CreateCommand(commandContext, System.Data.CommandType.StoredProcedure, "opsapp_ValidatePlannedMaintenanceRule", parameters);

                return (bool)datacommand.ExecuteScalar();
            }
            catch (Exception)
            {
                scanDC.ErrorCode = (int)ErrorCodes.ErrorReadingPlannedMaintenance;
            }

            return false;
        }

        /// <summary>
        /// CheckPlannedMaintenance operation
        /// </summary>
        public void CheckPlannedMaintenance(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            try
            {
                bool isUsingPlannedMaintenance;
                short pmFacilityId;
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var pmRepository = PlannedMaintenanceFlagSettingsRepository.New(workUnit);
                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    pmFacilityId = deliveryPointRepository.GetFacilityByDeliveryPoint(scanDC.DeliveryPtId).FacilityId;

                    isUsingPlannedMaintenance = pmRepository.Repository.Find(pm => pm.FacilityId == pmFacilityId && pm.StationTypeId == scanDC.StationTypeId).FirstOrDefault() != null;
                }

                if (isUsingPlannedMaintenance)
                {
                    var parameters = new Dictionary<string, object>
                    {
                        {"InstanceId", scanDC.Asset.ContainerInstanceId},
                        {"TurnaroundId", scanDC.TurnaroundId.GetValueOrDefault()},
                        {"FacilityId", pmFacilityId},
                        {"UserId", _data.UserId},
                        {"ProcessStationTypeId", _data.StationTypeId},
                        {"StationId", _data.StationId},
                        {"EventTypeId",_data.EventTypeId}
                    };

                    var commandContext = new OperativeModelContainer();
                    var datacommand = DataCommandFactory.CreateCommand(commandContext, System.Data.CommandType.StoredProcedure, "opsapp_RunAndCreatePlannedMaintenanceRule", parameters);

                    var reportData = datacommand.GetEntityList<PlannedMaintenanceReportData>().ToList();
                    if (reportData.Count > 0)
                    {
                        scanDC.PmWarned = new List<KeyValueDataContract>();
                        scanDC.PmQuarantined = new List<KeyValueDataContract>();

                        foreach (var t in reportData.GroupBy(i => i.ContainerInstancePrimaryId).Select(i => i.First()).ToList())
                        {
                            var formattedAlternateExternalId = string.IsNullOrEmpty(t.ContainerInstanceAlternateExternalId)? string.Empty : " - " + t.ContainerInstanceAlternateExternalId;

                            if ((!t.HasBeenWarned) && ((t.PlannedMaintenanceSettingFlag & 2) == 2))
                            {
                                scanDC.PmWarned.Add(new KeyValueDataContract { ContainerInstancePrimaryId = scanDC.Asset.ContainerInstancePrimaryId, TurnaroundId = t.TurnaroundId, Name = t.ContainerInstancePrimaryId + formattedAlternateExternalId });
                            }

                            if (!t.HasBeenQuarantined && ((t.PlannedMaintenanceSettingFlag & 4) == 4))
                            {
                                var quarantine = new Quarantine(_data);
                                quarantine.PutIntoQuarantine(scanDC, scanDetails, (int)QuarantineReasonIdentifier.PlannedMaintenance);

                                scanDC.PmQuarantined.Add(new KeyValueDataContract { ContainerInstancePrimaryId = scanDC.Asset.ContainerInstancePrimaryId, TurnaroundId = t.TurnaroundId, Name = t.ContainerInstancePrimaryId + formattedAlternateExternalId });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                scanDC.ErrorCode = (int)ErrorCodes.ErrorReadingPlannedMaintenance;
            }
        }

        /// <summary>
        /// UpdateStatus operation
        /// </summary>
        public void UpdateStatus(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            Log.Info("ProcessEvent CheckPlannedMaintenance");

            if ((scanDC.PmQuarantined != null) && (scanDC.PmQuarantined.Count > 0))
            {
                scanDC.IsInQuarantine = true;

                if (_data.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage)
                {
                    RemoveFromParent(scanDC);
                }
            }
            else if (_data.EventTypeId == TurnAroundEventTypeIdentifier.WashRelease && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BaseCarriage && scanDC.HasChildren)
            {
                foreach (var dc in _data.ScanDcList.Where(dc => dc != scanDC))
                {
                    if (dc.PmQuarantined != null && dc.PmQuarantined.Count > 0)
                    {
                        dc.IsInQuarantine = true;
                    }
                }
            }
        }
    }
}