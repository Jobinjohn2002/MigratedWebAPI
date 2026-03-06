using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum OrderDetailsConfirmation
    {
        None = 0,
        Created = 1,
        Updated = 2,
        Cancelled = 3,
        Commented = 4
    }

    /// <summary>
    /// OrderDetailsModel
    /// </summary>
    public class OrderDetailsModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public OrderDetailsConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets CommentsEnabled
        /// </summary>
        public bool CommentsEnabled { get; set; } = true;
        /// <summary>
        /// Gets or sets BatchCount
        /// </summary>
        public int BatchCount { get; set; }
        /// <summary>
        /// Gets or sets OrderLineCount
        /// </summary>
        public int OrderLineCount { get; set; }
        /// <summary>
        /// Gets or sets OrderLines
        /// </summary>
        public TableModel OrderLines { get; set; }
        /// <summary>
        /// Gets or sets Forecast
        /// </summary>
        public IList<StockForecast> Forecast { get; set; }
        /// <summary>
        /// Gets or sets UsagePoints
        /// </summary>
        public IEnumerable<GroupedListItem> UsagePoints { get; set; }
        /// <summary>
        /// Gets or sets OrderNotes
        /// </summary>
        public IList<string> OrderNotes { get; set; }
    }

    public enum OrderTemplateConfirmation
    {
        None = 0,
        Created = 1,
        Updated = 2,
        Archived = 3,
        Activated = 4
    }

    /// <summary>
    /// OrderTemplateDetails
    /// </summary>
    public class OrderTemplateDetails
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public OrderTemplateConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets Template
        /// </summary>
        public OrderTemplate Template { get; set; }
        /// <summary>
        /// Gets or sets OrderLineCount
        /// </summary>
        public int OrderLineCount { get; set; }
        /// <summary>
        /// Gets or sets OrderLines
        /// </summary>
        public TableModel OrderLines { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
    }
}