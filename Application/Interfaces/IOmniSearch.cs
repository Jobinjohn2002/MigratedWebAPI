using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Omni Search interface, returns detailed search data
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearch
    /// </summary>
    public interface IOmniSearch
    {
        /// <summary>
        /// Gets or sets the facility search related data.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        IList<IOmniSearchFacilityDetail> Facilities { get; set; }
        /// <summary>
        /// Gets or sets the customer search related data.
        /// </summary>
        /// <value>The customer.</value>
        /// <remarks></remarks>
        IList<IOmniSearchCustomerDetail> Customers { get; set; }
        /// <summary>
        /// Gets or sets the items search related data.
        /// </summary>
        /// <value>The items.</value>
        /// <remarks></remarks>
        IList<IOmniSearchItemDetail> Items { get; set; }
        /// <summary>
        /// Gets or sets the instruments.
        /// </summary>
        /// <value>
        /// The instruments.
        /// </value>
        IList<IOmniSearchItemDetail> Instruments { get; set; }
        /// <summary>
        /// Gets or sets the instances search related data.
        /// </summary>
        /// <value>The instances.</value>
        /// <remarks></remarks>
        IList<IOmniSearchInstanceDetail> Instances { get; set; }
        /// <summary>
        /// Gets or sets the turnarounds search related data.
        /// </summary>
        /// <value>The turnarounds.</value>
        /// <remarks></remarks>
        IList<IOmniSearchTurnaroundDetail> Turnarounds { get; set; }
        /// <summary>
        /// Gets or sets the delivery notes search related data.
        /// </summary>
        /// <value>The delivery notes.</value>
        /// <remarks></remarks>
        IList<IOmniSearchDeliveryNotesDetail> DeliveryNotes { get; set; }
        /// <summary>
        /// Gets or sets the defects search related data.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        IList<IOmniSearchDefectsDetail> Defects { get; set; }
        /// <summary>
        /// Gets or sets the users search related data.
        /// </summary>
        /// <value>The users.</value>
        /// <remarks></remarks>
        IList<IOmniSearchUserDetail> Users { get; set; }

        /// <summary>
        /// Gets or sets the users search related data.
        /// </summary>
        /// <value>The users.</value>
        /// <remarks></remarks>
        IList<IOmniSearchBatchDetail> Batches { get; set; }

        /// <summary>
        /// Gets or sets the Delivery Points search related data.
        /// </summary>
        /// <value>The Delivery Points.</value>
        /// <remarks></remarks>
        IList<IOmniSearchDeliveryPointDetail> DeliveryPoints { get; set; }

        /// <summary>
        /// Gets or sets the loansets search related data.
        /// </summary>
        /// <value>The LoanSets.</value>
        /// <remarks></remarks>
        IList<IOmniSearchLoanSetsDetail> LoanSets { get; set; }
    }
}
