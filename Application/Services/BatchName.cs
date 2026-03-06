using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class BatchName
    {
        /// <summary>
        /// GetNextBatchName operation
        /// </summary>
        public static string GetNextBatchName(Machine machine, short facilityId, DateTime? createdBatchTime)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                DateTime? createBatchLocalTime = null;
                string localDateTime = null;
                Data.Models.Operative.TimeZone timezone = null;

                var facilitySettingRepo = new FacilitySettingRepository(workUnit);
                var useDateBasedBatchIdFormat = facilitySettingRepo.ReadFacilitySetting<bool>(facilityId, KnownFacilitySetting.UseDateBasedBatchIdFormat);
                if (useDateBasedBatchIdFormat)
                {
                    var ownerRepo = new OwnerRepository(workUnit);
                    var owner = ownerRepo.GetByFacilityId(facilityId);
                    timezone = owner.TimeZone;

                    var batchIdFormat = facilitySettingRepo.ReadFacilitySetting<string>(facilityId, KnownFacilitySetting.DateBasedBatchIdFormat);
                    createBatchLocalTime = createdBatchTime?.ToLocalTime(timezone.Text) ?? DateTime.MinValue;
                    localDateTime = FormatLocalDateTime(createBatchLocalTime.Value, batchIdFormat);
                }

                var lastBatch = GetLatestBatchForMachine(machine, workUnit);
                var nextBatchNumber = GetNextBatchNumber(lastBatch, timezone, createBatchLocalTime);

                return GenerateFullBatchName(machine.BatchPrefix, localDateTime, nextBatchNumber);
            }
        }

        private static Batch GetLatestBatchForMachine(Machine machine, IUnitOfWork workUnit)
        {
            if (machine.MachineGroup != null)
            {
                var machineGroupRepo = new MachineGroupRepository(workUnit);
                return machineGroupRepo.GetLastBatchByMachineGroupId(machine.MachineGroup.MachineGroupId);
            }
            else
            {
                var batchRepository = new BatchRepository(workUnit);
                return batchRepository.GetLastBatchByMachineId(machine.MachineId);
            }
        }

        private static int GetNextBatchNumber(Batch lastBatch, Data.Models.Operative.TimeZone timezone, DateTime? createBatchLocalTime)
        {
            if (lastBatch == null)
            {
                return 1;
            }

            if (createBatchLocalTime.HasValue && createBatchLocalTime.Value.Date != lastBatch.Created.ToLocalTime(timezone.Text).Date)
            {
                return 1;
            }

            if (!string.IsNullOrEmpty(lastBatch?.ExternalId))
            {
                var split = lastBatch.ExternalId.Split('-');

                if (split.Length > 1 && int.TryParse(split[split.Length - 1], out int number))
                {
                    return number + 1;
                }
            }

            return 1;
        }

        private static string FormatLocalDateTime(DateTime createBatchLocalTime, string batchIdFormat)
        {
            try
            {
                if (string.IsNullOrEmpty(batchIdFormat))
                {
                    return createBatchLocalTime.ToString(FormatString.DateBasedBatchIdFormatDefault);
                }
                else
                {
                    return createBatchLocalTime.ToString(batchIdFormat);
                }
            }
            catch (FormatException)
            {
                return createBatchLocalTime.ToString(FormatString.DateBasedBatchIdFormatDefault);
            }
        }

        private static string GenerateFullBatchName(string prefix, string localDateTime, int NextBatchNumber)
        {
            if (string.IsNullOrEmpty(localDateTime))
            {
                return $"{prefix}-{NextBatchNumber}";
            }

            return $"{prefix}-{localDateTime}-{NextBatchNumber}";
        }
    }
}