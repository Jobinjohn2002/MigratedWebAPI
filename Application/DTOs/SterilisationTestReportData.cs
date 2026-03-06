using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class SterilisationTestReportData 
	{
        public SterilisationTestReportData()
        {
        }
        public int? ItemCount { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportStatusText
        /// </summary>
        public string SterilisationTestReportStatusText { get; set; }
        /// <summary>
        /// Gets or sets ReportTypeText
        /// </summary>
        public string ReportTypeText { get; set; }
        /// <summary>
        /// Gets or sets MachineName
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// Gets or sets ModifiedBy
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets CompletedBy
        /// </summary>
        public string CompletedBy { get; set; }
	}
}
		