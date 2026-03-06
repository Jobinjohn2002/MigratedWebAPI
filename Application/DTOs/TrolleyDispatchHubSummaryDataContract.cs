using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyDispatchHubSummaryDataContract
    /// </summary>
    public class TrolleyDispatchHubSummaryDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Trolleys
        /// </summary>
        public List<TrolleyDispatchTrolleySummaryDataContract> Trolleys { get; set; }
    }
}
