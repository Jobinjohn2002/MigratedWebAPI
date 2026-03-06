using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// GetComponentsRequestDataContract
    /// </summary>
    public class GetComponentsRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        public int? ContainerInstanceId { get; set; }
        public int? ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets IsViewTrayList
        /// </summary>
        public bool IsViewTrayList { get; set; }
    }
}