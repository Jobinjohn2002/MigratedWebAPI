using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderLineDataContract
    /// </summary>
    public class OrderLineDataContract
    {
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        public int? TurnaroundId { get; set; }
        public int? Revision { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets OrderLineId
        /// </summary>
        public int OrderLineId { get; set; }
        /// <summary>
        /// Gets or sets OrderLineStatusId
        /// </summary>
        public int OrderLineStatusId { get; set; }
        public int? LatestContainerMasterRevision { get; set; }
        /// <summary>
        /// Gets or sets LatestContainerMasterName
        /// </summary>
        public string LatestContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        public long? TurnaroundExternalId { get; set; }
        public DateTime? SterileExpiry { get; set; }
        public bool? HasItemException { get; set; }
        /// <summary>
        /// Gets or sets OrderLineSource
        /// </summary>
        public OrderSourceIdentifier OrderLineSource { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionDemandCount
        /// </summary>
        public int ContainerMasterDefinitionDemandCount { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionFulfilledCount
        /// </summary>
        public int ContainerMasterDefinitionFulfilledCount { get; set; }
        /// <summary>
        /// Gets or sets AllContainerMasterDefinitionIsOnDemand
        /// </summary>
        public bool AllContainerMasterDefinitionIsOnDemand { get; set; }
        /// <summary>
        /// Gets or sets OrderIsOnDemand
        /// </summary>
        public bool OrderIsOnDemand { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterAvailableAtLocationExternalId
        /// </summary>
        public string ContainerMasterAvailableAtLocationExternalId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterAvailableAtLocationText
        /// </summary>
        public string ContainerMasterAvailableAtLocationText { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterAvailableAtLocationQty
        /// </summary>
        public int ContainerMasterAvailableAtLocationQty { get; set; }
        /// <summary>
        /// Gets or sets LastModified
        /// </summary>
        public DateTime LastModified { get; set; }
        public DateTime? OrderDispatchedDate { get; set; }
    }
}