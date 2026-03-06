using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DataContractBase
    /// </summary>
    public class DataContractBase
    {
        /// <summary>
        /// Gets or sets ExtensionData
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
