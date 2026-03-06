using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IOmniSearchInstanceDetail
    /// </summary>
    public interface IOmniSearchInstanceDetail
    {

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The  instance id.</value>
        /// <remarks></remarks>
        int InstanceId { get; set; }

        int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the delivery point.
        /// </summary>
        /// <value>The delivery point.</value>
        /// <remarks></remarks>
        string DeliveryPoint { get; set; }

        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id.</value>
        /// <remarks></remarks>
        string Customer { get; set; }

        /// <summary>
        /// Gets or sets legacy internal id
        /// </summary>
        /// <value>The legacy internal id.</value>
        /// <remarks></remarks>
        long? LegacyInternalId { get; set; }

        /// <summary>
        /// Gets or sets the legacy external id.
        /// </summary>
        /// <value>The legacy external id.</value>
        /// <remarks></remarks>
        string LegacyExternalId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the super type.
        /// </summary>
        /// <value>The super type.</value>
        /// <remarks></remarks>
        string SuperType { get; set; }

        /// <summary>
        /// Gets or sets item uid
        /// </summary>
        int ItemUid { get; set; }

        /// <summary>
        /// Gets or sets item name
        /// </summary>
        string ItemName { get; set; }

        /// <summary>
        /// Gets or sets item type id
        /// </summary>
        short ItemTypeId { get; set; } 

        /// <summary>
        /// Gets or sets item type name
        /// </summary>
        string ItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets turnaround count
        /// </summary>
        int TurnaroundCount { get; set; }

        /// <summary>
        /// Gets or sets service requirement
        /// </summary>
        string ServiceRequirement { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        bool IsArchived { get; set; }

    }
}
