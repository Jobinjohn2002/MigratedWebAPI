using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IEnquiryStationService
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IEnquiryStationService
    /// </summary>
    public interface IEnquiryStationService
    {
        StationEnquiryData NewEnquiryByTurnaroundExternalId(long turnaroundExternalId, int userId, int stationId);
        StationEnquiryData NewEnquiryByContainerInstanceExternalId(string containerInstanceExternalId, int userId, int stationId);
        StationEnquiryData NewEnquiryByContainerInstanceId(int containerInstanceId, int userId, int stationId);

        /// <summary>
        /// News the enquiry.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="enquiryTypeIdentifier">The enquiry type identifier.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        StationEnquiryData NewEnquiryUsingFacilityId(string identifier, short facilityId, int userId, int stationId, EnquiryTypeIdentifier enquiryTypeIdentifier);

    }
}