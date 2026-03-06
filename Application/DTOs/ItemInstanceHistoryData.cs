using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class ItemInstanceHistoryData 
	{
        public ItemInstanceHistoryData()
        {

        }
        /// <summary>
        /// Gets or sets UserFullName
        /// </summary>
        public string UserFullName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceName
        /// </summary>
        public string ContainerInstanceName { get; set; }
        public int? TurnaroundId { get; set; }
        public long? TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets AuditExternalId
        /// </summary>
        public string AuditExternalId { get; set; }
        public int? AuditLineStatusTypeId { get; set; }
        public int? AuditLineExceptionReasonId { get; set; }
        public bool? IsRequiredBySpecification { get; set; }
    }
}