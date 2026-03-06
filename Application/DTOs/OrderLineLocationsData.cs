using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderLineLocationsData
    /// </summary>
    public class OrderLineLocationsData
    {
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationCode
        /// </summary>
        public string LocationCode { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets Qty
        /// </summary>
        public int Qty { get; set; }
    }
}
