using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundEventDetail
    /// </summary>
    public class TurnaroundEventDetail
    {
        /// <summary>
        /// Gets or sets ApplyEvent
        /// </summary>
        public ApplyTurnaroundEventDetails ApplyEvent { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public TurnaroundEvent TurnaroundEvent { get; set; }
        public int? NextWorkFlowId { get; set; }
    }
}