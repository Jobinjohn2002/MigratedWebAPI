using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ItemInstance
    {
        /// <summary>
        /// Gets or sets LastIndividualInstrumentTrackingEvent
        /// </summary>
        public IIndividualInstrumentTrackingEvent LastIndividualInstrumentTrackingEvent { get; set; }

        /// <summary>
        /// Gets or sets ContainerName
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        public long? TurnaroundExternalId { get; set; }

        /// <summary>
        /// Gets or sets CreatedUserName
        /// </summary>
        public string CreatedUserName { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

	    /// <summary>
	    /// Gets or sets ItemStatusText
	    /// </summary>
	    public string ItemStatusText { get; set; }

        /// <summary>
        /// Gets or sets ItemInstanceValue
        /// </summary>
        public string ItemInstanceValue { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets LastProcessEvent
        /// </summary>
        public string LastProcessEvent { get; set; }

        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; set; }
	}
}
