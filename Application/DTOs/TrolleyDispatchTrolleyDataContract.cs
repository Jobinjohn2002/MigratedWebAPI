using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyDispatchTrolleyDataContract
    /// </summary>
    public class TrolleyDispatchTrolleyDataContract : ScanAssetDataContract
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets InstancePrimaryId
        /// </summary>
        public string InstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancelId
        /// </summary>
        public int ContainerInstancelId { get; set; }
        /// <summary>
        /// Gets or sets LastEventAppliedId
        /// </summary>
        public int LastEventAppliedId { get; set; }
        /// <summary>
        /// Gets or sets Contents
        /// </summary>
        public List<TrolleyDispatchContainerDataContract> Contents { get; set; }
        /// <summary>
        /// Gets or sets SuggestedTurnarounds
        /// </summary>
        public List<TrolleyDispatchContainerDataContract> SuggestedTurnarounds { get; set; }
    }
}
