using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ListPriorityItemsDataContract
    /// </summary>
    public class ListPriorityItemsDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets UseTurnaroundId
        /// </summary>
        public bool UseTurnaroundId { get; set; }
        public int? ByEvent { get; set; }
        /// <summary>
        /// Gets or sets IsBiologicalIndicators
        /// </summary>
        public bool IsBiologicalIndicators { get; set; }
        public bool? CompletedOrdersOnly { get; set; }
    }
}