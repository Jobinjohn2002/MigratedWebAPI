using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PrintHistoryTurnaroundEventModel
    /// </summary>
    public class PrintHistoryTurnaroundEventModel
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        public int PrintHistoryId {get;set;}
        /// <summary>
        /// Gets or sets TurnaroundEventId
        /// </summary>
        public int TurnaroundEventId { get; set; }
    }
}