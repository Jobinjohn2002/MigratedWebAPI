using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class SterileExpiryHelper
    {
        private static int EndoscopeSterileExpiry(short? facilityId, int? machineId, TurnAroundEventTypeIdentifier eventType)
        {
            switch (eventType)
            {
                case TurnAroundEventTypeIdentifier.AerPassed:
                    return FacilitySettings.EndoscopeSterileExpiryAerPassedMinutes(facilityId.Value);
                case TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetWet:
                    return FacilitySettings.EndoscopeSterileExpiryRemovedFromDryingCabinetWetMinutes(facilityId.Value);
                case TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetDry:
                    return FacilitySettings.EndoscopeSterileExpiryRemovedFromDryingCabinetDryMinutes(facilityId.Value);
                case TurnAroundEventTypeIdentifier.VacuumPackedDry:
                    return MachineSettings.EndoscopeSterileExpiryVacuumPackedDryMinutes(machineId.Value) ?? 0;
                case TurnAroundEventTypeIdentifier.VacuumPackedWet:
                    return MachineSettings.EndoscopeSterileExpiryVacuumPackedWetMinutes(machineId.Value) ?? 0;
            }

            return 0;
        }

        /// <summary>
        /// UpdateSterileExpiry operation
        /// </summary>
        public static DateTime UpdateSterileExpiry(int turnaroundId, TurnAroundEventTypeIdentifier eventType, DateTime? startingPoint = null, int? machineId = null)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(turnaroundId);

                var sterileExpiryExtension = EndoscopeSterileExpiry(turnaround.FacilityId, machineId, eventType);

                if (startingPoint == null)
                {
                    startingPoint = DateTime.UtcNow;
                }

                turnaround.SterileExpiryDate = startingPoint.Value.AddMinutes(sterileExpiryExtension);

                turnaround.TurnaroundWH.ToList().ForEach(twh => twh.SterileExpiryDate = turnaround.SterileExpiryDate);

                workUnit.Save();
                return turnaround.SterileExpiryDate.Value;
            }
        }

        public static DateTime? UpdateSterileExpiry(ScanAssetDataContract scanDC)
        {
            DateTime? sterileExpiry = null;

            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.Value);

                var days = GetSterileExpiryDays(turnaround.TurnaroundId);
                var dpRepository = DeliveryPointRepository.New(workUnit);
                var customer = dpRepository.GetCustomerByDeliveryPoint(turnaround.DeliveryPointId);
                var customerTimezone = customer.CustomerDefinition.Owner.TimeZone.Text;
                var nowInCustomerZone = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));
                var dateCheckResult = false;

                if (turnaround.SterileExpiryDate != null)
                {
                    DateTime? expiryInCustomerZone = TimeZoneInfo.ConvertTimeFromUtc(turnaround.SterileExpiryDate.Value, TimeZoneInfo.FindSystemTimeZoneById(customerTimezone));

                    dateCheckResult = nowInCustomerZone.AddDays(days).Date.Equals(expiryInCustomerZone.Value.Date);
                }

                if ((turnaround.SterileExpiryDate == null) || (!dateCheckResult))
                {
                    turnaround.SterileExpiryDate = DateTime.UtcNow.AddDays(days);
                    sterileExpiry = turnaround.SterileExpiryDate;
                    turnaroundRepository.Save();

                    var turnaroundWhRepository = TurnaroundWHRepository.New(workUnit);
                    var turnaroundWh = turnaroundWhRepository.GetByTurnaround(turnaround.TurnaroundId);

                    if (turnaroundWh != null)
                    {
                        turnaroundWh.SterileExpiryDate = turnaround.SterileExpiryDate;
                        turnaroundWhRepository.Save();
                    }
                }
            }

            return sterileExpiry;
        }

        /// <summary>
        /// GetSterileExpiryDays operation
        /// </summary>
        public static int GetSterileExpiryDays(int turnaroundId)
        {
            int sterileExpiryDays;

            using (var repository = new PathwayRepository())
            {
                {
                    var context = repository.Container;
                    var parameters = new Dictionary<string, object>
                    {
                        {"TurnaroundId", turnaroundId}
                    };

                    var datacommand = DataCommandFactory.CreateCommand(context, System.Data.CommandType.StoredProcedure, "admapp_ReadSterilisationExpiryTime", parameters);
                    sterileExpiryDays = (int)datacommand.ExecuteScalar();
                }
            }
            return sterileExpiryDays;
        }
    }
}