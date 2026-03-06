using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SCSearch
    /// </summary>
    public class SCSearch
    {
        /// <summary>
        /// Gets or sets the instrument search related data.
        /// </summary>
        /// <value>The instrument.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Instruments
        /// </summary>
        public IList<IOmniSearchItemDetail> Instruments { get; set; }

        /// <summary>
        /// Gets or sets the items search related data.
        /// </summary>
        /// <value>The items.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public IList<IOmniSearchItemDetail> Items { get; set; }

        /// <summary>
        /// Gets or sets the instances search related data.
        /// </summary>
        /// <value>The instances.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Instances
        /// </summary>
        public IList<IOmniSearchInstanceDetail> Instances { get; set; }

        /// <summary>
        /// Gets or sets the turnarounds search related data.
        /// </summary>
        /// <value>The turnarounds.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public IList<IOmniSearchTurnaroundDetail> Turnarounds { get; set; }

        /// <summary>
        /// Gets or sets the delivery notes search related data.
        /// </summary>
        /// <value>The delivery notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public IList<IOmniSearchDeliveryNotesDetail> DeliveryNotes { get; set; }

        /// <summary>
        /// Gets or sets the defects search related data.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public IList<IOmniSearchDefectsDetail> Defects { get; set; }
        /// <summary>
        /// Gets or sets the defects search related data.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public IList<IOmniSearchLoanSetsDetail> LoanSets { get; set; }
    }
}
