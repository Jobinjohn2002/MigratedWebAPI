using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InstrumentDetailsPinnedModalModel
    /// </summary>
    public class InstrumentDetailsPinnedModalModel
    {
        /// <summary>
        /// Gets or sets TableIdentifier
        /// </summary>
        public string TableIdentifier { get; set; }
        /// <summary>
        /// Gets or sets TableIndex
        /// </summary>
        public int TableIndex { get; set; }
    }
}