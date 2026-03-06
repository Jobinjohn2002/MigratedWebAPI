using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SCSearchSummary
    /// </summary>
    public class SCSearchSummary
    {
         /// <summary>
        /// Initializes a new instance of the SCSearchSummary class.
        /// </summary>
        /// <remarks></remarks>
        public SCSearchSummary()
        {

        }

        /// <summary>
        /// Initializes a new instance of the SCSearchSummary class.
        /// </summary>
        /// <param name="instruments">The instruments.</param>
        /// <param name="items">The items.</param>
        /// <param name="instances">The instances.</param>
        /// <param name="turnarounds">The turnarounds.</param>
        /// <param name="deliveryNotes">The delivery notes.</param>
        /// <param name="defects">The defects.</param>
        /// <param name="loanSets">The loanSets.</param>
        /// <remarks></remarks>
        public SCSearchSummary(int instruments, int items, int instances, int turnarounds, int deliveryNotes, int defects, int loanSets)
        {
        
            Items = items;
            Instances = instances;
            Turnarounds = turnarounds;
            DeliveryNotes = deliveryNotes;
            Defects = defects;
            LoanSets = loanSets;

        }

        #region Implementation of IOmniSearchSummary

        /// <summary>
        /// Gets or sets Instruments
        /// </summary>
        public int Instruments { get; set; }

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
        /// Gets or sets the loanset search value.
        /// </summary>
        /// <value>The LoanSets.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public int LoanSets { get; set; }
        #endregion
    }
}
