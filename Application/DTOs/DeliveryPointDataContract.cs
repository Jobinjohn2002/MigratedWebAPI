using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// DeliveryPointDataContract
    /// </summary>
    public class DeliveryPointDataContract
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets IsStockLocation
        /// </summary>
        public bool IsStockLocation { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets HasExtras
        /// </summary>
        public bool HasExtras { get; set; }
        /// <summary>
        /// Gets or sets IsSelected
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Gets or sets RestrictedForTrolleys
        /// </summary>
        public bool RestrictedForTrolleys { get; set; }

    }
}