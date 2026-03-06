using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerAndContentsReplyDataContract
    /// </summary>
    public class ContainerAndContentsReplyDataContract : ContainerContentsDataContract
    {
        /// <summary>
        /// Gets or sets ScannedAsset
        /// </summary>
        public ScanAssetDataContract ScannedAsset { get; set; }
    }
}