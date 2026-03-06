using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class PerformanceCentreHelper
    {
        /// <summary>
        /// GetPerformanceTargets operation
        /// </summary>
        public static void GetPerformanceTargets(object obj, SynergyTrakData synergyTrakData)
        {
            var scanDC = obj as ScanAssetDataContract;

            if (scanDC != null && scanDC.Asset != null && scanDC.Asset.ContainerInstanceId.HasValue)
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                    var t = containerInstanceRepository.GetTargetTimeData(scanDC.Asset.ContainerInstanceId.Value, synergyTrakData.StationTypeId).FirstOrDefault();

                    if (t != null)
                    {
                        scanDC.TargetTimeSeconds = t.TargetTimeinSeconds;
                    }
                }

                scanDC.PercentageIpohVariance = GetIPOHVariance(synergyTrakData.UserId, synergyTrakData.StationTypeId);
            }
        }

        public static double? GetIPOHVariance(int userId, int stationTypeId)
        {
            {
                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                var u = containerInstanceRepository.GetUserPerformance(userId, stationTypeId).FirstOrDefault();

                if (u != null)
                {
                    return (double?)u.PercentageIPOHVariance;
                }
            }

            return null;
        }
    }
}