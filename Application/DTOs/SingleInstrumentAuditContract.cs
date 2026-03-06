using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class SingleInstrumentAuditContract 
	{
        
	    public SingleInstrumentAuditContract()
	    {
	    }
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets AuditResult
        /// </summary>
        public AuditResultTypeContract AuditResult { get; set; }
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public StationContract Station { get; set; }
        /// <summary>
        /// Gets or sets StationCategoryName
        /// </summary>
        public string StationCategoryName { get; set; }
        /// <summary>
        /// Gets or sets StartingTurnaroundEvent
        /// </summary>
        public TurnaroundEventContract StartingTurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets EndingTurnaroundEvent
        /// </summary>
        public TurnaroundEventContract EndingTurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets AuditLines
        /// </summary>
        public List<SingleInstrumentAuditLineContract> AuditLines { get; set; }
        /// <summary>
        /// Gets or sets InstrumentQtyOnTray
        /// </summary>
        public int InstrumentQtyOnTray { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId  { get; set; }
        public int? ContainerInstanceId { get; set; }
	    /// <summary>
	    /// Gets or sets TurnaroundExternalId
	    /// </summary>
	    public string TurnaroundExternalId { get; set; }
        public int? TurnaroundId { get; set; }
	    /// <summary>
	    /// Gets or sets ExternalId
	    /// </summary>
	    public string ExternalId { get; set; }

    }
}
		