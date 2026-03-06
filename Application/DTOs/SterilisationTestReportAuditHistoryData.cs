using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class SterilisationTestReportAuditHistoryData 
	{
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets SterilisationTestReportStatusText
        /// </summary>
        public string SterilisationTestReportStatusText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SterilisationTestReportAuditHistoryData()
        {
        }
	}
}
		