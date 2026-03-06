using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// SCSearchData
    /// </summary>
    public class SCSearchData 
    {
        /// <summary>
        /// Gets or sets the instrument search related data.
        /// </summary>
        /// <value>The instrument.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Instruments
        /// </summary>
        public IList<OmniSearchItemDetailData> Instruments { get; set; }

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
        /// Gets or sets the defects search related data.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public IList<OmniSearchLoanSetsDetailData> LoanSets { get; set; }
    }
}
