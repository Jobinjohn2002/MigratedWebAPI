using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// SCSearchSummaryData
    /// </summary>
    public class SCSearchSummaryData
    {
        public SCSearchSummaryData(ISCSearchSummary scSearchSummary)
        {
            Instruments = scSearchSummary.Instruments;
            Defects = scSearchSummary.Defects;
            Items = scSearchSummary.Items;
            DeliveryNotes = scSearchSummary.DeliveryNotes;
            Turnarounds = scSearchSummary.Turnarounds;
            Instances = scSearchSummary.Instances;
            LoanSets = scSearchSummary.LoanSets;
        }
        /// <summary>
        /// Gets or sets the insturment search value.
        /// </summary>
        /// <value>The instruments.</value>
        /// <remarks></remarks>
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
        /// Gets or sets the loansets search value.
        /// </summary>
        /// <value>The loansets.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public int LoanSets { get; set; }
    }
}
