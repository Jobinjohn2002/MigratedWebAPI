using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// RowModel
    /// </summary>
    public class RowModel : List<TableCellModel>
    {
        /// <summary>
        /// Gets or sets CssStyle
        /// </summary>
        public string CssStyle { get; set; }
        /// <summary>
        /// Gets or sets UniqueIdentifier
        /// </summary>
        public object UniqueIdentifier { get; set; } = null;
        /// <summary>
        /// Gets or sets Tag
        /// </summary>
        public object Tag { get; set; }
    }
}
