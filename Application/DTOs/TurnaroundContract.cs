using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class TurnaroundContract 
	{
	    /// <summary>
	    /// Gets or sets the exist defects.
	    /// </summary>
	    /// <value>The exist defects.</value>
	    /// <remarks></remarks>
	    /// <summary>
	    /// Gets or sets ExistsDefects
	    /// </summary>
	    public IList<IDefect> ExistsDefects { get; set; }

	    /// <summary>
	    /// Gets or sets the exist notes.
	    /// </summary>
	    /// <value>The exist notes.</value>
	    /// <remarks></remarks>
	    /// <summary>
	    /// Gets or sets ExistsNotes
	    /// </summary>
	    public IList<ITurnaroundNote> ExistsNotes { get; set; }

	    /// <summary>
	    /// Gets or sets the exist item notes.
	    /// </summary>
	    /// <value>The exists item notes.</value>
	    /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExistsItemNotes
        /// </summary>
        public IList<IContainerMasterNote> ExistsItemNotes { get; set; }

        /// <summary>
        /// The RAG priority of the turnaround
        /// </summary>
        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public TurnaroundPriority Priority { get; set; }

        public int? LastEventTypeId { get; set; }

        public int? NextEventTypeWHId { get; set; }

        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? StationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? WorkflowId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ProcessStationTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NextEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        public int? ItemInstanceTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        public short? BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundPrinted
        /// </summary>
        public bool IsTurnaroundPrinted { get; set; }

        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// EventDisplayOrder
        /// </summary>
        /// <summary>
        /// Gets or sets EventDisplayOrder
        /// </summary>
        public int EventDisplayOrder { get; set; }
    }
}
		