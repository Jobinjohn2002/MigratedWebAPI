using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderLinesData
    /// </summary>
    public class OrderLinesData
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        public int? ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemLocation
        /// </summary>
        public string ItemLocation { get; set; }
        public int? Required { get; set; }
        public int? ContainerInstanceId { get; set; }
        public int? Available { get; set; }
        /// <summary>
        /// Gets or sets Picked
        /// </summary>
        public int Picked { get; set; }
        /// <summary>
        /// Gets or sets OrderlineStatus
        /// </summary>
        public int OrderlineStatus { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        public int? TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets OrderLineId
        /// </summary>
        public int OrderLineId { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
    }
}
