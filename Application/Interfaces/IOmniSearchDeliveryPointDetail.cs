using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Omni Search Delivery Point Detail
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchDeliveryPointDetail
    /// </summary>
    public interface IOmniSearchDeliveryPointDetail
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        /// <remarks></remarks>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the Customer Name .
        /// </summary>
        /// <value>The Customer Name.</value>
        /// <remarks></remarks>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the Delivery Point Id.
        /// </summary>
        /// <value>The Delivery Point Id.</value>
        /// <remarks></remarks>
        int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        bool IsArchived { get; set; }
    }
}
