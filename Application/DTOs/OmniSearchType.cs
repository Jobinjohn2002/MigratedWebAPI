using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Relates to what detailed search type will be returned
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public enum OmniSearchType
    {
        /// <summary>
        /// Facility search type
        /// </summary>

        /// <summary>
        /// Items search type
        /// </summary>
        [EnumMember]
        Items = 1,

        /// <summary>
        /// Instruments search type
        /// </summary>
        [EnumMember]
        Instruments = 2,
        /// <summary>
        /// Instances search type
        /// </summary>
        [EnumMember]
        Instances = 3,
        /// <summary>
        /// Turnarounds search type
        /// </summary>
        [EnumMember]
        Turnarounds = 4,
        /// <summary>
        /// DeliveryNotes search type
        /// </summary>
        [EnumMember]
        DeliveryNotes = 5,
        /// <summary>
        /// Defects search type
        /// </summary>
        [EnumMember]
        Defects = 6,

        /// <summary>
        /// User search type
        /// </summary>
        [EnumMember]
        Users = 7,

        /// <summary>
        /// Customer search type
        /// </summary>
        [EnumMember]
        Customers = 8,
        /// <summary>
        /// Batch search type
        /// </summary>
        [EnumMember]
        Batches = 9,

        /// <summary>
        /// Delivery Point search type
        /// </summary>
        [EnumMember]
        DeliveryPoints = 10,

            /// <summary>
        /// LoanSets search type
        /// </summary>
        [EnumMember]
        LoanSets = 11,

         /// <summary>
        /// MaintenanceReports search type
        /// </summary>
        [EnumMember]
        MaintenanceReports = 12
}
}
