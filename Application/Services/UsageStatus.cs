using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    
    public partial class UsageStatus
    {
        public UsageStatus()
        {
            this.SurgicalProcedureTurnarounds = new HashSet<SurgicalProcedureTurnaround>();
        }
    
        /// <summary>
        /// Gets or sets UsageStatusId
        /// </summary>
        public byte UsageStatusId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Opened
        /// </summary>
        public bool Opened { get; set; }
        /// <summary>
        /// Gets or sets Used
        /// </summary>
        public bool Used { get; set; }
    
        /// <summary>
        /// Gets or sets SurgicalProcedureTurnarounds
        /// </summary>
        public virtual ICollection<SurgicalProcedureTurnaround> SurgicalProcedureTurnarounds { get; set; }
    }
}
