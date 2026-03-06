using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DocumentRequestDataContract
    /// </summary>
    public class DocumentRequestDataContract : BaseRequestDataContract
    {
        public int? ContainerInstanceId { get; set; }
        public int? ContainerMasterDefinitionId { get; set; }
        public int? ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets StartIndex
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// Gets or sets IsDocument
        /// </summary>
        public bool IsDocument { get; set; }
        /// <summary>
        /// Gets or sets DownloadContent
        /// </summary>
        public bool DownloadContent { get; set; }
        /// <summary>
        /// Gets or sets ImageSize
        /// </summary>
        public ImageSize ImageSize { get; set; }

    }
}