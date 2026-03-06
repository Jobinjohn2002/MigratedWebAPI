using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustSetting
    /// </summary>
    public class CustSetting : Setting
    {
        /// <summary>
        /// Gets or sets CustomerDefinitionID
        /// </summary>
        public int CustomerDefinitionID { get; set; }
    }
}