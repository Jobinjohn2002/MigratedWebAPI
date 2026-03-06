using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// GroupedRowTableModel
    /// </summary>
    public class GroupedRowTableModel
    {
        /// <summary>
        /// Get/Set the table ID. A table ID is required in order to use checkbox functionality
        /// </summary>
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString().Replace("-", "");

        /// <summary>
        /// Get/Set the table CssClass.
        /// </summary>
        /// <summary>
        /// Gets or sets CssClass
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Get/Set a value indicating if you want to apply the Table-Layout: fixed; width:
        /// </summary>        
        /// <summary>
        /// Gets or sets FixedLayout
        /// </summary>
        public bool FixedLayout { get; set; }

        /// <summary>
        /// Gets or sets Compact
        /// </summary>
        public bool Compact { get; set; }
        /// <summary>
        /// Gets or sets Striped
        /// </summary>
        public bool Striped { get; set; }

        /// <summary>
        /// Gets or sets ColumnRows
        /// </summary>
        public IList<ColumnRowModel> ColumnRows { get; set; }
        /// <summary>
        /// Gets or sets Groups
        /// </summary>
        public IList<RowGroupModel> Groups { get; set; }

        /// <summary>
        /// Gets or sets CaptionPartial
        /// </summary>
        public string CaptionPartial { get; set; }

    }

    /// <summary>
    /// RowGroupModel
    /// </summary>
    public class RowGroupModel
    {
        /// <summary>
        /// Gets or sets GroupRow
        /// </summary>
        public RowModel GroupRow { get; set; }
        /// <summary>
        /// Gets or sets ItemRows
        /// </summary>
        public IList<RowModel> ItemRows { get; set; }
        /// <summary>
        /// Gets or sets Collapsed
        /// </summary>
        public bool Collapsed { get; set; }
    }
}
