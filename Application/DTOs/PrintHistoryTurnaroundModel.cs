using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PrintHistoryTurnaroundModel
    /// </summary>
    public class PrintHistoryTurnaroundModel
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
    }
}