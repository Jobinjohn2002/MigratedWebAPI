using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SettingKeyValueDataContract
    /// </summary>
    public class SettingKeyValueDataContract
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets SettingTypeId
        /// </summary>
        public int SettingTypeId { get; set; }
    }
}