using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// PDFReport
    /// </summary>
    public class PDFReport
    {
        public byte[] ReportData { get; set; }
        /// <summary>
        /// Gets or sets ReportName
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// Gets or sets NumberOfCopies
        /// </summary>
        public int NumberOfCopies { get; set; } = 1;
    }
}