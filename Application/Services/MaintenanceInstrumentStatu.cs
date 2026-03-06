using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    
    public partial class MaintenanceInstrumentStatu
    {
        public MaintenanceInstrumentStatu()
        {
            this.MaintenanceReportInstrumentDetails = new HashSet<MaintenanceReportInstrumentDetail>();
        }
    
        /// <summary>
        /// Gets or sets MaintenanceInstrumentStatusId
        /// </summary>
        public int MaintenanceInstrumentStatusId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets FullFillsMaintenance
        /// </summary>
        public bool FullFillsMaintenance { get; set; }
    
        /// <summary>
        /// Gets or sets MaintenanceReportInstrumentDetails
        /// </summary>
        public virtual ICollection<MaintenanceReportInstrumentDetail> MaintenanceReportInstrumentDetails { get; set; }
    }
}
