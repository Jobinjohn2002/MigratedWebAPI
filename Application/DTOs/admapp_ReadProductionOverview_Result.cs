using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadProductionOverview_Result
    {
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public short EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public short DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemType
        /// </summary>
        public string ContainerMasterBaseItemType { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public Nullable<int> TurnaroundCount { get; set; }
        /// <summary>
        /// Gets or sets AnyOverdue
        /// </summary>
        public Nullable<int> AnyOverdue { get; set; }
    }
}
