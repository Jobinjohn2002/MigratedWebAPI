using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class SingleInstrumentAuditLineContract 
	{
	    /// <summary>
	    /// Gets or sets ItemInstance
	    /// </summary>
	    public ItemInstanceContract ItemInstance { get; set; }
        /// <summary>
        /// Gets or sets StatusType
        /// </summary>
        public AuditLineStatusTypeContract StatusType { get; set; }
        /// <summary>
        /// Gets or sets ExceptionReason
        /// </summary>
        public AuditLineExceptionReasonContract ExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public ItemMasterContract ItemMaster { get; set; }

	}
}
		