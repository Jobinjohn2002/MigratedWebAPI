using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustSettingsIndex
    /// </summary>
    public class CustSettingsIndex
    {
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<CustSettingInfo> Customers { get; set; }
    }
}