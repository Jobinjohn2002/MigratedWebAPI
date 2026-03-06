using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ComponentItemException
    /// </summary>
    public class ComponentItemException
    {
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionId
        /// </summary>
        public int ItemExceptionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentId
        /// </summary>
        public int ContainerContentId { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReasonId
        /// </summary>
        public byte ItemExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
    }
}