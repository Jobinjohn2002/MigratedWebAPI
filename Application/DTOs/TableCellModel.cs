using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Represents a single table cell (td)
    /// </summary>
    public struct TableCellModel
    {
        private static readonly TableCellModel _empty = new TableCellModel();
    
        /// <summary>
        /// Get/Set the value.
        /// </summary>
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Get/Set the Format string to use to display the value.
        /// </summary>
        /// <summary>
        /// Gets or sets Format
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Get/Set the Action Info used to render the value as an action.
        /// </summary>
        /// <summary>
        /// Gets or sets ActionInfo
        /// </summary>
        public ActionInfo ActionInfo { get; set; }

        /// <summary>
        /// The class to apply to the table cell
        /// </summary>
        /// <summary>
        /// Gets or sets CssClass
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// The tooptip for the table cell
        /// </summary>
        /// <summary>
        /// Gets or sets Tooltip
        /// </summary>
        public string Tooltip { get; set; }
        
        /// <summary>
        /// The icon to display in the table cell (after the text)
        /// </summary>
        /// <summary>
        /// Gets or sets Icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Raw Html to display after all other content
        /// </summary>
        /// <summary>
        /// Gets or sets Html
        /// </summary>
        public MvcHtmlString Html { get; set; }
        
        /// <summary>
        /// Indicates if this cell should span multiple cells.
        /// </summary>
        public int? Colspan { get; set; }

        /// <summary>
        /// An empty table cell model
        /// </summary>
        public static TableCellModel Empty => _empty;

        /// <summary>
        /// Gets or sets WrapClass
        /// </summary>
        public string WrapClass { get; set; }

    }
}
