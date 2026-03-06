using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Omni Search Summary Interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchSummary
    /// </summary>
    public interface IOmniSearchSummary
    {
        /// <summary>
        /// Gets or sets the facility search value.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        int Users { get; set; }
        /// <summary>
        /// Gets or sets the customer search value.
        /// </summary>
        /// <value>The customer.</value>
        /// <remarks></remarks>
        int Customers { get; set; }
        /// <summary>
        /// Gets or sets the items search value.
        /// </summary>
        /// <value>The items.</value>
        /// <remarks></remarks>
        int Items { get; set; }
        /// <summary>
        /// Gets or sets the instances search value.
        /// </summary>
        /// <value>The instances.</value>
        /// <remarks></remarks>
        int Instances { get; set; }
        /// <summary>
        /// Gets or sets the turnarounds search value.
        /// </summary>
        /// <value>The turnarounds.</value>
        /// <remarks></remarks>
        int Turnarounds { get; set; }
        /// <summary>
        /// Gets or sets the delivery notes search value.
        /// </summary>
        /// <value>The delivery notes.</value>
        /// <remarks></remarks>
        int DeliveryNotes { get; set; }
        /// <summary>
        /// Gets or sets the defects search value.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        int Defects { get; set; }
       
        /// <summary>
        /// Gets or sets the batches search value.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        int Batches { get; set; }

        /// <summary>
        /// Gets or sets the Delivery Points search value.
        /// </summary>
        /// <value>The Delivery Points.</value>
        /// <remarks></remarks>
        int DeliveryPoints{ get; set; }

        /// <summary>
        /// Gets or sets the instruments.
        /// </summary>
        /// <value>
        /// The instruments.
        /// </value>
        int Instruments { get; set; }

        /// <summary>
        /// Gets or sets the loanSets.
        /// </summary>
        /// <value>
        /// The loansets.
        /// </value>
        int LoanSets { get; set; }
    }
}
