using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomValue
    /// </summary>
    public class CustomValue
    {
        /// <summary>
        /// Gets or sets CustomisableTableId
        /// </summary>
        public int CustomisableTableId { get; set; }
        /// <summary>
        /// Gets or sets RowId
        /// </summary>
        public int RowId { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
    }
}