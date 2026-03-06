using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class EndoscopyVacPackHelper
    {
        /// <summary>
        /// Create operation
        /// </summary>
        public static EndoscopeDataContract Create(opsapp_GetEndscopeLocationData_Result endoscopeLocationData)
        {
            var scope = EndoscopeHelper.GetEndoscopeDataContract(endoscopeLocationData);

            if (scope != null)
            {
                scope.IsVacPack = true;
                scope.SterileExpiryDateTime = endoscopeLocationData.CurrentTurnaroundSterileExpiryDate != null ? DateTime.SpecifyKind(endoscopeLocationData.CurrentTurnaroundSterileExpiryDate.Value, DateTimeKind.Utc) : (DateTime?)null;

                var warningMinutes = FacilitySettings.EndoscopeAboutToExpireWarningMinutes(endoscopeLocationData.ContainerInstanceFacilityId) * -1;
                scope.AboutToExpireAtDateTime = scope.SterileExpiryDateTime?.AddMinutes(warningMinutes);
                EndoscopeHelper.SetEndoscopeVacuumPackedStatus(scope);
            }

            return scope;
        }

        /// <summary>
        /// VacuumPack operation
        /// </summary>
        public static ScanAssetDataContract VacuumPack(ScanDetails scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                ContainerInstance container;

                if (scanDetails.InstanceId != null)
                {
                    container = containerInstanceRepository.Get(scanDetails.InstanceId.Value);
                }
                else
                {
                    container = containerInstanceRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, false).FirstOrDefault();
                }

                var result = new ScanAssetDataContract();
                if (container?.CurrentTurnaround?.SterileExpiryDate <= DateTime.UtcNow)
                {
                    result.ErrorCode = (int)ErrorCodes.SterileExpiryExceeded;
                    return result;
                }

                TurnAroundEventTypeIdentifier eventToAppy = TurnAroundEventTypeIdentifier.VacuumPackedWet;
                if (container?.CurrentTurnaround?.CurrentTurnaroundEvent?.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetDry)
                {
                    eventToAppy = TurnAroundEventTypeIdentifier.VacuumPackedDry;
                }

                scanDetails.Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract
                    {
                        EventType = (int)eventToAppy
                    }
                };
                var machineRepository = MachineRepository.New(workUnit);
                var machine = machineRepository.Get(scanDetails.MachineId.Value);

                if (machine == null || machine.MachineTypeId != (byte)MachineTypeIdentifier.VacuumPacker)
                {
                    result.ErrorCode = (int)ErrorCodes.MachineTypeMismatch;
                    return result;
                }
                              

                var machineVacuumPackDryEnabled = MachineSettings.EndoscopeSterileExpiryVacuumPackedDryMinutes(machine.MachineId).HasValue;
                var machineVacuumPackWetEnabled = MachineSettings.EndoscopeSterileExpiryVacuumPackedWetMinutes(machine.MachineId).HasValue;

                ErrorCodes? misMatchErrorCode =null;

                if ((eventToAppy == TurnAroundEventTypeIdentifier.VacuumPackedWet && !machineVacuumPackWetEnabled) ||
                    (eventToAppy == TurnAroundEventTypeIdentifier.VacuumPackedDry && !machineVacuumPackDryEnabled))
                {
                    misMatchErrorCode = ErrorCodes.MachineTypeMismatch;
                }                
                var data = new Models.SynergyTrakData { StationId = scanDetails.StationId };
                var mk3Helper = new SynergyTrakHelperMk3(data, true);
                
                mk3Helper.Scan(scanDetails, result);

                if (result.ErrorCode ==null && misMatchErrorCode!=null)
                {//we have to add this wet/dry mismatch error after scan, so other errorcodes can take priority.
                    result.ErrorCode = (int)misMatchErrorCode;
                }

                return result;
            }
        }

        /// <summary>
        /// GetVacPackMachinesForStation operation
        /// </summary>
        public static List<VacPackMachineDataContract> GetVacPackMachinesForStation(int stationId)
        {
            using (var unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var stationRepository = StationRepository.New(unitOfWork);
                return stationRepository.GetVacPackMachinesByStation(stationId).Select(m => new VacPackMachineDataContract()
                {
                    MachineId = m.MachineId,
                    Name = m.Text
                }).ToList();
            }
        }
    }
}