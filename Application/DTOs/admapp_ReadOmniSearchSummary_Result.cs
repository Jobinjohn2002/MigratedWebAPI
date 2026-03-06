using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchSummary_Result
    {
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public int Items { get; set; }
        /// <summary>
        /// Gets or sets Instruments
        /// </summary>
        public int Instruments { get; set; }
        /// <summary>
        /// Gets or sets Instances
        /// </summary>
        public int Instances { get; set; }
        /// <summary>
        /// Gets or sets Item_Instances
        /// </summary>
        public int Item_Instances { get; set; }
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public int Turnarounds { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public int Customers { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public int DeliveryNotes { get; set; }
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public int Defects { get; set; }
        /// <summary>
        /// Gets or sets Users
        /// </summary>
        public int Users { get; set; }
        /// <summary>
        /// Gets or sets BatchNumbers
        /// </summary>
        public int BatchNumbers { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public int DeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets LoanSets
        /// </summary>
        public int LoanSets { get; set; }
    }
}
