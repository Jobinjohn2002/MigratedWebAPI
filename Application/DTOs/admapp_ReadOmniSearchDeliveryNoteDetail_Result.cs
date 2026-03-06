using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchDeliveryNoteDetail_Result
    {
        /// <summary>
        /// Gets or sets DeliveryNoteid
        /// </summary>
        public int DeliveryNoteid { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public Nullable<int> ExternalId { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public Nullable<int> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets Facilityid
        /// </summary>
        public short Facilityid { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets Customerid
        /// </summary>
        public int Customerid { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public byte CustomerStatusId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointid
        /// </summary>
        public int DeliveryPointid { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        public System.DateTime Printed { get; set; }
        /// <summary>
        /// Gets or sets PrintStatus
        /// </summary>
        public bool PrintStatus { get; set; }
    }
}
