using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CarriageBatchData
    /// </summary>
    public class CarriageBatchData
    {
        /// <summary>
        /// Gets or sets BatchExternalId
        /// </summary>
        public string BatchExternalId { get; set; }
        /// <summary>
        /// Gets or sets containerInstanceData
        /// </summary>
        public List<ContainerInstanceData> containerInstanceData { get; set; }
    }
}
