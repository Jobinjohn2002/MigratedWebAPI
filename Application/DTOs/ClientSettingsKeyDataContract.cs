using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ClientSettingsKeyDataContract
    /// </summary>
    public class ClientSettingsKeyDataContract : BaseRequestDataContract
    {
        public int? TenancyId { get; set; }
        /// <summary>
        /// Gets or sets ClientSettingsName
        /// </summary>
        public string ClientSettingsName { get; set; }
    }
}