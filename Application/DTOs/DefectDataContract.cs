using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// DefectDataContract
    /// </summary>
    public class DefectDataContract : BaseReplyDataContract
    {
        public int? TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets CmName
        /// </summary>
        public string CmName { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets DefectClassificationId
        /// </summary>
        public int DefectClassificationId { get; set; }
        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public string Details { get; set; }
    }
}