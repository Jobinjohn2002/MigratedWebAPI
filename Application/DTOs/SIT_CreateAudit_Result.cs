using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SIT_CreateAudit_Result
    {
        /// <summary>
        /// Gets or sets SingleInstrumentAuditId
        /// </summary>
        public int SingleInstrumentAuditId { get; set; }
        /// <summary>
        /// Gets or sets AuditLocationCategoryId
        /// </summary>
        public byte AuditLocationCategoryId { get; set; }
    }
}
