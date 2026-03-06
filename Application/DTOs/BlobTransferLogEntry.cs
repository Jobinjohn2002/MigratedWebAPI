using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BlobTransferLogEntry
    /// </summary>
    public class BlobTransferLogEntry
    {
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public string FacilityId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public string StationId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public string ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public string ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public string TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets FilePath
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Gets or sets Container
        /// </summary>
        public string Container { get; set; }
        /// <summary>
        /// Gets or sets Uploaded
        /// </summary>
        public bool Uploaded { get; set; }
    }
}
