using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StockLocationDataContract
    /// </summary>
    public class StockLocationDataContract
    {
        /// <summary>
        /// Gets or sets StockLocationID
        /// </summary>
        public int StockLocationID { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
    }
}
