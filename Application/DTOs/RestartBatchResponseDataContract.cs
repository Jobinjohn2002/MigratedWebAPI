using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// RestartBatchResponseDataContract
    /// </summary>
    public class RestartBatchResponseDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets CarriageExternalId
        /// </summary>
        public string CarriageExternalId { get; set; }
        /// <summary>
        /// Gets or sets ChildExternalIds
        /// </summary>
        public List<string> ChildExternalIds { get; set; }
    }
}
