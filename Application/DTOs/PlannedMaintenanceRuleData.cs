using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class PlannedMaintenanceRuleData
    {
        public PlannedMaintenanceRuleData()
        {

        }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        public int? ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets VendorName
        /// </summary>
        public string VendorName { get; set; }
        /// <summary>
        /// Gets or sets Scheduler
        /// </summary>
        public ScheduleData Scheduler { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityText
        /// </summary>
        public string MaintenanceActivityText { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterName
        /// </summary>
        public string ItemMasterName { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityId
        /// </summary>
        public int MaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        public int? RepeatType { get; set; }
        public int? RepeatEvery { get; set; }

    }
}
