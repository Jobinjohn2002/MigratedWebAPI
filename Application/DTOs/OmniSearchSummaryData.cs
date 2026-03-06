using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OmniSearchSummaryData
    /// </summary>
    public class OmniSearchSummaryData
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <remarks></remarks>
        public OmniSearchSummaryData()
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="users">The facility.</param>
        /// <param name="customers">The customer.</param>
        /// <param name="items">The items.</param>
        /// <param name="instances">The instances.</param>
        /// <param name="turnarounds">The turnarounds.</param>
        /// <param name="deliveryNotes">The delivery notes.</param>
        /// <param name="defects">The defects.</param>
        /// <param name="batches"></param>
        /// <param name="loanSets"></param>
        /// <remarks></remarks>
        public OmniSearchSummaryData(int users, int customers, int items, int instances, int turnarounds, int deliveryNotes, int defects, int batches, int deliveryPoints,int instruments, int loanSets)
        {
            Customers = customers;
            Items = items;
            Instances = instances;
            Turnarounds = turnarounds;
            DeliveryNotes = deliveryNotes;
            Defects = defects;
            Users = users;
            Batches = batches;
            DeliveryPoints = deliveryPoints;
            Instruments = instruments;
            LoanSets = loanSets;
        }

        /// <summary>
        /// Gets or sets the facility search value.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public int Users { get; set; }

        /// <summary>
        /// Gets or sets the customer search value.
        /// </summary>
        /// <value>The customer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public int Customers { get; set; }

        /// <summary>
        /// Gets or sets the items search value.
        /// </summary>
        /// <value>The items.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public int Items { get; set; }

        /// <summary>
        /// Gets or sets the instances search value.
        /// </summary>
        /// <value>The instances.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Instances
        /// </summary>
        public int Instances { get; set; }

        /// <summary>
        /// Gets or sets the turnarounds search value.
        /// </summary>
        /// <value>The turnarounds.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public int Turnarounds { get; set; }

        /// <summary>
        /// Gets or sets the delivery notes search value.
        /// </summary>
        /// <value>The delivery notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public int DeliveryNotes { get; set; }

        /// <summary>
        /// Gets or sets the defects search value.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public int Defects { get; set; }

        /// <summary>
        /// Gets or sets the batches search value.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Batches
        /// </summary>
        public int Batches { get; set; }

        /// <summary>
        /// Gets or sets the Delivery Points search value.
        /// </summary>
        /// <value>The Delivery Points.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public int DeliveryPoints { get; set; }

        /// <summary>
        /// Gets or sets the instruments.
        /// </summary>
        /// <value>
        /// The instruments.
        /// </value>
        /// <summary>
        /// Gets or sets Instruments
        /// </summary>
        public int Instruments { get; set; }

        /// <summary>
        /// Gets or sets the loansets.
        /// </summary>
        /// <value>
        /// The loansets.
        /// </value>
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public int LoanSets { get; set; }
    }
}
