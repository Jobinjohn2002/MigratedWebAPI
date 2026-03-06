using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class MaintenanceReportAuditHistoryData 
	{
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportStatusText
        /// </summary>
        public string MaintenanceReportStatusText { get; set; }

        public MaintenanceReportAuditHistoryData(int maintenanceReportAuditHistoryId,
            int maintenanceReportId, int maintenanceReportStatusId, decimal totalCost, DateTime created,
            int createdUserId, string notes, string createdUserName, string maintenanceReportStatusText)
        {

            MaintenanceReportAuditHistoryId = maintenanceReportAuditHistoryId;

            MaintenanceReportId = maintenanceReportId;

            MaintenanceReportStatusId = maintenanceReportStatusId;

            TotalCost = totalCost;

            Created = created;

            CreatedUserId = createdUserId;

            Notes = notes;

            EntityKeyValue = MaintenanceReportAuditHistoryId.ToString();

            CreatedBy = createdUserName;

            MaintenanceReportStatusText = maintenanceReportStatusText;
        }

        public MaintenanceReportAuditHistoryData()
        {
            
        }

	}
}
		