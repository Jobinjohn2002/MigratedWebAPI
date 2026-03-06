using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchDetailsResponseDataContract
    /// </summary>
    public class BatchDetailsResponseDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public List<BatchTurnaroundDataContract> Turnarounds { get; set; }
    }
}