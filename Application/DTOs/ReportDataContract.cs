using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ReportDataContract
    /// </summary>
    public class ReportDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        public byte[] Data { get; set; }
        public int? NumberOfCopies { get; set; }
    }
}