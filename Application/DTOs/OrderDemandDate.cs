using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderDemandModel
    /// </summary>
    public class OrderDemandModel
    {
        /// <summary>
        /// Gets or sets SelectableDates
        /// </summary>
        public List<DateTime> SelectableDates { get; set; }
        public DateTime? SelectedStartDate { get; set; }
        /// <summary>
        /// Gets or sets SelectedContainerMasterExternalId
        /// </summary>
        public string SelectedContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets Dates
        /// </summary>
        public List<OrderDemandDate> Dates { get; set; }
        /// <summary>
        /// Gets or sets TypeaheadSource
        /// </summary>
        public List<string> TypeaheadSource { get; set; }
    }

    /// <summary>
    /// DemandDate
    /// </summary>
    public class DemandDate
    {
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }

    /// <summary>
    /// OrderDemandDate
    /// </summary>
    public class OrderDemandDate
    {
        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets Orders
        /// </summary>
        public List<OrderDemandHeader> Orders { get; set; }

        /// <summary>
        /// Gets or sets DemandSummary
        /// </summary>
        public List<DemandDate> DemandSummary { get; set; }
    }

    /// <summary>
    /// OrderDemandHeader
    /// </summary>
    public class OrderDemandHeader
    {
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets AlternateId
        /// </summary>
        public string AlternateId { get; set; }
        /// <summary>
        /// Gets or sets OrderLines
        /// </summary>
        public List<OrderDemandLine> OrderLines { get; set; }
    }

    /// <summary>
    /// OrderDemandLine
    /// </summary>
    public class OrderDemandLine
    {
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }
    }
}