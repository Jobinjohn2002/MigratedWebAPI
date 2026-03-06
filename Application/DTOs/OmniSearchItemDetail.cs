using SynergyApplicationFrameworkApi.Application;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OmniSearchItemDetail
    /// </summary>
    public class OmniSearchItemDetail
    {

        public OmniSearchItemDetail(
            int masterUId,
            int masterSubtype,
            string name,
            int? legacyInternalId,
            string externalId,
            string status,
            string itemType,
            string baseType,
            int? numberOfInstance, int subtype, string customerName)
        {
            MasterId = masterUId;
            MasterSubtype = masterSubtype;
            Name = name;
            LegacyInternalId = legacyInternalId;
            ExternalId = externalId;
            Status = status;
            ItemType = itemType;
            BaseType = baseType;
            NumberOfInstance = numberOfInstance;
            MasterType = (MasterType)subtype;
            CustomerName = customerName;
        }

        public OmniSearchItemDetail(
            int masterUId,
            int masterSubtype,
            string name,
            int? legacyInternalId,
            string externalId,
            string status,
            string itemType,
            string baseType,
            int? numberOfInstance, int subtype, string customerName, bool isArchived)
        {
            MasterId = masterUId;
            MasterSubtype = masterSubtype;
            Name = name;
            LegacyInternalId = legacyInternalId;
            ExternalId = externalId;
            Status = status;
            ItemType = itemType;
            BaseType = baseType;
            NumberOfInstance = numberOfInstance;
            MasterType = (MasterType)subtype;
            CustomerName = customerName;
            IsArchived = isArchived;
        }

        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IndexId
        /// </summary>
        public int IndexId { get; set; }

        /// <summary>
        /// Gets or sets the master U id.
        /// </summary>
        /// <value>The master U id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterId
        /// </summary>
        public int MasterId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the legagcy internal id.
        /// </summary>
        /// <value>The legagcy internal id.</value>
        /// <remarks></remarks>
        public int? LegacyInternalId { get; set; }

        /// <summary>
        /// Gets or sets the legacy external id.
        /// </summary>
        /// <value>The legacy external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the master type.
        /// </summary>
        /// <value>The master type</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterSubtype
        /// </summary>
        public int MasterSubtype { get; set; }

        /// <summary>
        /// Gets or sets the sub type.
        /// </summary>
        /// <value>The subtype.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the base type.
        /// </summary>
        /// <value>The base type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }

        /// <summary>
        /// Gets or sets number of instances
        /// </summary>
        /// <value>The number of instance</value>
        /// <remarks></remarks>
        public int? NumberOfInstance { get; set; }

        /// <summary>
        /// Gets or sets the master type.
        /// </summary>
        /// <summary>
        /// Gets or sets MasterType
        /// </summary>
        public MasterType MasterType { get; set; }

        /// <summary>
        /// Gets or sets the CustomerName.
        /// </summary>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string  CustomerName { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }
    }
}
