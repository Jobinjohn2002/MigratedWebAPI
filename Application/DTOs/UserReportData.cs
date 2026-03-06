using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class UserReportData 
	{
       
        public UserReportData()
        {
        }

        public UserReportData(IUserReport genericUserReport, string reportName)
			: this(genericUserReport)
		{
            ReportName = reportName;
		}

        public UserReportData(IUserReport genericUserReport, string reportName, string reportCategoryName)
            : this(genericUserReport)
        {
            ReportName = reportName;
            ReportCategoryName = reportCategoryName;
        }

        #region extra Members
        /// <summary>
        /// Gets or sets ReportName
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// Gets or sets ReportCategoryName
        /// </summary>
        public string ReportCategoryName { get; set; }
        /// <summary>
        /// Gets or sets Selected
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Gets or sets RoleReport
        /// </summary>
        public bool RoleReport { get; set; }
        #endregion
    }
}
		