using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Operative_GetBiTests_PriorityList_Result
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets TestBiologicalIndicatorLotNumber
        /// </summary>
        public string TestBiologicalIndicatorLotNumber { get; set; }
        /// <summary>
        /// Gets or sets Well
        /// </summary>
        public string Well { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        /// <summary>
        /// Gets or sets RemainingMins
        /// </summary>
        public Nullable<int> RemainingMins { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorTestStatusId
        /// </summary>
        public int BiologicalIndicatorTestStatusId { get; set; }
    }
}
