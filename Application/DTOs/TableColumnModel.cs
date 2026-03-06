using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Defines the column types
    /// </summary>
    public enum TableColumnType
    {
        /// <summary>
        /// No type
        /// </summary>
        None = 0,
        /// <summary>
        /// The column contains string values
        /// </summary>
        String = 1,
        /// <summary>
        /// The column contains values defined in a list
        /// </summary>
        List = 2,
        /// <summary>
        /// The column contains dates
        /// </summary>
        Date = 3,
        /// <summary>
        /// The column contains a boolean
        /// </summary>
        Boolean = 4,
        /// <summary>
        /// The column contains a number
        /// </summary>
        Number = 5,
        /// <summary>
        /// The column values defined in a list and multiple can be selected
        /// </summary>
        MultiList = 6
    }

    /// <summary>
    /// Represents a table column (th)
    /// </summary>
    /// <summary>
    /// TableColumnModel
    /// </summary>
    public class TableColumnModel : TableColumnBase
    {
        /// <summary>
        /// Creates an instance with default values initialised.
        /// </summary>
        public TableColumnModel()
        {
            Items = new List<SelectListItem>();
            Type = TableColumnType.String;
            CollapseMode = CollapseMode.None;
        }

        /// <summary>
        /// Get/Set the display text for the column.
        /// </summary>
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Get/Set the CSS class of the column.
        /// </summary>
        /// <summary>
        /// Gets or sets CssClass
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// If an Icon Class is set for a column, the icon will be displayed instead of the body text
        /// </summary>
        /// <summary>
        /// Gets or sets IconClass
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// Get/Set the name attribute of the title, used when creating a filter input for the column and posting back the form.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get/Set the column type.
        /// </summary>
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public TableColumnType Type { get; set; }

        /// <summary>
        /// Get/Set whether the column is filterable (will display the filter control below the header)
        /// </summary>
        /// <summary>
        /// Gets or sets Filterable
        /// </summary>
        public bool Filterable { get; set; }

        /// <summary>
        /// Get/Set the items used when filtering with a predefined list of values.
        /// </summary>
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public IEnumerable<SelectListItem> Items { get; set; }

        /// <summary>
        /// Get/Set the current filter value, used for restoring the filter control after filtering and through postbacks.
        /// </summary>
        /// <summary>
        /// Gets or sets FilterValue
        /// </summary>
        public object FilterValue { get; set; }

        /// <summary>
        /// Gets or sets DefaultFilterValue
        /// </summary>
        public object DefaultFilterValue { get; set; }

        /// <summary>
        /// Get/Set the responsive collapse mode, indicates how soon the column will "collapse" when screen size is reduced.
        /// </summary>
        /// <summary>
        /// Gets or sets CollapseMode
        /// </summary>
        public CollapseMode CollapseMode { get; set; }

        /// <summary>
        /// Get/Set whether this column is sortable (displays a sort direction link in the column).
        /// </summary>
        /// <summary>
        /// Gets or sets Sortable
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        /// Get/Set the current sort order.
        /// </summary>
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public SortOrder Order { get; set; }

        /// <summary>
        /// Generate the css collapse class, based on the currently set collapse mode
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// CollapseCssClass operation
        /// </summary>
        public string CollapseCssClass()
        {
            if (CollapseMode == CollapseMode.None)
                return string.Empty;

            return "can collapse" + (byte)CollapseMode;
        }

        /// <summary>
        /// Gets or sets WrapClass
        /// </summary>
        public string WrapClass { get; set; }

        /// <summary>
        /// Gets or sets Tooltip
        /// </summary>
        public string Tooltip { get; set; }
    }
}
