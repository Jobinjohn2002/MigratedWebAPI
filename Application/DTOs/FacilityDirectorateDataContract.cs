using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityDirectorateDataContract
    /// </summary>
    public class FacilityDirectorateDataContract
    {
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryName
        /// </summary>
        public string DeliveryName { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        public int? DirectorateId { get; set; }
        /// <summary>
        /// Gets or sets DirectorateName
        /// </summary>
        public string DirectorateName { get; set; }
        /// <summary>
        /// Gets or sets HasDeliveryPoint
        /// </summary>
        public bool HasDeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public byte CustomerStatusId { get; set; }
        public DateTime? Archived { get; set; }

    }
}
