using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// CustomStationeryResultData
    /// </summary>
    public class CustomStationeryResultData
    {
        /// <summary>
        /// Gets or sets ReportType
        /// </summary>
        public string ReportType { get; set; }
        /// <summary>
        /// Gets or sets NumberofCopies
        /// </summary>
        public int NumberofCopies { get; set; }
    
    }
}