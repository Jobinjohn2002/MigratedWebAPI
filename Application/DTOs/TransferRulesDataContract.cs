using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TransferRulesDataContract
    /// </summary>
    public class TransferRulesDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Destinations
        /// </summary>
        public List<TransferDestination> Destinations { get; set; } 
    }
}
