using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ColumnRowModel
    /// </summary>
    public class ColumnRowModel
    {
        /// <summary>
        /// Gets or sets Columns
        /// </summary>
        public IList<TableColumnBase> Columns { get; set; }
    }
}
