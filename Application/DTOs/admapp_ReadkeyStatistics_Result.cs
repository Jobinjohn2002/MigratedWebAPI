using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadkeyStatistics_Result
    {
        /// <summary>
        /// Gets or sets ItemsProcessed
        /// </summary>
        public Nullable<int> ItemsProcessed { get; set; }
        /// <summary>
        /// Gets or sets OverdueItems
        /// </summary>
        public Nullable<int> OverdueItems { get; set; }
        /// <summary>
        /// Gets or sets OutstandingSynergyDefects
        /// </summary>
        public Nullable<int> OutstandingSynergyDefects { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectsAwaitingResponse
        /// </summary>
        public Nullable<int> CustomerDefectsAwaitingResponse { get; set; }
        /// <summary>
        /// Gets or sets FastTrackRequests
        /// </summary>
        public Nullable<int> FastTrackRequests { get; set; }
        /// <summary>
        /// Gets or sets Quarantineevents
        /// </summary>
        public Nullable<int> Quarantineevents { get; set; }
    }
}
