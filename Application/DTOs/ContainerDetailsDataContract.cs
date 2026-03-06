using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ContainerDetailsDataContract
    /// </summary>
    public class ContainerDetailsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceLegacyExternalId
        /// </summary>
        public string ContainerInstanceLegacyExternalId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeText
        /// </summary>
        public string ItemTypeText { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets TrackIndividualInstruments
        /// </summary>
        public bool TrackIndividualInstruments { get; set; }
        /// <summary>
        /// Gets or sets IsLoanSetExpired
        /// </summary>
        public bool IsLoanSetExpired { get; set; }
        /// <summary>
        /// Gets or sets IsContainerMasterArchived
        /// </summary>
        public bool IsContainerMasterArchived { get; set; }
        /// <summary>
        /// Gets or sets IsContainerInstanceArchived
        /// </summary>
        public bool IsContainerInstanceArchived { get; set; }
    }
}