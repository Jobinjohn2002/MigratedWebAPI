using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CreateContainerInstanceResponseDataContract
    /// </summary>
    public class CreateContainerInstanceResponseDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Assets
        /// </summary>
        public List<ScanAssetDataContract> Assets { get; set; }
    }
}