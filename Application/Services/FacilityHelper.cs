using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class FacilityHelper
    {
        /// <summary>
        /// IsOperativeDifferentDeliveryPointBatchTagWarning operation
        /// </summary>
        public static DeliveryPointBatchTagSetting IsOperativeDifferentDeliveryPointBatchTagWarning(short facilityId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                DeliveryPointBatchTagSetting deliveryPointBatchTagSetting = DeliveryPointBatchTagSetting.Off;

                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                var setting = facilitySettingRepository.ReadFacilitySetting<int?>(facilityId, KnownFacilitySetting.OperativeDifferentDeliveryPointBatchTagWarning);

                var success = (setting != null && Enum.IsDefined(typeof(DeliveryPointBatchTagSetting), setting));

                if (success)
                {
                    deliveryPointBatchTagSetting = (DeliveryPointBatchTagSetting)Enum.Parse(typeof(DeliveryPointBatchTagSetting), setting.ToString());
                }

                return deliveryPointBatchTagSetting;
            }
        }
    }
}