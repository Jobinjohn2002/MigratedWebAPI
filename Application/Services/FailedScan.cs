using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class FailedScan
    {
        /// <summary>
        /// AddFailedScanTurnaround operation
        /// </summary>
        public static void AddFailedScanTurnaround(string input, int userId, Enums.TurnAroundEventTypeIdentifier nominalEvent, DateTime? createdDate = null)
                => Add(input, ScanType.Turnaround, userId, nominalEvent, createdDate: createdDate);

        /// <summary>
        /// Add operation
        /// </summary>
        public static void Add(string input, ScanType scanType, int userId, TurnAroundEventTypeIdentifier nominalEvent, int? stationId = null, int? stationLocationId = null, DateTime? createdDate = null)
        {
            try
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var failedScanRepository = FailedScanRepository.New(workUnit);

                    var failedScan = FailedScanFactory.CreateEntity(workUnit,
                        createdDate: createdDate ?? DateTime.UtcNow,
                        createdByUserId: userId,
                        eventTypeId: (short)nominalEvent,
                        input: input,
                        locationId: stationLocationId,
                        scanTypeId: (short)scanType,
                        stationId: stationId ?? 0
                    );

                    failedScanRepository.Add(failedScan);
                    failedScanRepository.Save();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Add operation
        /// </summary>
        public static void Add(string input, short scanType, int user, int station, int? location, short? nominalEvent, DateTime? createdDate = null)
        {
            try
            {
                {
                    var failedScanRepository = FailedScanRepository.New(workUnit);

                    var failedScan = FailedScanFactory.CreateEntity(workUnit,
                        createdDate: createdDate ?? DateTime.UtcNow,
                        createdByUserId: user,
                        eventTypeId: nominalEvent,
                        input: input,
                        locationId: location.HasValue && location > 0 ? location : null,
                        scanTypeId: scanType,
                        stationId: station
                    );

                    failedScanRepository.Add(failedScan);
                    failedScanRepository.Save();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Add operation
        /// </summary>
        public static void Add(string input, ScanType scanType, int user, int station, int? location, TurnAroundEventTypeIdentifier nominalEvent, DateTime? createdDate = null)
        {
            Add(input, (short)scanType, user, station, location, (short)nominalEvent, createdDate);
        }

        /// <summary>
        /// Add operation
        /// </summary>
        public static void Add(object input, ScanType scanType, int user, int station, int? location, TurnAroundEventTypeIdentifier nominalEvent, DateTime? createdDate = null)
        {
            Add(input.ToString(), (short)scanType, user, station, location, (short)nominalEvent, createdDate);
        }
    }
}