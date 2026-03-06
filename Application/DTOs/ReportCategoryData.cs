using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public sealed partial class ReportCategoryData
	{
		/// <summary>
		/// Gets or sets ChildReportCategories
		/// </summary>
		public IList<ReportCategoryData> ChildReportCategories { get; set; }
		/// <summary>
		/// Gets or sets Reports
		/// </summary>
		public IList<ReportData> Reports { get; set; }
	}
}
