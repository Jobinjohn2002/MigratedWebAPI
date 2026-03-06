using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Omni Search Batch Detail
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchBatchDetail
    /// </summary>
    public interface IOmniSearchBatchDetail
    {
        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the Cycle Type Name .
        /// </summary>
        /// <value>The Cycle Type Name.</value>
        /// <remarks></remarks>
        string CycleTypeName { get; set; }

                /// <summary>
        /// Gets or sets the batch id.
        /// </summary>
        /// <value>The batch id.</value>
        /// <remarks></remarks>
        int  BatchId { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        /// <remarks></remarks>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        bool IsArchived { get; set; }
    }
}
