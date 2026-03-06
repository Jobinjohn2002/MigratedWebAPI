using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerContentsDataContract
    /// </summary>
    public class ContainerContentsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets IsImageAvailable
        /// </summary>
        public bool IsImageAvailable { get; set; }
        /// <summary>
        /// Gets or sets IsDocumentAvailable
        /// </summary>
        public bool IsDocumentAvailable { get; set; }
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<ComponentItem> Items { get; set; }
        /// <summary>
        /// Gets or sets UnexpectedItems
        /// </summary>
        public List<ComponentItem> UnexpectedItems { get; set; }
    }
}