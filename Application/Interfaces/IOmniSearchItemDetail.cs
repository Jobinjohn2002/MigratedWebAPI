using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Omni Search Item Detail
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchItemDetail
    /// </summary>
    public interface IOmniSearchItemDetail
    {
        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id.</value>
        /// <remarks></remarks>
        /// 
        int IndexId { get; set; }
       
        /// <summary>
        /// Gets or sets the master U id.
        /// </summary>
        /// <value>The master U id.</value>
        /// <remarks></remarks>
        int MasterId { get; set; }
       
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the legagcy internal id.
        /// </summary>
        /// <value>The legagcy internal id.</value>
        /// <remarks></remarks>
        int? LegacyInternalId { get; set; }

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
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        /// <remarks></remarks>
        string Status { get; set; }

        /// <summary>
        /// Gets or sets the master type.
        /// </summary>
        /// <value>The master type</value>
        /// <remarks></remarks>
        int MasterSubtype { get; set; }

        /// <summary>
        /// Gets or sets the sub type.
        /// </summary>
        /// <value>The subtype.</value>
        /// <remarks></remarks>
        string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the base type.
        /// </summary>
        /// <value>The base type.</value>
        /// <remarks></remarks>
        string BaseType { get; set; }

        /// <summary>
        /// Gets or sets number of instances
        /// </summary>
        /// <value>The number of instance</value>
        /// <remarks></remarks>
        int? NumberOfInstance { get; set; }

        /// <summary>
        /// Gets or sets the master type.
        /// </summary>
        /// <value>The master type.</value>
        /// <remarks></remarks>
        MasterType MasterType { get; set; }

        /// <summary>
        /// Gets or sets the CustomerName.
        /// </summary>
        /// <value>The customer name.</value>
        /// <remarks></remarks>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        bool IsArchived { get; set; }

    }
}
