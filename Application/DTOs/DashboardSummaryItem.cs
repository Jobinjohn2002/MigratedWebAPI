using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// DashboardSummaryData
    /// </summary>
    public class DashboardSummaryData
    {
        /// <summary>
        /// Gets or sets the items processed.
        /// </summary>
        /// <value>The items processed.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemsProcessed
        /// </summary>
        public int ItemsProcessed { get; set; }

        /// <summary>
        /// Gets or sets the overdue items.
        /// </summary>
        /// <value>The overdue items.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets OverdueItems
        /// </summary>
        public int OverdueItems { get; set; }

        /// <summary>
        /// Gets or sets the outstanding synergy defects.
        /// </summary>
        /// <value>The outstanding synergy defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets OutstandingSynergyDefects
        /// </summary>
        public int OutstandingSynergyDefects { get; set; }

        /// <summary>
        /// Gets or sets the customer defects awaiting response.
        /// </summary>
        /// <value>The customer defects awaiting response.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerDefectsAwaitingResponse
        /// </summary>
        public int CustomerDefectsAwaitingResponse { get; set; }

        /// <summary>
        /// Gets or sets the fast track requests.
        /// </summary>
        /// <value>The fast track requests.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FastTrackRequests
        /// </summary>
        public int FastTrackRequests { get; set; }

        /// <summary>
        /// Gets or sets the quarantine items.
        /// </summary>
        /// <value>The quarantine items.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets QuarantineItems
        /// </summary>
        public int QuarantineItems { get; set; }

        /// <summary>
        /// Gets or sets the alerts.
        /// </summary>
        /// <value>The alerts.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Alerts
        /// </summary>
        public List<DashboardItem> Alerts { get; set; }

    }
}
