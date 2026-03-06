using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IFacilityService
    /// </summary>
    public interface IFacilityService
    {
        /// <summary>
        /// Reads the facilities, associated customers and associated delivery points by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<BasicFacilityData> ReadFacilitiesCustomersDeliveryPointsByUser(int userId, int tenancyId);
        IList<FacilitySettingDataContract> ReadSettingsByFacilityId(short facilityId);

        /// <summary>
        /// Read facility assigned item types by facility
        /// </summary>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<FacilityItemTypeData> ReadFacilityItemTypes(short facilityId);

        /// <summary>
        /// Reading Planned Maintenance Flag Settings by facilityId
        /// </summary>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        List<PlannedMaintenanceFlagSettingsData> GetPlannedMaintenanceFlagSettings(short facilityId);

        /// <summary>
        /// Delete Planned Maintenance Flag Settings by facilityId
        /// </summary>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool DeletePlannedMaintenanceFlagSettings(short facilityId);

        /// <summary>
        /// Updates  Planned Maintenance Flag Settings
        /// </summary>
        /// <param name="facilityId">The facilityId parameter.</param>
        /// <param name="settings">The settings parameter.</param>
        OperationResponseContract UpdatePlannedMaintenanceFlagSettings(short facilityId, List<PlannedMaintenanceFlagSettingsData> settings);
        OperationResponseContract UpdateFacilitySettings(FacilityData facility, string settingName, int userId);
    }
}

