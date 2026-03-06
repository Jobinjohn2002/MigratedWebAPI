using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class FastTrackRequestLineData 
	{
        public FastTrackRequestLineData()
        {
        }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public TurnaroundData Turnaround { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public ContainerMasterData ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstanceData ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets FastTrackServiceRequirements
        /// </summary>
        public List<GenericKeyValueData> FastTrackServiceRequirements { get; set; }
        /// <summary>
        /// Gets or sets ItemUrl
        /// </summary>
        public string ItemUrl { get; set; }
        public int? ServiceRequirementId { get; set; }
    }
}
		