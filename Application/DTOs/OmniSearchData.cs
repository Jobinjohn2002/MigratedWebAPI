using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OmniSearchData
    /// </summary>
    public class OmniSearchData
    {
        /// <summary>
        /// Gets or sets the facility search related data.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public IList<OmniSearchFacilityDetailData> Facilities { get; set; }

        /// <summary>
        /// Gets or sets the customer search related data.
        /// </summary>
        /// <value>The customer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public IList<OmniSearchCustomerDetailData> Customers { get; set; }

        /// <summary>
        /// Gets or sets the items search related data.
        /// </summary>
        /// <value>The items.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public IList<OmniSearchItemDetailData> Items { get; set; }

        /// <summary>
        /// Gets or sets the instruments.
        /// </summary>
        /// <value>
        /// The instruments.
        /// </value>
        /// <summary>
        /// Gets or sets Instruments
        /// </summary>
        public IList<OmniSearchItemDetailData> Instruments { get; set; }

        /// <summary>
        /// Gets or sets the instances search related data.
        /// </summary>
        /// <value>The instances.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Instances
        /// </summary>
        public IList<OmniSearchInstanceDetailData> Instances { get; set; }

        /// <summary>
        /// Gets or sets the turnarounds search related data.
        /// </summary>
        /// <value>The turnarounds.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public IList<OmniSearchTurnaroundDetailData> Turnarounds { get; set; }

        /// <summary>
        /// Gets or sets the delivery notes search related data.
        /// </summary>
        /// <value>The delivery notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public IList<OmniSearchDeliveryNotesDetailData> DeliveryNotes { get; set; }

        /// <summary>
        /// Gets or sets the defects search related data.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public IList<OmniSearchDefectsDetailData> Defects { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public IList<OmniSearchUserDetailData> Users { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Batches
        /// </summary>
        public IList<OmniSearchBatchDetailData> Batches { get; set; }

        /// <summary>
        /// Gets or sets the Delivery Points.
        /// </summary>
        /// <value>The Delivery Points.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public IList<OmniSearchDeliveryPointDetailData> DeliveryPoints { get; set; }

        /// <summary>
        /// Gets or sets the Loansets
        /// </summary>
        /// <value>The Loansets.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public IList<OmniSearchLoanSetsDetailData> LoanSets { get; set; }
    }
}
